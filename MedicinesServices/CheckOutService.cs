using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicinesServices
{
    public class CheckOutService : ICheckout
    {
        private LibraryContext _context;

        public CheckOutService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Checkout newCheckout)
        {
            _context.Add(newCheckout);
            _context.SaveChanges();
        }
        public IEnumerable<Checkout> GetAll()
        {
            return _context.Checkouts;
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll()
                .FirstOrDefault(checkout => checkout.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int id)
        {
            return _context.CheckoutHistories
                .Include(h=>h.MedicineAsset)
                .Include(h=>h.MedicineCard)
                .Where(h => h.MedicineAsset.Id == id);
        }


        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return _context.Holds
                .Include(h => h.MedicineAsset)
                .Where(h => h.MedicineAsset.Id == id);
        }
        public Checkout GetLatestCheckout(int assetId)
        {
            return _context.Checkouts
                .Where(c => c.MedicineAsset.Id == assetId)
                .OrderByDescending(c => c.Since)
                .FirstOrDefault();
        }

        public void MarkFound(int assetId)
        {
            var now = DateTime.Now;

            var item = _context.MedicineAssets
               .FirstOrDefault(a => a.Id == assetId);

            _context.Update(item);
            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == "Available");

            RemoveExistingCheckouts(assetId);

            CloseExistingCheckoutHistory(assetId, now);

        
            _context.SaveChanges();
        }

        private void CloseExistingCheckoutHistory(int assetId, DateTime now)
        {

            //zamywaknie isniejacych checkout historii
            var history = _context.CheckoutHistories
                .FirstOrDefault(h => h.MedicineAsset.Id == assetId
                && h.CheckedIn == null);

            if (history != null)
            {
                _context.Update(history);
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckouts(int assetId)
        {
            //Usuwanie wszyztkich isniejących checkout na item
            var checkout = _context.Checkouts.FirstOrDefault(co => co.MedicineAsset.Id == assetId);

            if (checkout != null)
            {
                _context.Remove(checkout);
            }
        }

        public void MarkLost(int assetId)
        {
            var item = _context.MedicineAssets
                .FirstOrDefault(a => a.Id == assetId);

            _context.Update(item);
            item.Status = _context.Statuses
                .FirstOrDefault(status => status.Name == "Lost");
        }

        public void PlaceHold(int assetId, int MedicineCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckIInItem(int assetId, int MedicineCardId)
        {
            throw new NotImplementedException();
        }

        public void CheckOutItem(int assetId, int MedicineCardId)
        {
            throw new NotImplementedException();
        }
        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }
    }
}
