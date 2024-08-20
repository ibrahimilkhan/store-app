using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        // GET: CategoryController
        public IEnumerable<Category> Index()
        {
            var models = _repositoryManager.CategoryRepository.FindAll(false);
            return models;
        }

    }
}