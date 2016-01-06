using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Client> client { get; set; }
        private MainWindow mw;
        DataGridTextColumn dgcNom = new DataGridTextColumn();
        DataGridTextColumn dgcPrenom = new DataGridTextColumn();
        DataGridTextColumn dgcAdresse = new DataGridTextColumn();
        DataGridTextColumn dgcCodePostal = new DataGridTextColumn();
        DataGridTextColumn dgcTel = new DataGridTextColumn();
        

        public Interface()
        {
            this.DataContext = client;
            client = new ObservableCollection<Client>();
            client.Add(new Client(0, "Murat", "Yoann", "rue de la péruche", 33500, 0548976515));
            InitializeComponent();
            
        }

        public void Loaded()
        {
        mw = (MainWindow)this.Owner;


        //DGVlients.DataContext = mw.getListClient();
        DGVlients.ItemsSource = mw.getListClient();


        }



    }
}
