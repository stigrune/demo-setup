using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Integrations
{
    public interface IIntegrationClient
    {
        public Task<bool> CheckLiveAvailability(string externalProductKey, string instanceId, int passengerCount, CancellationToken cancellationToken);
    } 
}
