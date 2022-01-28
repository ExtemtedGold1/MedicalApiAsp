using LibraryData;
using LibraryData.Models;
using System.Collections.Generic;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MedicinesServices
{
    public class MedicinAssetService : IMedicineAsset
    {
        private LibraryContext _context;
        public MedicinAssetService(LibraryContext context)
        {
            _context = context;
        }


        public void Add(MedicineAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<MedicineAsset> GetAll()
        {
            return _context.MedicineAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

        

        public MedicineAsset GetById(int id)
        {
            return GetAll()
                /*_context.MedicineAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)*/
                .FirstOrDefault(asset => asset.Id == id);
        }

        public MedicineBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
            //return _context.MedicineAssets.FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Medicines.Any(medicine => medicine.Id == id))
            {
                return _context.Medicines
                    .FirstOrDefault(medicine => medicine.Id == id).DeweyIndex;
            }

            //var isMedicine = _context.MedicineAssets.OfType<Medicine>().Where(a => a.Id == id).Any();

            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_context.Medicines.Any(a => a.Id == id))
            {
                return _context.Medicines
                    .FirstOrDefault(a => a.Id == id).NRMD;
            }

            else return "";
        }

        public string GetTitle(int id)
        {
            return _context.MedicineAssets
                .FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            
            var medicin = _context.MedicineAssets.OfType<Medicine>()
                .Where(b => b.Id == id);

            return medicin.Any() ? "Medicines" : "Videos";
        }
        public string GetAuthorOrDirector(int id)
        {
            var isMedicine = _context.MedicineAssets.OfType<Medicine>()
                .Where(asset => asset.Id == id).Any();
            var isVideo = _context.MedicineAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();

            return isMedicine ?
                _context.Medicines.FirstOrDefault(medicine => medicine.Id == id).Author :
                _context.Videos.FirstOrDefault(viedo => viedo.Id == id).Director ?? "Unknown";
        }

    }
}
