using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_MODUL9_103022400023
{
    internal class CovidConfig
    {
        public ConfigData config;
        private const string filePath = "covid_config.json";
        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string jsonString = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<ConfigData>(jsonString);
        }

        private void SetDefault()
        {
            config = new ConfigData
            {
                satuan_suhu = "celcius",
                batas_hari_deman = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void UbahSatuan()
        {
            if (config.satuan_suhu == "celcius")
            {
                config.satuan_suhu = "fahrenheit";
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                config.satuan_suhu = "celcius";
            }

            WriteNewConfigFile(); 
        }
    }
}
