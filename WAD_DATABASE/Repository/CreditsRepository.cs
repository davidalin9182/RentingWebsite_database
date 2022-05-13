using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;


namespace WAD_DATABASE.Repository
{
    public class CreditsRepository : ICreditsRepository
    {
        private readonly ApplicationDbContext _context;

        public CreditsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Credits credits)
        {
            _context.Add(credits);
            return Save();
        }

        public bool Delete(Credits credits)
        {
            _context.Remove(credits);
            return Save();
        }

        public async Task<IEnumerable<Credits>> GetAll()
        {
            return await _context.Credits.ToListAsync();
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

        public bool Update(Credits credits)
        {
            _context.Update(credits);
            return Save();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Credits.CountAsync();
        }

        //public Task<IEnumerable<Play>> GetSliceAsync(int offset, int size)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Play>> GetClubsByState(string state)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<Credits?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Credits?> GetByIdAsyncNoTracking(int id)
        {
            throw new NotImplementedException();
        }

        //public Task<IEnumerable<ReadMore>> GetClubByCity(string city)
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