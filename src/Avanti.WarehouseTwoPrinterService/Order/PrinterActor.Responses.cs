namespace Avanti.WarehouseTwoPrinterService.Order;

public partial class PrinterActor
{
    public interface IResponse { }

    public class JobCompleted : IResponse
    { }
}
