using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class PersonaAdryanDL
    {
        public PersonaAdryanDL() { }

        public List<PersonaAdryanBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnPERSONABD");
            String strSQL = "SELECT ROW_NUMBER()Over(Order by ID_TRABAJADOR ASc) AS Secuencia, LTRIM(RTRIM(NUM_DOCUMENTO)) AS DNI,NUM_RUC AS RUC_EMPRESA,NOM_DISTRITO_TRABAJO AS UNIDAD,NOM_UNIDAD AS SEDE,NOM_AREA AS AREA,NOM_COMPLETO,FEC_NACIMIENTO AS FECHA_NACIMIENTO,DATEDIFF(D,FEC_NACIMIENTO,GETDATE()) AS EDAD,ISNULL(FEC_INGRESO,'') AS FECHA_INGRESO,FEC_RETIRO AS FECHA_RETIRO,NOM_PUESTO AS PUESTO,NOM_GENERO AS SEXO, CASE DES_TIPO_CONTRATO WHEN '' THEN 'Incremento Actividad' ELSE DES_TIPO_CONTRATO END AS TIPO_CONTRATO,NOM_ESTADO_CIVIL AS ESTADO_CIVIL,DES_EMAIL AS EMAIL_TRABAJO,CASE IND_ACTIVO WHEN 1 THEN 'ACTIVO' ELSE 'INACTIVO' END AS SITUACION FROM TRABAJADOR_SAP";
            DbCommand dbCommand = db.GetSqlStringCommand(strSQL);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PersonaAdryanBE> PersonaAdryanlist = new List<PersonaAdryanBE>();
            PersonaAdryanBE PersonaAdryan;
            while (reader.Read())
            {
                PersonaAdryan = new PersonaAdryanBE();
                PersonaAdryan.SECUENCIA = Int32.Parse(reader["SECUENCIA"].ToString());
                PersonaAdryan.DNI = reader["DNI"].ToString();
                PersonaAdryan.RUC_EMPRESA = reader["RUC_EMPRESA"].ToString();
                PersonaAdryan.UNIDAD = reader["UNIDAD"].ToString();
                PersonaAdryan.SEDE = reader["SEDE"].ToString();
                PersonaAdryan.AREA = reader["AREA"].ToString();
                PersonaAdryan.APENOM = reader["NOM_COMPLETO"].ToString().Trim();
                PersonaAdryan.FECHA_NACIMIENTO = DateTime.Parse(reader["FECHA_NACIMIENTO"].ToString());
                PersonaAdryan.EDAD = Int32.Parse(reader["EDAD"].ToString());
                PersonaAdryan.FECHA_INGRESO = DateTime.Parse(reader["FECHA_INGRESO"].ToString());
                PersonaAdryan.FECHA_RETIRO = reader.IsDBNull(reader.GetOrdinal("FECHA_RETIRO")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FECHA_RETIRO"));
                PersonaAdryan.PUESTO = reader["PUESTO"].ToString();
                PersonaAdryan.SEXO = reader["SEXO"].ToString();
                PersonaAdryan.TIPO_CONTRATO = reader["TIPO_CONTRATO"].ToString();
                PersonaAdryan.ESTADO_CIVIL = reader["ESTADO_CIVIL"].ToString();
                PersonaAdryan.EMAIL_TRABAJO = reader["EMAIL_TRABAJO"].ToString();
                PersonaAdryan.SITUACION = reader["SITUACION"].ToString();
                PersonaAdryanlist.Add(PersonaAdryan);
            }
            reader.Close();
            reader.Dispose();
            return PersonaAdryanlist;
        }

    }
}
