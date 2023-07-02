using Esperanza.Service.Business;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Esperanza.BackgroundTasks
{
    static public class SchedulerService
    {
        static public void Start(IConfiguration config)
        {
            //RecurringJob.AddOrUpdate<ItemUpdateService>("RestartServices", (p) => p.RestartServices(), config.GetValue<string>("Cron:RestartServices"));
            RecurringJob.AddOrUpdate<ItemUpdateService>("UpdateProducts", (p) => p.UpdateProducts(), config.GetValue<string>("Cron:Products"));
            RecurringJob.AddOrUpdate<ItemUpdateService>("UpdateCustomers", (p) => p.UpdateCtaCte(), config.GetValue<string>("Cron:Customers"));
            RecurringJob.AddOrUpdate<ItemUpdateService>("UpdateCustomerConditions", (p) => p.UpdateConditions(), config.GetValue<string>("Cron:CustomerConditions"));
            RecurringJob.AddOrUpdate<ItemUpdateService>("UpdatePriceLists", (p) => p.UpdateLists(), config.GetValue<string>("Cron:PriceLists"));
        }
    }
}
