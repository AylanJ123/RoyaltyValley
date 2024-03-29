﻿using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryResidencia : IRepositoryResidencia
    {
        public IEnumerable<Residencia> GetResidencias()
        {
            try
            {
                IEnumerable<Residencia> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Residencia.Include("Usuario").ToList();
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

        public Residencia GetResidenciaByID(int id)
        {
            try
            {
                Residencia residencia = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    residencia = cx.Residencia.Include("Usuario").Where(res => res.ID == id).FirstOrDefault();
                }
                return residencia;
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
    }
}
