using Client.Models;
using Client.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Client.Repos
{
    public class MaterialRepository:IMaterialRepository
    {
        private readonly ClientContext _ctx;
        public MaterialRepository(ClientContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Material>> GetMaterials()
        {
            return await _ctx.Materials.ToListAsync();
        }
    }
}
