using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CRM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String server = "";
        private String dbName = "";
        private Boolean quit = false;
        private Boolean close = false;
        private String id = "";
        private String pass = "";
        //private String stm = "";
        private MySqlConnection connection;
        //private MySqlDataAdapter da;
        private MySqlDataReader reader;
        String connectionString;
        public List<String> lstNom = new List<string>();
        public List<String> lstPrenom = new List<string>();
        public List<String> lstAdresse = new List<string>();
        public List<int> lstCP = new List<int>();
        public List<int> lstTel = new List<int>();
        public List<String> lstNomP = new List<string>();
        public List<String> lstPrenomP = new List<string>();
        public List<String> lstAdresseP = new List<string>();
        public List<int> lstCPP = new List<int>();
        public List<int> lstTelP = new List<int>();
        public List<String> lstDate = new List<string>();
        public List<String> lstLibelle = new List<string>();
        public List<int> lstIdClient = new List<int>();
        public List<Client> lstClient = new List<Client>();
        public List<Prospect> lstProspect = new List<Prospect>();
        public List<Historique> lstHistorique = new List<Historique>();
        public String nomClient;
        Interface inter = new Interface();


        public MainWindow()
        {
            InitializeComponent();
            
        }


        public List<Client> getListClient()
        {
            return lstClient;
        }
        public List<Prospect> getListProspect()
        {
            return lstProspect;
        }
        public List<Historique> getListHistorique()
        {
            return lstHistorique;
        }
        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            getClients();
            getProspects();
            getHistorique();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Connection réussie");
               
                quit = true;
            }
            this.Close();
            
        }
         
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (quit == true)
            {
                inter.Owner = this;
                inter.Loaded();
                inter.ShowDialog();
            }
            else if (close == true)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel = true;
                if (MessageBox.Show("Voulez vous quitter l'application ?", "Quitter", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    close = true;
                    Application.Current.Shutdown();
                }
            }
        }

        private void getClients()
        {
            server = tbServer.Text;
            dbName = tbdbName.Text;
            id = tbId.Text;
            pass = pbPass.Password;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            dbName + ";" + "UID=" + id + ";" + "PASSWORD=" + pass + ";";
            connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM client";
            connection.Open();

            reader = cmd.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                lstNom.Add(reader["Nom"].ToString());
                lstPrenom.Add(reader["Prenom"].ToString());
                lstAdresse.Add(reader["Adresse"].ToString());
                lstCP.Add(int.Parse(reader["CodePostal"].ToString()));
                lstTel.Add(int.Parse(reader["Telephone"].ToString()));
                i++;
            }
            for (int j = 0; j < lstNom.Count(); j++)
            {
                Client cli = new Client(j+1, lstNom[j], lstPrenom[j], lstAdresse[j], lstCP[j], lstTel[j]);
                lstClient.Add(cli);
            }
        }

        public void getProspects()
        {
            server = tbServer.Text;
            dbName = tbdbName.Text;
            id = tbId.Text;
            pass = pbPass.Password;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            dbName + ";" + "UID=" + id + ";" + "PASSWORD=" + pass + ";";
            connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM prospect";
            connection.Open();

            reader = cmd.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                lstNomP.Add(reader["Nom"].ToString());
                lstPrenomP.Add(reader["Prenom"].ToString());
                lstAdresseP.Add(reader["Adresse"].ToString());
                lstCPP.Add(int.Parse(reader["CodePostal"].ToString()));
                lstTelP.Add(int.Parse(reader["Telephone"].ToString()));
                i++;
            }
            for (int j = 0; j < lstNomP.Count(); j++)
            {
                Prospect pro = new Prospect(j+1, lstNomP[j], lstPrenomP[j], lstAdresseP[j], lstCPP[j], lstTelP[j]);
                lstProspect.Add(pro);
            }
        }

        public void getHistorique()
        {
            server = tbServer.Text;
            dbName = tbdbName.Text;
            id = tbId.Text;
            pass = pbPass.Password;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            dbName + ";" + "UID=" + id + ";" + "PASSWORD=" + pass + ";";
            connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM historique";
            connection.Open();

            reader = cmd.ExecuteReader();
            int i = 0;

            while (reader.Read())
            {
                lstDate.Add(reader["Date"].ToString());
                lstIdClient.Add(int.Parse(reader["IdClient"].ToString()));
                lstLibelle.Add(reader["Libelle"].ToString());
                i++;
            }
            for (int j = 0; j < lstDate.Count(); j++)
            {
                Historique his = new Historique(j+1, lstDate[j], lstIdClient[j], lstLibelle[j]);
                lstHistorique.Add(his);
            }
        }

        private void pbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                getClients();
                getProspects();
                getHistorique();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Connection réussie");

                    quit = true;
                }
                this.Close();
            }
        }
    }
    }
