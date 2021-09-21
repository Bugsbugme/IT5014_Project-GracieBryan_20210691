using System;

namespace TicketingSystem
{
    internal class PasswordGen
    {
        //----------------------------------
        //PASSWORD GENERATOR
        //----------------------------------
        public static void PasswordGenerator(Ticket ticket)
        {
            if (ticket.StrIssueDesc.Contains("Password Change", StringComparison.CurrentCultureIgnoreCase))

            {
                //Password is |the first 3 digits of the ticket issuers name
                //            |+the TicketID converted to Hexidecimal
                //            |+the first 3 digits of the time stamp converted to Hexidecimal

                string keyPart1 = ticket.StrIssuerName.Substring(0, 3).ToUpper();
                string keyPart2 = ticket.NTicketID.ToString("X");
                string keyPart3 = DateTime.Now.Ticks.ToString("X").Substring(0, 3);
                string password = keyPart1 + keyPart2 + keyPart3;

                //Update the ticket response
                ticket.StrIssueResponse =
                    $"*Password Reset Request Detected*\r\n" +
                    $"\r\nA new password has been generated for you.\r\n" +
                    $"\r\nNew password generated: {password}";
            }
        }
    }
}