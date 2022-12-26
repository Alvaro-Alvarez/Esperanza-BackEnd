using Esperanza.Core.Models.Options;
using Esperanza.Service.Business;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Esperanza.BackgroundTasks
{
    static public class SchedulerService
    {
        static public void Start(IConfiguration config)
        {
            //RecurringJob.AddOrUpdate<UserProductService>("UpdatePrices", (p) => p.UpdatePrices(), config.GetValue<string>("Cron:ReloadProducts"));
        }
    }
}
