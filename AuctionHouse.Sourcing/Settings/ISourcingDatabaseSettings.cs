namespace AuctionHouse.Sourcing.Settings
{
    public interface ISourcingDatabaseSettings
    {
         string ConnectionStrings { get; set; }
         string DatabaseName { get; set; }
    }
}
