using System.Linq;
using Akka.Actor;
using Akka.Event;

namespace Avanti.WarehouseTwoPrinterService.Order
{
    public partial class PrinterActor : ReceiveActor
    {
        private readonly ILoggingAdapter log = Logging.GetLogger(Context);

        public PrinterActor()
        {
            Receive<ExecuteJob>(m => Sender.Tell(Handle(m)));
        }

        private IResponse Handle(ExecuteJob m)
        {
            this.log.Info($"TODO: Should create print job for warehouse order {m.Id} with {m.Lines.Count()} lines...");
            return new JobCompleted();
        }
    }
}
