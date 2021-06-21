using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OData.Entities
{
  public class TimeRange
  {
    // Start of DateTime range
    [Required]
    public DateTime Start { get; set; }

    // End of DateTime range
    [Required]
    public DateTime End { get; set; }

  }
}
