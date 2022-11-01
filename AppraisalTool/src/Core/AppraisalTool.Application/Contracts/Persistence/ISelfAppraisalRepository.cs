﻿using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface ISelfAppraisalRepository
    {
        public  Task<List<Appraisal>> GetDataById(int userId, int financialYearId);

    }
}
