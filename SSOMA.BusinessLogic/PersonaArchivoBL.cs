using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PersonaArchivoBL
    {
        public List<PersonaArchivoBE> ListaTodosActivo(int IdPersona)
        {
            try
            {
                PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();
                return PersonaArchivo.ListaTodosActivo(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PersonaArchivoBE Selecciona(int IdPersonaArchivo)
        {
            try
            {
                PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();
                PersonaArchivoBE objEmp = PersonaArchivo.Selecciona(IdPersonaArchivo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PersonaArchivoBE pItem)
        {
            try
            {
                PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();
                PersonaArchivo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PersonaArchivoBE pItem)
        {
            try
            {
                PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();
                PersonaArchivo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PersonaArchivoBE pItem)
        {
            try
            {
                PersonaArchivoDL PersonaArchivo = new PersonaArchivoDL();
                PersonaArchivo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
