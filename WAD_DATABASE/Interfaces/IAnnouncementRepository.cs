
using WAD_DATABASE.Models;
using WAD_DATABASE.Data;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAll();

        //Task<IEnumerable<Home>> GetSliceAsync(int offset, int size);

        //Task<IEnumerable<Home>> GetClubsByState(string state);

        //Task<IEnumerable<Home>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size);

        //Task<List<State>> GetAllStates();

        //Task<List<City>> GetAllCitiesByState(string state);

        Task<Announcement?> GetByIdAsync(int id);

        Task<Announcement?> GetByIdAsyncNoTracking(int id);

        //Task<IEnumerable<Home>> GetClubByCity(string city);

        Task<int> GetCountAsync();

        //Task<int> GetCountByCategoryAsync(ClubCategory category);

        bool Add(Announcement Announcement);

        bool Update(Announcement Announcement);

        bool Delete(Announcement Announcement);

        bool Save();
    }
}