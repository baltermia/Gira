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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        /// <summary>
        /// True = LoginPage, False = RegisterPage
        /// </summary>
        private bool activePage;

        private readonly Page loginPage;

        private readonly Page registerPage;

        public LoginView(bool startAsLogin = true)
        {
            InitializeComponent();

            activePage = startAsLogin;

            loginPage = new LoginPage();
            registerPage = new RegisterPage();

            SwitchPage();
        }

        public Login GetLogin()
        {
            ShowDialog();
            
            return null;
        }

        private void Navigate(Page page)
        {
            frMain.NavigationService.Navigate(page);
        }

        private void SwitchPage(bool? isLoginPage = null)
        {
            activePage = !(isLoginPage == true || (isLoginPage == null && activePage));

            if (!activePage)
            {
                tbkChangePage.Text = "Register";

                Navigate(loginPage);
            }
            else
            {
                tbkChangePage.Text = "Login";

                Navigate(registerPage);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            SwitchPage();
        }
    }
}
