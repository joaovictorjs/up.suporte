using System.IO;
using up.suporte.Stores;

namespace up.suporte.Services
{
    public interface IConfigFileService
    {
        void Read();
        void Write();
        bool IsOk();
    }

    public class ConfigFileService : IConfigFileService
    {
        private ConfigFileStore _store;
        private readonly string _path;

        public ConfigFileService(ConfigFileStore store, string path = "up.suporte.ini")
        {
            _store = store;
            _path = path;
        }

        public void Read()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    DecodeLine(line);
                }
            }
        }

        private void DecodeLine(string line)
        {
            string[] keyValue = line.Split('=', 2);

            if (keyValue.Length < 2) return;

            _store.CurrentConfig.TryAdd(keyValue[0].Trim().ToLower(), keyValue[1].Trim().ToLower());
        }

        public void Write()
        {
            using (StreamWriter sw = new StreamWriter(_path, new FileStreamOptions() { Mode = FileMode.OpenOrCreate }))
            {
                sw.WriteLine("address=", _store.CurrentConfig.GetValueOrDefault("address", string.Empty));
                sw.WriteLine("port=", _store.CurrentConfig.GetValueOrDefault("port", string.Empty));
                sw.WriteLine("database=", _store.CurrentConfig.GetValueOrDefault("database", string.Empty));
                sw.WriteLine("username=", _store.CurrentConfig.GetValueOrDefault("username", string.Empty));
            }
        }

        public bool IsOk()
        {
            return _store.CurrentConfig.ContainsKey("address")
                && _store.CurrentConfig.ContainsKey("port")
                && _store.CurrentConfig.ContainsKey("database");
        }
    }
}
