using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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

namespace Project04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransportAgency _currentItem = new TransportAgency();
        public MainWindow()
        {
            InitializeComponent();
            
            DGridTransportAgency.ItemsSource = Project04DBEntities.GetContext().TransportAgency.ToList();
            
        }
        public static int BusCount = 0;
        public static int SteamshipCount = 0;
        public static int TrainCount = 0;
        public static int AircraftCount = 0;

        private void btBuyTicket_Click(object sender, RoutedEventArgs e)
        {
            TransportAgency _targetItem = (TransportAgency)DGridTransportAgency.SelectedItem;

            TransportAgency _currentItem = (TransportAgency)DGridTransportAgency.SelectedItem;
            try
            {
                if(_currentItem.seats > _currentItem.ticketsSold)
                {
                    _currentItem.ticketsSold += 1;
                    DGridTransportAgency.SelectedItem = _currentItem;
                    DGridTransportAgency.Items.Refresh();

                    if (_currentItem.type == "Автобус   ")
                        BusCount++;
                    else if (_currentItem.type == "Пароход   ")
                        SteamshipCount++;
                    else if (_currentItem.type == "Поезд     ")
                        TrainCount++;
                    else if (_currentItem.type == "Самолёт   ")
                        AircraftCount++;

                    if (BusCount > SteamshipCount && BusCount > SteamshipCount && TrainCount > AircraftCount)
                        lbHit.Content = "Автобус";

                    else if (SteamshipCount > BusCount && SteamshipCount > TrainCount && SteamshipCount > AircraftCount)
                        lbHit.Content = "Пароход";

                    else if (TrainCount > BusCount && TrainCount > SteamshipCount && TrainCount > AircraftCount)
                        lbHit.Content = "Поезд";

                    else if (AircraftCount > BusCount && AircraftCount > SteamshipCount && AircraftCount > TrainCount)
                        lbHit.Content = "Самолёт";
                    try
                    {
                        Project04DBEntities.GetContext().SaveChanges();
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете купить билетов больше, чем мест");
                }
            }
            catch (Exception)
            {

            }
        }

        private void btCheckRecomendation_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DGridTransportAgency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
    
}
