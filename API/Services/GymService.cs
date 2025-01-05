using API.Interfaces;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class GymService : IGymService
{
    private readonly DataContext _dataContext;

    public GymService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Gym?> GetGymByIdAsync(Guid id)
    {
        return await _dataContext.Gyms.FindAsync(id);
    }

    public async Task<Gym?> GetGymBySlugAsync(string slug)
    {
        return await _dataContext.Gyms.FirstOrDefaultAsync(x => x.Slug == slug);
    }

    public async Task<List<Gym>> GetGymsAsync()
    {
        return await _dataContext.Gyms.ToListAsync();
    }

    public async Task<bool> CreateGymAsync(Gym gym)
    {
        await _dataContext.Gyms.AddAsync(gym);
        return await _dataContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateGymAsync(Gym gym)
    {
        _dataContext.Gyms.Update(gym);
        return await _dataContext.SaveChangesAsync() > 0;
    }
}
