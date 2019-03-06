using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyMediatR.Application.Commands;
using MyMediatR.Application.Models;
using Serilog;

namespace MyMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator _mediator;


        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public async Task Get()
        {
           var createOrderDraftCommand=   new CreateOrderDraftCommand("1",new List<BasketItem>{new BasketItem{Id="11",UnitPrice=1, Quantity =1} });
            //发送 请求
            var response = await _mediator.Send(createOrderDraftCommand);
            Log.Debug("response:{@response}", response); // "Pong"
           
        }

       


    }
}
