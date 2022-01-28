using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface IMedicineAsset
    {
        IEnumerable<MedicineAsset> GetAll();
        MedicineAsset GetById(int id);

        void Add(MedicineAsset newAsset);
        string GetAuthorOrDirector(int id);
        string GetDeweyIndex(int id);
        string GetType(int id);
        string GetTitle(int id);
        string GetIsbn(int id);

        MedicineBranch GetCurrentLocation(int id);
    }
}
