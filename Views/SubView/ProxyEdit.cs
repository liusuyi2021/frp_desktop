using AntdUI;
using frp_desktop.Domain;
using System.Linq;
using System.Windows.Forms;

namespace frp_desktop.Views.SubView
{
    public partial class ProxyEdit : UserControl
    {
        private readonly Window Window;
        public FrpProxy ProxyData
        {
            get
            {
                return new FrpProxy
                {
                    Name = input_name.Text,
                    Type = select_type.Text?.ToString(),
                    LocalIp = input_local_host.Text,
                    LocalPort = int.TryParse(input_local_port.Text, out var lp) ? lp : 0,
                    RemotePort = int.TryParse(input_remote_port.Text, out var rp) ? rp : 0,
                    // 其他字段
                };
            }
            set
            {
                if (value == null) return;
                input_name.Text = value.Name;
                select_type.SelectedText = value.Type;
                input_local_host.Text = value.LocalIp;
                input_local_port.Text = value.LocalPort.ToString();
                input_remote_port.Text = value.RemotePort.ToString();
            }
        }
        public ProxyEdit(Window _window)
        {
            Window = _window;
            InitializeComponent();
            //设置默认值
            InitData();
            //绑定事件
            BindingEventHandler();
        }
        private void InitData()
        { }
        private void BindingEventHandler()
        { }
    }
}
