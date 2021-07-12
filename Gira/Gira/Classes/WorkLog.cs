using System;

namespace Gira.Classes
{
    public class WorkLog
    {
        public Account Owner { get; private set; }
        public DateTime Created { get; private set; }
        public int Length { get; private set; } //seconds
        public string Text { get; private set; }

        public WorkLog(string text, int length, Account owner)
        {
            Owner = owner;
            Text = text;
            Length = length;
            Created = DateTime.Now;
        }
    }
}
