using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class DocumentoPersonaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<DocumentoPersonaBE> ListaTodosActivo(int IdEmpresa, int IdPersona, int IdDocumento)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                return DocumentoPersona.ListaTodosActivo(IdEmpresa,IdPersona, IdDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoPersonaBE> ListaCarpeta(int IdEmpresa, int IdPersona)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                return DocumentoPersona.ListaCarpeta(IdEmpresa, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoPersonaBE> ListaCarpetaArchivo(int IdEmpresa, int IdPersona, int IdCarpeta)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                return DocumentoPersona.ListaCarpetaArchivo(IdEmpresa, IdPersona,IdCarpeta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoPersonaBE Selecciona(int IdDocumentoPersona)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                DocumentoPersonaBE objEmp = DocumentoPersona.Selecciona(IdDocumentoPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<DocumentoPersonaBE> pListaDocumentoPersona)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (DocumentoPersonaBE item in pListaDocumentoPersona)
                    {
                         if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            DocumentoPersona.Inserta(item);
                        }
                        else
                        {
                            DocumentoPersona.Actualiza(item);
                        }
                     }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<DocumentoPersonaBE> pListaDocumentoPersona, int IdPersona, string Usuario, string Maquina)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (DocumentoPersonaBE item in pListaDocumentoPersona)
                    {
                        if (item.IdDocumentoPersona == 0 && item.FlagAsigna == true) //INSERTAR DOCUMENTO PERSONA
                        {
                            DocumentoPersonaBE objE_DocumentoPersona = new DocumentoPersonaBE();
                            objE_DocumentoPersona.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoPersona.IdDocumentoPersona = item.IdDocumentoPersona;
                            objE_DocumentoPersona.IdPersona = IdPersona;
                            objE_DocumentoPersona.IdDocumento = item.IdDocumento;
                            objE_DocumentoPersona.FlagImpresion = item.FlagImpresion;
                            objE_DocumentoPersona.Lectura = item.Lectura;
                            objE_DocumentoPersona.FlagEstado = true;
                            objE_DocumentoPersona.Usuario = Usuario;
                            objE_DocumentoPersona.Maquina = Maquina;

                            DocumentoPersona.Inserta(objE_DocumentoPersona);

                        }

                        if (item.IdDocumentoPersona >  0 && item.FlagAsigna == true) //ACTUALIZAR DOCUMENTO PERSONA
                        {
                            DocumentoPersonaBE objE_DocumentoPersona = new DocumentoPersonaBE();
                            objE_DocumentoPersona.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoPersona.IdDocumentoPersona = item.IdDocumentoPersona;
                            objE_DocumentoPersona.IdPersona = IdPersona;
                            objE_DocumentoPersona.IdDocumento = item.IdDocumento;
                            objE_DocumentoPersona.FlagImpresion = item.FlagImpresion;
                            objE_DocumentoPersona.Lectura = item.Lectura;
                            objE_DocumentoPersona.FlagEstado = true;
                            objE_DocumentoPersona.Usuario = Usuario;
                            objE_DocumentoPersona.Maquina = Maquina;

                            DocumentoPersona.Actualiza(objE_DocumentoPersona);

                        }

                        if (item.IdDocumentoPersona > 0 && item.FlagAsigna == false) //ELIMINAR DOCUMENTO PERSONA
                        {
                            DocumentoPersonaBE objE_DocumentoPersona = new DocumentoPersonaBE();
                            objE_DocumentoPersona.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoPersona.IdDocumentoPersona = item.IdDocumentoPersona;
                            objE_DocumentoPersona.Usuario = Usuario;
                            objE_DocumentoPersona.Maquina = Maquina;

                            DocumentoPersona.Elimina(objE_DocumentoPersona);

                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaLectura(int IdPersona, int IdDocumento)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                DocumentoPersona.ActualizaLectura(IdPersona,IdDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoPersonaBE pItem)
        {
            try
            {
                DocumentoPersonaDL DocumentoPersona = new DocumentoPersonaDL();
                DocumentoPersona.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
