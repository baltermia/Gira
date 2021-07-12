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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;
using MediaColor = System.Windows.Media.Color;

namespace Gira
{
    /// <summary>
    /// Interaction logic for TicketControl.xaml
    /// </summary>
    public partial class TicketControl : UserControl
    {
        public delegate void TicketControlClickedHandler(object sender, TicketControlEventArgs e);
        public event TicketControlClickedHandler OnTicketControlClick;

        public readonly Ticket Ticket;

        public TicketControl(Ticket ticket)
        {
            Ticket = ticket;

            InitializeComponent();

            SetTicketProperties();

            Color[] colors = new Color[] {
                Color.Khaki,
                Color.Teal,
                Color.YellowGreen,
                Color.Plum,
                Color.PeachPuff,
                Color.LightSteelBlue,
                Color.LightCoral,
                Color.DarkSalmon
            };

            Random rnd = new Random();
            Color rndColor = colors[rnd.Next(colors.Length - 1)];
            MediaColor mColor = MediaColor.FromArgb(rndColor.A, rndColor.R, rndColor.G, rndColor.B);

            brdLeft.BorderBrush = new SolidColorBrush(mColor);
        }

        private void SetTicketProperties()
        {
            tbkID.Text = Ticket.ID.ToString(); ;
            tbkTitel.Text = Ticket.Title;
            tbkDueDate.Text = Ticket.DueDate?.ToString("yyyy-MM-dd") ?? "None";
            tbkLogged.Text = Ticket.Logged.ToString();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            OnTicketControlClick?.Invoke(sender, new TicketControlEventArgs(Ticket));
        }
    }
}
