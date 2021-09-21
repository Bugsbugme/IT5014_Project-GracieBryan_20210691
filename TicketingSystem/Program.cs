using System;
using System.Globalization;

namespace TicketingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TicketStats TicketStats = new();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

            bool MainMenu()
            {
                //Display main menu and wait for further instructions
                Console.Clear();
                Console.WriteLine(
                    "\r\n-----------------------------" +
                    "\r\n|          WELCOME          |" +
                    "\r\n-----------------------------");

                TicketStats.DisplayTicketStats();

                Console.WriteLine(
                    "\r\nWhat would you like to do?" +
                    "\r\n" +
                    "\r\n1) Submit New Support Ticket" +
                    //"\r\n2) Display Ticket Statistics" +
                    "\r\n2) Display All Tickets..." +
                    "\r\n3) Search | Respond..." +
                    "\r\nESC) Exit Program");
                Console.Write("\r\nSelect an option: ");

                ConsoleKeyInfo menuOption = Console.ReadKey();

                while (true)
                {
                    switch (menuOption.Key)
                    {
                        case ConsoleKey.D1:
                            //----------------------------
                            //SUBMIT NEW TICKET
                            //----------------------------
                            SubmitNewTicket();
                            return true;

                        //case ConsoleKey.D2:
                        //    //----------------------------
                        //    //DISPLAY TICKET STATISTICS
                        //    //----------------------------
                        //    DispayTicketSats();
                        //    return true;

                        case ConsoleKey.D2:
                            //----------------------------
                            //DISPLAY ALL TICKETS
                            //----------------------------
                            DisplayAllTickets();
                            return true;

                        case ConsoleKey.D3:
                            //----------------------------
                            //SEARCH | RESPOND
                            //----------------------------
                            SearchAndRespond();
                            return true;

                        case ConsoleKey.Escape:
                            //----------------------------
                            //EXIT PROGRAM
                            //----------------------------
                            Exit();
                            return false;
                    }

                    Console.Clear();
                    Console.WriteLine(
                        "\r\n-----------------------------" +
                        "\r\n|          WELCOME          |" +
                        "\r\n-----------------------------");

                    TicketStats.DisplayTicketStats();

                    Console.WriteLine(
                        "\r\nWhat would you like to do?" +
                        "\r\n" +
                        "\r\n1) Submit New Support Ticket" +
                        //"\r\n2) Display Ticket Statistics" +
                        "\r\n2) Display All Tickets..." +
                        "\r\n3) Search | Respond..." +
                        "\r\nESC) Exit Program" +
                        "\r\n" +
                        "\r\n*Please select one of the given options *");
                    Console.Write("\r\nSelect an option: ");

                    menuOption = Console.ReadKey();
                }

                void SubmitNewTicket()
                {
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
                            "\r\n-------------------------------" +
                            "\r\n|  SUBMIT NEW SUPPORT TICKET  |" +
                            "\r\n-------------------------------");

                        Console.Write("\r\nEnter your Employee ID: ");
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
                        }
                        else
                        {
                            //If all inputs are provided, create a full Ticket
                            var newTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssuerName, strUsrSetIssuerEmail, strUsrSetIssueDesc);

                            //Generate a password if the decription contains the trigger pharase "Password Change"
                            PasswordGen.PasswordGenerator(newTicket);

                            //Add the new Ticket to the Ticket List and display it
                            TicketStats.AddNewTicket(newTicket);
                        }

                        Console.WriteLine(
                            "\r\nR) Return Main Menu" +
                            "\r\nESC) Exit Program" +
                            "\r\n");
                        Console.Write("Select an option: ");

                        ConsoleKeyInfo addMenuOption = Console.ReadKey();

                        while (true)
                        {
                            if (addMenuOption.Key == ConsoleKey.R)
                            {
                                MainMenu();
                            }

                            if (addMenuOption.Key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }

                            Console.Clear();
                            TicketStats.DisplayTicketStats();

                            Console.WriteLine(
                                "\r\nR) Return to Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n" +
                                "\r\n*Please select one of the given options*" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            addMenuOption = Console.ReadKey();
                        }
                    }
                }

                void DispayTicketSats()
                {
                    //----------------------------
                    //DISPLAY TICKET STATISTICS
                    //----------------------------
                    {
                        Console.Clear();
                        TicketStats.DisplayTicketStats();

                        Console.WriteLine(
                            "\r\nR) Return Main Menu" +
                            "\r\nESC) Exit Program" +
                            "\r\n");
                        Console.Write("Select an option: ");

                        ConsoleKeyInfo dtsMenuOption = Console.ReadKey();

                        while (true)
                        {
                            if (dtsMenuOption.Key == ConsoleKey.R)
                            {
                                MainMenu();
                            }

                            if (dtsMenuOption.Key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }

                            Console.Clear();
                            TicketStats.DisplayTicketStats();

                            Console.WriteLine(
                                "\r\nR) Return to Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n" +
                                "\r\n*Please select one of the given options*" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            dtsMenuOption = Console.ReadKey();
                        }
                    }
                }

                void DisplayAllTickets()
                {
                    //----------------------------
                    //DISPLAY ALL TICKETS
                    //----------------------------
                    {
                        Console.Clear();

                        TicketStats.DisplayAllTickets();

                        Console.WriteLine(
                            "R) Return Main Menu" +
                            "\r\nESC) Exit Program" +
                            "\r\n");
                        Console.Write("Select an option: ");

                        ConsoleKeyInfo dspMenuOption = Console.ReadKey();

                        while (true)
                        {
                            if (dspMenuOption.Key == ConsoleKey.D1)
                            {
                                Console.Clear();
                                TicketStats.DisplayOpenTickets();

                                Console.WriteLine(
                                    "R) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n");
                                Console.Write("Select an option: ");

                                dspMenuOption = Console.ReadKey();

                                while (true)
                                {
                                    if (dspMenuOption.Key == ConsoleKey.D1)
                                    {
                                        Console.Clear();
                                        DisplayAllTickets();
                                    }

                                    if (dspMenuOption.Key == ConsoleKey.R)
                                    {
                                        MainMenu();
                                    }

                                    if (dspMenuOption.Key == ConsoleKey.Escape)
                                    {
                                        Environment.Exit(0);
                                    }

                                    Console.Clear();
                                    TicketStats.DisplayOpenTickets();

                                    Console.WriteLine(
                                        "R) Return Main Menu" +
                                        "\r\nESC) Exit Program" +
                                        "\r\n" +
                                        "\r\n*Please select one of the given options*" +
                                        "\r\n");
                                    Console.Write("Select an option: ");

                                    dspMenuOption = Console.ReadKey();
                                }
                            }

                            if (dspMenuOption.Key == ConsoleKey.D2)
                            {
                                Console.Clear();
                                TicketStats.DisplayClosedTickets();

                                Console.WriteLine(
                                    "2) Filter OPEN Tickets" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n");
                                Console.Write("Select an option: ");

                                dspMenuOption = Console.ReadKey();

                                while (true)
                                {
                                    if (dspMenuOption.Key == ConsoleKey.D1)
                                    {
                                        Console.Clear();
                                        DisplayAllTickets();
                                    }

                                    if (dspMenuOption.Key == ConsoleKey.R)
                                    {
                                        MainMenu();
                                    }

                                    if (dspMenuOption.Key == ConsoleKey.Escape)
                                    {
                                        Environment.Exit(0);
                                    }

                                    Console.Clear();
                                    TicketStats.DisplayClosedTickets();

                                    Console.WriteLine(
                                        "R) Return Main Menu" +
                                        "\r\nESC) Exit Program" +
                                        "\r\n" +
                                        "\r\n*Please select one of the given options*" +
                                        "\r\n");
                                    Console.Write("Select an option: ");

                                    dspMenuOption = Console.ReadKey();
                                }
                            }

                            if (dspMenuOption.Key == ConsoleKey.R)
                            {
                                MainMenu();
                            }

                            if (dspMenuOption.Key == ConsoleKey.Escape)
                            {
                                Environment.Exit(0);
                            }

                            Console.Clear();

                            TicketStats.DisplayAllTickets();

                            Console.WriteLine(
                                "R) Return to Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n" +
                                "\r\n*Please select one of the given options*" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            dspMenuOption = Console.ReadKey();
                        }
                    }
                }

                void SearchAndRespond()
                {
                    //----------------------------
                    //SEARCH | RESPOND
                    //----------------------------
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "\r\n------------------------------" +
                            "\r\n|        TICKET SEARCH       |" +
                            "\r\n------------------------------");

                        //Capture search term from the user
                        Console.Write("\r\nEnter the TicketID to search for: ");
                        int ticketID = Convert.ToInt32(Console.ReadLine());
                        TicketStats.SearchTicketID(ticketID);

                        ConsoleKeyInfo srchmenuOption = Console.ReadKey();

                        if (srchmenuOption.Key == ConsoleKey.D1)
                        {
                            SearchAndRespond();
                        }

                        if (srchmenuOption.Key == ConsoleKey.R)
                        {
                            MainMenu();
                        }

                        if (srchmenuOption.Key == ConsoleKey.Escape)
                        {
                            Exit();
                        }

                        if (srchmenuOption.Key == ConsoleKey.D1 & TicketStats.SearchTicketID(ticketID) == "CLOSED")
                        {
                            Console.Clear();
                            TicketStats.UpdateTicketStatus(ticketID, "OPEN");
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "CLOSED")
                        {
                            Console.Clear();
                            TicketStats.UpdateTicketStatus(ticketID, "OPEN");
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {                                
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "CLOSED+PW")
                        {
                            Console.Clear();
                            TicketStats.UpdateTicketStatus(ticketID, "OPEN");
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            Console.Clear();
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D3 & TicketStats.SearchTicketID(ticketID) == "CLOSED+PW")
                        {
                            Console.Clear();
                            TicketStats.GeneratePWManual(ticketID);
                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D1 & TicketStats.SearchTicketID(ticketID) == "OPEN")
                        {
                            Console.Clear();
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            Console.Clear();
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "OPEN")
                        {
                            Console.Clear();
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D2 & TicketStats.SearchTicketID(ticketID) == "OPEN+PW")
                        {
                            Console.Clear();
                            TicketStats.DisplayThisTicket(ticketID);

                            //Capture the response entry from the user
                            Console.WriteLine(
                                "\r\nEnter your response below:" +
                                "\r\n");
                            string response = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());

                            //Update the Ticket Response field and display the updated ticket
                            TicketStats.UpdateTicketResponse(ticketID, response);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }

                        if (srchmenuOption.Key == ConsoleKey.D3 & TicketStats.SearchTicketID(ticketID) == "OPEN+PW")
                        {
                            Console.Clear();
                            TicketStats.GeneratePWManual(ticketID);
                            TicketStats.DisplayThisTicket(ticketID);

                            //Ask the user if the Ticket Status should be updated
                            Console.Write("\r\nShould the Ticket Status be updated to CLOSED? (Y|N): ");
                            srchmenuOption = Console.ReadKey();

                            Console.Clear();
                            if (srchmenuOption.Key == ConsoleKey.Y)
                            {
                                TicketStats.UpdateTicketStatus(ticketID, "CLOSED");
                            }

                            TicketStats.DisplayThisTicket(ticketID);

                            Console.WriteLine(
                                "\r\n1) Start a New Search" +
                                "\r\nR) Return Main Menu" +
                                "\r\nESC) Exit Program" +
                                "\r\n");
                            Console.Write("Select an option: ");

                            srchmenuOption = Console.ReadKey();

                            while (true)
                            {
                                if (srchmenuOption.Key == ConsoleKey.D1)
                                {
                                    SearchAndRespond();
                                }

                                if (srchmenuOption.Key == ConsoleKey.R)
                                {
                                    MainMenu();
                                }

                                if (srchmenuOption.Key == ConsoleKey.Escape)
                                {
                                    Exit();
                                }

                                Console.Clear();
                                TicketStats.DisplayThisTicket(ticketID);

                                Console.WriteLine(
                                    "\r\n1) Start a New Search" +
                                    "\r\nR) Return Main Menu" +
                                    "\r\nESC) Exit Program" +
                                    "\r\n" +
                                    "\r\n* Please select one of the given options *" +
                                    "\r\n ");
                                Console.Write("Select an option: ");

                                srchmenuOption = Console.ReadKey();
                            }
                        }
                    }
                }

                void Exit()
                {
                    //----------------------------
                    //EXIT PROGRAM
                    //----------------------------
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}