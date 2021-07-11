using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

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

        public Ticket(int id, string title, string desc, Account assignee, Manager reporter, DateTime? dueDate = null, Priorities prio = Priorities.None, Types type = Types.None)
        {
            ID = id;
            Title = title;
            Description = desc;
            Assignee = assignee;
            Reporter = reporter;
            dueDate = DueDate;
            CreateDate = DateTime.Now;
            LastModifiedDate = CreateDate;
            Priority = prio;
            Type = type;
        }

        public int? GetTotalLoggedWork()
        {
            return null;
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
    }
}
