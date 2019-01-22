using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class EmpresaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<EmpresaBE> ListaTodosActivo(int IdEmpresa, int IdTipoEmpresa)
        {
            try
            {
                EmpresaDL Empresa = new EmpresaDL();
                return Empresa.ListaTodosActivo(IdEmpresa,IdTipoEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> SeleccionaTodos()
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.SeleccionaTodos();
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EmpresaBE> ListaCombo(int IdTipoEmpresa)
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                List<EmpresaBE> lista = empresa.ListaCombo(IdTipoEmpresa);
                return lista;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmpresaBE Selecciona(int IdEmpresa)
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                EmpresaBE objEmp = empresa.Selecciona(IdEmpresa);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmpresaBE SeleccionaDescripcion(string RazonSocial)
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                EmpresaBE objEmp = empresa.SeleccionaDescripcion(RazonSocial);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EmpresaBE SeleccionaRuc(string Ruc)
        {
            try
            {
                EmpresaDL empresa = new EmpresaDL();
                EmpresaBE objEmp = empresa.SeleccionaRuc(Ruc);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void Inserta(EmpresaBE pItem, List<EmpresaArchivoBE> pListaEmpresaArchivo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EmpresaDL Empresa = new EmpresaDL();
                    EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();

                    int intIdEmpresa = 0;
                    intIdEmpresa = Empresa.Inserta(pItem);

                    foreach (var item in pListaEmpresaArchivo)
                    {
                        item.IdEmpresa = intIdEmpresa;
                        EmpresaArchivo.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EmpresaBE pItem, List<EmpresaArchivoBE> pListaEmpresaArchivo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EmpresaDL Empresa = new EmpresaDL();
                    EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();

                    foreach (EmpresaArchivoBE item in pListaEmpresaArchivo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdEmpresa = pItem.IdEmpresa;
                            EmpresaArchivo.Inserta(item);
                        }
                        else
                        {
                            EmpresaArchivo.Actualiza(item);
                        }
                    }

                    Empresa.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EmpresaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EmpresaDL Empresa = new EmpresaDL();
                    EmpresaArchivoDL EmpresaArchivo = new EmpresaArchivoDL();

                    List<EmpresaArchivoBE> lstEmpresaArchivo = null;
                    lstEmpresaArchivo = new EmpresaArchivoDL().ListaTodosActivo(pItem.IdEmpresa);

                    foreach (EmpresaArchivoBE item in lstEmpresaArchivo)
                    {
                        EmpresaArchivo.Elimina(item);
                    }

                    Empresa.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
