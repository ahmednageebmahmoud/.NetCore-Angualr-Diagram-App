## Hangfire with .NET 6


# # Install Dependencies
--------------------------------------------------------------------------------
Hangfire is available as a NuGet package. You can install it using the NuGet Package Console window:
```
	install-package Hangfire
```

# #Overview.
--------------------------------------------------------------------------------
Incredibly easy way to perform fire-and-forget, delayed and recurring jobs inside ASP.NET applications. CPU and I/O intensive, long-running and short-running jobs are supported. No Windows Service / Task Scheduler required. Backed by Redis, SQL Server, SQL Azure and MSMQ.

Hangfire provides a unified programming model to handle background tasks in a reliable way and run them on shared hosting, dedicated hosting or in cloud. You can start with a simple setup and grow computational power for background jobs with time for these scenarios:
 

# #Configration
--------------------------------------------------------------------------------
Add Hangfire
```
    builder.Services.AddHangfire(x => x.UseSqlServerStorage(nameOrConnectionString: builder.Configuration.GetConnectionString("PC_Windows")));
    builder.Services.AddHangfireServer();
```
Use Hangfire, With dashboard under path "/hangfire"
```
    app.UseHangfireDashboard(pathMatch: "/hangfire");
```

# #Jobs
--------------------------------------------------------------------------------

# Enqueue Job, Call Job Immediately, Call For Fisrt Itme Only
```
  public void SendMail(string message)
    {
      BackgroundJob.Enqueue(() => DoJob("Enqueue", message));
    }

  public void DoJob(string jobType, string message)
    {
      //Any Implementation Here
      Console.WriteLine($"[Hangfire] => [${jobType}] Job: Your Message {message} Sent");
    }
```

# Scheduled Job, Call Job After Some Seconds, Call For Fisrt Itme Only
```
    ...
    BackgroundJob.Schedule(() => DoJob("Schedule", message),TimeSpan.FromSeconds(seconds));
    ...
```

# Recurring Job , Call Job After Period Starting , Call For Every Period
```
    ...
    //Call Job On Second Day In Each Month And At 1 PM
    RecurringJob.AddOrUpdate(() => DoJob("Schedule", message), Cron.Monthly(day:2,hour:1));
    //Call Job Every Minute
    RecurringJob.AddOrUpdate(() => DoJob("Schedule", message), Cron.Monthly);    ...
```

RecurringJob
Pictures
--------------------------------------------------------------------------------
- Configrations
<br>![Hangfire Configrations](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_Configrations.png?raw=true)
- Database Tables
<br>![Hangfire DB Tables](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_DBTables.png?raw=true)
- Hangfire Dashboard
<br> ![Hangfire Dashboard](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_Dashboard.png?raw=true)
- Enqueue Job Example
<br> ![Hangfire Enqueue Job Example](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_EnqueueJobExample.png?raw=true)
- Enqueue Job Example In Dashboard
<br> ![Hangfire Enqueue Job Example Dashboard](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_EnqueueJobExampleDashboard.png?raw=true)
- Enqueue Job Example In Details Dashboard 
<br> ![Enqueue Job Example In Details Dashboard](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_EnqueueJobExampleDetails.png?raw=true)
- Scheduled Job Example Dashboard 
<br> ![Database](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_ScheduledJobExampleDashboard.png?raw=true)
- Scheduled Job Example In Details Dashboard 
<br> ![Database](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Hangfire_ScheduledJobExampleDetails.png?raw=true)
