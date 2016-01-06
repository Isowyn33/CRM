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
        private String id = "";
        private String pass = "";
        //private String stm = "";
        private MySqlConnection connection;
        //private MySqlDataAdapter da;
        private MySqlDataReader reader;
        public List<String> lstNom = new List<string>();
        public List<String> lstPrenom = new List<string>();
        public List<String> lstAdresse = new List<string>();
        public List<int> lstCP = new List<int>();
        public List<int> lstTel = new List<int>();
        public List<Client> lstClient = new List<Client>();
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
        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            server = tbServer.Text;
            dbName = tbdbName.Text;
            id = tbId.Text;
            pass = pbPass.Password;
            String connectionString;
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
                Client cli = new Client(j, lstNom[j], lstPrenom[j], lstAdresse[j], lstCP[j], lstTel[j]);
                lstClient.Add(cli);
            }
            if (connection.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Connection réussie");
                this.Close();
            }
            
        }
         
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            inter.Owner = this;
            inter.Loaded();
            inter.ShowDialog();
        }
    }
    }
