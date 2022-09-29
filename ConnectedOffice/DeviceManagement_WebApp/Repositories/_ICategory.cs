using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repositories
{
    public interface _ICategory
    {
        public  Task<List<Category>> all();
        public  Task<Category> details(Guid? id); 
        public  Task<Category> create(Category category);
        public  Task<Category> edit(Guid id, Category category);
        public  Task<Category> delete(Guid? id);
        public  Task<Category> getCat(Guid? id);
    }
}