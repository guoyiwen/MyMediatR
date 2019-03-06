using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyMediatR.Controllers
{
    [Route("api/[controller]")]
    public class MulticastController : Controller
    {
        private readonly IMediator _mediator;
        public MulticastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //构建 通知消息
        public class Ping : INotification { }
        //构建 消息处理器1
        public class Pong1 : INotificationHandler<Ping>
        {
            public Task Handle(Ping notification, CancellationToken cancellationToken)
            {
                Console.WriteLine("Pong 1");
                return Task.CompletedTask;
            }
        }
        //构建 消息处理器2
        public class Pong2 : INotificationHandler<Ping>
        {
            public Task Handle(Ping notification, CancellationToken cancellationToken)
            {
                Console.WriteLine("Pong 2");
                return Task.CompletedTask;
            }
        }

        public async Task Index()
        {
            //发布消息
            await _mediator.Publish(new Ping());
            
        }
    }
}