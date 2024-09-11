namespace up.suporte.Stores
{
    public class ConfigFileStore
    {
        private Dictionary<string, string> _currentConfig;

        public Dictionary<string, string> CurrentConfig { get => _currentConfig; set => _currentConfig = value; }

        public ConfigFileStore()
        {
            _currentConfig = new Dictionary<string, string>();
        }
    }
}
