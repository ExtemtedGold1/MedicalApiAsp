/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;*/
using Microsoft.AspNetCore.Mvc;
using LibraryData;
using MedicalApi.Models.Medicine;
using System.Linq;

namespace MedicalApi.Controllers
{
    public class MedicineController : Controller
    {
        private IMedicineAsset _assets;

        public MedicineController(IMedicineAsset asset)
        {
            _assets = asset;
        }

        public IActionResult Index()
        {
            var assetModels = _assets.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDirector = _assets.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _assets.GetDeweyIndex(result.Id),
                    Title = result.Title,
                    Type = _assets.GetType(result.Id)
                });

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var asset = _assets.GetById(id);

            var model = new AssetDetailModel
            {
                AssedId = id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assets.GetAuthorOrDirector(id),
                //CurrentLocation = _assets.GetCurrentLocation(id).Name,
                DeweyCallNumber = _assets.GetDeweyIndex(id),
                NRMD = _assets.GetIsbn(id)
            };

            return View(model);
        }
    }
}
