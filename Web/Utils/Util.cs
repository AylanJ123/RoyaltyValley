﻿using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Utils
{
    public class Util
    {
        public static void ValidateErrors(Controller pController)
        {

            var listaErrores = pController.ModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();

            foreach (ModelErrorCollection item in listaErrores)
            {
                if (item.Count > 0)
                    pController.ModelState.AddModelError("", item[0].ErrorMessage.ToString());
            }

        }


        public static List<string> GetModelStateErrors(ModelStateDictionary pModelState)
        {

            List<string> lista = new List<string>();

            var listaErrores = pModelState.Select(x => x.Value.Errors)
                         .Where(y => y.Count > 0)
                         .ToList();

            foreach (var item in pModelState)
            {
                lista.Add(item.Value.Errors[0].ErrorMessage);
            }


            return lista;

        }

        public static bool IsAuthorized(Controller controller, UserAuth authLevel)
        {
            if (!(controller.Session["Usuario"] is Usuario user)) return false;
            return user.tipo == (byte) authLevel;
        }

        public static bool IsAuthorized(object usuarioObj, UserAuth authLevel)
        {
            return ((Usuario)usuarioObj).tipo == (byte)authLevel;
        }

        [Flags]
        public enum UserAuth : byte
        {
            Resident = 0,
            Admin = 1
        }

    }
}