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
    public class RepoZone:_IZone
    {
        private readonly ConnectedOfficeContext _context;

        public RepoZone(ConnectedOfficeContext context)
        {
            _context = context;
        }

        public async Task<List<Zone>> all(){
            return await _context.Zone.ToListAsync();
        }

        public async Task<Zone> details(Guid? id){
            return await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
        }

        public async Task<Zone> create(Zone zone){
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        public async Task<Zone> edit(Guid id, Zone zone){
            try
            {
                _context.Update(zone);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(zone.ZoneId))
                {
                    throw;
                }
                
            }
            return zone;
        }

        public async Task<Zone> delete(Guid? id){
            var zone =await _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            return zone;
        }

        public async Task<Zone> deleteConfirm(Guid id){
            var zone = await _context.Zone.FindAsync(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

        private bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

        public async Task<Zone> getZone(Guid? id){
            return await _context.Zone.FindAsync(id);
        }
    }
}