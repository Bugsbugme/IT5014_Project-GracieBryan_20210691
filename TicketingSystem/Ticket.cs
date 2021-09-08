using System;

namespace TicketingSystem
{
    internal class Ticket
    {
        //Declare initial attributes
        private static int _nTicketID = 2000;
        private static int _nUniqueTicketID;
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
            _nTicketID++;
            _nUniqueTicketID = _nTicketID;
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

        //public void SetIssuerID(int input_IssuerID)
        //{
        //    _nIssuerID = input_IssuerID;
        //}

        //public void SetIssuerName(string input_IssuerName)
        //{
        //    _strIssuerName = input_IssuerName;
        //}

        //public void SetIssuerEmail(string input_IssuerEmail)
        //{
        //    _strIssuerEmail = input_IssuerEmail;
        //}

        //public void SetIssuerDesc(string input_issueDesc)
        //{
        //    _strIssueDesc = input_issueDesc;
        //}

        public int GetTicketID()
        {
            return _nUniqueTicketID;
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
            Console.WriteLine("------------TICKET INFORMATION------------");
            Console.WriteLine("Ticket Status    : " + GetTicketStatus());
            Console.WriteLine("Ticket Created   : " + GetTicketDateTime());
            Console.WriteLine("Ticket ID        : " + GetTicketID());
            Console.WriteLine("Issuer ID        : " + GetIssuerID());
            Console.WriteLine("Issuer Name      : " + GetIssuerName());
            Console.WriteLine("Issuer Email     : " + GetIssuerEmail());
            Console.WriteLine("------------ISSUE DESCRIPTION-------------");
            Console.WriteLine(GetIssueDesc());
        }
    }
}