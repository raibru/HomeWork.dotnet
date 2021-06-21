using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Bogus;
using OData.Entities;

namespace ProductFaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Run Product Faker...");
            var fakeProducts = CreateProductFakes();

            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonStr = JsonSerializer.Serialize(fakeProducts, options);
            File.WriteAllText("product_fake.json", jsonStr);

            Console.WriteLine(jsonStr);
            Console.WriteLine("");
            Console.WriteLine("...done");

        }

        public static IList<Product> CreateProductFakes()
        {
            var platform = new[] { "S1A", "S1B", "S2A", "S1B" };
            var param1 = new[] { "IW", "EW" }; // Aufnahmeart
            var param2 = new[] { "OCN", "RAW" };
            var param3 = new[] { "SDH" };

            var productFaker = new Faker<Product>()
            .CustomInstantiator(f => new Product())
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            //.RuleFor(p => p.Name, f => "S1A_EW_OCN__2SDH_20171231T194900_20171231T194913_019951_021F8C_5392.zip")
            .RuleFor(p => p.Name, f =>
                f.PickRandom(platform)
                + "_"
                + f.PickRandom(param1)
                + "_"
                + f.PickRandom(param2)
                + "__"
                + f.Random.Number(0, 9)
                + f.PickRandom(param3)
                + "_"
                + f.Date.Past().ToString("yyyyMMddThhmmss")
                + "_"
                + f.Date.Past().ToString("yyyyMMddThhmmss")
                + "_"
                + "019951_"
                + f.Random.Hexadecimal(6, "").ToUpper()
                + "_"
                + f.Random.Number(1000, 9999)
                + ".zip")
            .RuleFor(p => p.PublicationDate, f => f.Date.Past())
            .RuleFor(p => p.EvictionDate, f => f.Date.Past())
            .RuleFor(p => p.ContentType, f => "application/octet-stream")
            .RuleFor(p => p.ProductionType, f => ProductionType.systematic_production)
            .RuleFor(p => p.ContentLength, f => 4063869137)
            .RuleFor(p => p.ContentLength, f => f.Random.Long(1000000000, 90000000000))
            .RuleFor(p => p.ContentDate, f => 
            {
                var contentDate = new TimeRange();
                contentDate.Start = f.Date.Past();
                contentDate.End = f.Date.Past();
                return contentDate;
            })
            .RuleFor(p => p.Checksums, f =>
            {
              var checksum = new Checksum();
              checksum.Algorithm = "MD5";
              checksum.Value = f.Random.Hexadecimal(32, "").ToUpper(); //"E8A303BF3D85200514F727DB60E7DB65";
              checksum.ChecksumDate = f.Date.Past();
              var checksums = new List<Checksum>();
              checksums.Add(checksum);
              return checksums;
            });


      var products = productFaker.Generate(2000);
            return products;
        }
    }
}
