using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SeguroViajeDL
    {
        public SeguroViajeDL() { }

        public Int32 Inserta(SeguroViajeBE pItem)
        {
            Int32 intIdSeguroViaje = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_Inserta");

            db.AddOutParameter(dbCommand, "pIdSeguroViaje", DbType.Int32, pItem.IdSeguroViaje);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pFechaLLegada", DbType.DateTime, pItem.FechaLlegada);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pPais", DbType.String, pItem.Pais);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pPasaporte", DbType.String, pItem.Pasaporte);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pDistrito", DbType.String, pItem.Distrito);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmailPersonal", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pTelefonoContacto1", DbType.String, pItem.TelefonoContacto1);
            db.AddInParameter(dbCommand, "pTelefonoContacto2", DbType.String, pItem.TelefonoContacto2);
            db.AddInParameter(dbCommand, "pEmpresaBoleta", DbType.String, pItem.EmpresaBoleta);
            db.AddInParameter(dbCommand, "pEmpresaFactura", DbType.String, pItem.EmpresaFactura);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pAutoriza", DbType.String, pItem.Autoriza);
            db.AddInParameter(dbCommand, "pOiseco", DbType.String, pItem.Oiseco);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdSeguroViaje = (int)db.GetParameterValue(dbCommand, "pIdSeguroViaje");

            return intIdSeguroViaje;

        }

        public void Actualiza(SeguroViajeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_Actualiza");

            db.AddInParameter(dbCommand, "pIdSeguroViaje", DbType.Int32, pItem.IdSeguroViaje);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSalida", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pFechaLLegada", DbType.DateTime, pItem.FechaLlegada);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pPais", DbType.String, pItem.Pais);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pPasaporte", DbType.String, pItem.Pasaporte);
            db.AddInParameter(dbCommand, "pSolicitante", DbType.String, pItem.Solicitante);
            db.AddInParameter(dbCommand, "pFechaNacimiento", DbType.DateTime, pItem.FechaNacimiento);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pDistrito", DbType.String, pItem.Distrito);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pEmailPersonal", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pCargo", DbType.String, pItem.Cargo);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pTelefonoContacto1", DbType.String, pItem.TelefonoContacto1);
            db.AddInParameter(dbCommand, "pTelefonoContacto2", DbType.String, pItem.TelefonoContacto2);
            db.AddInParameter(dbCommand, "pEmpresaBoleta", DbType.String, pItem.EmpresaBoleta);
            db.AddInParameter(dbCommand, "pEmpresaFactura", DbType.String, pItem.EmpresaFactura);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pAutoriza", DbType.String, pItem.Autoriza);
            db.AddInParameter(dbCommand, "pOiseco", DbType.String, pItem.Oiseco);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdSeguroViaje, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdSeguroViaje", DbType.Int32, IdSeguroViaje);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdSeguroViaje, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdSeguroViaje", DbType.Int32, IdSeguroViaje);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(SeguroViajeBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_Elimina");

            db.AddInParameter(dbCommand, "pIdSeguroViaje", DbType.Int32, pItem.IdSeguroViaje);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SeguroViajeBE Selecciona(int idSeguroViaje)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_Selecciona");
            db.AddInParameter(dbCommand, "pidSeguroViaje", DbType.Int32, idSeguroViaje);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeguroViajeBE SeguroViaje = null;
            while (reader.Read())
            {
                SeguroViaje = new SeguroViajeBE();
                SeguroViaje.IdSeguroViaje = Int32.Parse(reader["idSeguroViaje"].ToString());
                SeguroViaje.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                SeguroViaje.Numero = reader["Numero"].ToString();
                SeguroViaje.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                SeguroViaje.FechaLlegada = DateTime.Parse(reader["FechaLlegada"].ToString());
                SeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                SeguroViaje.Pais = reader["Pais"].ToString();
                SeguroViaje.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SeguroViaje.Dni = reader["Dni"].ToString();
                SeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                SeguroViaje.Solicitante = reader["Solicitante"].ToString();
                SeguroViaje.FechaNacimiento= DateTime.Parse(reader["FechaNacimiento"].ToString());
                SeguroViaje.Direccion = reader["Direccion"].ToString();
                SeguroViaje.Distrito = reader["Distrito"].ToString();
                SeguroViaje.Telefono = reader["Telefono"].ToString();
                SeguroViaje.Email = reader["Email"].ToString();
                SeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                SeguroViaje.Cargo = reader["Cargo"].ToString();
                SeguroViaje.Contacto = reader["Contacto"].ToString();
                SeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                SeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                SeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                SeguroViaje.Ruc = reader["Ruc"].ToString();
                SeguroViaje.Autoriza = reader["Autoriza"].ToString();
                SeguroViaje.Oiseco = reader["Oiseco"].ToString();
                SeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                SeguroViaje.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                SeguroViaje.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SeguroViaje;
        }

        public SeguroViajeBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeguroViajeBE SeguroViaje = null;
            while (reader.Read())
            {
                SeguroViaje = new SeguroViajeBE();
                SeguroViaje.IdSeguroViaje = Int32.Parse(reader["idSeguroViaje"].ToString());
                SeguroViaje.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                SeguroViaje.Numero = reader["Numero"].ToString();
                SeguroViaje.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                SeguroViaje.FechaLlegada = DateTime.Parse(reader["FechaLlegada"].ToString());
                SeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                SeguroViaje.Pais = reader["Pais"].ToString();
                SeguroViaje.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SeguroViaje.Dni = reader["Dni"].ToString();
                SeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                SeguroViaje.Solicitante = reader["Solicitante"].ToString();
                SeguroViaje.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                SeguroViaje.Direccion = reader["Direccion"].ToString();
                SeguroViaje.Distrito = reader["Distrito"].ToString();
                SeguroViaje.Telefono = reader["Telefono"].ToString();
                SeguroViaje.Email = reader["Email"].ToString();
                SeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                SeguroViaje.Cargo = reader["Cargo"].ToString();
                SeguroViaje.Contacto = reader["Contacto"].ToString();
                SeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                SeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                SeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                SeguroViaje.Ruc = reader["Ruc"].ToString();
                SeguroViaje.Autoriza = reader["Autoriza"].ToString();
                SeguroViaje.Oiseco = reader["Oiseco"].ToString();
                SeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                SeguroViaje.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                SeguroViaje.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SeguroViaje;
        }

        public List<SeguroViajeBE> ListaTodosActivo(int IdEmpresa, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeguroViajeBE> SeguroViajelist = new List<SeguroViajeBE>();
            SeguroViajeBE SeguroViaje;
            while (reader.Read())
            {
                SeguroViaje = new SeguroViajeBE();
                SeguroViaje.IdSeguroViaje = Int32.Parse(reader["idSeguroViaje"].ToString());
                SeguroViaje.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                SeguroViaje.Numero = reader["Numero"].ToString();
                SeguroViaje.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                SeguroViaje.FechaLlegada = DateTime.Parse(reader["FechaLlegada"].ToString());
                SeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                SeguroViaje.Pais = reader["Pais"].ToString();
                SeguroViaje.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SeguroViaje.Dni = reader["Dni"].ToString();
                SeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                SeguroViaje.Solicitante = reader["Solicitante"].ToString();
                SeguroViaje.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                SeguroViaje.Direccion = reader["Direccion"].ToString();
                SeguroViaje.Distrito = reader["Distrito"].ToString();
                SeguroViaje.Telefono = reader["Telefono"].ToString();
                SeguroViaje.Email = reader["Email"].ToString();
                SeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                SeguroViaje.Cargo = reader["Cargo"].ToString();
                SeguroViaje.Contacto = reader["Contacto"].ToString();
                SeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                SeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                SeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                SeguroViaje.Ruc = reader["Ruc"].ToString();
                SeguroViaje.Autoriza = reader["Autoriza"].ToString();
                SeguroViaje.Oiseco = reader["Oiseco"].ToString();
                SeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                SeguroViaje.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                SeguroViaje.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SeguroViajelist.Add(SeguroViaje);
            }
            reader.Close();
            reader.Dispose();
            return SeguroViajelist;
        }

        public List<SeguroViajeBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeguroViajeBE> SeguroViajelist = new List<SeguroViajeBE>();
            SeguroViajeBE SeguroViaje;
            while (reader.Read())
            {
                SeguroViaje = new SeguroViajeBE();
                SeguroViaje.IdSeguroViaje = Int32.Parse(reader["idSeguroViaje"].ToString());
                SeguroViaje.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                SeguroViaje.Numero = reader["Numero"].ToString();
                SeguroViaje.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                SeguroViaje.FechaLlegada = DateTime.Parse(reader["FechaLlegada"].ToString());
                SeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                SeguroViaje.Pais = reader["Pais"].ToString();
                SeguroViaje.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SeguroViaje.Dni = reader["Dni"].ToString();
                SeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                SeguroViaje.Solicitante = reader["Solicitante"].ToString();
                SeguroViaje.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                SeguroViaje.Direccion = reader["Direccion"].ToString();
                SeguroViaje.Distrito = reader["Distrito"].ToString();
                SeguroViaje.Telefono = reader["Telefono"].ToString();
                SeguroViaje.Email = reader["Email"].ToString();
                SeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                SeguroViaje.Cargo = reader["Cargo"].ToString();
                SeguroViaje.Contacto = reader["Contacto"].ToString();
                SeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                SeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                SeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                SeguroViaje.Ruc = reader["Ruc"].ToString();
                SeguroViaje.Autoriza = reader["Autoriza"].ToString();
                SeguroViaje.Oiseco = reader["Oiseco"].ToString();
                SeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                SeguroViaje.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                SeguroViaje.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SeguroViajelist.Add(SeguroViaje);
            }
            reader.Close();
            reader.Dispose();
            return SeguroViajelist;
        }

        public List<SeguroViajeBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SeguroViaje_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeguroViajeBE> SeguroViajelist = new List<SeguroViajeBE>();
            SeguroViajeBE SeguroViaje;
            while (reader.Read())
            {
                SeguroViaje = new SeguroViajeBE();
                SeguroViaje.IdSeguroViaje = Int32.Parse(reader["idSeguroViaje"].ToString());
                SeguroViaje.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SeguroViaje.RazonSocial = reader["RazonSocial"].ToString();
                SeguroViaje.Numero = reader["Numero"].ToString();
                SeguroViaje.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                SeguroViaje.FechaLlegada = DateTime.Parse(reader["FechaLlegada"].ToString());
                SeguroViaje.Dias = Int32.Parse(reader["Dias"].ToString());
                SeguroViaje.Pais = reader["Pais"].ToString();
                SeguroViaje.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SeguroViaje.Dni = reader["Dni"].ToString();
                SeguroViaje.Pasaporte = reader["Pasaporte"].ToString();
                SeguroViaje.Solicitante = reader["Solicitante"].ToString();
                SeguroViaje.FechaNacimiento = DateTime.Parse(reader["FechaNacimiento"].ToString());
                SeguroViaje.Direccion = reader["Direccion"].ToString();
                SeguroViaje.Distrito = reader["Distrito"].ToString();
                SeguroViaje.Telefono = reader["Telefono"].ToString();
                SeguroViaje.Email = reader["Email"].ToString();
                SeguroViaje.EmailPersonal = reader["EmailPersonal"].ToString();
                SeguroViaje.Cargo = reader["Cargo"].ToString();
                SeguroViaje.Contacto = reader["Contacto"].ToString();
                SeguroViaje.TelefonoContacto1 = reader["TelefonoContacto1"].ToString();
                SeguroViaje.TelefonoContacto2 = reader["TelefonoContacto2"].ToString();
                SeguroViaje.EmpresaBoleta = reader["EmpresaBoleta"].ToString();
                SeguroViaje.Ruc = reader["Ruc"].ToString();
                SeguroViaje.Autoriza = reader["Autoriza"].ToString();
                SeguroViaje.EmpresaFactura = reader["EmpresaFactura"].ToString();
                SeguroViaje.Oiseco = reader["Oiseco"].ToString();
                SeguroViaje.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                SeguroViaje.DescSituacion = reader["DescSituacion"].ToString();
                SeguroViaje.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SeguroViajelist.Add(SeguroViaje);
            }
            reader.Close();
            reader.Dispose();
            return SeguroViajelist;
        }

        
    }
}
