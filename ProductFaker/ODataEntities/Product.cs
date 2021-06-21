using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Microsoft.Spatial;

namespace OData.Entities
{
  public class Product
  {
    // It is a universally unique identifier (UUID). The Id is a local identifier for the product instance within the PRIP
    [Key]
    //[Required]
    public Guid Id { get; set; }

    // Data file name
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    // The Mime type of the product
    [Required]
    [MaxLength(50)]
    public string ContentType { get; set; }

    // Actual size in bytes (B) of the downloadable file
    [Required]
    public long ContentLength { get; set; }

    // Publication date and time of the data file (time at which the file becomes visible to the user). Time is in UTC in the format YYYY-MM-DDThh:mm:ss.sssZ
    // icd DT: DateTimeOffset
    [Required]
    //[]
    public DateTime PublicationDate { get; set; }

    // Date when the data file will be removed from the rolling archive. Time is in UTC in the format YYYY-MM-DDThh:mm:ss.sssZ
    // The EvictionDate is optional but should be provided if a rolling policy is in place.
    // icd DT: DateTimeOffset
    public DateTime EvictionDate { get; set; }

    // Represents the known checksums for the product’s physical date, providing a unique value for supporting download integrity check. At least MD5 checksum, including ChecksumDate, is mandatory.
    public IList<Checksum> Checksums { get; set; } = new List<Checksum>();

    // The sensing range period. Start and end times are in UTC in the format YYYY-MM-DDThh:mm:ss.sssZ
    // icd DT: TimeRange of start-end
    // complex DT
    public TimeRange ContentDate { get; set; }

    // ProductionType values: - systematic_production - on-demand:default - on-demand:non-default
    [Required]
    public ProductionType ProductionType { get; set; }

    // Footprint of the product
    // icd DT: Geography type (SRID, Polygon)
    // complex DT
    //public Geography Footprint { get; set; } = null;
    public string Footprint { get; set; } = null;

    // Datatype Attributes
    public IList<Attribute> Attributes {get; set; } = new List<Attribute>();
    public IList<StringAttribute> StringAttributes {get; set; } = new List<StringAttribute>();
    public IList<IntegerAttribute> IntegerAttributes {get; set; } = new List<IntegerAttribute>();
    public IList<IntegerAttribute> DoubleAttributes {get; set; } = new List<IntegerAttribute>();
    public IList<IntegerAttribute> DateTimeAttributes {get; set; } = new List<IntegerAttribute>();
  }
}
