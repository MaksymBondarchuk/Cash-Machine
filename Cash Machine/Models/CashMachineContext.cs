namespace Cash_Machine.Models
{
    using System.Data.Entity;

    public class CashMachineContext : DbContext
    {
        public virtual DbSet<Card> CardSet { get; set; }
        public virtual DbSet<CardOperation> CardOperationSet { get; set; }
        public virtual DbSet<OperationType> OperationTypeSet { get; set; }
    }
}