namespace Cash_Machine.Models
{
    using System.Data.Entity;

    public class CashMachineContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardOperation> CardOperations { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
    }
}