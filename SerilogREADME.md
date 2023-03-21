## Serilog with .NET 6


# # Install Dependencies
```
	Serilog
    Serilog.Sinks.File //To Write Serilog events to text files in plain or JSON format
    Serilog.Sinks.Console //To write log events to the console/terminal.
    Serilog.Sinks.MSSqlServer //To write log events to Microsoft SQL Server
    Serilog.Enrichers.Environment //Enrich Serilog log events with properties from System.Environment, That's mean if you want to read value abount current environment and write with log details
    Serilog.Enrichers.Thread //Enrich Serilog events with properties from the current thread, That's mean if you want to read value abount current thread and write with log
    Serilog.Enrichers.Process //Enrich Serilog events with properties from the current process, That's mean if you want to read value abount current process and write with log
```

# #level of logs.
====================================================================================================
1-Fatal: Is used for reporting errors that force the application to shut down.
2- Error: Is only used for logging serious problems that occurred while executing some code in your program.
3- Warning: Is used when you have to report a non-critical event. This could also be a warning about unusual behavior in the application.
4- Information: The information level is used when you got informative messages from events in a program. This could be logs about step completion in a program or when a user is signed in. Typically a system administrator loves this kind of log level - especially when they are delivered to a Syslog Server (Yeah I have been in that chair too... I know what I am talking about 😅).
5- Debug: Debug messages are used to extend the information level when processing data in your application.
6- Verbose: It's in the name. The verbose level is the noisiest level. I only activate this kind of log when I have to troubleshoot an application.


# #Create Map
```
    
```

 