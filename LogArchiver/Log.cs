using System;
using Serilog;

/// <summary>
/// Example appsettings.json configuration for archiver:
/// {
///  "AppLog": {
///    "Using": [
///      "Serilog.Sinks.File"
///    ],
///    "MinimumLevel": "Debug",
///    "WriteTo": [
///      {
///        "Name": "File",
///        "Args": {
///          "path": "app-logging-.log",
///          "rollingInterval": "Day",
///          "restrictedToMinimumLevel": "Verbose"
///        }
///      }
///    ]
///  },
/// }
/// </summary>

namespace LogArchiver
{

  public static class Log
  {
    private static ILogger applogger = new LoggerConfiguration()
            .ReadFrom.Configuration(Program.SerilogConfig, "AppLog")
            .Enrich.FromLogContext()
            .CreateLogger();

    public static ILogger AppLogger
    {
      get => applogger;
      internal set => applogger = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static void Error(string m, params object[] pvs)
    {
      AppLogger.Error(m, pvs);
    }

    public static void Warning(string m, params object[] pvs)
    {
      AppLogger.Warning(m, pvs);
    }

    public static void Information(string m, params object[] pvs)
    {
      AppLogger.Information(m, pvs);
    }
    public static void Debug(string m, params object[] pvs)
    {
      AppLogger.Debug(m, pvs);
    }

    public static void Verbose(string m, params object[] pvs)
    {
      AppLogger.Verbose(m, pvs);
    }
  }
}