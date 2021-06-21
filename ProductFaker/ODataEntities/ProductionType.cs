using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OData.Entities
{
  public enum ProductionType
  {
    [Description("Systematic Production")]
    systematic_production = 0,

    [Description("On-Demand default")]
    on_demand_default = 1,

    [Description("On-Demand non-default")]
    on_demand_non_default = 2,
  }
}