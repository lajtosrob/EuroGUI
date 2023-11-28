using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroGUI
{
    internal class Dal
    {
        public int Id {  get; set; }
        public int Ev {  get; set; }
        public string Orszag { get; set; }
        public string Eloado { get; set; }
        public string Cim { get; set; }
        public int Helyezes { get; set; }
        public int Pontszam { get; set; }
        public Dal(MySqlDataReader songReader)
        {
            Id = songReader.GetInt32(0);
            Ev = songReader.GetInt32(1);
            Orszag = songReader.GetString(2);
            Eloado = songReader.GetString(3);
            Cim = songReader.GetString(4);
            Helyezes = songReader.GetInt32(5);
            Pontszam = songReader.GetInt32(6);
        }

    }
}
