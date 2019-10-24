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
    public class DeleteModel : PageModel
    {
        private readonly IVarorData varorData;
        public VarorModel Varor { get; set; }

        public DeleteModel(IVarorData varorData)
        {
            this.varorData = varorData;
        }

        public IActionResult OnGet(int varorId)
        {
            Varor = varorData.GetById(varorId);
            if (Varor == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int varorId)
        {
            var vara = varorData.Delete(varorId);
            varorData.Commit();

            //if (vara == null)
            //{
            //    return RedirectToPage("./NotFound");
            //}
            //TempData["Message"] = $"{vara.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}