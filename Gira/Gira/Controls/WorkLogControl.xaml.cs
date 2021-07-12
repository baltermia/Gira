using Gira.Classes;
using System.Windows.Controls;

namespace Gira.Controls
{
    /// <summary>
    /// Interaction logic for WorkLogControl.xaml
    /// </summary>
    public partial class WorkLogControl : UserControl
    {
        public readonly WorkLog WorkLog;
        public WorkLogControl(WorkLog worklog)
        {
            InitializeComponent();

            WorkLog = worklog;

            SetWorklogProperties();
        }

        private void SetWorklogProperties()
        {
            tbkOwner.Text = WorkLog.Owner.Name;
            tbkDate.Text = WorkLog.Created.ToString();
            tbkSpent.Text = Ticket.SecondsToTimeString(WorkLog.Length);
            tbkComment.Text = WorkLog.Text;
        }
    }
}
