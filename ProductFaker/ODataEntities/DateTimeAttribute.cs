using System;

namespace OData.Entities
{
  public class DateTimeAttribute : Attribute
  {
    // The value of the attribute
    public DateTime Value { get; set; }

  }
}
