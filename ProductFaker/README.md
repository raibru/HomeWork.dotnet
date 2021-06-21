Product Faker
=============

Product Faker gernerates product fake data for a Demonstrator. This is only a simple hack which produce 2000 records and save it in json formated file named __product_fake.json__.

The program use a some kind of a OData Product entity model - this is only a quick and dirty implementation.

## Build and run

To build and run the program the the following devenvironment is needed

* Dotnet Core 3.1 CLI
* Bogus (31.0.2)

The program use __Bogus__ to create a OData.Entity.Product entity object and set the properties with some kind of data values. Howto use it follow the link

(Bogus for .NET: C#, F#, and VB.NET on GitHub)[https://github.com/bchavez/Bogus]

In a console run

```console
$ dotnet restore
$ dotnet build
$ dotnet run
```

After finish execution successful you will find the file __product_fake.json__ inside ProductFaker root directory.
This file can be used to initial load data at startup inside demonstartor (in development state)
