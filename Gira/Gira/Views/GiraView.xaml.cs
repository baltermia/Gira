using Gira.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gira
{
    /// <summary>
    /// Interaction logic for Gira.xaml
    /// </summary>
    public partial class GiraView : Window
    {
        private readonly Login Login;

        public GiraView(Login login)
        {
            InitializeComponent();

            Navigate(new TicketPage());

            Login = login ?? new LoginView().GetLogin();

            Login?.ToString();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Hide();

            new GiraView(new LoginView().GetLogin());

            Close();
        }

        private void Navigate(Page page)
        {
            frMain.NavigationService.Navigate(page);
        }
    }
}
