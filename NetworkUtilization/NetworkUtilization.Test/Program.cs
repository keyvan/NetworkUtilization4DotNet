using System;

namespace NetworkUtilization.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Network Utilization Counter for .NET";

            string networkCard = "Realtek RTL8168B_8111B Family PCI-E Gigabit Ethernet NIC [NDIS 6.0]";

            double utilization = UtilizationCounter.GetNetworkUtilization(networkCard);

            Console.WriteLine(string.Format("Network Utilization = %{0}", utilization));

            Console.ReadLine();
        }
    }
}
