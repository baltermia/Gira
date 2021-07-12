using Gira.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gira
{
    public class Ticket
    {
        public readonly int ID;
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Account Assignee { get; private set; }
        public Manager Reporter { get; private set; }
        public DateTime? DueDate { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastModifiedDate { get; private set; }
        public Priorities Priority { get; private set; }
        public Types Type { get; private set; }
        public States Status { get; private set; }
        public int Estimated { get; private set; }
        public int Remaining => GetRemainingTime();
        public int Logged => GetLoggedTime();
        public List<WorkLog> WorkLogs { get; private set; } = new List<WorkLog>();
        public List<Comment> Comments { get; private set; } = new List<Comment>();

        public Ticket(int id, string title, string desc, Account assignee, Manager reporter, DateTime? dueDate = null, int estimated = 0, Priorities prio = Priorities.None, Types type = Types.None, States status = States.Open)
        {
            ID = id;
            Title = title;
            Description = desc;
            Assignee = assignee;
            Reporter = reporter;
            DueDate = dueDate;
            CreateDate = DateTime.Now;
            LastModifiedDate = CreateDate;
            Priority = prio;
            Type = type;
            Status = status;
            Estimated = estimated;
        }

        private int GetLoggedTime()
        {
            return WorkLogs.Sum(w => w.Length);
        }

        private int GetRemainingTime()
        {
            return Logged > Estimated ? 0 : Estimated - Logged;
        }

        public void AddWorklogs(params WorkLog[] worklogs)
        {
            WorkLogs.AddRange(worklogs);
        }

        public void AddComments(params Comment[] comments)
        {
            Comments.AddRange(comments);
        }

        public enum Priorities
        {
            None,
            Minor,
            Major,
            Critical,
            Blocker
        }

        public enum Types
        {
            None,
            Task,
            Bug,
            Idea,
            Improvement,
            NewFeature
        }

        public enum States
        {
            Open,
            Closed,
            Paused,
            Fixed,
            Done
        }

        public static string SecondsToTimeString(int length)
        {
            int s, m, h, d;
            string result = "";

            TimeSpan time =TimeSpan.FromSeconds(length);

            s = time.Seconds;
            m = time.Minutes;
            h = time.Hours;
            d = time.Days;

            if (d > 0)
            {
                result += d + "d ";
            }
            if (h > 0)
            {
                result += h + "h ";
            }
            if (m > 0)
            {
                result += m + "m ";
            }
            if (s > 0)
            {
                result += s + "s ";
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = "None";
            }

            return result.Trim();
        }
    }
}
