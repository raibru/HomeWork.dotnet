using System;
using Serilog;
using Serilog.Context;
using Serilog.Sinks.File.Header;

/// <summary>
/// Example appsettings.json configuration for archiver:
/// {
///  "ArchiveLog": {
///    "Using": [
///      "Serilog.Sinks.File"
///    ],
///    "MinimumLevel": "Information",
///    "WriteTo": [
///      {
///        "Name": "File",
///        "Args": {
///          "path": "my-archive-.csv",
///          "restrictedToMinimumLevel": "Information",
///          "rollingInterval": "Day",
///          "Formatter": "ArchiveSandbox.CsvFormatter, ArchiveSandbox",
///          "hooks": "ArchiveSandbox.Archive::CsvHeaderWriter, ArchiveSandbox",
///          "outputTemplate": "{Timestamp:yyyy-MM-dd HH.mm.ss.fff}|{ContextNr}|{Context}|{PduType}|{PduSubtype}|{Apid}|{ServiceType}|{ServiceSubtype}|{RawData}{NewLine}"
///        }
///      }
///    ]
///  }
/// }
///
/// "outputTemplate" overwrite "Formatter" settings. Formatter use only comma CSV formar 
/// </summary>

namespace LogArchiver
{

  public static class Archive
  {
    private static Func<string> CsvHeaderFactory = () =>
        "Timestamp,Nr,Context,PduType,PduSubtype,APID,ServiceType,ServiceSubtype,Raw-Data";

    public static HeaderWriter CsvHeaderWriter = new HeaderWriter(CsvHeaderFactory);

    private static ILogger archiver = new LoggerConfiguration()
            .ReadFrom.Configuration(Program.SerilogConfig, "ArchiveLog")
            .Enrich.FromLogContext()
            // Set in appconfig.json
            //.WriteTo.File(new CsvFormatter(), "my-archive.csv", hooks: new HeaderWriter(CsvHeaderFactory))
            .CreateLogger();

    public static ILogger Archiver
    {
      get => archiver;
      internal set => archiver = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static void Write(string m, params object[] pvs)
    {
      Archiver.Information(m, pvs);
    }

    public static void Write(ArchiveData d)
    {
      _ = d ?? throw new ArgumentNullException(typeof(ArchiveData).Name);

      using (LogContext.PushProperty("Context", d.Context))
      using (LogContext.PushProperty("ContextNr", d.ContextNr))
      using (LogContext.PushProperty("RawData", d.RawData))
      using (LogContext.PushProperty("PduType", d.PduType))
      using (LogContext.PushProperty("PduSubtype", d.PduSubtype))
      using (LogContext.PushProperty("Apid", d.Apid))
      using (LogContext.PushProperty("ServiceType", d.ServiceType))
      using (LogContext.PushProperty("ServiceSubtype", d.ServiceSubtype))
      {
        //Archiver.Information("Archive {@data}", d);
        Archiver.Information("");
        //Archiver.Write(Serilog.Events.LogEventLevel.Information, "");
      }
    }
  }
}