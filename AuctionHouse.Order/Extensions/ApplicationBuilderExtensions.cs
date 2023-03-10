using AuctionHouse.Order.Consumers;

namespace AuctionHouse.Order.Extensions
{
    /// <summary>
    /// ApplicationBuilderExtensions
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// EventBusOrderCreateConsumer
        /// </summary>
        public static EventBusOrderCreateConsumer Listener { get; set; }

        /// <summary>
        /// RabbitMQ Listener
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusOrderCreateConsumer>();
            var life = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            life.ApplicationStarted.Register(OnStarted);
            life.ApplicationStopping.Register(OnStopping);

            return app;
        }

        /// <summary>
        /// OnStarted
        /// </summary>
        private static void OnStarted()
        {
            Listener.Consume();
        }

        /// <summary>
        /// OnStopping
        /// </summary>
        private static void OnStopping()
        {
            Listener.Disconnect();
        }
    }
}
