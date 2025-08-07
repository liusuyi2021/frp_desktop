namespace frp_desktop.Domain
{
    public class FrpProxy : AntdUI.NotifyProperty
    {
        public int Index { get; set; }
        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name));  // 这里传入属性名
            }
        }
        public string Type { get; set; } = "tcp";
        public string LocalIp { get; set; } = "127.0.0.1";
        public int LocalPort { get; set; }
        public int RemotePort { get; set; }
        public AntdUI.CellLink[] Btns { get; set; }

    }
}
