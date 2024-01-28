using System;
using System.IO;
using System.Reflection;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Environment = System.Environment;

namespace CustomChatFormat
{
    public class Configuration
    {
        public static ConfigMappings Map;
        
        private static string _EnvoPath;
        private static string _ConfigPath;
        
        public static bool LoadConfig()
        {
            _EnvoPath = Environment.CurrentDirectory;
            _ConfigPath = $@"{_EnvoPath}\Plugins\CustomChatFormat\ccf-config.yml";

            try
            {
                if (!File.Exists(_ConfigPath)) WriteDefaults();
                MapConfigs();
                return true;
            }
            catch
            {
                WriteDefaults();
                MapConfigs();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("[CCF] Could not load configurations...\n[CCF] Reverting to default configurations.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        private static void MapConfigs()
        {
            Map = ParseTagMaps(File.ReadAllText(_ConfigPath));
        }

        private static ConfigMappings ParseTagMaps(string contents) {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(HyphenatedNamingConvention.Instance)
                .Build();
            return deserializer.Deserialize<ConfigMappings>(contents);
        }
        
        private static void WriteDefaults()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("CustomChatFormat.Configuration.ConfigDefaults.yml");
            var reader = new StreamReader(stream);
            var configDefaults = reader.ReadToEnd();
            reader.Close(); reader.Dispose();
            stream.Close(); stream.Dispose();

            var writer = new StreamWriter(_ConfigPath, false);
            writer.Write($"{configDefaults}\n# Locker Configuration file generated {DateTime.Now.ToString()}\n");
            writer.Close(); writer.Dispose();
        }
    }

    public class ConfigMappings
    {
        public string Localizations { get; set; }
        public ServerMessages ServerMessages { get; set; }
        public bool SendWelcomeMessageToConsole { get; set; }
    }

    public class ServerMessages
    {
        public bool EnableWelcomeMessage { get; set; }
        public bool EnableJoinleaveMessages { get; set; }
        public bool EnableDeathMessages { get; set; }
    }
}