using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace CRM
{
    /// <summary>
    /// Logique d'interaction pour Interface.xaml
    /// </summary>
    public partial class Interface : Window
    {
        private int IdClient;
        private String NomClient;
        private String PrenomClient;
        private String AdresseClient;
        private int CodePostalClient;
        private int TelephoneClient;
        private Client cli;
        private MainWindow mw;


        public Interface()
        {
            InitializeComponent();
            
        }

        public void Interface_Loaded()
        {
            NomClient = mw.nomClient;
            tbId.Text = NomClient;
        }

        
        

        
    }
}
