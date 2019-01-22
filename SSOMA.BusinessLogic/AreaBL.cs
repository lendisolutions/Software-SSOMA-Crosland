using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AreaBL
    {
        public List<AreaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                AreaDL Area = new AreaDL();
                return Area.ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AreaBE Selecciona(int IdEmpresa, int IdUnidadMinera,  int IdArea)
        {
            try
            {
                AreaDL Area = new AreaDL();
                AreaBE objEmp = Area.Selecciona(IdEmpresa, IdUnidadMinera, IdArea);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AreaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, string DescArea)
        {
            try
            {
                AreaDL Area = new AreaDL();
                AreaBE objEmp = Area.SeleccionaDescripcion(IdEmpresa, IdUnidadMinera,  DescArea);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AreaBE pItem)
        {
            try
            {
                AreaDL Area = new AreaDL();
                Area.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
