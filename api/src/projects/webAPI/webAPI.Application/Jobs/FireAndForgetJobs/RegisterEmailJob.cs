using Core.Mailing;
using Microsoft.Extensions.Configuration;
using MimeKit;
using webAPI.Application.Features.Auths.Commands.Register;

namespace webAPI.Application.Jobs.FireAndForgetJobs
{
    public class RegisterEmailJob
    {
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public RegisterEmailJob(IMailService mailService, IConfiguration configuration)
        {
            _mailService = mailService;
            _configuration = configuration;
        }

        public void Execute(RegisterCommand registerInformation)
        {
            string emailTemplatePath = _configuration.GetSection("WebRootPath").Value + "\\EmailContent\\content.html";
            string emailTemplateContent = getEmailTemplateContent(emailTemplatePath);

            emailTemplateContent = emailTemplateContent.Replace("{{name}}", $"{registerInformation.UserForRegister.FirstName} {registerInformation.UserForRegister.LastName}");
            emailTemplateContent = emailTemplateContent.Replace("{{login_url}}", $"https://www.shopingo.com/authentication-login");
            emailTemplateContent = emailTemplateContent.Replace("{{username}}", $"{registerInformation.UserForRegister.UserName}");
            emailTemplateContent = emailTemplateContent.Replace("{{trial_length}}", $"10");
            emailTemplateContent = emailTemplateContent.Replace("{{trial_start_date}}", $"{DateTime.Now.ToString("dd/MM/yyyy")}");
            emailTemplateContent = emailTemplateContent.Replace("{{trial_end_date}}", $"{DateTime.Now.AddDays(10).ToString("dd/MM/yyyy")}");
            emailTemplateContent = emailTemplateContent.Replace("[Sender Name]", $"Shopingo");
            emailTemplateContent = emailTemplateContent.Replace("[Product Name]", $"Shopingo");
            emailTemplateContent = emailTemplateContent.Replace("{{action_url}} ", $"https://www.shopingo.com");
            emailTemplateContent = emailTemplateContent.Replace("[Company Name, LLC] ", $"Shopingo");


            var toEmailList = new List<MailboxAddress>
            {
                new MailboxAddress($"{registerInformation.UserForRegister.FirstName} {registerInformation.UserForRegister.LastName}",$"{registerInformation.UserForRegister.Email}")
            };

            _mailService.SendMail(new Mail { HtmlBody = emailTemplateContent, ToList = toEmailList, Subject = "Welcome" });

        }

        private string getEmailTemplateContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
