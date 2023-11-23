using Common;
using Data.ViewModels.Communication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        public CommunicationService(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public async Task<ServiceResult<bool>> SendEmail(CommunicationViewModel communication)
        {
            var apiKey = _environment.IsProduction()
                ? Environment.GetEnvironmentVariable("SENDGRID_API_KEY")
                : _configuration["Communication:Email:SendGridApiKey"];

            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_environment.IsProduction()
                ? Environment.GetEnvironmentVariable("SERVICE_EMAIL")
                : _configuration["Communication:Email:ServiceEmail"], communication.SenderName);

            var to = new EmailAddress(_environment.IsProduction()
                ? Environment.GetEnvironmentVariable("RECIPIENT_EMAIL")
                : _configuration["Communication:Email:RecipientEmail"]);

            var subject = $"New message from {communication.SenderName}";
            var plainTextContent = communication.Message;

            var htmlBodyTemplate = File.ReadAllText(_configuration["Communication:Email:TemplatePath"]);

            var htmlBody = htmlBodyTemplate.Replace("{{from_name}}", communication.SenderName)
                .Replace("{{from_email}}", communication.SenderEmail)
                .Replace("{{message}}", communication.Message);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlBody);

            // Set content type for both plain text and HTML
            msg.PlainTextContent = plainTextContent;
            msg.HtmlContent = htmlBody;

            try
            {
                var response = await client.SendEmailAsync(msg);

                return response.IsSuccessStatusCode
                    ? new ServiceResult<bool> { IsSuccess = true, Message = "", Data = true }
                    : throw new Exception("Error sending the email!");
            }
            catch (Exception ex)
            {
                return new ServiceResult<bool> { IsSuccess = false, Message = ex.Message, Data = true };
            }
        }
    }
}