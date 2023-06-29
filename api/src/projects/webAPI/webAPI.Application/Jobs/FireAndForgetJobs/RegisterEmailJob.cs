using Core.Mailing;
using MimeKit;

namespace webAPI.Application.Jobs.FireAndForgetJobs
{
    public class RegisterEmailJob
    {
        private readonly IMailService _mailService;

        public RegisterEmailJob(IMailService mailService)
        {
            _mailService = mailService;
        }

        public void Execute(string email, string firstName, string lastName)
        {
            var toEmailList = new List<MailboxAddress>
                {
                    new($"{firstName} {lastName}",email)
                };
            _mailService.SendMail(new Mail { TextBody = "Hoş Geldiniz.", ToList = toEmailList, Subject = "Üyelik" });

        }
    }
}
