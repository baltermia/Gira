using System.Windows;
using System.Threading;
using System.Threading.Tasks;

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

            Run();
        }

        private async void Run()
        {
            Show();

            Login login = null;

            await Task.Run(() => 
            {
                login = Login.GetSavedLogin();

                Thread.Sleep(2000);
            });

            Hide();

            new GiraView(login).ShowDialog();

            Close();
        }
    }
}
