using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class EquipoBL
    {
        public List<EquipoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EquipoBE Selecciona(int IdEmpresa, int IdEquipo)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                return Equipo.Selecciona(IdEmpresa, IdEquipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EquipoBE pItem)
        {
            try
            {
                EquipoDL Equipo = new EquipoDL();
                Equipo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
