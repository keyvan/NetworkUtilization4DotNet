using System.Diagnostics;

namespace NetworkUtilization
{
    public static class UtilizationCounter
    {
        public static double GetNetworkUtilization(string networkCard)
        {
            const int numberOfIterations = 10;

            PerformanceCounter bandwidthCounter =
                new PerformanceCounter("Network Interface", "Current Bandwidth", networkCard);

            float bandwidth = bandwidthCounter.NextValue();

            PerformanceCounter dataSentCounter =
                new PerformanceCounter("Network Interface", "Bytes Sent/sec", networkCard);
            PerformanceCounter dataReceivedCounter =
                new PerformanceCounter("Network Interface", "Bytes Received/sec", networkCard);

            float sendSum = 0;
            float receiveSum = 0;

            for (int index = 0; index < numberOfIterations; index++)
            {
                sendSum += dataSentCounter.NextValue();
                receiveSum += dataReceivedCounter.NextValue();
            }

            float dataSent = sendSum;
            float dataReceived = receiveSum;

            double utilization = (8 * (dataSent + dataReceived)) / (bandwidth * numberOfIterations) * 100;

            return utilization;
        }
    }
}
