using AppraisalTool.Application.Features.Branches.Command.AddBranchCommand;
using AppraisalTool.Application.Features.Branches.Command.RemoveBranchCommand;
using AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IBranchRepository
    {
        public Task<IEnumerable<Branch>> GetAllBranch();
        Task<AddBranchCommandDto> AddBranch(Branch branch);
        Task <UpdateBranchCommandDto> UpdateBranchAsync(int id, UpdateBranchCommand request);
        public Task<Branch> GetBranchById(int id);
        public Task<RemoveBranchesCommandDto> RemoveBranch(int id);
    }
}
