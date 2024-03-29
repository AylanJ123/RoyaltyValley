﻿using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public class RepositoryRubro : IRepositoryRubro
    {
        public IEnumerable<Rubro> GetRubros()
        {
            try
            {
                IEnumerable<Rubro> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Rubro.ToList();
                }
                return list;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "Error en la conexión a la base de datos";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "Error desconocido";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw ex;
            }
        }

        public Rubro GetRubroByID(int id)
        {
            try
            {
                Rubro rubro = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    rubro = cx.Rubro.Where(res => res.ID == id).FirstOrDefault();
                }
                return rubro;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Rubro Save(Rubro rubro)
        {
            int retorno = 0;
            Rubro oRubro = null;
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oRubro = GetRubroByID(rubro.ID);
                IRepositoryRubro _RepositoryRubro = new RepositoryRubro();
                if (oRubro == null)
                {
                    ctx.Rubro.Add(rubro);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Rubro.Add(rubro);
                    ctx.Entry(rubro).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }
            if (retorno >= 0) oRubro = GetRubroByID(rubro.ID);
            return oRubro;
        }

    }
}
