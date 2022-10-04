using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using planete_biblio.Data;

namespace planete_biblio.Facade
{
    public class GetContact
    {
        public class Request : IRequest<IEnumerable<Result>>
        {
            public string? Username { get; set; }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, IEnumerable<Result>>
        {
            private readonly ApplicationDbContext ctx;
            
            public Handler(ApplicationDbContext ctx)
            {
                this.ctx = ctx;
            }

            public async Task<IEnumerable<Result>> Handle(Request request, CancellationToken cancellationToken)
            {
                var teste = await ctx.Livre.ToListAsync(cancellationToken);
                Console.WriteLine("Bonjour, tous va tres bien");
                return new List<Result>() { new Result { Id = 1, Nom = "Jean" }, new Result { Id = 2, Nom = "Fidele"} };
            }
        }

        public class Validator : AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(x => x.Username).Empty();
                RuleFor(x => x.Id);
            }
        }

        public class Result
        {
            public int Id { get; set; }
            public string? Nom { get; set; }
        }
    }
}
