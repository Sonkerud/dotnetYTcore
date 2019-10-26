using VarorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Varor.Data
{
    public interface IVarorData
    {
        IEnumerable<VarorModel> GetVaraByName(string name);
        IEnumerable<VarorModel> GetVaraByName();
        IEnumerable<VarorModel> GetHungryVaraByName(string name);

        VarorModel GetById(int id);
        VarorModel Update(VarorModel updatedVara);
        VarorModel Add(VarorModel newVara);
        int Commit();
        VarorModel Delete(int id);
        int GetCountofVaror();
    }

}
