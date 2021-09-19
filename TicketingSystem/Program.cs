using System;
using System.Globalization;

namespace TicketingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TicketStats TicketStats = new();

            //----------------------------------
            //Generate example tickets: First way
            //----------------------------------
            //Ticket created with partial constructor
            Ticket ticket1 = new Ticket("INNAM", "My monitor stopped working");
            TicketStats.AddNewTicket(ticket1);

            //Ticket created with full constructor
            Ticket ticket2 = new Ticket("MARIAH", "Maria", "maria@whitecliffe.co.nz", "Request for a videocamera to conduct webinars");
            TicketStats.AddNewTicket(ticket2);

            //Ticket for password reset
            Ticket ticket3 = new Ticket("CLOSED", "JOHNS", "John", "john.@whitecliffe.co.nz", "Password Change", "New password generated: JO7D332312F");
            TicketStats.AddNewTicket(ticket3);

            //----------------------------------
            //Generate example tickets: Second way
            //----------------------------------
            //Ticket created with partial constructor
            string obj4IssuerID = "BENL";
            string obj4IssueDesc = "Computer says no...";
            Ticket ticket4 = new Ticket(obj4IssuerID, obj4IssueDesc);
            TicketStats.AddNewTicket(ticket4);

            //Ticket created with full constructor
            string obj5IssuerID = "SARAHM";
            string obj5IssuerName = "Sarah";
            string obj5IssuerEmail = "sarah.@whitecliffe.co.nz";
            string obj5IssueDesc = "I spilled coffee on my keyboard!";
            Ticket ticket5 = new Ticket(obj5IssuerID, obj5IssuerName, obj5IssuerEmail, obj5IssueDesc);
            TicketStats.AddNewTicket(ticket5);

            //Ticket for password reset
            string obj6IssuerID = "PETERH";
            string obj6IssuerName = "Peter";
            string obj6IssuerEmail = "peter.@whitecliffe.co.nz";
            string obj6IssueDesc = "password change";
            Ticket ticket6 = new Ticket(obj6IssuerID, obj6IssuerName, obj6IssuerEmail, obj6IssueDesc);
            TicketStats.AddNewTicket(ticket6);

            //Display main menu and wait for further instructions
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("          :Welcome:           ");
            Console.WriteLine("------------------------------");
            TicketStats.DisplayTicketStats();
            Console.WriteLine("\r\nWhat would you like to do?");
            Console.WriteLine("\r\n1) Submit new Support Ticket");
            Console.WriteLine("2) Display Ticket Statistics");
            Console.WriteLine("3) Display All Tickets");
            Console.WriteLine("4) Search For TicketID");
            Console.WriteLine("5) Respond to Ticket");
            Console.WriteLine("X) Exit Program");
            Console.Write("\r\nSelect an option: ");

            var userInput = Console.ReadLine().ToUpper();
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        {
                            //----------------------------------
                            //Generate example tickets: Third way
                            //----------------------------------
                            //Get input from user
                            Console.Clear();
                            Console.Write("Enter your Employee ID: ");
                            string strUsrSetIssuerID = Console.ReadLine().ToUpper();

                            Console.Write("Enter your Name: ");
                            string strUsrSetIssuerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
                            Console.Write("Enter your Email Address: ");
                            string strUsrSetIssuerEmail = Console.ReadLine();

                            Console.Write("Enter a description of the issue you are having: ");
                            string strUsrSetIssueDesc = Console.ReadLine();

                            //Determine which Ticket Constructor to use
                            if (string.IsNullOrEmpty(strUsrSetIssuerName) & (string.IsNullOrEmpty(strUsrSetIssuerEmail)))
                            {
                                //If no Name and Email is provided, create a partial Ticket
                                //Ticket newTicket = new();
                                var newTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssueDesc);
                                TicketStats.AddNewTicket(newTicket);
                                Console.WriteLine("\r\nYour Support Ticket has been submitted:");
                                TicketStats.DisplayTicketDetails(newTicket);
                            }
                            else
                            {
                                //If all inputs are provided, create a full Ticket
                                //Ticket newTicket = new();
                                var newTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssuerName, strUsrSetIssuerEmail, strUsrSetIssueDesc);
                                TicketStats.AddNewTicket(newTicket);
                                Console.WriteLine("\r\nYour Support Ticket has been submitted:");
                                TicketStats.DisplayTicketDetails(newTicket);
                            }
                        }
                        break;

                    case "2":
                        {
                            Console.Clear();
                            TicketStats.DisplayTicketStats();
                        }
                        break;

                    case "3":
                        {
                            Console.Clear();
                            TicketStats.DisplayAllTickets();
                        }
                        break;

                    case "4":
                        {
                            Console.Clear();
                            Console.Write("Enter the TicketID to search for: ");
                            int ticketID = Convert.ToInt32(Console.ReadLine());
                            TicketStats.SearchTicketID(ticketID);
                        }
                        break;

                    case "5":
                        {
                            Console.Clear();
                            TicketStats.DisplayTicketStats();
                            Console.WriteLine("\r\n1) Respond to OPEN Ticket");
                            Console.WriteLine("2) Reopen CLOSED Ticket");
                            Console.WriteLine("R) Return Main Menu");
                            Console.WriteLine("X) Exit Program");

                            userInput = Console.ReadLine().ToUpper();

                            while (true)
                            {
                                if (userInput == "1")
                                {
                                    Console.Clear();
                                    TicketStats.DisplayOpenTickets();
                                    Console.Write("\r\nEnter the TicketID of the Ticket you are responding to: ");
                                    int ticketID = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Enter your response below:");
                                    Console.WriteLine("");
                                    string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
                                    TicketStats.UpdateTicketResponse(ticketID, response);
                                    TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                                }

                                if (userInput == "2")
                                {
                                    Console.Clear();
                                    TicketStats.DisplayClosedTickets();
                                    Console.Write("\r\nEnter the TicketID of the Ticket you want to Reopen: ");
                                    int ticketID = (Convert.ToInt32(Console.ReadLine()));
                                    TicketStats.UpdateTicketStatus(ticketID, "OPEN");
                                }
                                if (userInput == "R")
                                {
                                    break;
                                }

                                if (userInput == "X")
                                {
                                    Environment.Exit(0);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.Write("*Please select one of the given options*");
                                    Console.WriteLine("");
                                    TicketStats.DisplayTicketStats();
                                    Console.WriteLine("\r\n1) Respond to OPEN Ticket");
                                    Console.WriteLine("2) Reopen CLOSED Ticket");
                                    Console.WriteLine("R) Return to Main Menu");
                                    Console.WriteLine("X) Exit Program");

                                    userInput = Console.ReadLine().ToUpper();
                                }
                                break;
                            }
                        }
                        break;

                    case "X":
                        {
                            Environment.Exit(0);
                        }
                        break;

                    default:
                        {
                            Console.Clear();
                            Console.Write("*Please select one of the given options*");
                        }
                        break;
                }
                Console.WriteLine("\r\nWhat would you like to do?");
                Console.WriteLine("\r\n1) Submit new Support Ticket");
                Console.WriteLine("2) Display Ticket Statistics");
                Console.WriteLine("3) Display All Tickets");
                Console.WriteLine("4) Search For TicketID");
                Console.WriteLine("5) Respond to Ticket");
                Console.WriteLine("X) Exit Program");
                Console.Write("\r\nSelect an option: ");

                userInput = Console.ReadLine().ToUpper();
            }
        }
    }
}