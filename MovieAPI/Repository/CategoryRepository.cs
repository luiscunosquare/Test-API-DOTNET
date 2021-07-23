using MovieAPI.Data;
using MovieAPI.Models;
using MovieAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateCategory(Category category)
        {
            _db.Category.Add(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _db.Category.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _db.Category.Remove(category);
            return Save();
        }

        public bool ExistCategory(string name)
        {
            bool value = _db.Category.Any(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool ExistCategory(int id)
        {
            return _db.Category.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _db.Category.ToList();
        }

        public Category GetCategory(int CategoryId)
        {
            return _db.Category.FirstOrDefault(c => c.Id == CategoryId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
