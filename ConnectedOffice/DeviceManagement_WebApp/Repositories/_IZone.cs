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
    public interface _IZone
    {
        public Task<List<Zone>> all();
        public  Task<Zone> details(Guid? id); 
        public  Task<Zone> create(Zone zone);
        public  Task<Zone> edit(Guid id, Zone zone);
        public  Task<Zone> delete(Guid? id);
        public Task<Zone> getZone(Guid? id);
        public Task<Zone> deleteConfirm(Guid id);
    }
}