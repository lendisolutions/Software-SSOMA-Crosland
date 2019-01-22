using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class RiesgoBL
    {
        public List<RiesgoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                return Riesgo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<RiesgoBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                return Riesgo.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RiesgoBE Selecciona(int IdRiesgo)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                RiesgoBE objEmp = Riesgo.Selecciona(IdRiesgo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RiesgoBE pItem)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                Riesgo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RiesgoBE pItem)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                Riesgo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(RiesgoBE pItem)
        {
            try
            {
                RiesgoDL Riesgo = new RiesgoDL();
                Riesgo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
