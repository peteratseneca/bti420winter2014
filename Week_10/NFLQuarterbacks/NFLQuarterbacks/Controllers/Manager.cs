using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using NFLQuarterbacks.Models;
using AutoMapper;

namespace NFLQuarterbacks.Controllers
{
    public class Manager
    {
        private ApplicationDbContext ds = new ApplicationDbContext();

        public IEnumerable<QuarterbackBase> GetAllQB()
        {
            var fetchedObjects = ds.Quarterbacks.OrderBy(o => o.Rank);

            return Mapper.Map<IEnumerable<QuarterbackBase>>(fetchedObjects);
        }

        public QuarterbackBase GetQBById(int id)
        {
            var fetchedObject = ds.Quarterbacks.Find(id);

            if (fetchedObject==null)
            {
                return null;
            }
            else
            {
                return Mapper.Map<QuarterbackBase>(fetchedObject);
            }
        }

    }
}
