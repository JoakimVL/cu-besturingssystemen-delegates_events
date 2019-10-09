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

namespace WpfEventsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player player;
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            player = new Player(10, Names.GetRandomPlayerName());

            PrintHp(player.Health);
            lblPlayerName.Content = player.Name;
            playerGrid.Background = new SolidColorBrush(Colors.Beige);

            player.OnHpChanged += ChangeHealthLabel;

            player.OnDie += ChangeColor;
            player.OnDie += PlayerDiedMessage;
            player.OnDie += Reset;
        }

        private void PrintHp(int hp)
        {
            lblHealth.Content = $"{hp} HP";
        }

        private void ChangeHealthLabel(object sender, PlayerEventArgs e)
        {
            PrintHp(((Player)sender).Health);
        }

        private void LoseHp_Click(object sender, RoutedEventArgs e)
        {
            player.LoseHp();
        }

        private void GetHp_Click(object sender, RoutedEventArgs e)
        {
            player.GetHp();
        }

        private void PlayerDiedMessage(object sender, PlayerEventArgs e)
        {
            Player diedPlayer = (Player)sender;
            MessageBox.Show($"{diedPlayer.Name} died at {e.TimeOfDeath}");
        }

        private void ChangeColor(object sender, PlayerEventArgs e)
        {
            playerGrid.Background = new SolidColorBrush(Colors.Red);
        }

        private void Reset(object sender, PlayerEventArgs e)
        {
            SetUpGame();
        }
    }
}
