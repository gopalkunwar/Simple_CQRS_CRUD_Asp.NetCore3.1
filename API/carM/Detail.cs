using Core.Domain;
using Infra;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.carM
{
    public class Detail
    {
        //we are creating a Query class which is inherited from IRequest Mediator Interface. 
        //And this interface will return the single car to this Query. 
        //We have one Id property in this Query class to get a specific book from the database.
        public class Query : IRequest<Car>
        {
            public int Id { get; set; }
        }
        //we are getting a specific car from the database.  
        //And this handler is inherited from the IRequestHandler with two parameters.
        public class Handler : IRequestHandler<Query, Car>
        {
            public ApplicationDbContext _context { get; }
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Car> Handle(Query request, CancellationToken cancellationToken)
            {
                var car = await _context.Cars.FindAsync(request.Id);
                return car;
            }
        }
    }
}
