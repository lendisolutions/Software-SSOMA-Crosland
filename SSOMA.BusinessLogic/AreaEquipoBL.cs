using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AreaEquipoBL
    {
        public List<AreaEquipoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                return AreaEquipo.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AreaEquipoBE Selecciona(int IdAreaEquipo)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                AreaEquipoBE objEmp = AreaEquipo.Selecciona(IdAreaEquipo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AreaEquipoBE SeleccionaEquipo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdEquipo)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                AreaEquipoBE objEmp = AreaEquipo.SeleccionaEquipo(IdEmpresa, IdUnidadMinera, IdArea, IdEquipo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AreaEquipoBE pItem)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                AreaEquipo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AreaEquipoBE pItem)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                AreaEquipo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AreaEquipoBE pItem)
        {
            try
            {
                AreaEquipoDL AreaEquipo = new AreaEquipoDL();
                AreaEquipo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
