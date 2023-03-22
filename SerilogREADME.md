## Serilog with .NET 6


# # Install Dependencies
```
	Serilog
    Serilog.AspNetCore
    Serilog.Sinks.File //To Write Serilog events to text files in plain or JSON format
    Serilog.Sinks.Console //To write log events to the console/terminal.
    Serilog.Sinks.MSSqlServer //To write log events to Microsoft SQL Server
    Serilog.Enrichers.Environment //Enrich Serilog log events with properties from System.Environment, That's mean if you want to read value abount current environment and write with log details
    Serilog.Enrichers.Thread //Enrich Serilog events with properties from the current thread, That's mean if you want to read value abount current thread and write with log
    Serilog.Enrichers.Process //Enrich Serilog events with properties from the current process, That's mean if you want to read value abount current process and write with log
```

# #level of logs.
--------------------------------------------------------------------------------
1-Fatal: Is used for reporting errors that force the application to shut down.
2- Error: Is only used for logging serious problems that occurred while executing some code in your program.
3- Warning: Is used when you have to report a non-critical event. This could also be a warning about unusual behavior in the application.
4- Information: The information level is used when you got informative messages from events in a program. This could be logs about step completion in a program or when a user is signed in. Typically a system administrator loves this kind of log level - especially when they are delivered to a Syslog Server (Yeah I have been in that chair too... I know what I am talking about 😅).
5- Debug: Debug messages are used to extend the information level when processing data in your application.
6- Verbose: It's in the name. The verbose level is the noisiest level. I only activate this kind of log when I have to troubleshoot an application.


# #Configration
--------------------------------------------------------------------------------
You can manage Serilog configuration from appsetting.json or form code, but I prefer to add Console and MSSqlServer to appsetting.json and manage File configuration from code.

```
    "Serilog": {
    "Using": [ ],
    "MinimumLevel": {
      "Default": "Information",//Default Minimum Level For Any Name Space Not Overridden In The Override Section
      "Override": {
        "Microsoft": "Warning", // Add Warning As The Minimum Level For And Log Run In Nampe Space Related With Microsoft
        "System": "Warning",
        "{Any Name Space}":"{Any MinimumLevel}" //Just For Example
      }
    },
    "WriteTo": [
      {
        "Name": "Console", // Write to console, but make sure you installed Serilog.Sinks.Console Libarury
        "Args": {
          "outputTemplate": "[{Timestamp:HH:mm:ss} => {SourceContext} => [{Level}] => {Message}{NewLine}{Exception}", // Log Tempalte 
          "restrictedToMinimumLevel": "Warning" // MinimumLevel For Any Message Can Log in Console
        }
      },
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "Data Source=DESKTOP-PCI8IKG;Initial Catalog=AhmedNMFinalTask;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
          "sinkOptionsSection": {
            "tableName": "logs",
            "schemaName": "logging",
            "autoCreateSqlTable": true
          },
          "restrictedToMinimumLevel": "Warning"
        }
      }
    ],
    "Enrich": [ //More information can read from Enrich
      "FromLogContext",
      "WithMachineName",
      "WithThreadId",
      "WithProcessId"
    ],
    "Properties": {
      "Application": "Draw.Serilog" // App name it's important to set if you save logs for more apps in one file or one table
    }
  }
```

# Code Confirgation And Build
```
try
{
    //To Apply appsettings.json configrations you need to ConfigurationBuilder to easy do that
    var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json") // Add main appsettings.json
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true) // if you have setting file for every environment
            .Build();

    //Now Create Logger And Pass Configration And Set File Configation
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        //I Prefer You Add the Configuration File Here Because It's Available To Add Args In File Path Like Date Or Else
        //Write As Text
        .WriteTo.File(
        //Log Path
        path: "./logs/log-text-",
        //Every Day Log In A New File
        rollingInterval: RollingInterval.Day,
         //Log Text Formatter
         outputTemplate: "[{Timestamp:HH:mm:ss} => {SourceContext} => [{Level}] => {Message}{NewLine}{Exception}"
        )
      //Write Also As Json
      .WriteTo.File(
        //Log Path
        path: "./logs/log-json-",
        //Every Day Log In A New File
        rollingInterval: RollingInterval.Day,
        //Or Log As Josn Format
        formatter: new Serilog.Formatting.Json.JsonFormatter(",")
        )
        .CreateLogger();

    //Use Serilog
    builder.Host.UseSerilog();
}
catch (Exception ex)
{
    Log.Fatal(ex, "I Can't Run The Project");
}
finally
{
    Log.CloseAndFlush();
}
```

Pictures
--------------------------------------------------------------------------------
- Console
<br>![Console](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_console.png?raw=true)
- File Text Location
<br>![File Text Location](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_File_Text.png?raw=true)
- File Text Content
<br> ![File Text Content](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_File_Text2.png?raw=true)
- File Json Complect Formatter
<br> ![File Json](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_File_Json.png?raw=true)
- File Json Sink Formatter
<br> ![File Json Formatter](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_File_Json2.png?raw=true)
- Database
<br> ![Database](https://github.com/ahmednageebmahmoud/.NetCore-Angualr-Diagram-App/blob/master/Documentation/Serilog_DataBase.png?raw=true)
