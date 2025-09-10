using AntdUI;
using frp_desktop.Domain;
using frp_desktop.Service;
using frp_desktop.Utils;
using frp_desktop.Views.SubView;
using KMZDemo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = AntdUI.Button;
using Label = AntdUI.Label;
using Message = AntdUI.Message;
using Timer = System.Windows.Forms.Timer;

namespace frp_desktop
{
    public partial class MainWindows : AntdUI.Window
    {
        private bool isLight = false;
        private bool isConnect = false;
        private FrpDownload frpDownload;
        private List<string> versions;
        private bool frpTabLoaded = false; // 标记是否已加载过
        public MainWindows()
        {
            InitializeComponent();
            BindEventHandler();
            InitData();
        }


        private void BindEventHandler()
        {
            //button事件
            button_sysConfig.Click += Button_SysConfig_Click;
            button_color.Click += Button_Color_Click;

            button_save_server.Click += Button_Save_Server_Click;
            button_proxy_add.Click += Button_Proxy_Add_Click;
            button_connect.Click += Button_Connect_Click;
            button_refresh.Click += Button_Refresh_Click;
            FrpcManager.OnOutput += OnFrpcOutput;
            //表格单元格按钮点击事件
            table_proxy.CellButtonClick += OnTableProxyCellButtonClick;
            tabs.SelectedIndexChanged += tabs_SelectedIndexChanged;
            //监听系统深浅色变化
            SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;

            // 订阅关闭事件
            this.FormClosing += MainWindows_FormClosing;
        }


        private void AppendLog(string text)
        {
            input_log.AppendText(text + Environment.NewLine);
            input_log.ScrollToCaret(); // 自动滚动到底部
        }

        //初始化数据
        private void InitData()
        {
            //根据系统亮暗初始化一次
            isLight = ThemeHelper.IsLightMode();
            button_color.Toggle = !isLight;
            ThemeHelper.SetColorMode(this, isLight);
            //初始化消息弹出位置
            Config.ShowInWindow = true;
            #region Table
            table_proxy.Columns = new AntdUI.ColumnCollection {
                new AntdUI.Column("Name", "名称"),
                new AntdUI.Column("Type", "代理类型"),
                new AntdUI.Column("LocalIp", "本地服务地址"),
                new AntdUI.Column("LocalPort", "本地服务端口"),
                new AntdUI.Column("RemotePort", "远程端口"),
                new AntdUI.Column("", "操作")
                {
                    Render=(value,record,i) =>{
                        CellLink[] btns = new CellLink[1];
                        btns[0]=new CellButton("delete","删除",TTypeMini.Error);
                        return btns;
                    }
                }
            };

            LoadProxyListData();
            #endregion
            FrpServerConfig frpServerConfig = ProxyData.LoadServerConfig();
            if (frpServerConfig != null)
            {
                input_server_ip.Text = frpServerConfig.ServerAddr;
                input_server_port.Text = frpServerConfig.ServerPort.ToString();
                input_token.Text = frpServerConfig.AuthToken;
                inputNumber_interval.Text = frpServerConfig.HeartbeatInterval.ToString();
                inputNumber_timeout.Text = frpServerConfig.HeartbeatTimeout.ToString();
                select_frp_version.Text = frpServerConfig.version;
            }
            frpDownload = new FrpDownload();
            versions = frpDownload.GetDownloadedFrpVersions();
            select_frp_version.Items.Clear();
            foreach (var v in versions)
            {
                select_frp_version.Items.Add(v);
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 假设目标 Tab 页的索引是 1，或者用 Name 比较
            if (tabs.SelectedIndex == 4 && !frpTabLoaded)
            {
                frpTabLoaded = true; // 标记已加载，避免重复加载
                LoadFrpVersionsAsync();
            }
            if (tabs.SelectedIndex == 2 && !frpTabLoaded)
            {
                frpTabLoaded = true; // 标记已加载，避免重复加载
                versions = frpDownload.GetDownloadedFrpVersions();
            }
        }

        // 异步加载 FRP 版本信息
        private void LoadFrpVersionsAsync()
        {
            Task.Factory.StartNew(() =>
            {
                var versionList = new List<FrpVersionInfo>();

                this.Invoke(new Action(() =>
                {
                    AntdUI.Spin.open(panel_download, AntdUI.Localization.Get("Loading", "正在加载中..."), config =>
                    {
                        versionList = frpDownload.GetReleasesWithCache();
                    }, () =>
                    {
                        this.Invoke(new Action(() =>
                        {
                            collapse_download.Size = new Size(665, versionList.Count * 50 + 30); // 设置高度为每个版本信息的高度之和
                            collapse_download.Items.Clear();
                            foreach (var info in versionList)
                            {
                                var item = new CollapseItem();
                                item.Text = info.Version;
                                item.Height = 70;

                                var lblDate = new Label
                                {
                                    Text = "发布时间: " + info.PublishDate.ToString("yyyy-MM-dd"),
                                    Location = new Point(10, 5),
                                    AutoSize = true
                                };

                                var lblFileName = new Label
                                {
                                    Text = "文件名称: " + info.FileName,
                                    Location = new Point(10, 25),
                                    AutoSize = true
                                };

                                var lblDownloadCount = new Label
                                {
                                    Text = "下载数量: " + info.DownloadCountl,
                                    Location = new Point(10, 45),
                                    AutoSize = true
                                };

                                string size = FileSizeFormatter.FormatSize(info.Size);
                                string btnText = frpDownload.IsVersionDownloaded(info.FileName) ? "重新下载" : "下载";
                                var btnDownload = new Button
                                {
                                    Name = "button_download",
                                    IconSvg = "DownloadOutlined",
                                    Text = btnText + "\r\n" + size,
                                    Type = TTypeMini.Primary,
                                    Dock = DockStyle.Right,
                                    Size = new Size(133, 45),
                                    Location = new Point(10, 45)
                                };

                                btnDownload.Click += (s, eBtn) =>
                                {
                                    btnDownload.Loading = true;
                                    Task.Factory.StartNew(() =>
                                    {
                                        try
                                        {
                                            string baseDir = AppDomain.CurrentDomain.BaseDirectory; // 当前程序目录，末尾带斜杠
                                            string saveFolder = Path.Combine(baseDir, "frp", "download");

                                            // 确保目录存在
                                            if (!Directory.Exists(saveFolder))
                                            {
                                                Directory.CreateDirectory(saveFolder);
                                            }

                                            string savePath = Path.Combine(saveFolder, info.FileName);
                                            frpDownload.DownloadFrp(info.DownloadUrl, savePath);
                                            this.Invoke(new Action(() =>
                                            {
                                                AntdUI.Message.info(this, ($"下载完成 {info.Version}"));
                                            }));
                                        }
                                        catch (Exception ex)
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                AntdUI.Message.error(this, "下载失败: " + ex.Message);
                                            }));
                                        }
                                        finally
                                        {
                                            this.Invoke(new Action(() =>
                                            {
                                                btnDownload.Loading = false;
                                                btnDownload.Text = frpDownload.IsVersionDownloaded(info.FileName) ? "重新下载" : "下载";
                                            }
                                            ));
                                        }
                                    });
                                };

                                item.Controls.Add(lblDate);
                                item.Controls.Add(lblFileName);
                                item.Controls.Add(lblDownloadCount);
                                item.Controls.Add(btnDownload);

                                collapse_download.Items.Add(item);
                            }
                        }));
                    });

                }));
            });
        }

        //加载代理数据
        private List<FrpProxy> LoadProxyListData()
        {
            var proxies = ProxyData.LoadData();
            table_proxy.DataSource = proxies;
            return proxies;
        }

        //连接事件
        private void Button_Connect_Click(object sender, EventArgs e)
        {

            var proxies = LoadProxyListData();
            if (proxies.Count == 0)
            {
                AntdUI.Message.warn(this, "请先添加代理");
                return;
            }


            if (!isConnect)
            {
                string folder = Path.Combine(Environment.CurrentDirectory, "frp");
                string serverIp = input_server_ip.Text;
                int serverPort = int.Parse(input_server_port.Text);
                string token = input_token.Text;
                string interval = inputNumber_interval.Text;
                string timeout = inputNumber_timeout.Text;
                FrpcYmlGenerator.GenerateYml(folder, serverIp, serverPort, "token", token, interval, timeout, proxies);
                string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frp", "frpc.yml");
                bool started = FrpcManager.StartFrpc(configPath);
                if (started)
                {
                    isConnect = true;
                    button_connect.Text = "断    开";
                    button_connect.Type = TTypeMini.Error;
                    label_status.Text = "  Frpc 已启动";
                    label_status.PrefixSvg = "CheckCircleFilled";
                    label_status.PrefixColor = Color.Green;
                    StartRunTimer(); // 开始倒计时显示
                }
            }
            else
            {
                FrpcManager.StopFrpc();
                isConnect = false;
                button_connect.Text = "连    接";
                button_connect.Type = TTypeMini.Success;
                label_status.Text = "  Frpc 未启动";
                label_status.PrefixSvg = "CloseCircleFilled";
                label_status.PrefixColor = Color.Red;
                StopRunTimer();
            }
        }

        //添加代理事件
        private void Button_Proxy_Add_Click(object sender, EventArgs e)
        {
            using (var form = new ProxyEdit(this))
            {
                string title = AntdUI.Localization.Get("proxyedit", "代理配置");
                AntdUI.Modal.open(new AntdUI.Modal.Config(this, title, form, TType.Info)
                {
                    OnBtns = btn =>
                    {
                        MessageBox.Show("触发的Name：" + btn.Name);
                        return true;
                    },
                    OnOk = config =>
                    {
                        //添加数据
                        bool added = ProxyData.AddData(form.ProxyData, out string errMsg);
                        if (!added)
                        {
                            AntdUI.Message.error(this, errMsg);
                            return false; // 返回 false 阻止弹窗关闭
                        }
                        LoadProxyListData();
                        return true;
                    }
                });
            }
        }

        //保存服务器配置
        private void Button_Save_Server_Click(object sender, EventArgs e)
        {
            FrpServerConfig frpServerConfig = new FrpServerConfig();

            frpServerConfig.ServerAddr = input_server_ip.Text;
            frpServerConfig.ServerPort = int.Parse(input_server_port.Text);
            frpServerConfig.AuthToken = input_token.Text;
            frpServerConfig.HeartbeatInterval = int.Parse(inputNumber_interval.Text);
            frpServerConfig.HeartbeatTimeout = int.Parse(inputNumber_timeout.Text);
            frpServerConfig.version = select_frp_version.Text;
            ProxyData.SaveServerConfig(frpServerConfig);

            //解压选择的版本
            frpDownload.ExtractFrpc(frpServerConfig.version);
            Message.success(this, "保存成功!");
        }

        // frp版本列表刷新
        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            LoadFrpVersionsAsync();
        }

        //日志输出
        private void OnFrpcOutput(string text)
        {
            string log = Regex.Replace(text, @"\x1B\[[0-9;]*[mGKF]", "");
            if (input_log.InvokeRequired)
            {
                input_log.Invoke(new Action(() => AppendLog(log)));
            }
            else
            {
                AppendLog(log);
            }
        }

        //表格代理删除事件
        private void OnTableProxyCellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (e.Record is FrpProxy proxy && e.Btn.Id == "delete")
            {
                var result = AntdUI.Modal.open(new AntdUI.Modal.Config(this, "确认删除", new AntdUI.Modal.TextLine[]
                {
                    new AntdUI.Modal.TextLine($"名称: {proxy.Name}", AntdUI.Style.Db.Primary),
                    new AntdUI.Modal.TextLine($"本地IP: {proxy.LocalIp}", 6, AntdUI.Style.Db.TextSecondary),
                    new AntdUI.Modal.TextLine($"本地端口: {proxy.LocalPort}", 6, AntdUI.Style.Db.TextSecondary),
                    new AntdUI.Modal.TextLine($"远程端口: {proxy.RemotePort}", 6, AntdUI.Style.Db.TextSecondary)
                }, AntdUI.TType.Error)
                {
                    CancelText = null,
                    OkType = AntdUI.TTypeMini.Error,
                    OkText = "删除"
                });

                if (result == DialogResult.OK)
                {
                    ProxyData.DeleteDataByName(proxy.Name);
                    LoadProxyListData();
                }
            }
        }

        // 跟随系统主题
        private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (e.Category == UserPreferenceCategory.General)
            {
                isLight = ThemeHelper.IsLightMode();
                button_color.Toggle = !isLight;
                ThemeHelper.SetColorMode(this, isLight);
            }
        }

        //主题颜色按钮点击事件
        private void Button_Color_Click(object sender, EventArgs e)
        {
            isLight = !isLight;
            //这里使用了Toggle属性切换图标
            button_color.Toggle = !isLight;
            ThemeHelper.SetColorMode(this, isLight);
        }

        //系统设置按钮点击事件
        private void Button_SysConfig_Click(object sender, EventArgs e)
        {
            using (var form = new SystemSet(this))
            {
                string title = AntdUI.Localization.Get("systemset", "系统设置");
                AntdUI.Modal.open(new AntdUI.Modal.Config(this, title, form, TType.Info)
                {
                    CloseIcon = true,
                    BtnHeight = 0,
                });
            }
        }

        //程序关闭事件
        private void MainWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnect)
            {
                // 停止 FRPC 连接
                FrpcManager.StopFrpc();
                isConnect = false;
            }
        }

        private Timer runTimer;
        private DateTime startTime;

        private void StartRunTimer()
        {
            startTime = DateTime.Now;
            if (runTimer == null)
            {
                runTimer = new System.Windows.Forms.Timer();
                runTimer.Interval = 1000; // 每秒触发一次
                runTimer.Tick += RunTimer_Tick;
            }
            runTimer.Start();
        }

        private void RunTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - startTime;
            labelTime.Text = $"运行时间：{elapsed:hh\\:mm\\:ss}";
        }

        private void StopRunTimer()
        {
            runTimer?.Stop();
        }


    }
}
