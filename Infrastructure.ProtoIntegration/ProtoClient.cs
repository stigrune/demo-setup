using Core.Integrations;

namespace Infrastructure.DummyIntegration
{
    public class ProtoClient : IIntegrationClient
    {
        public async Task<bool> CheckLiveAvailability(string externalProductKey, string instanceId, int passengerCount, CancellationToken cancellationToken)
        {
            var random = new Random();
            await Task.Delay(1500); // Simulate slow external call
            return random.Next(2) == 0;
        }
    }
}
