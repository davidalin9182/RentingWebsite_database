using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Announcement Announcement)
        {
            _context.Add(Announcement);
            return Save();
        }

        public bool Delete(Announcement Announcement)
        {
            _context.Remove(Announcement);
            return Save();
        }

        public async Task<IEnumerable<Announcement>> GetAll()
        {
            return await _context.Announcement.ToListAsync();
        }

        //public async Task<List<State>> GetAllStates()
        //{
        //    return await _context.States.ToListAsync();
        //}

        //public async Task<IEnumerable<Home>> GetSliceAsync(int offset, int size)
        //{
        //    return await _context.Home.Include(i => i.Address).Skip(offset).Take(size).ToListAsync();
        //}

        //public async Task<IEnumerable<Club>> GetClubsByCategoryAndSliceAsync(ClubCategory category, int offset, int size)
        //{
        //    return await _context.Clubs
        //        .Include(i => i.Address)
        //        .Where(c => c.ClubCategory == category)
        //        .Skip(offset)
        //        .Take(size)
        //        .ToListAsync();
        //}

        //public async Task<int> GetCountByCategoryAsync(ClubCategory category)
        //{
        //    return await _context.Clubs.CountAsync(c => c.ClubCategory == category);
        //}

        //public async Task<Home?> GetByIdAsync(int id)
        //{
        //    return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        //}

        //public async Task<Home?> GetByIdAsyncNoTracking(int id)
        //{
        //    return await _context.Home.Include(i => i.Address).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        //}

        //public async Task<IEnumerable<Home>> GetClubByCity(string city)
        //{
        //    return await _context.Home.Where(c => c.Address.City.Contains(city)).Distinct().ToListAsync();
        //}

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Announcement Announcement)
        {
            _context.Update(Announcement);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Announcement.CountAsync();
        }

        //public Task<IEnumerable<Play>> GetSliceAsync(int offset, int size)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Play>> GetClubsByState(string state)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Announcement> GetByIdAsync(int id)
        {
            return await _context.Announcement.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Announcement> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Announcement.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        //public Task<IEnumerable<Games>> GetClubByCity(string city)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<Home>> GetClubsByState(string state)
        //{
        //    return await _context.Home.Where(c => c.Address.State.Contains(state)).ToListAsync();
        //}

        //public async Task<List<City>> GetAllCitiesByState(string state)
        //{
        //    return await _context.Cities.Where(c => c.StateCode.Contains(state)).ToListAsync();
        //}
    }
}