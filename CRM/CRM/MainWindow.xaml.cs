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
        private String stm = "";
        private MySqlConnection connection;
        private MySqlDataAdapter da;
        private MySqlDataReader reader;
        public String nomClient;
        Interface inter = new Interface();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, RoutedEventArgs e)
        {
            server = tbServer.Text;
            dbName = tbdbName.Text;
            id = tbId.Text;
            pass = tbPass.Text;
            String connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            dbName + ";" + "UID=" + id + ";" + "PASSWORD=" + pass + ";";


            connection = new MySqlConnection(connectionString);
            

            //stm = "SELECT Nom FROM client";
            //da = new MySqlDataAdapter(stm, connection);
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Nom FROM client WHERE id = 1";
            connection.Open();
            
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //nomClient = reader.ToString();
                nomClient = reader.GetValue(0).ToString();
                
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
            inter.Show();
        }
    }
    }
