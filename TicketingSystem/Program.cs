using System;
using System.Collections.Generic;
using System.Globalization;

namespace TicketingSystem
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Ticket> lstTicketsList = new();//Create list to store tickets

            string strNewTicket;
            do
            {
                //Get input from user//////////////////////////////////////////////////////////////////////
                Console.Write("Enter your Employee ID: ");
                string strUsrSetIssuerID = Console.ReadLine().ToUpper();

                Console.Write("Enter your Name: ");
                string tempName = Console.ReadLine().ToLower().ToLower();
                string strUsrSetIssuerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tempName);

                Console.Write("Enter your Email Address: ");
                string strUsrSetIssuerEmail = Console.ReadLine();

                Console.Write("Enter a description of the issue you are having: ");
                string strUsrSetIssueDesc = Console.ReadLine();

                //Determine which Ticket Constructor to use///////////////////////////////////////////////
                if (string.IsNullOrEmpty(strUsrSetIssuerName) & (string.IsNullOrEmpty(strUsrSetIssuerEmail)))
                {
                    //If no Name and Email is provided, create a partial Ticket
                    Ticket objTicket = new();
                    objTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssueDesc);
                    objTicket.GetTicketInfo();
                    lstTicketsList.Add(objTicket);
                }
                else
                {
                    //If all inputs are provided, create a full Ticket
                    Ticket objTicket = new();
                    objTicket = new Ticket(strUsrSetIssuerID, strUsrSetIssuerName, strUsrSetIssuerEmail, strUsrSetIssueDesc);
                    objTicket.GetTicketInfo();
                    lstTicketsList.Add(objTicket);
                }

                Console.WriteLine("Do you want to submit another ticket: ");
                strNewTicket = Console.ReadLine();
            }
            while ((strNewTicket == "yes") || (strNewTicket == "YES") || (strNewTicket == "y") || (strNewTicket == "Y"));
        }
    }
}