﻿namespace Shortener.Domain
{
    public class Url
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public Uri BaseUri { get; set; }
        public Uri CreatedUri { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}