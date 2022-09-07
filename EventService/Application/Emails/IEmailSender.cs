namespace EventService.Application.Emails;
public interface IEmailSender
{
    void SendEmail(EmailMessage message);
}
