using System;
using System.Configuration;

namespace lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigReadAll();
            Console.ReadLine();
        }

        private static void ConfigReadAll()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;

                if (appSettings.Count == 0)
                {
                    Console.Write("Введите Имя пользователя: ");
                    ConfigAdd("UserName", Console.ReadLine());
                    Console.Write("Введите возраст: ");
                    ConfigAdd("Age", Console.ReadLine());
                    Console.Write("Введите род деятельности: ");
                    ConfigAdd("Activity", Console.ReadLine());
                }
                else
                {
                    foreach (var key in appSettings.AllKeys)
                    {
                        Console.WriteLine("{0}: {1}", key, appSettings[key]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ConfigAdd(string key, string readLine)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, readLine);
                }
                else
                {
                    settings[key].Value = readLine;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
