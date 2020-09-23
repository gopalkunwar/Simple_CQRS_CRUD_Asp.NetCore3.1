using Core.Domain;
using Infra;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static API.carM.Create;

namespace API.carM
{
    public class Create
    {
        //we are creating the Command class which is inherited from IRequest interface from MediatR. 
        //And this command class has some properties same as the Car class.
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Color { get; set; }
        }
    }

    //we are creating the Handler class which is inherited from the IRequestHandler interface.
    public class Handler : IRequestHandler<Command>
    {
        private readonly ApplicationDbContext _context;
        public Handler(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            //we are initializing the book object and then inserting into the database. 
            var car = new Car
            {
                Id = request.Id,
                Name = request.Name,
                Color = request.Color
            };
            //inserting into the database. 
            _context.Cars.Add(car);
            //return the value. If it will return the value greater than 0, 
            //it means the object is created successfully. 
            //Otherwise, it will return the exception.
            var success = await _context.SaveChangesAsync() > 0;
            if (success)
            {
                return Unit.Value;
            }
            else
            {
                throw new Exception("some error");
            }

        }
    }
}
