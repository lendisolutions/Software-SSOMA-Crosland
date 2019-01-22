using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class SeveridadBL
    {
        public List<SeveridadBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                SeveridadDL Severidad = new SeveridadDL();
                return Severidad.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeveridadBE Selecciona(int IdSeveridad)
        {
            try
            {
                SeveridadDL Severidad = new SeveridadDL();
                SeveridadBE objEmp = Severidad.Selecciona(IdSeveridad);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SeveridadBE pItem)
        {
            try
            {
                SeveridadDL Severidad = new SeveridadDL();
                Severidad.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SeveridadBE pItem)
        {
            try
            {
                SeveridadDL Severidad = new SeveridadDL();
                Severidad.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SeveridadBE pItem)
        {
            try
            {
                SeveridadDL Severidad = new SeveridadDL();
                Severidad.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
