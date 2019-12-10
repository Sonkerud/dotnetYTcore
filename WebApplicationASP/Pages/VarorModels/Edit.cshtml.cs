using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Varor.Data;
using VarorLibrary;

namespace WebApplicationASP.Pages.VarorModels
{
    public class EditModel : PageModel
    {
        private readonly IVarorData varorData;

        [BindProperty]
        public VarorModel VarorModel { get; set; }
        //public IEnumerable<VarorModel> Varor;

        public EditModel(IVarorData varorData)
        {
            this.varorData = varorData;
        }

        public IActionResult OnGet(int? varorId)
        {
            if (varorId.HasValue)
            {
                VarorModel = varorData.GetById(varorId.Value);
            }
            else
            {
                VarorModel = new VarorModel();
            }
            if (VarorModel == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        //For InMemoryData
        public IActionResult OnPost()
        {
            var varor = InMemoryVarorData.varor;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (VarorModel.Id > 0)
            {
                varorData.Update(VarorModel);
            }
            else
            {
                var found = varor.Any(x => x.Name.ToLower() == VarorModel.Name.ToLower());

                for (int i = 0; i < varor.Count; i++)
                {
                    if (varor[i].Name.ToLower() == VarorModel.Name.ToLower())
                    {
                        InMemoryVarorData.varor[i].Price = VarorModel.Price;
                    }
                }

                //If if doesn't exist: Add new Vara.
                if (!found)
                {
                    VarorModel.Name = VarorModel.Name.First().ToString().ToUpper() + VarorModel.Name.Substring(1).ToLower();
                    varorData.Add(VarorModel);
                }
                //varorData.Add(VarorModel);
            }
            //varorData.Commit();
            return RedirectToPage("./List");
        }
        ////For SQL
        //public IActionResult OnPost()
        //{
        //    var varor = InMemoryVarorData.varor;

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    if (VarorModel.Id > 0)
        //    {
        //        varorData.Update(VarorModel);
        //    }
        //    else
        //    {
        //            varorData.Add(VarorModel);
        //    }
        //    varorData.Commit();
        //    return RedirectToPage("./List");
        //}


    }
}