using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;
namespace DeviceManagement_WebApp.Repositories.Impl
{
    public class RepoCategory:_ICategory
    {
        private readonly ConnectedOfficeContext _context;

        public RepoCategory(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> all(){
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> details(Guid? id){
            return await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
        }

        public async Task<Category> create(Category category){
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> edit(Guid id, Category category){
            _context.Update(category);
                await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> delete(Guid? id){
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> getCat(Guid? id){
            return await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}