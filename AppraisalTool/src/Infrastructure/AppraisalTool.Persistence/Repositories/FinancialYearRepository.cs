using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Command.UpdateFinancialYearCommand;
using AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Persistence.Repositories
{
    public class FinancialYearRepository : BaseRepository<FinancialYear>, IFinacialYearRepository, IFinancialYearRepository
    {
        public FinancialYearRepository(ApplicationDbContext dbContext, ILogger<FinancialYear> logger) : base(dbContext, logger)
        {
        }

        public async Task<CreateFinancialYearDto> AddFY(FinancialYear Fy)
        {
            var FyResponse = await _dbContext.FinancialYear.Where(x => x.Id == Fy.Id).FirstOrDefaultAsync();
            CreateFinancialYearDto response = new CreateFinancialYearDto();
            if (FyResponse != null)
            {
                response.Message = "Failed to add Financial Year";
                response.Succeeded = false;
                return response;
            }
            var result = await _dbContext.FinancialYear.AddAsync(Fy);

            await _dbContext.SaveChangesAsync();
            response.Id = Fy.Id;
            response.Message = "FY Added Successfully";
            response.Succeeded = true;
            return response;
            
        }

        public async Task<FinancialYear> GetFinancialYearById(int id)
        {
            var Fy = await _dbContext.FinancialYear.Where(x => x.Id == id).FirstOrDefaultAsync();
            return Fy;
        }

        public async Task<IEnumerable<FinancialYear>> ListFinancialYear()
        {
            return await ListAllAsync();
        }

        public async Task<UpdateFinancialYearCommandDto> UpdateFinancialYearAsync(int id, UpdateFinanacialYearCommand request)
        {
            UpdateFinancialYearCommandDto Response = new UpdateFinancialYearCommandDto();
            var FytoUpdate =await _dbContext.FinancialYear.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (FytoUpdate != null)
            {
                FytoUpdate.StartYear=request.StartYear;
                FytoUpdate.EndYear = request.EndYear;
                //FytoUpdate.StartDate = request.StartDate;
                //FytoUpdate.EndDate = request.EndDate;
                await _dbContext.SaveChangesAsync();
                Response.Message = "Update Successfully";
                Response.Succeeded = true;
                Response.Id = FytoUpdate.Id;
                return Response;
            }
            else
            {
                Response.Succeeded = false;
                return Response;
            }
        }
        public async Task<RemoveFinancialYearCommandDto> RemoveFinancialYear(int id)
        {
            var fyresult = await _dbContext.FinancialYear.Where(u => u.Id == id).FirstOrDefaultAsync();

            RemoveFinancialYearCommandDto response = new RemoveFinancialYearCommandDto();


            if (fyresult != null)
            {
                //fyresult.IsDeleted = true;
                //await DeleteAsync(user);
                await _dbContext.SaveChangesAsync();
                response.Id = id;
                response.Message = $"Financial Year id:{id} has been removed successfully .";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.Id = id;
                response.Message = $"Financial Year id:{id} does not exists .";
                response.Succeeded = false;
                return response;
            }
        }
         public async Task<List<FinancialYear>> GetAllFinancialYears()
        {
            List<FinancialYear> years = _dbContext.FinancialYear.ToList();
            return years;
        }

        public async Task<List<FinancialYear>> GetFinancialYearsByUserJoining(int userId)
        {
            User user = await _dbContext.User.FirstOrDefaultAsync(u => u.Id == userId);
            int year = DateTime.Parse(user.JoinDate.ToString()).Year;
            List<FinancialYear> years = await _dbContext.FinancialYear.Where(item =>item.StartYear >= year).ToListAsync();
            return years;
        }
    }
}
