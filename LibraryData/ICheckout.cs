using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        Checkout GetById(int checkoutId);
        void Add(Checkout newCheckout);
        void CheckOutItem(int assetId, int MedicineCardId);
        void CheckIInItem(int assetId, int MedicineCardId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);

        void PlaceHold(int assetId, int MedicineCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int assetId);
        void MarkFound(int assetId);
        Checkout GetLatestCheckout(int assetId);
    }
}
