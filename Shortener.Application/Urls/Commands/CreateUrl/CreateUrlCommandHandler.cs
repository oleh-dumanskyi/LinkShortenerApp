﻿using MediatR;
using Shortener.Application.Interfaces;
using Shortener.Domain;
using System.Text;

namespace Shortener.Application.Urls.Commands.CreateUrl
{
    public class CreateUrlCommandHandler
        : IRequestHandler<CreateUrlCommand, Guid>
    {
        private readonly IUrlDbContext _context;

        public CreateUrlCommandHandler(IUrlDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateUrlCommand request, CancellationToken cancellationToken)
        {
            var url = new Url
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Description = request.Description,
                CreationDate = DateTime.Now,
                EditDate = null,
                CreatedUri = CreateShortUrl(request.BaseUri, cancellationToken).Result
            };

            return url.Id;
        }

        private async Task<Uri> CreateShortUrl(Uri baseUri, CancellationToken cancellationToken)
        {
            var rngNumberHash = Random.Shared.NextInt64()
                .GetHashCode().ToString();
            var base64EncodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(rngNumberHash));
            return new Uri(@$"http://home/{base64EncodedString}");
        }
}
}