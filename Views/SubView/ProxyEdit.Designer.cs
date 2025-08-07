namespace frp_desktop.Views.SubView
{
    partial class ProxyEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.stackPanel1 = new AntdUI.StackPanel();
            this.flowPanel5 = new AntdUI.FlowPanel();
            this.input_remote_port = new AntdUI.Input();
            this.label5 = new AntdUI.Label();
            this.flowPanel4 = new AntdUI.FlowPanel();
            this.input_local_port = new AntdUI.Input();
            this.label4 = new AntdUI.Label();
            this.flowPanel3 = new AntdUI.FlowPanel();
            this.input_local_host = new AntdUI.Input();
            this.label3 = new AntdUI.Label();
            this.flowPanel2 = new AntdUI.FlowPanel();
            this.select_type = new AntdUI.Select();
            this.label2 = new AntdUI.Label();
            this.flowPanel1 = new AntdUI.FlowPanel();
            this.input_name = new AntdUI.Input();
            this.label1 = new AntdUI.Label();
            this.pageHeader_proxy = new AntdUI.PageHeader();
            this.stackPanel1.SuspendLayout();
            this.flowPanel5.SuspendLayout();
            this.flowPanel4.SuspendLayout();
            this.flowPanel3.SuspendLayout();
            this.flowPanel2.SuspendLayout();
            this.flowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stackPanel1
            // 
            this.stackPanel1.Controls.Add(this.flowPanel5);
            this.stackPanel1.Controls.Add(this.flowPanel4);
            this.stackPanel1.Controls.Add(this.flowPanel3);
            this.stackPanel1.Controls.Add(this.flowPanel2);
            this.stackPanel1.Controls.Add(this.flowPanel1);
            this.stackPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel1.Location = new System.Drawing.Point(0, 23);
            this.stackPanel1.Name = "stackPanel1";
            this.stackPanel1.Size = new System.Drawing.Size(593, 225);
            this.stackPanel1.TabIndex = 1;
            this.stackPanel1.Text = "stackPanel1";
            this.stackPanel1.Vertical = true;
            // 
            // flowPanel5
            // 
            this.flowPanel5.Controls.Add(this.input_remote_port);
            this.flowPanel5.Controls.Add(this.label5);
            this.flowPanel5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.flowPanel5.Location = new System.Drawing.Point(3, 155);
            this.flowPanel5.Name = "flowPanel5";
            this.flowPanel5.Size = new System.Drawing.Size(587, 32);
            this.flowPanel5.TabIndex = 4;
            this.flowPanel5.Text = "flowPanel5";
            // 
            // input_remote_port
            // 
            this.input_remote_port.Location = new System.Drawing.Point(228, 3);
            this.input_remote_port.Name = "input_remote_port";
            this.input_remote_port.PlaceholderText = "80";
            this.input_remote_port.Size = new System.Drawing.Size(187, 32);
            this.input_remote_port.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 32);
            this.label5.TabIndex = 0;
            this.label5.Text = "远程端口：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowPanel4
            // 
            this.flowPanel4.Controls.Add(this.input_local_port);
            this.flowPanel4.Controls.Add(this.label4);
            this.flowPanel4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.flowPanel4.Location = new System.Drawing.Point(3, 117);
            this.flowPanel4.Name = "flowPanel4";
            this.flowPanel4.Size = new System.Drawing.Size(587, 32);
            this.flowPanel4.TabIndex = 3;
            this.flowPanel4.Text = "flowPanel4";
            // 
            // input_local_port
            // 
            this.input_local_port.Location = new System.Drawing.Point(228, 3);
            this.input_local_port.Name = "input_local_port";
            this.input_local_port.PlaceholderText = "80";
            this.input_local_port.Size = new System.Drawing.Size(187, 32);
            this.input_local_port.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "本地服务端口：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowPanel3
            // 
            this.flowPanel3.Controls.Add(this.input_local_host);
            this.flowPanel3.Controls.Add(this.label3);
            this.flowPanel3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.flowPanel3.Location = new System.Drawing.Point(3, 79);
            this.flowPanel3.Name = "flowPanel3";
            this.flowPanel3.Size = new System.Drawing.Size(587, 32);
            this.flowPanel3.TabIndex = 2;
            this.flowPanel3.Text = "flowPanel3";
            // 
            // input_local_host
            // 
            this.input_local_host.Location = new System.Drawing.Point(228, 3);
            this.input_local_host.Name = "input_local_host";
            this.input_local_host.PlaceholderText = "192.168.8.1";
            this.input_local_host.Size = new System.Drawing.Size(187, 32);
            this.input_local_host.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "本地服务地址：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowPanel2
            // 
            this.flowPanel2.Controls.Add(this.select_type);
            this.flowPanel2.Controls.Add(this.label2);
            this.flowPanel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.flowPanel2.Location = new System.Drawing.Point(3, 41);
            this.flowPanel2.Name = "flowPanel2";
            this.flowPanel2.Size = new System.Drawing.Size(587, 32);
            this.flowPanel2.TabIndex = 1;
            this.flowPanel2.Text = "flowPanel2";
            // 
            // select_type
            // 
            this.select_type.Items.AddRange(new object[] {
            "tcp",
            "udp"});
            this.select_type.Location = new System.Drawing.Point(228, 3);
            this.select_type.Name = "select_type";
            this.select_type.Size = new System.Drawing.Size(187, 32);
            this.select_type.TabIndex = 1;
            this.select_type.Text = "tcp";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "类型：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowPanel1
            // 
            this.flowPanel1.Controls.Add(this.input_name);
            this.flowPanel1.Controls.Add(this.label1);
            this.flowPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.flowPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowPanel1.Name = "flowPanel1";
            this.flowPanel1.Size = new System.Drawing.Size(587, 32);
            this.flowPanel1.TabIndex = 0;
            this.flowPanel1.Text = "flowPanel1";
            // 
            // input_name
            // 
            this.input_name.Location = new System.Drawing.Point(228, 3);
            this.input_name.Name = "input_name";
            this.input_name.PlaceholderText = "nginx";
            this.input_name.Size = new System.Drawing.Size(187, 32);
            this.input_name.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pageHeader_proxy
            // 
            this.pageHeader_proxy.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader_proxy.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.pageHeader_proxy.Location = new System.Drawing.Point(0, 0);
            this.pageHeader_proxy.Name = "pageHeader_proxy";
            this.pageHeader_proxy.Size = new System.Drawing.Size(593, 23);
            this.pageHeader_proxy.TabIndex = 0;
            this.pageHeader_proxy.Text = "";
            // 
            // ProxyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stackPanel1);
            this.Controls.Add(this.pageHeader_proxy);
            this.Name = "ProxyEdit";
            this.Size = new System.Drawing.Size(593, 248);
            this.stackPanel1.ResumeLayout(false);
            this.flowPanel5.ResumeLayout(false);
            this.flowPanel4.ResumeLayout(false);
            this.flowPanel3.ResumeLayout(false);
            this.flowPanel2.ResumeLayout(false);
            this.flowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private AntdUI.StackPanel stackPanel1;
        private AntdUI.FlowPanel flowPanel5;
        private AntdUI.Input input_remote_port;
        private AntdUI.Label label5;
        private AntdUI.FlowPanel flowPanel4;
        private AntdUI.Input input_local_port;
        private AntdUI.Label label4;
        private AntdUI.FlowPanel flowPanel3;
        private AntdUI.Input input_local_host;
        private AntdUI.Label label3;
        private AntdUI.FlowPanel flowPanel2;
        private AntdUI.Select select_type;
        private AntdUI.Label label2;
        private AntdUI.FlowPanel flowPanel1;
        private AntdUI.Input input_name;
        private AntdUI.Label label1;
        private AntdUI.PageHeader pageHeader_proxy;
    }
}
