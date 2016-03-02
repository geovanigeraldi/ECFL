using System;
using System.Configuration;
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
using BusinessLogics;

namespace ECFLight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", ConfigurationManager.AppSettings["NomeApp"], MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                App.Current.Shutdown();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            UsuarioBL u = new UsuarioBL();
            if (!u.ValidarLogin(txtUsuario.Text, txtSenha.Password))
                MessageBox.Show("Usuário e/ou senha inválidos", ConfigurationManager.AppSettings["NomeApp"]);
        }
    }
}