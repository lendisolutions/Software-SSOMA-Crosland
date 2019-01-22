using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class DocumentoBL
    {
        public List<DocumentoBE> ListaTodosActivo(int IdEmpresa, int IdCarpeta)
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                return Documento.ListaTodosActivo(IdEmpresa, IdCarpeta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoBE> ListaCombo()
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                return Documento.ListaCombo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoBE Selecciona(int IdDocumento)
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                DocumentoBE objEmp = Documento.Selecciona(IdDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(DocumentoBE pItem)
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                Documento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DocumentoBE pItem)
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                Documento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoBE pItem)
        {
            try
            {
                DocumentoDL Documento = new DocumentoDL();
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                Documento.Elimina(pItem);

                //ELIMINAMOS EL DETALLE
                List<DocumentoPersonaBE> lstDocumentoPersona = null;
                lstDocumentoPersona = new DocumentoPersonaBL().ListaTodosActivo(0, 0, pItem.IdDocumento);

                if (lstDocumentoPersona.Count > 0)
                {
                    foreach (var item in lstDocumentoPersona)
                    {
                        item.Usuario = pItem.Usuario;
                        item.Maquina = pItem.Maquina;
                        item.IdEmpresa = pItem.IdEmpresa;
                        DocumentoPersona.Elimina(item);
                    }
                }



            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
