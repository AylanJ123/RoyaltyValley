﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryPlanCobro
    {
        IEnumerable<PlanCobro> GetPlanesCobro();
        PlanCobro GetPlanCobroByID(int id);
        PlanCobro Save(PlanCobro plan, int[] rubros);
    }
}
