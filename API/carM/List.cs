using Core.Domain;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.carM
{
    public class List
    {
        //we are creating a Query class which is inherited from IRequest Mediator Interface. 
        //And this interface will return the List of cars to this Query.
        public class Query : IRequest<List<Car>> { }

        //we are creating the handler for the query. 
        //And this handler is inherited from the IRequestHandler with two parameters. 
        //One is query class and the other one is what we want to return from this handler. 
        //In our case, we are returning a List of cars.
        public class Handler : IRequestHandler<Query, List<Car>>
        {
            public ApplicationDbContext _context { get; }
            public Handler(ApplicationDbContext context)
            {
                _context = context;
            }

            //we are implementing the IRequestHandler interface and 
            //it will create a Handle method within the Handler class. 
            public async Task<List<Car>> Handle(Query request, CancellationToken cancellationToken)
            {
                var cars = await _context.Cars.ToListAsync();
                //we are getting the list of books from the database.
                return cars;
            }
        }
    }
}
