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

namespace ECFLight3_Server
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            if(App.Current.Properties["UsuarioAtivo"] == null)
            {
                MessageBox.Show("Faça novo acesso!", System.Configuration.ConfigurationManager.AppSettings["NomeApp"]);
                App.Current.Shutdown();
            }

            DataAccessObject.Model.USUARIO usuario = (DataAccessObject.Model.USUARIO)App.Current.Properties["UsuarioAtivo"];
            lblUsuarioLogado.Content = usuario._NOME.ToString();

            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Usuário clicou no X");
        }
    }
}
