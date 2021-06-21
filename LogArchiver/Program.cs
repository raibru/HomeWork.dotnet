using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace LogArchiver
{
  class Program
  {
    internal static IConfigurationRoot SerilogConfig = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("IF_SIM_CONFIG") ?? "Production"}.json", optional: true)
        .AddEnvironmentVariables()
        .Build();


    static void Main(string[] args)
    {
      //Archive.Write("Hallo World again");
      Log.Information("Starting application");

      var data1 = new ArchiveData()
      {
        Context = "TX Client",
        ContextNr = 1,
        RawData = "...",
        PduType = "TM",
        PduSubtype = "PKT",
        Apid = "4711",
        ServiceType = "47",
        ServiceSubtype = "11",
      };

      Log.Debug("Archiving 1st dataset");
      Archive.Write(data1);

      var data2 = new ArchiveData()
      {
        Context = "TX Client",
        ContextNr = 2,
        RawData = "...",
        PduType = "TM",
        PduSubtype = "PKT",
        Apid = "4711",
      };

      Log.Debug("Archiving 2nd dataset");
      Archive.Write(data2);

      Log.Information("Finish application");
      Console.WriteLine("...done");
    }
  }
}
