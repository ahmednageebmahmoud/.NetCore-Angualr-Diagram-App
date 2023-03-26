using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.HangfireBLL
{
    public class HangfireService : IHangfireService
    {
        public void SendMail(string message)
        {
            BackgroundJob.Enqueue(() => DoJob("Enqueue", message));
        }

        public void SendMail(string message,int seconds)
        {
            BackgroundJob.Schedule(() => DoJob("Schedule", message),TimeSpan.FromSeconds(seconds));
        }

        public void SendMail(string message, bool isRcurring)
        {
            //Call Job On Second Day In Each Month And At 1 PM
            RecurringJob.AddOrUpdate(() => DoJob("Schedule", message), Cron.Monthly(day:2,hour:1));
            //Call Job Every Minute
            RecurringJob.AddOrUpdate(() => DoJob("Schedule", message), Cron.Monthly);
        }

        public void DoJob(string jobType, string message)
        {
            //Any Implementation Here
            Console.WriteLine($"[Hangfire] => [${jobType}] Job: Your Message {message} Sent");
        }
    }
}
