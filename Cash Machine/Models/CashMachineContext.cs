namespace Cash_Machine.Models
{
    using System.Data.Entity;

    public class CashMachineContext : DbContext
    {
        public virtual DbSet<Card> Cards { get; set; }
        //public virtual DbSet<CardOperation> CardOperations { get; set; }
        //public virtual DbSet<OperationType> OperationTypes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<ForeignTest> ForeignTests { get; set; }
    }
}