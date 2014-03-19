using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using System.Data.Entity;
using CsvHelper;
using System.IO;
using AutoMapper;
using NFLQuarterbacks.Controllers;

namespace NFLQuarterbacks.Models
{
    public class StoreInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            if (context.Quarterbacks.Count() == 0)
            {
                // File system path to the data file
                string path = HttpContext.Current.Server.MapPath("~/App_Data/NFLQuarterbacks.csv");

                // Create a stream reader object, to read the file stream
                StreamReader sr = File.OpenText(path);

                // Create the CsvHelper object
                var csv = new CsvReader(sr);

                // Go through the data file
                while (csv.Read())
                {
                    // Create an object from the line of text
                    QuarterbackAdd newQB = csv.GetRecord<QuarterbackAdd>();
                    // Add it to the data store
                    context.Quarterbacks.Add(Mapper.Map<Quarterback>(newQB));
                }
                context.SaveChanges();

                // Clean up
                sr.Close();
                sr = null;
            }
        }
    }

}
