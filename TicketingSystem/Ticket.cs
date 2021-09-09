using System;

namespace TicketingSystem
{
    internal class Ticket
    {
        //Declare initial attributes
        private static int _nTicketID = 2000;
        private static string _strDateTime;
        private static string _strTicketStatus;
        private static string _strIssuerID;
        private static string _strIssuerName;
        private static string _strIssuerEmail;
        private static string _strIssueDesc;
        

        //Constructor for default values
        public Ticket()
        {
            //Define attribute defaults
            _nTicketID ++;
            _strDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            _strTicketStatus = "Open";
            _strIssuerID = "Not Specified";
            _strIssuerName = "Not Specified";
            _strIssuerEmail = "Not Specified";
            _strIssueDesc = "No Details Provided";
        }

        //Constructor for ID and Description user inputs
        public Ticket(string strUsrSetIssuerID, string strUsrSetIssueDesc)
        {
            
            _strIssuerID = strUsrSetIssuerID;
            _strIssueDesc = strUsrSetIssueDesc;
        }

        //Constructor for all user inputs
        public Ticket(string strUsrSetIssuerID, string strUsrSetIssuerName, string strUsrSetIssuerEmail, string strUsrSetIssueDesc)
        {
            _strIssuerID = strUsrSetIssuerID;
            _strIssuerName = strUsrSetIssuerName;
            _strIssuerEmail = strUsrSetIssuerEmail;
            _strIssueDesc = strUsrSetIssueDesc;
        }

        //Set Methods
        public void SetIssuerID(string strSetIssuerID)
        {
            _strIssuerID = strSetIssuerID;
        }

        public void SetIssuerName(string strSetIssuerName)
        {
            _strIssuerName = strSetIssuerName;
        }

        public void SetIssuerEmail(string strSetIssuerEmail)
        {
            _strIssuerEmail = strSetIssuerEmail;
        }

        public void SetIssueDesc(string strSetIssueDesc)
        {
            _strIssueDesc = strSetIssueDesc;
        }

        //Get Methods
        public int GetTicketID()
        {
            return _nTicketID;
        }

        public string GetTicketDateTime()
        {
            return _strDateTime;
        }

        public string GetTicketStatus()
        {
            return _strTicketStatus;
        }

        public string GetIssuerID()
        {
            return _strIssuerID;
        }

        public string GetIssuerName()
        {
            return _strIssuerName;
        }

        public string GetIssuerEmail()
        {
            return _strIssuerEmail;
        }

        public string GetIssueDesc()
        {
            return _strIssueDesc;
        }

        public void GetTicketInfo()
        {
            Console.WriteLine();
            Console.WriteLine("------------TICKET INFORMATION------------");
            Console.WriteLine("Ticket Status    : " + GetTicketStatus());
            Console.WriteLine("Ticket Created   : " + GetTicketDateTime());
            Console.WriteLine("Ticket ID        : " + GetTicketID());
            Console.WriteLine("Issuer ID        : " + GetIssuerID());
            Console.WriteLine("Issuer Name      : " + GetIssuerName());
            Console.WriteLine("Issuer Email     : " + GetIssuerEmail());
            Console.WriteLine("------------ISSUE DESCRIPTION-------------");
            Console.WriteLine(GetIssueDesc());
            Console.WriteLine("------------------------------------------");
        }
    }
}