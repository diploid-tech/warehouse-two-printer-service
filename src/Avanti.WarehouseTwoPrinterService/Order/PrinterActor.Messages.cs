using System;
using System.Collections.Generic;

namespace Avanti.WarehouseTwoPrinterService.Order
{
    public partial class PrinterActor
    {
        public class ExecuteJob
        {
            public string Id { get; set; } = "unknown";
            public int OrderId { get; set; }
            public int WarehouseId { get; set; }
            public DateTimeOffset OrderDate { get; set; }
            public IEnumerable<OrderLine> Lines { get; set; } = Array.Empty<OrderLine>();

            public class OrderLine
            {
                public int Line { get; set; }
                public int ProductId { get; set; }
                public string Description { get; set; } = "unknown";
                public int Amount { get; set; }
            }
        }
    }
}
