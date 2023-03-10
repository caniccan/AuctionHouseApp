namespace AuctionHouse.Sourcing.Settings
{
    /// <summary>
    /// SourcingDatabaseSettings
    /// </summary>
    public interface ISourcingDatabaseSettings
    {
        /// <summary>
        /// ConnectionString
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// DatabaseName
        /// </summary>
        string DatabaseName { get; set; }
    }
}
