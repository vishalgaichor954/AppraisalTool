using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Branches.Command.AddBranchCommand;
using AppraisalTool.Application.Features.Branches.Command.RemoveBranchCommand;
using AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand;
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
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(ApplicationDbContext dbContext, ILogger<Branch> logger) : base(dbContext, logger)
        {
        }

        public async Task<AddBranchCommandDto> AddBranch(Branch branch)
        {
            var branchResponse = await _dbContext.Branch.Where(x => x.Id == branch.Id).FirstOrDefaultAsync();
            AddBranchCommandDto response = new AddBranchCommandDto();
            if (branchResponse != null)
            {
                response.Message = "Failed to add Branch";
                response.Succeeded = false;
                return response;
            }
            var result= await _dbContext.Branch.AddAsync(branch);

           await _dbContext.SaveChangesAsync();
            response.Id = branch.Id;
            response.Message = "Branch Added Successfully";
            response.Succeeded = true;
            return response;
        }

        public async Task<IEnumerable<Branch>> GetAllBranch()
        {
            var res =await _dbContext.Branch.Where(x => x.IsDeleted!=true).ToListAsync();
            return res;
        }

        public async Task<Branch> GetBranchById(int id)
        {
            var branch = await _dbContext.Branch.Where(x => x.Id == id).FirstOrDefaultAsync();
            return branch;
        }

        public async Task<RemoveBranchesCommandDto> RemoveBranch(int id)
        {
            RemoveBranchesCommandDto Response = new RemoveBranchesCommandDto();
            var res = await _dbContext.Branch.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (res != null)
            {
                res.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                Response.Succeeded = true;
                Response.Message = $"Id{id} deleted Successfully";
                return Response;
            }
            else
            {
                Response.Succeeded = false;
                Response.Message = "Id Doesn'nt Exist";
                return Response;
            }
        }

        public async Task<UpdateBranchCommandDto> UpdateBranchAsync(int id, UpdateBranchCommand request)
        {
            UpdateBranchCommandDto Response = new UpdateBranchCommandDto();
            var branchtoUpdate = await _dbContext.Branch.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (branchtoUpdate != null)
            {
                branchtoUpdate.BranchName=request.BranchName;
                branchtoUpdate.BranchCode = request.BranchCode;
                await _dbContext.SaveChangesAsync();
                Response.Message = "Update Successfully";
                Response.Succeeded = true;
                Response.Id = branchtoUpdate.Id;
                return Response;
            }
            else
            {
                Response.Succeeded = false;
                return Response;
            }
        }
    }
}
