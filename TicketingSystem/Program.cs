using System;
using System.Globalization;

namespace TicketingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TicketStats TicketStats = new();

            //Display main menu and wait for further instructions
            Console.Clear();
            Console.WriteLine(
                "-----------------------------" +
                "|          WELCOME          |" +
                "-----------------------------");
            TicketStats.DisplayTicketStats();
            Console.WriteLine(
                "" +
                "What would you like to do?" +
                "" +
                "1) Submit New Support Ticket" +
                "2) Display Ticket Statistics" +
                "3) Display All Tickets..." +
                "4) Search | Respond..." +
                "X) Exit Program" +
                "" +
                "Select an option: ");

            var menuOption = Console.ReadKey();

            while (menuOption.Key != ConsoleKey.X || menuOption.Key != ConsoleKey.Escape)
            {
                switch (menuOption.Key)
                {
                    case ConsoleKey.D1:
                        //----------------------------
                        //SUBMIT NEW TICKET
                        //----------------------------
                        {
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

                            //----------------------------------
                            //Generate example tickets: Third way
                            //----------------------------------
                            //Get input from user
                            Console.Clear();
                            Console.WriteLine(
                                "-------------------------------" +
                                "|  SUBMIT NEW SUPPORT TICKET  |" +
                                "-------------------------------" +
                                "" +
                                "Enter your Employee ID: ");
                            string strUsrSetIssuerID = Console.ReadLine().ToUpper();

                            Console.Write("Enter your Name: ");
                            string strUsrSetIssuerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
                            
                            Console.Write("Enter your Email Address: ");
                            string strUsrSetIssuerEmail = Console.ReadLine();

                            Console.Write("Enter a description of the issue you are having: ");
                            string strUsrSetIssueDesc = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Determine which Ticket Constructor to use
                            if (string.IsNullOrEmpty(strUsrSetIssuerName) & (string.IsNullOrEmpty(strUsrSetIssuerEmail)))
                            {
                                //If no Name and Email is provided, create a partial Ticket
                                var newTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssueDesc);

                                //Generate a password if the decription contains the trigger pharase "Password Change"
                                PasswordGen.PasswordGenerator(newTicket);

                                ///Add the new Ticket to the Ticket List and display it
                                TicketStats.AddNewTicket(newTicket);
                                Console.WriteLine(
                                    "" +
                                    "*Your Support Ticket has been submitted*");
                                TicketStats.DisplayTicketDetails(newTicket);
                            }
                            else
                            {
                                //If all inputs are provided, create a full Ticket
                                var newTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssuerName, strUsrSetIssuerEmail, strUsrSetIssueDesc);

                                //Generate a password if the decription contains the trigger pharase "Password Change"
                                PasswordGen.PasswordGenerator(newTicket);

                                //Add the new Ticket to the Ticket List and display it
                                TicketStats.AddNewTicket(newTicket);
                                Console.WriteLine(
                                    "" +
                                    "*Your Support Ticket has been submitted*");
                                TicketStats.DisplayTicketDetails(newTicket);
                            }
                        }
                        break;

                    case ConsoleKey.D2:
                        //----------------------------
                        //DISPLAY TICKET STATISTICS
                        //----------------------------
                        {
                            Console.Clear();
                            TicketStats.DisplayTicketStats();
                        }
                        break;

                    case ConsoleKey.D3:
                        //----------------------------
                        //DISPLAY ALL TICKETS
                        //----------------------------
                        {
                            Console.Clear();
                            Console.WriteLine(
                                "----------------------------" +
                                "|        ALL TICKETS       |" +
                                "----------------------------" +
                                "" +
                                "");
                            TicketStats.DisplayAllTickets();

                            Console.WriteLine(
                                "" +
                                "1) Filter OPEN Tickets" +
                                "2) Filter CLOSED Tickets" +
                                "R) Return to Main Menu" +
                                "" +
                                "Select an option: ");

                            ConsoleKeyInfo dspMenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (dspMenuOption.Key == ConsoleKey.D1)
                                {
                                    Console.WriteLine(
                                        "-----------------------------" +
                                        "|        OPEN TICKETS       |" +
                                        "-----------------------------" +
                                        "");
                                    TicketStats.DisplayOpenTickets();
                                    break;
                                }

                                if (dspMenuOption.Key == ConsoleKey.D2)
                                {
                                    Console.WriteLine(
                                        "-------------------------------" +
                                        "|        CLOSED TICKETS       |" +
                                        "-------------------------------" +
                                        "");
                                    TicketStats.DisplayClosedTickets();
                                    break;
                                }

                                Console.WriteLine(
                                "" +
                                "1) Filter OPEN Tickets" +
                                "2) Filter CLOSED Tickets" +
                                "R) Return to Main Menu" +
                                "" +
                                "*Please select one of the given options*" +
                                "" +
                                "Select an option: ");
                            }
                        }
                        break;

                    case ConsoleKey.D4:
                        //----------------------------
                        //SEARCH | RESPOND
                        //----------------------------
                        {
                            Console.Clear();
                            Console.WriteLine(
                                "------------------------------" +
                                "|        TICKET SEARCH       |" +
                                "------------------------------" +
                                "");
                            //Capture search term from the user
                            Console.Write("Enter the TicketID to search for: ");
                            int ticketID = Convert.ToInt32(Console.ReadLine());
                            TicketStats.SearchTicketID(ticketID);

                            //Display menu and wait for further instructions
                            //Other options are added based on search result
                            Console.WriteLine(
                                "R) Return Main Menu" +
                                "X) Exit Program");
                            Console.Write(
                                "" +
                                "Select an option: ");

                            while (true)
                            {
                                ConsoleKeyInfo srchmenuOption = Console.ReadKey();

                                if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "resultSuccessOPEN")
                                {
                                    Console.Clear();
                                    TicketStats.DisplayThisTicket(ticketID);

                                    //Capture the response entry from the user
                                    Console.WriteLine(
                                        "" +
                                        "Enter your response below:" +
                                        "");
                                    string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                                    //Update the Ticket Response field and Close it
                                    TicketStats.UpdateTicketResponse(ticketID, response);

                                    break;
                                }

                                if (srchmenuOption.Key == ConsoleKey.D3 & TicketStats.SearchTicketID(ticketID) == "resultSuccessOPENPW")
                                {
                                    Console.Clear();
                                    TicketStats.DisplayThisTicket(ticketID);
                                    TicketStats.GeneratePWManual(ticketID);

                                    break;
                                }

                                if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "resultSuccessCLOSED")
                                {
                                    Console.Clear();
                                    TicketStats.UpdateTicketStatus(ticketID, "OPEN");
                                    TicketStats.DisplayThisTicket(ticketID);

                                    //Capture the response entry from the user
                                    Console.WriteLine(
                                        "" +
                                        "Enter your response below:" +
                                        "");
                                    string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                                    //Update the Ticket Response field and Close it
                                    TicketStats.UpdateTicketResponse(ticketID, response);

                                    break;
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    break;
                                }

                                if (srchmenuOption.Key == ConsoleKey.X || srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Environment.Exit(0);
                                }

                                //If the user enters an invalid menu option, show the menu again
                                Console.Clear();
                                Console.WriteLine(
                                    "------------------------------" +
                                    "|        TICKET SEARCH       |" +
                                    "------------------------------" +
                                    "");

                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                "R) Return Main Menu" +
                                "X) Exit Program");
                                Console.Write(
                                    "" +
                                    "* Please select one of the given options *" +
                                    "" +
                                    "Select an option: ");
                            }
                        }
                        break;

                    case ConsoleKey.X:
                    case ConsoleKey.Escape:
                        //----------------------------
                        //EXIT PROGRAM
                        //----------------------------
                        {
                            Environment.Exit(0);
                        }
                        break;
                }

                //If the user enters an invalid menu option, show the menu again
                Console.WriteLine(
                    "" +
                    "*Please select one of the given options*" +
                    "" +
                    "1) Submit new Support Ticket" +
                    "2) Display Ticket Statistics" +
                    "3) Display All Tickets" +
                    "4) Search For TicketID" +
                    "5) Respond to Ticket" +
                    "X) Exit Program" +
                    "" +
                    "Select an option: ");

                menuOption = Console.ReadKey();
            }
        }
    }
}