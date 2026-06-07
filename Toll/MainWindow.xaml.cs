using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Toll
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("paths.json"))
            {
                string json = File.ReadAllText("paths.json");

                Path.Paths = string.IsNullOrWhiteSpace(json)
                    ? new List<Path>()
                    : JsonSerializer.Deserialize<List<Path>>(json) ?? new List<Path>();
            }
            else
            {
                File.Create("paths.json").Close();
            }

            if (File.Exists("routes.json"))
            {
                string json = File.ReadAllText("routes.json");

                Route.Routes = string.IsNullOrWhiteSpace(json)
                    ? new List<Route>()
                    : JsonSerializer.Deserialize<List<Route>>(json) ?? new List<Route>();
            }
            else
            {
                File.Create("routes.json").Close();
            }

            if (File.Exists("telepassUsers.json"))
            {
                string json = File.ReadAllText("telepassUsers.json");

                TelepassUser.Users = string.IsNullOrWhiteSpace(json)
                    ? new List<TelepassUser>()
                    : JsonSerializer.Deserialize<List<TelepassUser>>(
                        json,
                        new JsonSerializerOptions
                        {
                            Converters =
                            {
                                new JsonStringEnumConverter()
                            }
                        }) ?? new List<TelepassUser>();
            }
            else
            {
                File.Create("telepassUsers.json").Close();
            }
            gridAccessHistory.ItemsSource = Transit.TransitList;
            gridAllUsers.ItemsSource = User.Users;
            gridTelepassUsers.ItemsSource = TelepassUser.Users;
            comboCountryCode.ItemsSource = new List<string>
            {
                "AL","AD","AT","BY","BE","BA","BG","HR","CY","CZ",
                "DK","EE","FI","FR","DE","GR","HU","IS","IE","IT",
                "XK","LV","LI","LT","LU","MT","MD","MC","ME","NL",
                "MK","NO","PL","PT","RO","RU","SM","RS","SK","SI",
                "ES","SE","CH","TR","UA","GB","VA"
            };
            comboRoute.ItemsSource = Route.Routes;
        }

        private void updateUI()
        {
            gridAccessHistory.ItemsSource = null;
            gridAllUsers.ItemsSource = null;
            gridTelepassUsers.ItemsSource = null;
            gridAccessHistory.ItemsSource = Transit.TransitList.AsEnumerable().Reverse().ToList();
            gridAllUsers.ItemsSource = User.Users;
            gridTelepassUsers.ItemsSource = TelepassUser.Users;
        }

        private void txtLicensePlate_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLicensePlate.Text = txtLicensePlate.Text.ToUpper();
            txtLicensePlate.CaretIndex = txtLicensePlate.Text.Length;
            radioTelepass.IsEnabled = TelepassUser.Users.Exists(user => comboCountryCode.Text + txtLicensePlate.Text == user.LicensePlate.ToString()) ? true : false;
            if (!radioTelepass.IsEnabled)
            {
                radioTelepass.IsChecked = false;
            }
        }
        private void comboCountryCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            radioTelepass.IsEnabled = TelepassUser.Users.Exists(user => comboCountryCode.SelectedValue.ToString() + txtLicensePlate.Text == user.LicensePlate.ToString()) ? true : false;
            if (!radioTelepass.IsEnabled)
            {
                radioTelepass.IsChecked = false;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(comboCountryCode.Text) || String.IsNullOrWhiteSpace(txtLicensePlate.Text))
            {
                MessageBox.Show("Inserire i dati della targa");
            }
            else
            {
                if (comboRoute.SelectedIndex == -1)
                {
                    MessageBox.Show("Selezionare la tratta percorsa");
                }
                else
                {
                    if (!((bool)radioCash.IsChecked || (bool)radioCard.IsChecked || (bool)radioTelepass.IsChecked))
                    {
                        MessageBox.Show("Selezionare il metodo di pagamento");
                    }
                    else
                    {
                        LicensePlate licensePlate = new LicensePlate(comboCountryCode.Text, txtLicensePlate.Text);
                        Route route = (Toll.Route)comboRoute.SelectedItem;
                        Transit.PaymentMethod paymentBy = (bool)radioCash.IsChecked ? Transit.PaymentMethod.Cash : ((bool)radioCard.IsChecked ? Transit.PaymentMethod.Card : Transit.PaymentMethod.Telepass);
                        Transit.TransitList.Add(new Transit(licensePlate, route, paymentBy, DateTime.Now));
                        updateUI();
                    }
                }
            }
        }
    }
}