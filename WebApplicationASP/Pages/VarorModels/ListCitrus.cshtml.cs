using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Varor.Data;
using VarorLibrary;

namespace WebApplicationASP.Pages.VarorModels
{
    public class ListCitrusModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IVarorData varorData;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public string Message { get; set; }
        public IEnumerable<VarorModel> Varor { get; set; }
        public List<VarorModel> cheapestList = new List<VarorModel>();
        public List<VarorModel> expensiveList = new List<VarorModel>();

        public void MostExpensive(IEnumerable<VarorModel> varor)
        {
            if (varor.Any())
            {
                var mostExpensiveVara = varor.Max(x => x.Price);

                for (int i = 0; i < varor.Count(); i++)
                {
                    if (varor.ElementAt(i).Price == mostExpensiveVara)
                    {
                        expensiveList.Add(varor.ElementAt(i));
                    }
                }
            }
        }

        public void Cheapest(IEnumerable<VarorModel> varor)
        {
            if (varor.Any())
            {
                var cheapestVara = varor.Min(x => x.Price);

                for (int i = 0; i < Varor.Count(); i++)
                {
                    if (varor.ElementAt(i).Price == cheapestVara)
                    {
                        cheapestList.Add(varor.ElementAt(i));
                    }
                }
            }
        }

        public ListCitrusModel(IConfiguration config,
                         IVarorData varorData)
        {
            this.config = config;
            this.varorData = varorData;
        }
        public void OnGet(string searchTerm)
        {
            Message = config["Message"];
            Varor = varorData.GetCitrusVaraByName(SearchTerm);
            MostExpensive(Varor);
            Cheapest(Varor);
        }
    }
}