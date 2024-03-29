﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServicePlanCobro
    {
        IEnumerable<PlanCobro> GetPlanesCobro();
        PlanCobro GetPlanCobroByID(int id);
        PlanCobro Save(PlanCobro plan, int[] rubros);
    }
}
