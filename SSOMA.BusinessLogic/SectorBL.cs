using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Transactions;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;

namespace SSOMA.BusinessLogic
{
    public class SectorBL
    {
        public List<SectorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                return Sector.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SectorBE Selecciona(int IdSector)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                SectorBE objEmp = Sector.Selecciona(IdSector);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SectorBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, int IdArea, string DescSector)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                SectorBE objEmp = Sector.SeleccionaDescripcion(IdEmpresa, IdUnidadMinera, IdArea, DescSector);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SectorBE pItem)
        {
            try
            {
                SectorDL Sector = new SectorDL();
                Sector.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
