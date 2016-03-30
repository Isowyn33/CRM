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
        formulaireAjoutClient fac = new formulaireAjoutClient();
        formulaireAjoutProspect fap = new formulaireAjoutProspect();


        public Interface()
        {
            InitializeComponent();
            
        }

        public void Loaded()
        {
        mw = (MainWindow)this.Owner;
            btnAdd.Click += AddClient_Click;

        //DGVlients.DataContext = mw.getListClient();
        DGVlients.ItemsSource = mw.getListClient();
        DGProspects.ItemsSource = mw.getListProspect();
        DGEntretiens.ItemsSource = mw.getListHistorique();
        }

        private void TabItem_Client(object sender, MouseButtonEventArgs e)
        {
            btnAdd.Click -= AddProspect_Click;
            btnAdd.Click += AddClient_Click;
            btnUpdate.Click += UpdateClient_Click;
        }

        private void UpdateClient_Click(object sender, RoutedEventArgs e)
        {
            fap.Show();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            fac.Show();
        }

        private void AddProspect_Click(object sender, RoutedEventArgs e)
        {
            fap.Show();
        }

        private void TabItem_Prospect(object sender, MouseButtonEventArgs e)
        {
            btnAdd.Click -= AddClient_Click;
            btnAdd.Click += AddProspect_Click;
        }

        private void TabItem_Entretien(object sender, MouseButtonEventArgs e)
        {

        }
    }

    
}
