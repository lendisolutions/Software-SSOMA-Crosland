using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class TemaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<TemaBE> ListaTodosActivo(int IdEmpresa, int idCategoriaTema, int Periodo)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                return Tema.ListaTodosActivo(IdEmpresa, idCategoriaTema,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TemaBE> ListaCombo(int IdEmpresa, int Periodo)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                return Tema.ListaCombo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaBE Selecciona(int IdEmpresa, int IdTema)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                TemaBE objEmp = Tema.Selecciona(IdEmpresa, IdTema);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }



        public void Inserta(TemaBE pItem, List<TemaDetalleBE> pListaTemaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TemaDL Tema = new TemaDL();
                    TemaDetalleDL TemaDetalle = new TemaDetalleDL();

                    int intIdTema = 0;
                    intIdTema = Tema.Inserta(pItem);

                    foreach (var item in pListaTemaDetalle)
                    {
                        item.IdTema = intIdTema;
                        TemaDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TemaBE pItem, List<TemaDetalleBE> pListaTemaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TemaDL Tema = new TemaDL();
                    TemaDetalleDL TemaDetalle = new TemaDetalleDL();

                    foreach (TemaDetalleBE item in pListaTemaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdTema = pItem.IdTema;
                            TemaDetalle.Inserta(item);
                        }
                        else
                        {
                            TemaDetalle.Actualiza(item);
                        }
                    }

                    Tema.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdTema, int IdSituacion)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                Tema.ActualizaSituacion(IdTema, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void Elimina(TemaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TemaDL Tema = new TemaDL();
                    TemaDetalleDL TemaDetalle = new TemaDetalleDL();

                    List<TemaDetalleBE> lstTemaDetalle = null;
                    lstTemaDetalle = new TemaDetalleDL().ListaTodosActivo(pItem.IdTema);

                    foreach (TemaDetalleBE item in lstTemaDetalle)
                    {
                        TemaDetalle.Elimina(item);
                    }

                    Tema.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        

        
    }
}
