﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category()
            {
                CategoryName = createCategoryDto.CategoryName,
                CategoryStatus = true,
            });
            return Ok($"Category Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return Ok("Kategori Silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryId= updateCategoryDto.CategoryId,
                CategoryName = updateCategoryDto.CategoryName,
                CategoryStatus = updateCategoryDto.CategoryStatus,
            });
            return Ok("Category Eklendi");
        }
    }
}
