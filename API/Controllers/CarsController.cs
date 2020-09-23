using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.carM;
using Core.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        //we are injecting the IMediator.
        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// we are getting the list of cars. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Car>>> List()
        {
            //we are sending the message to the List query handler using the mediator to get the list of cars.
            return await _mediator.Send(new List.Query());
        }

        /// <summary>
        /// we are getting the specific car by its id. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> Details(int id)
        {
            // is sending the message to the Detail query handler with specific car id.
            return await _mediator.Send(new Detail.Query { Id = id });
        }

        /// <summary>
        /// we are sending the command to the Create Command Handler to insert the object into the database.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        /// <summary>
        /// we are sending the command to the Edit Command handler to update the 
        /// specific car object using the specific car id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// we are sending the command to the Delete Command Handler to delete the object 
        /// using the specific car object id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }
    }
}
