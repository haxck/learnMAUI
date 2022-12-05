using MauiApp1.Models;

namespace MauiApp1.Services
{
    public interface IPoetryStorage
    {
        Task InitializeAsync();
        Task AddAsync(Poetry poetry);

        Task<IEnumerable<Poetry>> ListAsync();
    }
}
