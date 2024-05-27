using Core.Integrations;

namespace Infrastructure.DummyIntegration
{
    public class DummyClient : IIntegrationClient
    {
        public async Task<bool> CheckLiveAvailability(string externalProductKey, string instanceId, int passengerCount, CancellationToken cancellationToken)
        {
            var random = new Random();
            await Task.Delay(100); // Simulate external call
            return random.Next(2) == 0;
        }
    }
}
