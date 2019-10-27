using System.Linq;
using System.Collections.Generic;
using VarorLibrary;

namespace Varor.Data
{
    public class InMemoryVarorData : IVarorData
    {
        //readonly List<VarorModel> varor;

        public static List<VarorModel> varor;
        public static List<VarorModel> varorHungry;
        public static List<VarorModel> citrus;



        public InMemoryVarorData()
        {
            varorHungry = new List<VarorModel>()
            {
                new VarorModel { Id = 1, Name = "Banan", Price = 12},
                new VarorModel { Id = 2, Name = "Grädde", Price = 22},
                new VarorModel { Id = 3, Name = "Jordnötter", Price = 31.50},
                new VarorModel { Id = 4, Name = "Kolasås", Price = 17},
                new VarorModel { Id = 5, Name = "Krusbär", Price = 13},
                new VarorModel { Id = 6, Name = "Ananas", Price = 19.90},
                new VarorModel { Id = 7, Name = "Revbensspjäll", Price = 17}

            };

            varor = new List<VarorModel>()
            {
            };

            citrus = new List<VarorModel>()
            {
                new VarorModel { Id = 1, Name = "Apelsin", Price = 9.90},
                new VarorModel { Id = 2, Name = "Lime", Price = 23},
                new VarorModel { Id = 3, Name = "Satsumas", Price = 12.90},
                new VarorModel { Id = 4, Name = "Klementin", Price = 59},
                new VarorModel { Id = 4, Name = "Mandarin", Price = 39.90},
                new VarorModel { Id = 4, Name = "Ugli", Price = 29.90},


            };
        }

        public VarorModel GetById(int id)
        {
            return varor.SingleOrDefault(r => r.Id == id);
        }

        public VarorModel Add(VarorModel newVara)
        {
            varor.Add(newVara);
            newVara.Id = varor.Max(r => r.Id) + 1;
            return newVara;
        }

        //Riktiga update
        public VarorModel Update(VarorModel updatedVara)
        {
            var vara = varor.SingleOrDefault(r => r.Id == updatedVara.Id);
            if (vara != null)
            {
                vara.Name = updatedVara.Name;
                vara.Price = updatedVara.Price;
            }
            return vara;
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<VarorModel> GetVaraByName(string name = null)
        {
            return from r in varor
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public IEnumerable<VarorModel> GetHungryVaraByName(string name = null)
        {
            return from r in varorHungry
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public IEnumerable<VarorModel> GetCitrusVaraByName(string name = null)
        {
            return from r in citrus
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public IEnumerable<VarorModel> GetVaraByName()
        {
            string name = "";
            return from r in varor
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public VarorModel Delete(int id)
        {
            var restaurant = varor.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                varor.Remove(restaurant);
            }
            return null;
        }

        public int GetCountofVaror()
        {
            return varor.Count();
        }
    }
}
