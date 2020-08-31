using System.CodeDom.Compiler;
using Avanti.Core.Microservice;

namespace Avanti.WarehouseTwoPrinterService
{
    [GeneratedCode("avanti-cli", "1.0.0-beta+c101678abd")]
    public static class Program
    {
        public static void Main()
        {
            Service.Run<Startup>();
        }
    }
}
