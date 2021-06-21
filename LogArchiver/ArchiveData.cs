namespace LogArchiver
{
  public class ArchiveData
  {
    public string Context { get; set; }

    public int ContextNr { get; set; }

    public string PduType { get; set; }

    public string PduSubtype { get; set; }

    public string Apid { get; set; }

    public string ServiceType { get; set; }

    public string ServiceSubtype { get; set; }

    public string RawData { get; set; }
  }
}