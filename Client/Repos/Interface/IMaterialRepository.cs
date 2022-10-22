using Client.Models;

namespace Client.Repos.Interface
{
    public interface IMaterialRepository
    {
        public Task<List<Material>> GetMaterials();
    }
}
