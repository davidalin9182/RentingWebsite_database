
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;

namespace WAD_DATABASE.Interfaces
{
    public interface IBlogRepository
    {
        Task<IEnumerable<Blog>> GetAll();

        //Task<IEnumerable<Home>> GetSliceAsync(int offset, int size);

        //Task<IEnumerable<Home>> GetClubsByState(string state);

        //Task<IEnumerable<Home>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size);

        //Task<List<State>> GetAllStates();

        //Task<List<City>> GetAllCitiesByState(string state);

        Task<Blog?> GetByIdAsync(int id);

        Task<Blog?> GetByIdAsyncNoTracking(int id);

        //Task<IEnumerable<Home>> GetClubByCity(string city);

        Task<int> GetCountAsync();

        //Task<int> GetCountByCategoryAsync(ClubCategory category);

        bool Add(Blog blog);

        bool Update(Blog blog);

        bool Delete(Blog blog);

        bool Save();
    }
}