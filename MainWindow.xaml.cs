using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace EuroGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=eurovizio;";

        private readonly string connectionStringRace = "datasource=127.0.0.1;port=3306;username=root;password=;database=eurovizio;";

        private readonly string connectionStringSong = "datasource=127.0.0.1;port=3306;username=root;password=;database=eurovizio;";

        private MySqlConnection connection;

        private List<Versenyzo> versenyzok;

        private List<Verseny> versenyek;

        private List<Dal> dalok;


        public MainWindow()
        {
            InitializeComponent();

            versenyzok = new List<Versenyzo>();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string queryText = "SELECT dal.ev, eloado, cim, helyezes, pontszam FROM `dal` INNER JOIN verseny ON dal.ev = verseny.ev;";
                MySqlCommand query = new MySqlCommand(queryText, connection);
                MySqlDataReader reader= query.ExecuteReader();
                while (reader.Read())
                {

                    Versenyzo versenyzo = new Versenyzo(reader);

                    versenyzok.Add(versenyzo);
                }

                reader.Close();
                connection.Close();

                dgDataTable.ItemsSource = versenyzok;
                dgDataTable.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnFeladat4_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string queryText2 = "";

                MySqlCommand query2 = new MySqlCommand(queryText2, connection);
                MySqlDataReader raceReader = query2.ExecuteReader();
                while (raceReader.Read())
                {
                    Verseny versenySor = new Verseny(raceReader);

                    versenyek.Add(versenySor);
                }

                raceReader.Close();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }

            var selectedItemInDataGrid = dgDataTable.SelectedItem.ToString()[1];

            lblFeladat4.Content = $"Szervező ország: {selectedItemInDataGrid}";


        }

        private void btnFeladat5_Click(object sender, RoutedEventArgs e)
        {
            dalok = new List<Dal>();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string queryText1 = "SELECT id, ev, orszag, eloado, cim, helyezes, pontszam FROM `dal`;";

                MySqlCommand query1 = new MySqlCommand(@queryText1, connection);
                MySqlDataReader songReader = query1.ExecuteReader();
                while (songReader.Read())
                {
                    Dal dalSor = new Dal(songReader);

                    dalok.Add(dalSor);
                }
                songReader.Close();
                connection.Close ();    
            }
            catch ( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            lblFeladat5.Content = $"Magyarországi versenyzők: {dalok.Count(x => x.Orszag == "Magyarország")}";
        }
    }
}