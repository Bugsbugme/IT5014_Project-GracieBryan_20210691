using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystem
{
    internal class TicketStats
    {
        private List<Ticket> TicketList { get; set; } = new List<Ticket>();

        public static void DisplayTicketDetails(Ticket ticket)
        {
            Console.WriteLine($"\r\n------------TICKET INFORMATION------{ticket.StrTicketStatus}");
            Console.WriteLine($"\r\nTicket Created   : {ticket.StrDateTime}");
            Console.WriteLine($"Ticket ID        : {ticket.NTicketID}");
            Console.WriteLine($"Issuer ID        : {ticket.StrIssuerID}");
            Console.WriteLine($"Issuer Name      : {ticket.StrIssuerName}");
            Console.WriteLine($"Issuer Email     : {ticket.StrIssuerEmail}");
            Console.WriteLine("\r\n------------ISSUE DESCRIPTION-------------");
            Console.WriteLine("");
            Console.WriteLine(ticket.StrIssueDesc);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\r\n------------ISSUE RESPONSE----------------");
            Console.WriteLine("");
            Console.WriteLine(ticket.StrIssueResponse);
            Console.WriteLine("------------------------------------------");
        }

        public void UpdateTicketStatus(int ticketID, string newValue)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    ticket.StrTicketStatus = newValue;
                    break;
                }
            }
        }

        public void UpdateTicketResponse(int ticketID, string newValue)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    ticket.StrIssueResponse = newValue;
                    break;
                }
            }
        }

        public void DisplayTicket(List<Ticket> tickets)
        {
            foreach (Ticket ticket in tickets)
            {
                DisplayTicketDetails(ticket);
            }
        }

        public void AddNewTicket(Ticket ticket)
        {
            TicketList.Add(ticket);
        }

        public void DisplayAllTickets()
        {
            DisplayTicket(TicketList);
        }

        public void SearchTicketID(int ticketID)
        {
            Ticket ticket = TicketList.FirstOrDefault(t => t.NTicketID == ticketID);
            if (ticket == null)
            {
                Console.WriteLine("\r\nNo ticket with that ID was found");
            }
            else
            {
                DisplayTicketDetails(ticket);
            }
        }

        public void DisplayTicketStats()
        {
            List<Ticket> openTickets = TicketList.FindAll(t => t.StrTicketStatus == "OPEN").ToList();
            List<Ticket> closedTickets = TicketList.FindAll(t => t.StrTicketStatus == "CLOSED").ToList();

            Console.WriteLine("------------------------------");
            Console.WriteLine("*Current Ticket Statistics*");
            Console.WriteLine("");
            Console.WriteLine($"Total number of Tickets  : {TicketList.Count}");
            Console.WriteLine($"Number of OPEN Tickets   : {openTickets.Count}");
            Console.WriteLine($"Number of CLOSED Tickets : {closedTickets.Count}");
            Console.WriteLine("------------------------------");
        }

        public void DisplayOpenTickets()
        {
            List<Ticket> openTickets = TicketList.FindAll(t => t.StrTicketStatus == "OPEN").ToList();

            foreach (Ticket ticket in openTickets)
            {
                DisplayTicketDetails(ticket);
            }
        }

        public void DisplayClosedTickets()
        {
            List<Ticket> closedTickets = TicketList.FindAll(t => t.StrTicketStatus == "CLOSED").ToList();

            foreach (Ticket ticket in closedTickets)
            {
                DisplayTicketDetails(ticket);
            }
        }
    }
}