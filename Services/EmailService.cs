using System.Net;
using System.Net.Mail;
using nba_results_notifier.Interfaces;

namespace nba_results_notifier.Services;

public class EmailService : ISendable
{
    public Task Send(string subject, string body)
    {
        MailMessage message = ConfigureMessage(subject, body);
        
        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
        
        return smtpClient.SendMailAsync(message);
    }

    private static MailMessage ConfigureMessage(string subject, string body)
    {
        MailMessage message = new MailMessage(
            Environment.GetEnvironmentVariable("SENDER_EMAIL"), 
            Environment.GetEnvironmentVariable("RECEIVER_EMAIL"));
        
        message.From = new MailAddress(Environment.GetEnvironmentVariable("SENDER_EMAIL"));
        message.To.Add(new MailAddress(Environment.GetEnvironmentVariable("RECEIVER_EMAIL")));
        message.Subject = subject;
        message.IsBodyHtml = true;
        message.Body = body;
        
        return message;
    }

    private static SmtpClient ConfigureSmtpClient()
    {
        throw new NotImplementedException();
    }
}