using AppTest.DataAccess;
using AppTest.DataAccess.Entities;
using AppTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTest.Services
{
    public class FolderService : IFolderServices
    {
        private readonly AppDBContext _context;

        public FolderService(AppDBContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public async Task<IEnumerable<Folder>> Get(int? Id)
        {
            if (Id.HasValue)
            {
                return await _context.Folder.Where( f => f.Id == Id)
                    .Include(f => f.Children)
                    .ToListAsync();
            }
            else
            {
                return await _context.Folder.Where(f => f.ParentId == null)
                    .Include(f => f.Children)
                    .ToListAsync();
            }
        }

        public async Task Import(IEnumerable<Folder> folders)
        {
            _context.AddRange(folders);
            await _context.SaveChangesAsync();
        }
    }
}
