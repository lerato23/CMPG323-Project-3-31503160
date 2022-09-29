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
    public class RepoDevice:_IDevice
    {
        private readonly ConnectedOfficeContext _context;

        public RepoDevice(ConnectedOfficeContext context)
        {
            _context = context;
        }

       public async Task<List<Device>> all(){
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return await connectedOfficeContext.ToListAsync();
       }

        public async Task<Device> details(Guid? id){
            return await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
        }

        public async Task<Device> create(Device device){
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> edit(Guid id, Device device){
            try
            {
                _context.Update(device);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return device;
        }

        public async Task<Device> delete(Guid? id){
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return device;
        }

        public async Task<Device> getDeviceToDelete(Guid? id){
            return await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
        }

        public async Task<Device> getDevice(Guid? id){
            return await _context.Device
                .FirstOrDefaultAsync(m => m.DeviceId == id);
        }

        private bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}