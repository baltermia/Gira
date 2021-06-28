using System.Windows;
using System.Threading;

namespace Gira
{
    /// <summary>
    /// Interaction logic for Load.xaml
    /// </summary>
    public partial class Load : Window
    {
        public Load()
        {
            InitializeComponent();

            Login login = Login.GetSavedLogin();

            Thread.Sleep(2000);

            Close();

            new Gira(login).ShowDialog();
        }
    }
}
