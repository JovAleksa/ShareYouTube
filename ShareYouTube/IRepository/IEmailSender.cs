﻿namespace ShareYouTube.IRepository
{
    public interface IEmailSender
    {        
       Task SendEmailAsync(string email, string subject, string message);
    }
}
