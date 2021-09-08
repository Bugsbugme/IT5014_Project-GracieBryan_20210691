using System;
using System.Collections.Generic;

namespace TicketingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Ticket> objTicketsList = new List<Ticket>();//Create list to store tickets

            //Ticket objDefualtTicket = new();
            Ticket objTicket = new();//Intialize ticket object

            //Get input from user
            Console.Write("Enter your Employee ID: ");
            string strUsrSetIssuerID = Console.ReadLine();

            Console.Write("Enter your Name: ");
            string strUsrSetIssuerName = Console.ReadLine();

            Console.Write("Enter your Email Address: ");
            string strUsrSetIssuerEmail = Console.ReadLine();

            Console.Write("Enter a description of the issue you are having: ");
            string strUsrSetIssueDesc = Console.ReadLine();

            //Add user input ticket object
            //objTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssueDesc);
            objTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssuerName, strUsrSetIssuerEmail, strUsrSetIssueDesc);
            
            //Add ticket to list
            objTicketsList.Add(objTicket);

            //Display ticket info
            objTicket.GetTicketInfo();

            //Ticket ticket001 = new();//Create new Ticket object

            //ticket001.SetIssuerID();

            ////Print Ticket details
            //ticket001.GetTicketInfo();
        }
    }
}