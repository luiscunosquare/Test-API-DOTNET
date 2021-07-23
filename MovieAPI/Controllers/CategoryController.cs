using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using MovieAPI.Models.Dtos;
using MovieAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoriesList = _ctRepo.GetCategories();

            var categoriesListDto = new List<CategoryDto>();

            foreach (var list in categoriesList)
            {
                categoriesListDto.Add(_mapper.Map<CategoryDto>(list));
            }
            return Ok(categoriesListDto);
        }

        [HttpGet("{categoryId:int}", Name ="GetCategory")]
        public IActionResult GetCategory([FromRoute] int categoryId)
        {
            var category = _ctRepo.GetCategory(categoryId);

            if(category == null)
            {
                return NotFound();
            }

            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if(categoryDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExistCategory(categoryDto.Name))
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(404, ModelState);
            }

            var category = _mapper.Map<Category>(categoryDto);

            if (!_ctRepo.CreateCategory(category))
            {
                ModelState.AddModelError("", "Something went wrong!");
                return StatusCode(404, ModelState);
            }

            return CreatedAtRoute("GetCategory", new { categoryId = category.Id}, category );
        }
    }
}
