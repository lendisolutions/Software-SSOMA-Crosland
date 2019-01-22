﻿using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccesoBL
    {
        public List<AccesoBE> SeleccionaPerfil(int IdPerfil)
        {
            try
            {
                AccesoDL acceso = new AccesoDL();
                return acceso.SeleccionaPerfil(IdPerfil);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
