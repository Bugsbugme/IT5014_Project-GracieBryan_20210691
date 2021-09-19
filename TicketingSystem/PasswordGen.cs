using System;

namespace TicketingSystem
{
    internal class PasswordGen
    {
        
        public static void PasswordGenerator(Ticket ticket)
        {
            short timeStamp = Convert.ToInt16(DateTime.Now.ToString("HHm"));

            string keyPart1 = ticket.StrIssuerName.Substring(0, 3);
            string keyPart2 = ticket.NTicketID.ToString("X");
            string keyPart3 = timeStamp.ToString("X");
            string keyFull = keyPart1 + keyPart2 + keyPart3;

            ticket.StrIssueResponse = $"New password generated: {keyFull}";
        }

        public void PasswordResetCheck(Ticket ticket)
        {
            if (ticket.StrIssueDesc.Contains("password change",
                StringComparison.CurrentCultureIgnoreCase))
            {
                PasswordGenerator(ticket);
                ticket.StrTicketStatus = "CLOSED";
                Console.WriteLine("\r\n*Password Reset request Detected*");
                Console.WriteLine("A new passwrod has been generated for you and your Support Ticket has been closed.");
            }
        }
    }
}