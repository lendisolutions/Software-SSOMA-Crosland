using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class ProveedorBL
    {
        public List<ProveedorBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                return Proveedor.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProveedorBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                return Proveedor.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProveedorBE Selecciona(int IdEmpresa, int IdProveedor)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                ProveedorBE objEmp = Proveedor.Selecciona(IdEmpresa, IdProveedor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                Proveedor.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                Proveedor.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProveedorBE pItem)
        {
            try
            {
                ProveedorDL Proveedor = new ProveedorDL();
                Proveedor.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
