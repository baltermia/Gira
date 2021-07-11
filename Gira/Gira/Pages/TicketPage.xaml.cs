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

namespace Gira.Pages
{
    /// <summary>
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        private readonly Ticket Ticket;
        public TicketPage(Ticket ticket)
        {
            InitializeComponent();

            Ticket = ticket;

            SetContent();
        }

        private void SetContent()
        {
            tbkTitle.Text = Ticket.Title;

            tbkType.Text = Ticket.Type.ToString();
            tbkPriority.Text = Ticket.Priority.ToString();
            tbkStatus.Text = Ticket.Status.ToString();

            tbkAssignee.Text = Ticket.Assignee.Name;
            tbkReporter.Text = Ticket.Reporter.Name;

            tbkDesc.Text = Ticket.Description;

            tbkCreated.Text = Ticket.CreateDate.ToString("yyyy-MM-dd");
            tbkDueDate.Text = Ticket.DueDate?.ToString("yyyy-MM-dd") ?? "None";
            tbkLastModified.Text = Ticket.LastModifiedDate.ToString("yyyy-MM-dd");
        }
    }
}
