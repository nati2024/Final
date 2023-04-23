using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public class EFRepository: IRepository
    {
        private EntertainmentAgencyExampleContext context { get; set; }

        public EFRepository(EntertainmentAgencyExampleContext temp)
        {
            context = temp;
        }

        public IQueryable<Entertainers> Entertainers => context.Entertainers;

        public void AddEntertainer(Entertainers e)
        {
            context.Add(e);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void UpdateEntertainer(Entertainers e)
        {
            context.Update(e);
        }
        public void DeleteEntertainer(Entertainers e)
        {
            context.Entertainers.Remove(e);
        }
    }
}
