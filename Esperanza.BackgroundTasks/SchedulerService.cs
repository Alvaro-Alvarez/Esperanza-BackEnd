using Esperanza.Service.Business;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Esperanza.BackgroundTasks
{
    static public class SchedulerService
    {
        static public void Start(IConfiguration config)
        {
            //RecurringJob.AddOrUpdate<ProductService>("GetAllFull", (p) => p.GetAllFull(), config.GetValue<string>("Cron:ReloadProducts"));
            RecurringJob.AddOrUpdate<ProductService>("TestHangfire", (p) => p.TestHangfire(), Cron.Minutely);
            //RecurringJob.AddOrUpdate("myrecurringjob", () => Console.WriteLine("Recurring!"), Cron.Minutely);
        }
    }
}
