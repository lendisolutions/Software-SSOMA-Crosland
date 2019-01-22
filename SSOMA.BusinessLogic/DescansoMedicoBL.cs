using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class DescansoMedicoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<DescansoMedicoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdPersona)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                return DescansoMedico.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<DescansoMedicoBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                return DescansoMedico.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public List<DescansoMedicoBE> ListaNumero(int Numero)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                return DescansoMedico.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DescansoMedicoBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea, int Dias)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                return DescansoMedico.ListaPorVencer(IdEmpresa, IdUnidadMinera, IdArea, Dias);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DescansoMedicoBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                return DescansoMedico.ListaVencido(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public DescansoMedicoBE Selecciona(int IdDescansoMedico)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                DescansoMedicoBE objEmp = DescansoMedico.Selecciona(IdDescansoMedico);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DescansoMedicoBE SeleccionaNumero(int Numero)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                DescansoMedicoBE objEmp = DescansoMedico.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(DescansoMedicoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                    
                    decimal decTotal = 0;
                    int IdDescansoMedico = 0;
                    IdDescansoMedico = DescansoMedico.Inserta(pItem);

                    

                    ts.Complete();

                    return IdDescansoMedico;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescansoMedicoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();

                    DescansoMedico.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdDescansoMedico, string Numero)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                DescansoMedico.ActualizaNumero(IdDescansoMedico, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdDescansoMedico, int IdSituacion)
        {
            try
            {
                DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                DescansoMedico.ActualizaSituacion(IdDescansoMedico, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescansoMedicoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DescansoMedicoDL DescansoMedico = new DescansoMedicoDL();
                    
                    DescansoMedico.Elimina(pItem);

                    //Actualizamos la solicitud del DescansoMedico
                    DescansoMedicoDL objDL_DescansoMedico = new DescansoMedicoDL();
                    objDL_DescansoMedico.ActualizaSituacion(pItem.IdDescansoMedico, Parametros.intDMCesado);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
