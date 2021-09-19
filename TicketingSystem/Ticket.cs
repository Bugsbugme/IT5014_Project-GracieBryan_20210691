using System;

namespace TicketingSystem
{
    internal class Ticket
    {
        //Declare initial attributes
        private static int V = 2000;

        public int NTicketID { get; set; }
        public string StrDateTime { get; set; }
        public string StrTicketStatus { get; set; }
        public string StrIssuerID { get; set; }
        public string StrIssuerName { get; set; }
        public string StrIssuerEmail { get; set; }
        public string StrIssueDesc { get; set; }
        public string StrIssueResponse { get; set; }

        //Constructor for default values
        private Ticket()
        {
            //Define attribute defaults
            NTicketID = V++;
            StrDateTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            StrTicketStatus = "OPEN";
            StrIssuerID = "*Not Specified*";
            StrIssuerName = "*Not Specified*";
            StrIssuerEmail = "*Not Specified*";
            StrIssueDesc = "*No Details Provided*";
            StrIssueResponse = "*This ticket is awaiting a response*";
        }

        //Constructor for ID and Description user inputs
        public Ticket(string strUsrSetIssuerID, string strUsrSetIssueDesc)
            : this()
        {
            StrIssuerID = strUsrSetIssuerID;
            StrIssueDesc = strUsrSetIssueDesc;
        }

        //Constructor for all user inputs
        public Ticket(string strUsrSetIssuerID, string strUsrSetIssuerName, string strUsrSetIssuerEmail, string strUsrSetIssueDesc)
            : this()
        {
            StrIssuerID = strUsrSetIssuerID;
            StrIssuerName = strUsrSetIssuerName;
            StrIssuerEmail = strUsrSetIssuerEmail;
            StrIssueDesc = strUsrSetIssueDesc;
        }

        public Ticket(string strTicketStatus, string strIssuerID, string strIssuerName, string strIssuerEmail, string strIssueDesc, string strIssueResponse)
            : this()
        {
            StrTicketStatus = strTicketStatus;
            StrIssuerID = strIssuerID;
            StrIssuerName = strIssuerName;
            StrIssuerEmail = strIssuerEmail;
            StrIssueDesc = strIssueDesc;
            StrIssueResponse = strIssueResponse;
        }
    }
}