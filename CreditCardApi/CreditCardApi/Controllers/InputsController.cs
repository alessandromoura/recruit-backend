using CreditCardApi.Domain.Communications;
using CreditCardApi.Extensions;
using CreditCardApi.Services;
using CreditCardApi.Services.Commands;
using CreditCardApi.Services.Queries;
using CreditCardApi.Validators;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreditCardApi.Controllers
{
    [Route("api/inputs")]
    [ApiController]
    public class InputsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<InputsController> _logger;

        public InputsController(IMediator mediator, ILogger<InputsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: api/<InputController>
        [HttpGet]
        public async Task<ActionResult<List<InputResponse>>> Get()
        {
            try
            {
                var result = await _mediator.Send(new GetInputsQuery());
                var response = result.Select(x => x.ToInputResponse()).ToList();
                return response;
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/<InputController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InputResponse>> Get(string id)
        {
            try
            {
                var validator = new InputIdValidator();
                validator.ValidateAndThrow(id);

                var result = await _mediator.Send(new GetInputByIdQuery
                {
                     InputId = id
                });

                if (result != null)
                    return result.ToInputResponse();
                else return NotFound();
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("fluentvalidation", StringComparison.OrdinalIgnoreCase))
                    return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<InputController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] InputRequest inputReq)
        {
            try
            {
                var validator = new InputRequestValidator();
                validator.ValidateAndThrow(inputReq);

                var result = await _mediator.Send(new CreateNewInputCommand
                {
                     NewInput = inputReq.ToInputModel()
                });
                 
                return CreatedAtAction(nameof(Get), new { id = result.Id}, result.ToInputResponse());
            }
            catch (KeyNotFoundException kex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, kex.Message);
            }
            catch (Exception ex)
            {
                if (ex.Source.Equals("fluentvalidation", StringComparison.OrdinalIgnoreCase))
                    return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<InputController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InputController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
