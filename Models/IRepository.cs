using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.Models
{
    public interface IRepository
    {
        public IQueryable<Entertainers> Entertainers { get; }
        void AddEntertainer(Entertainers e);
        void Save();
        void UpdateEntertainer(Entertainers e);
        void DeleteEntertainer(Entertainers e);
    }
}
