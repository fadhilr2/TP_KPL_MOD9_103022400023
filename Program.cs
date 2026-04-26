using System;
using TP_MODUL9_103022400023;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig covidConfig = new CovidConfig();

        void RunScreening()
        {
            Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {covidConfig.config.satuan_suhu}");
            double suhu = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman?");
            int hari = Convert.ToInt32(Console.ReadLine());

            bool isSuhuValid = false;
            if (covidConfig.config.satuan_suhu == "celcius")
            {
                isSuhuValid = (suhu >= 36.5 && suhu <= 37.5);
            }
            else if (covidConfig.config.satuan_suhu == "fahrenheit")
            {
                isSuhuValid = (suhu >= 97.7 && suhu <= 99.5);
            }

            bool isHariValid = (hari < covidConfig.config.batas_hari_deman);

            if (isSuhuValid && isHariValid)
            {
                Console.WriteLine(covidConfig.config.pesan_diterima);
            }
            else
            {
                Console.WriteLine(covidConfig.config.pesan_ditolak);
            }
        }

        RunScreening();

        covidConfig.UbahSatuan();

        RunScreening();
    }
}