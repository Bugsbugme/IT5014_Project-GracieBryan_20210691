using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketingSystem
{
    internal class TicketStats
    {
        private List<Ticket> TicketList { get; set; } = new List<Ticket>();

        //Method for displaying ticket details
        public static void DisplayTicketDetails(Ticket ticket)
        {
            Console.WriteLine(
                $"" +
                $"----------------------------------------" +
                $"|          TICKET INFORMATION          |" +
                $"----------------------------------------" +
                $"" +
                $"|{ticket.StrTicketStatus}|" +
                $"" +
                $"Ticket Created   : {ticket.StrDateTime}" +
                $"Ticket ID        : {ticket.NTicketID}" +
                $"Issuer ID        : {ticket.StrIssuerID}" +
                $"Issuer Name      : {ticket.StrIssuerName}" +
                $"Issuer Email     : {ticket.StrIssuerEmail}" +
                $"" +
                $"ISSUE DESCRIPTION-----------------------" +
                $"" +
                $"{ticket.StrIssueDesc}" +
                $"----------------------------------------" +
                $"ISSUE RESPONSE--------------------------" +
                $"{ticket.StrIssueResponse}" +
                $"----------------------------------------");
        }

        //Method for adding a new ticket to the list
        public void AddNewTicket(Ticket ticket)
        {
            TicketList.Add(ticket);
        }

        //Method for diplaying all tickets in the list
        public void DisplayAllTickets()
        {
            foreach (Ticket ticket in TicketList)
            {
                DisplayTicketDetails(ticket);
            }
        }

        //Method for dislpaying closed tickets
        public void DisplayClosedTickets()
        {
            List<Ticket> closedTickets = TicketList.FindAll(t => t.StrTicketStatus == "CLOSED").ToList();

            foreach (Ticket ticket in closedTickets)
            {
                DisplayTicketDetails(ticket);
            }
        }

        //Method for displaying open tickets
        public void DisplayOpenTickets()
        {
            List<Ticket> openTickets = TicketList.FindAll(t => t.StrTicketStatus == "OPEN").ToList();

            foreach (Ticket ticket in openTickets)
            {
                DisplayTicketDetails(ticket);
            }
        }

        //Method displaying a specific ticket
        public void DisplayThisTicket(int ticketID)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    DisplayTicketDetails(ticket);
                    break;
                }
            }
        }

        //Method for displaying ticket stats
        public void DisplayTicketStats()
        {
            List<Ticket> openTickets = TicketList.FindAll(t => t.StrTicketStatus == "OPEN").ToList();
            List<Ticket> closedTickets = TicketList.FindAll(t => t.StrTicketStatus == "CLOSED").ToList();

            Console.WriteLine(
                $"-----------------------------" +
                $"|     TICKET STATISTICS     |" +
                $"-----------------------------" +
                $"Total number of Tickets     | {TicketList.Count}" +
                $"Number of OPEN Tickets      | {openTickets.Count}" +
                $"Number of CLOSED Tickets    | {closedTickets.Count}" +
                $"-----------------------------");
        }

        //Method for manually generating a new password
        public void GeneratePWManual(int ticketID)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    
                    PasswordGen.PasswordGenerator(ticket);
                    break;
                }
            }
        }

        //Method to search for a specific ticket ID
        public string SearchTicketID(int ticketID)
        {
            Ticket ticket = TicketList.FirstOrDefault(t => t.NTicketID == ticketID);

            if (ticket.StrTicketStatus == "OPEN")
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "" +
                    "1) Search Again" +
                    "2) Issue Response to this Ticket");

                return "resultSuccessOPEN";
            }

            if (ticket.StrTicketStatus == "OPEN" & ticket.StrIssueDesc.Contains("Password Change"))
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "" +
                    "1) Search Again" +
                    "2) Issue Response to this Ticket" +
                    "3) Generate New Password for this Ticket");

                return "resultSuccessOPENPW";
            }

            if (ticket.StrTicketStatus == "CLOSED")
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "" +
                    "1) Search Again" +
                    "2) Reopen and Respond to this Ticket");

                return "resultSuccessCLOSED";
            }

            else 
            {
                Console.WriteLine(
                    "" +
                    "No ticket with that ID was found" +
                    "" +
                    "1) Search Again");
                return "resultNULL";
            }
        }

        //Method for updating the ticket response
        public void UpdateTicketResponse(int ticketID, string newValue)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    ticket.StrIssueResponse = newValue;
                    ticket.StrTicketStatus = "CLOSED";

                    Console.WriteLine(
                        $"Your response has been added" +
                        $"" +
                        $"The Ticket Status has been Updated and is now: {ticket.StrTicketStatus}");

                    break;
                }
            }
        }

        //Method for updating the ticket status
        public void UpdateTicketStatus(int ticketID, string newValue)
        {
            for (int i = 0; i < TicketList.Count; i++)
            {
                Ticket ticket = TicketList[i];
                if (ticket.NTicketID == ticketID)
                {
                    ticket.StrTicketStatus = newValue;

                    Console.WriteLine(
                        $"The Ticket Status has been Updated and is now: " +
                        $"{ticket.StrTicketStatus}");

                    DisplayTicketDetails(ticket);

                    break;
                }
            }
        }
    }
}