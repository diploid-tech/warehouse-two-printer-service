using Akka.Actor;
using Avanti.Core.Microservice.Actors;
using Avanti.Core.Microservice.AkkaSupport;

namespace Avanti.WarehouseTwoPrinterService.Order
{
    public class PrinterActorProvider : BaseActorProvider<PrinterActor>
    {
        public PrinterActorProvider(ActorSystem actorSystem)
        {
            this.ActorRef = actorSystem.ActorOfWithDI<PrinterActor>("printer-actor");
        }
    }
}
