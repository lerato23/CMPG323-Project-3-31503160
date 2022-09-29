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
    public interface _IDevice
    {
        public Task<List<Device>> all();
        public Task<Device> details(Guid? id); 
        public Task<Device> create(Device device);
        public Task<Device> edit(Guid id, Device device);
        public Task<Device> delete(Guid? id);
        public Task<Device> getDeviceToDelete(Guid? id);
        public Task<Device> getDevice(Guid? id);
    }
}