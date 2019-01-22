﻿using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TablaBL
    {
        public List<TablaBE> ListaTodosActivo(int IdRegional)
        {
            try
            {
                TablaDL Tabla = new TablaDL();
                return Tabla.ListaTodosActivo(IdRegional);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TablaBE pItem)
        {
            try
            {
                TablaDL Tabla = new TablaDL();
                Tabla.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TablaBE pItem)
        {
            try
            {
                TablaDL Tabla = new TablaDL();
                Tabla.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TablaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TablaDL Tabla = new TablaDL();
                    TablaElementoDL TablaElemento = new TablaElementoDL();

                    List<TablaElementoBE> pListaTablaElemento = null;
                    pListaTablaElemento = new TablaElementoBL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdTabla);

                    //Eliminar los elementos de la tabla
                    foreach (var item in pListaTablaElemento)
                    {
                        TablaElemento.Elimina(item);
                    }

                    Tabla.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
