using Gira.Controls;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Gira.Pages
{
    /// <summary>
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public delegate void TicketPageHandler(object sender, EventArgs e);
        public event TicketPageHandler OnBackButtonClick;

        public readonly Ticket Ticket;

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

            int estimated = Ticket.Estimated;
            int remaining = Ticket.Remaining;
            int logged = Ticket.Logged;

            int percentage = (int)Math.Round((double)(100 * logged) / estimated);

            tbkEstimated.Text = Ticket.SecondsToTimeString(estimated);
            tbkRemaining.Text = Ticket.SecondsToTimeString(remaining);
            tbkLogged.Text = Ticket.SecondsToTimeString(logged);

            pbEstimated.Value = logged > estimated ? 100 / logged * estimated : 0;
            pbRemaining.Value = 100 - percentage;
            pbLogged.Value = percentage;

            Ticket.WorkLogs.Select(w => new WorkLogControl(w)).OrderBy(w => w.WorkLog.Created).ToList().ForEach(w => stpWorklogs.Children.Add(w));
            Ticket.Comments.Select(c => new CommentControl(c)).OrderBy(c => c.Comment.Created).ToList().ForEach(c => stpComments.Children.Add(c));
        }

        public void Reload() => SetContent();

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            OnBackButtonClick?.Invoke(sender, new EventArgs());
        }
    }
}
