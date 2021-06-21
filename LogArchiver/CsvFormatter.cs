using System.IO;
using Serilog.Events;
using Serilog.Formatting;

namespace LogArchiver
{
  public class CsvFormatter : ITextFormatter
  {
    public void Format(LogEvent logEvent, TextWriter output)
    {
      output.Write(logEvent.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));
      output.Write(",");
      //output.Write(logEvent.Level);
      //output.Write(",");
      //output.Write(logEvent.MessageTemplate);
      //output.Write(",");
      output.Write(logEvent.Properties["ContextNr"]);
      output.Write(",");
      output.Write(logEvent.Properties["Context"]);
      output.Write(",");
      output.Write(logEvent.Properties["PduType"]);
      output.Write(",");
      output.Write(logEvent.Properties["PduSubtype"]);
      output.Write(",");
      output.Write(logEvent.Properties["Apid"]);
      output.Write(",");
      output.Write(logEvent.Properties["ServiceType"]);
      output.Write(",");
      output.Write(logEvent.Properties["ServiceSubtype"]);
      output.Write(",");
      output.Write(logEvent.Properties["RawData"]);
      output.WriteLine();

      //...
      //var iter = logEvent.Properties.GetEnumerator();
      //while (iter.MoveNext())
      //{
      //    output.Write(",");
      //    output.Write(iter.Current.Value.ToString());
      //}

      //output.Write("[" + logEvent.Timestamp + "] " + logEvent.Level + ": \"");
      //  output.Write(logEvent.MessageTemplate);
      //  output.WriteLine("\"");
      //  if (logEvent.Exception != null)
      //    output.WriteLine(logEvent.Exception);
      //  foreach (var property in logEvent.Properties)
      //  {
      //    output.Write(property.Key + " = ");
      //    property.Value.Render(output);
      //    output.WriteLine();
      //  }
      //  output.WriteLine();
    }
  }
}