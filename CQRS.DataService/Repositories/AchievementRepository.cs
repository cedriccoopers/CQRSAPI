using CQRS.DataService.Data;
using CQRS.DataService.Repositories.Interfaces;
using CQRS.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataService.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(AppDbContext context, ILogger logger) : base(context, logger) {  }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Achievement Repository GetDriverAchievementAsync");
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.CreateDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Achievement Repository All");
                throw;
            }
        }


        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Achievement Repository Delete");
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                //get my entity
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

                if (result == null)
                    return false;

                result.FastestLap = achievement.FastestLap;
                result.PolePosition = achievement.PolePosition;
                result.RaceWins = achievement.RaceWins;
                result.WorldChampionship = achievement.WorldChampionship;
                result.UpdatedDate = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Achievement Repository Update");
                throw;
            }
        }
    }
}
