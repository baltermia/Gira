namespace Gira
{
    public class Account
    {
        public string Name { get; private set; }
        public Account(string name)
        {
            Name = name;
        }
    }
}