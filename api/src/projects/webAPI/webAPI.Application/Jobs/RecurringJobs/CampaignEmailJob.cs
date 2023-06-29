using Core.Mailing;
using MimeKit;

namespace webAPI.Application.Jobs.RecurringJobs
{
    public class CampaignEmailJob
    {
        private readonly IMailService _mailService;

        public CampaignEmailJob(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void Execute()
        {
            var toEmailList = new List<MailboxAddress>
                {
                    new("Emre Can Ayar","emrecan.ayar@hotmail.com")
                };
            _mailService.SendMail(new Mail { TextBody = "Bu bir hangire test emailidir.", ToList = toEmailList, Subject = "HangFire Test" });
        }
    }
}
