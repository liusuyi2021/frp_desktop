﻿namespace KMZDemo
{
    partial class SystemSet
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
            AntdUI.Tabs.StyleLine styleLine1 = new AntdUI.Tabs.StyleLine();
            this.tabs = new AntdUI.Tabs();
            this.tabPage1 = new AntdUI.TabPage();
            this.label8 = new AntdUI.Label();
            this.label9 = new AntdUI.Label();
            this.label5 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.label7 = new AntdUI.Label();
            this.label4 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.label3 = new AntdUI.Label();
            this.tabPage2 = new AntdUI.TabPage();
            this.stackPanel6 = new AntdUI.StackPanel();
            this.stackPanel8 = new AntdUI.StackPanel();
            this.input_offset = new AntdUI.InputNumber();
            this.label10 = new AntdUI.Label();
            this.stackPanel7 = new AntdUI.StackPanel();
            this.switch_showinwindow = new AntdUI.Switch();
            this.label11 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.stackPanel6.SuspendLayout();
            this.stackPanel8.SuspendLayout();
            this.stackPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabs.Controls.Add(this.tabPage1);
            this.tabs.Controls.Add(this.tabPage2);
            this.tabs.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tabs.Gap = 12;
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Margin = new System.Windows.Forms.Padding(6);
            this.tabs.Name = "tabs";
            this.tabs.Pages.Add(this.tabPage1);
            this.tabs.Pages.Add(this.tabPage2);
            this.tabs.Size = new System.Drawing.Size(598, 396);
            this.tabs.Style = styleLine1;
            this.tabs.TabIndex = 0;
            this.tabs.Text = "消息配置";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.tabPage1.Location = new System.Drawing.Point(90, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(502, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本设置";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(202, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 23);
            this.label8.TabIndex = 8;
            this.label8.Text = "20250807";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(130, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 7;
            this.label9.Text = "日期：";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(202, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Frp内网穿透客户端";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(202, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "v1.0.0";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(202, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 23);
            this.label7.TabIndex = 4;
            this.label7.Text = "刘苏义";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(130, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "名称：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(130, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "版本：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(130, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "作者：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stackPanel6);
            this.tabPage2.Location = new System.Drawing.Point(-502, -384);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(502, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "消息配置";
            // 
            // stackPanel6
            // 
            this.stackPanel6.Controls.Add(this.stackPanel8);
            this.stackPanel6.Controls.Add(this.stackPanel7);
            this.stackPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackPanel6.Location = new System.Drawing.Point(0, 0);
            this.stackPanel6.Name = "stackPanel6";
            this.stackPanel6.Size = new System.Drawing.Size(502, 384);
            this.stackPanel6.TabIndex = 1;
            this.stackPanel6.Text = "stackPanel6";
            this.stackPanel6.Vertical = true;
            // 
            // stackPanel8
            // 
            this.stackPanel8.Controls.Add(this.input_offset);
            this.stackPanel8.Controls.Add(this.label10);
            this.stackPanel8.Location = new System.Drawing.Point(3, 41);
            this.stackPanel8.Name = "stackPanel8";
            this.stackPanel8.Size = new System.Drawing.Size(496, 32);
            this.stackPanel8.TabIndex = 5;
            this.stackPanel8.Text = "stackPanel8";
            // 
            // input_offset
            // 
            this.input_offset.Location = new System.Drawing.Point(189, 3);
            this.input_offset.Name = "input_offset";
            this.input_offset.Size = new System.Drawing.Size(60, 26);
            this.input_offset.TabIndex = 1;
            this.input_offset.Text = "0";
            this.input_offset.WaveSize = 0;
            // 
            // label10
            // 
            this.label10.LocalizationText = "windowOffsetXY";
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(180, 26);
            this.label10.TabIndex = 0;
            this.label10.Text = "边界偏移量";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stackPanel7
            // 
            this.stackPanel7.Controls.Add(this.switch_showinwindow);
            this.stackPanel7.Controls.Add(this.label11);
            this.stackPanel7.Location = new System.Drawing.Point(3, 3);
            this.stackPanel7.Name = "stackPanel7";
            this.stackPanel7.Size = new System.Drawing.Size(496, 32);
            this.stackPanel7.TabIndex = 4;
            this.stackPanel7.Text = "stackPanel7";
            // 
            // switch_showinwindow
            // 
            this.switch_showinwindow.Checked = true;
            this.switch_showinwindow.CheckedText = "";
            this.switch_showinwindow.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.switch_showinwindow.Location = new System.Drawing.Point(189, 3);
            this.switch_showinwindow.Name = "switch_showinwindow";
            this.switch_showinwindow.Size = new System.Drawing.Size(60, 26);
            this.switch_showinwindow.TabIndex = 1;
            this.switch_showinwindow.Text = "switch5";
            this.switch_showinwindow.UnCheckedText = "";
            this.switch_showinwindow.WaveSize = 0;
            // 
            // label11
            // 
            this.label11.LocalizationText = "showinwindow";
            this.label11.Location = new System.Drawing.Point(3, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 26);
            this.label11.TabIndex = 0;
            this.label11.Text = "窗口内弹出";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 160);
            this.label2.TabIndex = 1;
            this.label2.Text = "作者：刘苏义";
            // 
            // SystemSet
            // 
            this.Controls.Add(this.tabs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SystemSet";
            this.Size = new System.Drawing.Size(598, 396);
            this.tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.stackPanel6.ResumeLayout(false);
            this.stackPanel8.ResumeLayout(false);
            this.stackPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Tabs tabs;
        private AntdUI.TabPage tabPage1;
        private AntdUI.Label label2;
        private AntdUI.Label label8;
        private AntdUI.Label label9;
        private AntdUI.Label label5;
        private AntdUI.Label label6;
        private AntdUI.Label label7;
        private AntdUI.Label label4;
        private AntdUI.Label label1;
        private AntdUI.Label label3;
        private AntdUI.TabPage tabPage2;
        private AntdUI.StackPanel stackPanel6;
        private AntdUI.StackPanel stackPanel8;
        private AntdUI.InputNumber input_offset;
        private AntdUI.Label label10;
        private AntdUI.StackPanel stackPanel7;
        private AntdUI.Switch switch_showinwindow;
        private AntdUI.Label label11;
    }
}
