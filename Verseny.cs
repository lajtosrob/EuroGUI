using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroGUI
{
    internal class Verseny
    {
        public int Ev;
        public string Datum;
        public string Varos;
        public string Orszag;
        public int InduloSzam;
        public Verseny(MySqlDataReader raceReader)
        {
            Ev = raceReader.GetInt32(0);
            Datum = raceReader.GetString(1);
            Varos = raceReader.GetString(2);
            Orszag = raceReader.GetString(3);
            InduloSzam = raceReader.GetInt32(4);
        }
    }
}
