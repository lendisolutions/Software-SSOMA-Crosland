using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSOMA.BusinessLogic
{
    public class Parametros
    {
        //Tabla
        public static int intTblTipoEmpresa = 1;
        public static int intTblEstadoCivil = 2;
        public static int intTblTipoContrato = 3;
        public static int intTblSituacionSolicitudEpp = 4;
        public static int intTblSituacionPersona = 6;
        public static int intTblClaseCapacitacion = 7;
        public static int intTblResponsableCapacitacion = 8;
        public static int intTblClasificacionCapacitacion = 9;
        public static int intTblProgramaAnualCapacitacion = 10;
        public static int intTblPotencialDaño = 11;
        public static int intTblGradoAccidente = 12;
        public static int intTblProbablidadOcurrencia = 13;


        //Tipo de Empresa

        public static int intTECorporativo = 1;
        public static int intTEContratista = 2;
        public static int intTEProveedor = 3;

        //Situacion Solicitud EPP

        public static int intSLCPendiente = 9;
        public static int intSLCAtendido = 10;
        public static int intSLCAnulado = 11;

        //CONDICION DESCANSO MEDICO
        public static int intDMActico = 1;
        public static int intDMCesado = 2;
        public static int intDMVacaciones = 3;
        public static int intDM = 4;
    }
}
