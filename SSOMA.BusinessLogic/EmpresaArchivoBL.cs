using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class EmpresaArchivoBL
    {
        public List<EmpresaArchivoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();
                return EmpresaArchivo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmpresaArchivoBE Selecciona(int IdEmpresaArchivo)
        {
            try
            {
                EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();
                EmpresaArchivoBE objEmp = EmpresaArchivo.Selecciona(IdEmpresaArchivo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EmpresaArchivoBE pItem)
        {
            try
            {
                EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();
                EmpresaArchivo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EmpresaArchivoBE pItem)
        {
            try
            {
                EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();
                EmpresaArchivo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EmpresaArchivoBE pItem)
        {
            try
            {
                EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();
                EmpresaArchivo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
