using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Avanti.Core.Microservice.Web;

namespace Avanti.WarehouseTwoPrinterService.Order.Api
{
    public partial class PrivateApiController
    {
        public class PostOrderRequest
        {
            [Required]
            public string? Id { get; set; }
            [Required]
            public int OrderId { get; set; }
            [Required]
            public int? WarehouseId { get; set; }
            [Required]
            public DateTimeOffset OrderDate { get; set; }

            [Required]
            [MustHaveElements]
            public IEnumerable<OrderLine> Lines { get; set; } = Array.Empty<OrderLine>();

            public class OrderLine
            {
                [Required]
                public int? Line { get; set; }
                [Required]
                public int? ProductId { get; set; }
                public string Description { get; set; } = "unknown";
                [Required]
                public int? Amount { get; set; }
            }
        }
    }
}
