﻿using Microsoft.EntityFrameworkCore;
using Shortener.Domain;

namespace Shortener.Application.Interfaces
{
    public interface IUrlDbContext
    {
        DbSet<Url> Urls { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}