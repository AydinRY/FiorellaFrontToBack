using System.Linq;
using HomeWork.DataLayerAccess;
using HomeWork.Models;
using HomeWork.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var sliderImages = _dbContext.SliderImages.ToList();
            var slider = _dbContext.Sliders.SingleOrDefault();
            var categories = _dbContext.Categories.ToList();
            var products = _dbContext.Products.Include(x => x.Category).ToList();
            var about = _dbContext.Abouts.SingleOrDefault();
            var experts = _dbContext.Experts.SingleOrDefault();
            var expertImages = _dbContext.ExpertImages.ToList();
            var subscribe = _dbContext.Subscribes.SingleOrDefault();
            return View(new HomeViewModel
            {
                SliderImages = sliderImages,
                Slider = slider,
                Categories = categories,
                Products = products,
                About = about,
                Experts = experts,
                ExpertImagesList = expertImages,
                Subscribes = subscribe,
            });
        }
    }
}