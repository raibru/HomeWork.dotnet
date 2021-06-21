using System;
using System.ComponentModel.DataAnnotations;

namespace OData.Entities
{
    public class Checksum
    {
        [Required]
        [MaxLength(200)]
        public string Algorithm { get; set; }

        [Required]
        [MaxLength(200)]
        public string Value { get; set; }

        public DateTime ChecksumDate { get; set; }
  }
}