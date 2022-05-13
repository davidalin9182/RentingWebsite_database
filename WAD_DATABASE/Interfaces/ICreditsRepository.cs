
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;

namespace WAD_DATABASE.Interfaces
{
    public interface ICreditsRepository
    {
        Task<IEnumerable<Credits>> GetAll();

        //Task<IEnumerable<Home>> GetSliceAsync(int offset, int size);

        //Task<IEnumerable<Home>> GetClubsByState(string state);

        //Task<IEnumerable<Home>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size);

        //Task<List<State>> GetAllStates();

        //Task<List<City>> GetAllCitiesByState(string state);

        Task<Credits?> GetByIdAsync(int id);

        Task<Credits?> GetByIdAsyncNoTracking(int id);

        //Task<IEnumerable<Home>> GetClubByCity(string city);

        Task<int> GetCountAsync();

        //Task<int> GetCountByCategoryAsync(ClubCategory category);

        bool Add(Credits Credits);

        bool Update(Credits Credits);

        bool Delete(Credits Credits);

        bool Save();
    }
}