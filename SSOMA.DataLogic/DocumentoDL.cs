using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class DocumentoDL
    {
        public DocumentoDL() { }

        public void Inserta(DocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_Inserta");

            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, pItem.IdDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, pItem.IdCarpeta);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pRuta", DbType.String, pItem.Ruta);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pRevision", DbType.String, pItem.Revision);
            db.AddInParameter(dbCommand, "pFechaAprobacion", DbType.DateTime, pItem.FechaAprobacion);
            db.AddInParameter(dbCommand, "pFlagContabilidad", DbType.Boolean, pItem.FlagContabilidad);
            db.AddInParameter(dbCommand, "pFlagSistemas", DbType.Boolean, pItem.FlagSistemas);
            db.AddInParameter(dbCommand, "pFlagLegal", DbType.Boolean, pItem.FlagLegal);
            db.AddInParameter(dbCommand, "pFlagTesoreria", DbType.Boolean, pItem.FlagTesoreria);
            db.AddInParameter(dbCommand, "pFlagAtraccion", DbType.Boolean, pItem.FlagAtraccion);
            db.AddInParameter(dbCommand, "pFlagAdministracion", DbType.Boolean, pItem.FlagAdministracion);
            db.AddInParameter(dbCommand, "pFlagComercial", DbType.Boolean, pItem.FlagComercial);
            db.AddInParameter(dbCommand, "pFlagDesarrolloNegocio", DbType.Boolean, pItem.FlagDesarrolloNegocio);
            db.AddInParameter(dbCommand, "pFlagControlGestion", DbType.Boolean, pItem.FlagControlGestion);
            db.AddInParameter(dbCommand, "pFlagAlmacen", DbType.Boolean, pItem.FlagAlmacen);
            db.AddInParameter(dbCommand, "pFlagDespacho", DbType.Boolean, pItem.FlagDespacho);
            db.AddInParameter(dbCommand, "pFlagGerenciaGeneral", DbType.Boolean, pItem.FlagGerenciaGeneral);
            db.AddInParameter(dbCommand, "pFlagMarketing", DbType.Boolean, pItem.FlagMarketing);
            db.AddInParameter(dbCommand, "pFlagOperacion", DbType.Boolean, pItem.FlagOperacion);
            db.AddInParameter(dbCommand, "pFlagProyecto", DbType.Boolean, pItem.FlagProyecto);
            db.AddInParameter(dbCommand, "pFlagServicioGeneral", DbType.Boolean, pItem.FlagServicioGeneral);
            db.AddInParameter(dbCommand, "pFlagPlaneamiento", DbType.Boolean, pItem.FlagPlaneamiento);
            db.AddInParameter(dbCommand, "pFlagCompensacion", DbType.Boolean, pItem.FlagCompensacion);
            db.AddInParameter(dbCommand, "pFlagBienestar", DbType.Boolean, pItem.FlagBienestar);
            db.AddInParameter(dbCommand, "pFlagAlquiler", DbType.Boolean, pItem.FlagAlquiler);
            db.AddInParameter(dbCommand, "pFlagDesarrolloOrganizacional", DbType.Boolean, pItem.FlagDesarrolloOrganizacional);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(DocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, pItem.IdDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, pItem.IdCarpeta);
            db.AddInParameter(dbCommand, "pArchivo", DbType.Binary, pItem.Archivo);
            db.AddInParameter(dbCommand, "pRuta", DbType.String, pItem.Ruta);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pNombreArchivo", DbType.String, pItem.NombreArchivo);
            db.AddInParameter(dbCommand, "pRevision", DbType.String, pItem.Revision);
            db.AddInParameter(dbCommand, "pFechaAprobacion", DbType.DateTime, pItem.FechaAprobacion);
            db.AddInParameter(dbCommand, "pFlagContabilidad", DbType.Boolean, pItem.FlagContabilidad);
            db.AddInParameter(dbCommand, "pFlagSistemas", DbType.Boolean, pItem.FlagSistemas);
            db.AddInParameter(dbCommand, "pFlagLegal", DbType.Boolean, pItem.FlagLegal);
            db.AddInParameter(dbCommand, "pFlagTesoreria", DbType.Boolean, pItem.FlagTesoreria);
            db.AddInParameter(dbCommand, "pFlagAtraccion", DbType.Boolean, pItem.FlagAtraccion);
            db.AddInParameter(dbCommand, "pFlagAdministracion", DbType.Boolean, pItem.FlagAdministracion);
            db.AddInParameter(dbCommand, "pFlagComercial", DbType.Boolean, pItem.FlagComercial);
            db.AddInParameter(dbCommand, "pFlagDesarrolloNegocio", DbType.Boolean, pItem.FlagDesarrolloNegocio);
            db.AddInParameter(dbCommand, "pFlagControlGestion", DbType.Boolean, pItem.FlagControlGestion);
            db.AddInParameter(dbCommand, "pFlagAlmacen", DbType.Boolean, pItem.FlagAlmacen);
            db.AddInParameter(dbCommand, "pFlagDespacho", DbType.Boolean, pItem.FlagDespacho);
            db.AddInParameter(dbCommand, "pFlagGerenciaGeneral", DbType.Boolean, pItem.FlagGerenciaGeneral);
            db.AddInParameter(dbCommand, "pFlagMarketing", DbType.Boolean, pItem.FlagMarketing);
            db.AddInParameter(dbCommand, "pFlagOperacion", DbType.Boolean, pItem.FlagOperacion);
            db.AddInParameter(dbCommand, "pFlagProyecto", DbType.Boolean, pItem.FlagProyecto);
            db.AddInParameter(dbCommand, "pFlagServicioGeneral", DbType.Boolean, pItem.FlagServicioGeneral);
            db.AddInParameter(dbCommand, "pFlagPlaneamiento", DbType.Boolean, pItem.FlagPlaneamiento);
            db.AddInParameter(dbCommand, "pFlagCompensacion", DbType.Boolean, pItem.FlagCompensacion);
            db.AddInParameter(dbCommand, "pFlagBienestar", DbType.Boolean, pItem.FlagBienestar);
            db.AddInParameter(dbCommand, "pFlagAlquiler", DbType.Boolean, pItem.FlagAlquiler);
            db.AddInParameter(dbCommand, "pFlagDesarrolloOrganizacional", DbType.Boolean, pItem.FlagDesarrolloOrganizacional);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(DocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, pItem.IdDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public DocumentoBE Selecciona(int IdDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_Selecciona");
            db.AddInParameter(dbCommand, "pidDocumento", DbType.Int32, IdDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DocumentoBE Documento = null;
            while (reader.Read())
            {
                Documento = new DocumentoBE();
                Documento.IdDocumento = Int32.Parse(reader["idDocumento"].ToString());
                Documento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Documento.RazonSocial = reader["RazonSocial"].ToString();
                Documento.IdCarpeta = Int32.Parse(reader["IdCarpeta"].ToString());
                Documento.DescCarpeta = reader["DescCarpeta"].ToString();
                Documento.Archivo = (byte[])reader["Archivo"];
                Documento.Ruta = reader["Ruta"].ToString();
                Documento.Codigo = reader["Codigo"].ToString();
                Documento.NombreArchivo = reader["NombreArchivo"].ToString();
                Documento.Revision = reader["Revision"].ToString();
                Documento.FechaAprobacion = DateTime.Parse(reader["FechaAprobacion"].ToString());
                Documento.FlagContabilidad = Boolean.Parse(reader["FlagContabilidad"].ToString());
                Documento.FlagSistemas = Boolean.Parse(reader["FlagSistemas"].ToString());
                Documento.FlagLegal = Boolean.Parse(reader["FlagLegal"].ToString());
                Documento.FlagTesoreria = Boolean.Parse(reader["FlagTesoreria"].ToString());
                Documento.FlagAtraccion = Boolean.Parse(reader["FlagAtraccion"].ToString());
                Documento.FlagAdministracion = Boolean.Parse(reader["FlagAdministracion"].ToString());
                Documento.FlagComercial = Boolean.Parse(reader["FlagComercial"].ToString());
                Documento.FlagDesarrolloNegocio = Boolean.Parse(reader["FlagDesarrolloNegocio"].ToString());
                Documento.FlagControlGestion = Boolean.Parse(reader["FlagControlGestion"].ToString());
                Documento.FlagAlmacen = Boolean.Parse(reader["FlagAlmacen"].ToString());
                Documento.FlagDespacho = Boolean.Parse(reader["FlagDespacho"].ToString());
                Documento.FlagGerenciaGeneral = Boolean.Parse(reader["FlagGerenciaGeneral"].ToString());
                Documento.FlagMarketing = Boolean.Parse(reader["FlagMarketing"].ToString());
                Documento.FlagOperacion = Boolean.Parse(reader["FlagOperacion"].ToString());
                Documento.FlagProyecto = Boolean.Parse(reader["FlagProyecto"].ToString());
                Documento.FlagServicioGeneral = Boolean.Parse(reader["FlagServicioGeneral"].ToString());
                Documento.FlagPlaneamiento = Boolean.Parse(reader["FlagPlaneamiento"].ToString());
                Documento.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                Documento.FlagBienestar = Boolean.Parse(reader["FlagBienestar"].ToString());
                Documento.FlagAlquiler = Boolean.Parse(reader["FlagAlquiler"].ToString());
                Documento.FlagDesarrolloOrganizacional = Boolean.Parse(reader["FlagDesarrolloOrganizacional"].ToString());
                Documento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Documento;
        }

        public List<DocumentoBE> ListaTodosActivo(int IdEmpresa, int IdCarpeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, IdCarpeta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoBE> Documentolist = new List<DocumentoBE>();
            DocumentoBE Documento;
            while (reader.Read())
            {
                Documento = new DocumentoBE();
                Documento.IdDocumento = Int32.Parse(reader["idDocumento"].ToString());
                Documento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Documento.RazonSocial = reader["RazonSocial"].ToString();
                Documento.IdCarpeta = Int32.Parse(reader["IdCarpeta"].ToString());
                Documento.DescCarpeta = reader["DescCarpeta"].ToString();
                //Documento.Archivo = (byte[])reader["Archivo"];
                Documento.Ruta = reader["Ruta"].ToString();
                Documento.Codigo = reader["Codigo"].ToString();
                Documento.NombreArchivo = reader["NombreArchivo"].ToString();
                Documento.Revision = reader["Revision"].ToString();
                Documento.FechaAprobacion = DateTime.Parse(reader["FechaAprobacion"].ToString());
                Documento.FlagContabilidad = Boolean.Parse(reader["FlagContabilidad"].ToString());
                Documento.FlagSistemas = Boolean.Parse(reader["FlagSistemas"].ToString());
                Documento.FlagLegal = Boolean.Parse(reader["FlagLegal"].ToString());
                Documento.FlagTesoreria = Boolean.Parse(reader["FlagTesoreria"].ToString());
                Documento.FlagAtraccion = Boolean.Parse(reader["FlagAtraccion"].ToString());
                Documento.FlagAdministracion = Boolean.Parse(reader["FlagAdministracion"].ToString());
                Documento.FlagComercial = Boolean.Parse(reader["FlagComercial"].ToString());
                Documento.FlagDesarrolloNegocio = Boolean.Parse(reader["FlagDesarrolloNegocio"].ToString());
                Documento.FlagControlGestion = Boolean.Parse(reader["FlagControlGestion"].ToString());
                Documento.FlagAlmacen = Boolean.Parse(reader["FlagAlmacen"].ToString());
                Documento.FlagDespacho = Boolean.Parse(reader["FlagDespacho"].ToString());
                Documento.FlagGerenciaGeneral = Boolean.Parse(reader["FlagGerenciaGeneral"].ToString());
                Documento.FlagMarketing = Boolean.Parse(reader["FlagMarketing"].ToString());
                Documento.FlagOperacion = Boolean.Parse(reader["FlagOperacion"].ToString());
                Documento.FlagProyecto = Boolean.Parse(reader["FlagProyecto"].ToString());
                Documento.FlagServicioGeneral = Boolean.Parse(reader["FlagServicioGeneral"].ToString());
                Documento.FlagPlaneamiento = Boolean.Parse(reader["FlagPlaneamiento"].ToString());
                Documento.FlagCompensacion = Boolean.Parse(reader["FlagCompensacion"].ToString());
                Documento.FlagBienestar = Boolean.Parse(reader["FlagBienestar"].ToString());
                Documento.FlagAlquiler = Boolean.Parse(reader["FlagAlquiler"].ToString());
                Documento.FlagDesarrolloOrganizacional = Boolean.Parse(reader["FlagDesarrolloOrganizacional"].ToString());
                Documento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Documentolist.Add(Documento);
            }
            reader.Close();
            reader.Dispose();
            return Documentolist;
        }

        public List<DocumentoBE> ListaCombo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Documento_ListaCombo");
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoBE> Documentolist = new List<DocumentoBE>();
            DocumentoBE Documento;
            while (reader.Read())
            {
                Documento = new DocumentoBE();
                Documento.IdDocumento = Int32.Parse(reader["idDocumento"].ToString());
                Documento.NombreArchivo = reader["NombreArchivo"].ToString();
                Documentolist.Add(Documento);
            }
            reader.Close();
            reader.Dispose();
            return Documentolist;
        }
    }
}
