using System;

namespace AlfanoWebDev.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }

        // These are the new optional social fields
        public string? InstagramHandle { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? TwitterHandle { get; set; }

        public string MessageBody { get; set; }
        public DateTime SentDate { get; set; }
    }
}