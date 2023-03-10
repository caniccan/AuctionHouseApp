using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    /// <summary>
    /// IRabbitMQPersistentConnection
    /// </summary>
    public interface IRabbitMQPersistentConnection :IDisposable
    {
        /// <summary>
        /// Gets the IsConnected
        /// </summary>
        public bool IsConnected { get; }

        /// <summary>
        /// TryConnect
        /// </summary>
        bool TryConnect();

        /// <summary>
        /// CreateModel
        /// </summary>
        IModel CreateModel();
    }
}
