using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ValoracionRiesgoBL
    {
        public List<ValoracionRiesgoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ValoracionRiesgoDL ValoracionRiesgo = new ValoracionRiesgoDL();
                return ValoracionRiesgo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ValoracionRiesgoBE Selecciona(int IdValoracionRiesgo)
        {
            try
            {
                ValoracionRiesgoDL ValoracionRiesgo = new ValoracionRiesgoDL();
                ValoracionRiesgoBE objEmp = ValoracionRiesgo.Selecciona(IdValoracionRiesgo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ValoracionRiesgoBE pItem)
        {
            try
            {
                ValoracionRiesgoDL ValoracionRiesgo = new ValoracionRiesgoDL();
                ValoracionRiesgo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ValoracionRiesgoBE pItem)
        {
            try
            {
                ValoracionRiesgoDL ValoracionRiesgo = new ValoracionRiesgoDL();
                ValoracionRiesgo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ValoracionRiesgoBE pItem)
        {
            try
            {
                ValoracionRiesgoDL ValoracionRiesgo = new ValoracionRiesgoDL();
                ValoracionRiesgo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
