using Gira.Pages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Gira.Classes;
using static Gira.Ticket;

namespace Gira
{
    /// <summary>
    /// Interaction logic for Gira.xaml
    /// </summary>
    public partial class GiraView : Window
    {
        private readonly Login Login;

        private List<Ticket> tickets = new List<Ticket>();

        private readonly StartPage startPage;

        public GiraView(Login login)
        {
            InitializeComponent();

            Login = login ?? new LoginView().GetLogin();

            Login?.ToString();

            AddTickets();
            /*
            TicketPage page = new TicketPage(tickets.ToArray()[0]);

            page.OnBackButtonClick += OnBackButtonClick_Handler;

            Navigate(page);
            */
            
            startPage = new StartPage(tickets.ToArray());

            startPage.OnLogoutButtonClick += OnLogoutButtonClick_Handler;

            startPage.OnTicketControlClick += OnTicketControlClick_Handler;

            Navigate(startPage);
        }

        private void AddTickets()
        {
            Manager man = new Manager("Max Manager");
            Account acc = new Account("Max Account");

            Ticket t1 = new Ticket(
                1,
                "Projekt Doku fertig stellen",
                "Für die Projektabgabe fehlt noch die fertige Dokumentation. Diese sollte noch fertig erstellt werden. Die Doku ist auf https://github.com/speyck/Gira zu finden. Bitte bei mir (max) melden sobald fertig.",
                acc,
                man,
                estimated: 7200,
                prio: Priorities.Major,
                type: Types.Improvement
            );

            t1.AddWorklogs(new WorkLog("Angefangen", 600, acc));
            t1.AddWorklogs(new WorkLog("Hauptteil", 1200, acc));
            t1.AddWorklogs(new WorkLog("Finale Version", 600, acc));
            t1.AddWorklogs(new WorkLog("Review", 300, man));

            t1.AddComments(new Comment("@manager die Doku ist fertig bitte anschauen", acc));
            t1.AddComments(new Comment("@account ja passt!", man));

            Ticket t2 = new Ticket(
                2,
                "Test Ticket für Vorschau",
                "",
                acc,
                man
            );

            Ticket t3 = new Ticket(
                3,
                "Test Ticket für Vorschau",
                "",
                acc,
                man
            );

            tickets.Add(t1);
            tickets.Add(t2);
            tickets.Add(t3);
        }

        private void OnLogoutButtonClick_Handler(object sender, EventArgs e)
        {
            Hide();

            new GiraView(new LoginView().GetLogin());
        }

        private void OnTicketControlClick_Handler(object sender, TicketControlEventArgs e)
        {
            TicketPage page = new TicketPage(e.Ticket);

            page.OnBackButtonClick += OnBackButtonClick_Handler;

            Navigate(page);
        }

        private void OnBackButtonClick_Handler(object sender, EventArgs e)
        {
            Navigate(startPage);
        }

        private void Navigate(Page page)
        {
            frMain.Navigate(page);
        }
    }
}
