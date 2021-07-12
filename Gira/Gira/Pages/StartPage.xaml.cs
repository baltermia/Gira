using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Windows.Navigation;
using static Gira.TicketControl;

namespace Gira.Pages
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public delegate void StartPageHandler(object sender, EventArgs e);
        public event StartPageHandler OnLogoutButtonClick;

        public event TicketControlClickedHandler OnTicketControlClick;

        public readonly IEnumerable<Ticket> Tickets;
        public StartPage(params Ticket[] tickets)
        {
            InitializeComponent();

            Tickets = tickets;

            Tickets.OrderBy(t => t.CreateDate).ToList().ForEach(t => 
            {
                TicketControl control = new TicketControl(t);
                stpTickets.Children.Add(control);
                control.OnTicketControlClick += OnTicketControlClick_Handler;
            });
        }

        private void OnTicketControlClick_Handler(object sender, TicketControlEventArgs e)
        {
            OnTicketControlClick?.Invoke(sender, e);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            OnLogoutButtonClick?.Invoke(sender, new EventArgs());
        }
    }
}
