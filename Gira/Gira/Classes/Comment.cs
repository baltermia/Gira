using System;
using System.Collections.Generic;
using System.Text;

namespace Gira.Classes
{
    class Comment
    {
        public Account Owner { get; private set; }
        public DateTime Created { get; private set; }
        public string Text { get; private set; }
        public Comment(string text, Account owner)
        {
            Text = text;
            Owner = owner;
            Created = DateTime.Now;
        }
    }
}
