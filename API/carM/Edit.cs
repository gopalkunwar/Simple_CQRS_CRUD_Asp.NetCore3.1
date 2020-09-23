using Infra;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.carM
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Color { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _context;

            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var car = await _context.Cars.FindAsync(request.Id);
                if (car == null)
                {
                    throw new Exception("Could not find car");
                }
                car.Name = request.Name ?? car.Name;
                car.Color = request.Color ?? car.Color;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    return Unit.Value;
                }
                throw new Exception("some problem");
            }
        }
    }
}
