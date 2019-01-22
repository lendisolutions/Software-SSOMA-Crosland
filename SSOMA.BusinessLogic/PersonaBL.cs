using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PersonaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<PersonaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                return Persona.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> ListaContratista(int IdContratista)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                return Persona.ListaContratista(IdContratista);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE Selecciona(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdPersona)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                PersonaBE objEmp = Persona.Selecciona(IdEmpresa, IdUnidadMinera, IdArea, IdPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, int IdArea, string DescPersona)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                PersonaBE objEmp = Persona.SeleccionaDescripcion(IdEmpresa, IdUnidadMinera, IdArea, DescPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaBE SeleccionaNumeroDocumento(int IdEmpresa, string Dni)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                PersonaBE objEmp = Persona.SeleccionaNumeroDocumento(IdEmpresa,Dni);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PersonaBE> SeleccionaBusqueda(int IdEmpresa, int IdUnidadMinera, int IdSituacion, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                return Persona.SeleccionaBusqueda(IdEmpresa, IdUnidadMinera, IdSituacion, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaBusquedaCount(int IdEmpresa, int IdUnidadMinera, int IdSituacion, string pFiltro)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                return Persona.SeleccionaBusquedaCount(IdEmpresa, IdUnidadMinera, IdSituacion, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PersonaBE pItem, List<PersonaArchivoBE> pListaPersonaArchivo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaDL Persona = new PersonaDL();
                    PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();

                    int intIdPersona = 0;
                    intIdPersona = Persona.Inserta(pItem);

                    foreach (var item in pListaPersonaArchivo)
                    {
                        item.IdPersona = intIdPersona;
                        PersonaArchivo.Inserta(item);
                    }

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMasivo(List<PersonaBE> pListaPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaDL objPersona = new PersonaDL();

                    foreach (PersonaBE item in pListaPersona)
                    {
                        objPersona.InsertaMasivo(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(PersonaBE pItem, List<PersonaArchivoBE> pListaPersonaArchivo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaDL Persona = new PersonaDL();
                    PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();

                    foreach (PersonaArchivoBE item in pListaPersonaArchivo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdPersona = pItem.IdPersona;
                            PersonaArchivo.Inserta(item);
                        }
                        else
                        {
                            PersonaArchivo.Actualiza(item);
                        }
                    }

                    Persona.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdEmpresa, string Dni, int IdSituacion, DateTime FechaIngreso)
        {
            try
            {
                PersonaDL Persona = new PersonaDL();
                Persona.ActualizaSituacion(IdEmpresa, Dni, IdSituacion, FechaIngreso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PersonaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PersonaDL Persona = new PersonaDL();
                    PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();

                    List<PersonaArchivoBE> lstPersonaArchivo = null;
                    lstPersonaArchivo = new PersonaArchivoDL().ListaTodosActivo(pItem.IdPersona);

                    foreach (PersonaArchivoBE item in lstPersonaArchivo)
                    {
                        PersonaArchivo.Elimina(item);
                    }

                    Persona.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
