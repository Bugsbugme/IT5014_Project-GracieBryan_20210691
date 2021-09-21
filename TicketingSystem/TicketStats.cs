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
                $"\r\n----------------------------------------" +
                $"\r\n|          TICKET INFORMATION          |" +
                $"\r\n----------------------------------------" +
                $"\r\n" +
                $"\r\nTICKET STATUS" +
                $"\r\n*{ticket.StrTicketStatus}*" +
                $"\r\n" +
                $"\r\nTicket Created   : {ticket.StrDateTime}" +
                $"\r\nTicket ID        : {ticket.NTicketID}" +
                $"\r\nIssuer ID        : {ticket.StrIssuerID}" +
                $"\r\nIssuer Name      : {ticket.StrIssuerName}" +
                $"\r\nIssuer Email     : {ticket.StrIssuerEmail}" +
                $"\r\n" +
                $"\r\nISSUE DESCRIPTION-----------------------" +
                $"\r\n" +
                $"\r\n{ticket.StrIssueDesc}" +
                $"\r\n----------------------------------------" +
                $"\r\n" +
                $"\r\nISSUE RESPONSE--------------------------" +
                $"\r\n" +
                $"\r\n{ticket.StrIssueResponse}" +
                $"\r\n----------------------------------------");
        }

        //Method for adding a new ticket to the list
        public void AddNewTicket(Ticket ticket)
        {
            TicketList.Add(ticket);

            Console.Clear();
            DisplayTicketDetails(ticket);

            Console.WriteLine(
                "\r\n*Your Support Ticket has been submitted*" +
                "\r\n" +
                "\r\nSupport staff will contact you shortly.");
        }

        //Method for diplaying all tickets in the list
        public void DisplayAllTickets()
        {
            Console.WriteLine(
                "\r\n-----------------------------" +
                "\r\n|        ALL TICKETS        |" +
                "\r\n-----------------------------");

            if (TicketList.Count == 0)
            {
                Console.WriteLine(
                    "\r\nThere are currently no Tickets" +
                    "\r\n");
            }
            else
            {
                foreach (Ticket ticket in TicketList)
                {
                    DisplayTicketDetails(ticket);
                }
                Console.WriteLine(
                    "\r\n1) Filter OPEN Tickets" +
                    "\r\n2) Filter CLOSED Tickets");
            }
        }

        //Method for dislpaying closed tickets
        public void DisplayClosedTickets()
        {
            List<Ticket> closedTickets = TicketList.FindAll(t => t.StrTicketStatus == "CLOSED").ToList();

            Console.WriteLine(
                "\r\n-------------------------------" +
                "\r\n|        CLOSED TICKETS       |" +
                "\r\n-------------------------------");

            foreach (Ticket ticket in closedTickets)
            {
                DisplayTicketDetails(ticket);
            }

            Console.WriteLine("\r\n1) Display All Tickets");
        }

        //Method for displaying open tickets
        public void DisplayOpenTickets()
        {
            List<Ticket> openTickets = TicketList.FindAll(t => t.StrTicketStatus == "OPEN").ToList();

            Console.WriteLine(
                "\r\n-----------------------------" +
                "\r\n|        OPEN TICKETS       |" +
                "\r\n-----------------------------");

            foreach (Ticket ticket in openTickets)
            {
                DisplayTicketDetails(ticket);
            }

            Console.WriteLine("\r\n1) Display All Tickets");
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
                $"\r\n-----------------------------" +
                $"\r\n|     TICKET STATISTICS     |" +
                $"\r\n-----------------------------" +
                $"\r\nTotal number of Tickets     | {TicketList.Count}" +
                $"\r\nNumber of OPEN Tickets      | {openTickets.Count}" +
                $"\r\nNumber of CLOSED Tickets    | {closedTickets.Count}" +
                $"\r\n-----------------------------");
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

            if (ticket == null)
            {
                Console.WriteLine(
                    "\r\nNo ticket with that ID was found" +
                    "\r\n1) Start New Search" +
                    "\r\nR) Return Main Menu" +
                    "\r\nESC) Exit Program" +
                    "\r\n");
                Console.Write("Select an option: ");

                return "NOTFOUND";
            }

            if (ticket.StrTicketStatus == "CLOSED" & ticket.StrIssueDesc.Contains("Password Change", StringComparison.CurrentCultureIgnoreCase))
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "\r\n1) Start New Search" +
                    "\r\n2) Reopen and Respond to this Ticket" +
                    "\r\n3) Generate New Password for this Ticket" +
                    "\r\nR) Return Main Menu" +
                    "\r\nESC) Exit Program" +
                    "\r\n");
                Console.Write("Select an option: ");

                return "CLOSED+PW";
            }

            if (ticket.StrTicketStatus == "CLOSED")
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "\r\n1) Start New Search" +
                    "\r\n2) Reopen and Respond to this Ticket" +
                    "\r\nR) Return Main Menu" +
                    "\r\nESC) Exit Program" +
                    "\r\n");
                Console.Write("Select an option: ");

                return "CLOSED";
            }

            if (ticket.StrTicketStatus == "OPEN" & ticket.StrIssueDesc.Contains("Password Change", StringComparison.CurrentCultureIgnoreCase))
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "\r\n1) Start New Search" +
                    "\r\n2) Issue Response to this Ticket" +
                    "\r\n3) Generate New Password for this Ticket" +
                    "\r\nR) Return Main Menu" +
                    "\r\nESC) Exit Program" +
                    "\r\n");
                Console.Write("Select an option: ");

                return "OPEN+PW";
            }

            if (ticket.StrTicketStatus == "OPEN")
            {
                DisplayTicketDetails(ticket);

                Console.WriteLine(
                    "\r\n1) Start New Search" +
                    "\r\n2) Issue Response to this Ticket" +
                    "\r\nR) Return Main Menu" +
                    "\r\nESC) Exit Program" +
                    "\r\n");
                Console.Write("Select an option: ");

                return "OPEN";
            }
            else
            {
                return "invalidInput";
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

                    Console.Clear();
                    Console.WriteLine($"\r\nYour response has been added");

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

                    Console.Clear();
                    Console.WriteLine(
                        $"\r\nThe Ticket Status has been Updated and is now: " +
                        $"\r\n{ticket.StrTicketStatus}");

                    break;
                }
            }
        }
    }
}