using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MediaItem_Example.Models
{
    //public class StoreInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    public class StoreInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            Vehicle v = new Vehicle();
            v.Model = "Camry";
            v.Trim = "LE";
            v.Year = 2013;
            v.MSRP = 23700;
            v.Photo = this.GetImage("Camry_LE.png");
            v.PhotoType = "image/png";
            context.Vehicles.Add(v);

            context.SaveChanges();

        }

        protected byte[] GetImage(string i)
        {
            string imageFile = string.Format("/App_Data/images/{0}", i);
            return System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath(imageFile));
        }

    }
}