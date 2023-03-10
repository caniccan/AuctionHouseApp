using AutoMapper;
using EventBusRabbitMQ;
using EventBusRabbitMQ.Core;
using EventBusRabbitMQ.Events;
using MediatR;
using Newtonsoft.Json;
using Ordering.Application.Commands.OrderCreate;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace AuctionHouse.Order.Consumers
{
    /// <summary>
    /// EventBusOrderCreateConsumer
    /// </summary>
    public class EventBusOrderCreateConsumer
    {
        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// EventBusOrderCreateConsumer Constructor
        /// </summary>
        /// <param name="persistentConnection"></param>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public EventBusOrderCreateConsumer(IRabbitMQPersistentConnection persistentConnection, IMediator mediator, IMapper mapper)
        {
            _persistentConnection = persistentConnection ?? throw new ArgumentNullException(nameof(persistentConnection));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Consume
        /// </summary>
        public void Consume()
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();
            channel.QueueDeclare(queue: EventBusConstants.OrderCreateQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer=new EventingBasicConsumer(channel);

            consumer.Received += ReceivedEvent;

            channel.BasicConsume(queue:EventBusConstants.OrderCreateQueue,autoAck:true,consumer:consumer);
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect()
        {
            _persistentConnection?.Dispose();
        }

        /// <summary>
        /// Forwards the Received Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ReceivedEvent(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            var @event = JsonConvert.DeserializeObject<OrderCreateEvent>(message);

            if (e.RoutingKey.Equals(EventBusConstants.OrderCreateQueue))
            {
                var command = _mapper.Map<OrderCreateCommand>(@event);
                command.CreatedAt= DateTime.Now;
                command.TotalPrice=@event.Quantity * @event.Price;
                command.UnitPrice = @event.Price;

                var result = await _mediator.Send(command);
            }
        }
    }
}
