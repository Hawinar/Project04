using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Project04
{
    /// <summary>
    /// 2.6.1	Задачи по обработке и анализу информации Вариант 2 https://github.com/Hawinar
    /// </summary>
    public partial class MainWindow : Window
    {
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
            if (int.Parse(tbToRecomendation.Text) > 1999)
                lbRecomedation.Content = "Самолёт";
            else if (int.Parse(tbToRecomendation.Text) > 999)
            {
                lbRecomedation.Content = "Поезд";
            }
            else if (int.Parse(tbToRecomendation.Text) > 499)
            {
                lbRecomedation.Content = "Пароход";
            }
            else if (int.Parse(tbToRecomendation.Text) >= 0)
            {
                lbRecomedation.Content = "Автобус";
            }

        }

        private void DGridTransportAgency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
    
}
