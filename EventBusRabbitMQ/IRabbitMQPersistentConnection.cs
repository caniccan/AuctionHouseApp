﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQPersistentConnection :IDisposable
    {
        public bool IsConnected { get; }
        bool TryConnect();
        IModel CreateModel();
    }
}
