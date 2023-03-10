namespace AuctionHouse.Sourcing.Settings
{
    /// <summary>
    /// SourcingDatabaseSettings
    /// </summary>
    public class SourcingDatabaseSettings : ISourcingDatabaseSettings
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// DatabaseName
        /// </summary>
        public string DatabaseName { get; set; }
    }
}
