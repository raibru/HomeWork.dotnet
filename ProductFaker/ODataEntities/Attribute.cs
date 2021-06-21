using System.ComponentModel.DataAnnotations;

namespace OData.Entities
{
  public abstract class Attribute
  {
    [Key]
    public int Id { get; set; }

    // String name of the attribute
    public string Name { get; set; }

    // The type of attribute. This corresponds to OData v4 primitive types
    public string ValueType { get; set; }

  }
}
