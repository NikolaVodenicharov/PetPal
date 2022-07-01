using AccessoriesService.Domain.Models;

namespace AccessoriesService.Domain.Infrastructures
{
    public interface ICollarRepository
    {
        Task<ICollection<Collar>> AllAsync();
        Collar Create(Collar collar);
    }
}
