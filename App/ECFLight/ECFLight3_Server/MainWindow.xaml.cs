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
using DataAccessObject.Model;

namespace ECFLight3_Server
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
            if (validar())
                Acessar();
            else
                MessageBox.Show("Dados inválidos", ConfigurationManager.AppSettings["NomeApp"]);
        }

        private bool validar()
        {
            try
            {
                BusinessLogics.UsuarioBL objUs = new BusinessLogics.UsuarioBL();
                DataAccessObject.Model.USUARIO us = new DataAccessObject.Model.USUARIO();
                bool valido = false;

                if (string.IsNullOrEmpty(txtUsuario.Text) && string.IsNullOrEmpty(txtSenha.Password))
                    valido = false;
                
                if (objUs.ValidarLogin(txtUsuario.Text, txtSenha.Password))
                    App.Current.Properties["UsuarioAtivo"] = objUs.ObterUsuario(txtUsuario.Text);
                    
                if(us != null)
                    valido = true;

                return valido;
            }
            catch
            {
                return false;
            }
        }

        private void Acessar()
        {
            Principal janela = new Principal();
            janela.Show();
            this.Close(); 
        }
    }
}
