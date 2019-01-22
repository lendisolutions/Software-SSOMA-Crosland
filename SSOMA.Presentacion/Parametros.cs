using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.BusinessLogic;

namespace SSOMA.Presentacion
{
    public class Parametros
    {
        public static List<AccesoUsuarioBE> pListaPermisoAcceso = new List<AccesoUsuarioBE>();
        
        public static string Key = "YUXTAPUESTO/ARIN";
        public static string IV = "kabosilva0123456";

        public static DateTime dtFechaHoraServidor = DateTime.Today;

        public static string sIdDepartamento = "15"; //LIMA
        public static string sIdProvincia = "01"; //LIMA
        public static string sIdDistrito = "01"; //LIMA

        public static string strContactoSeguroViaje = "MONTEVERDE LUQUE ZARELLA LIZBETH";
        public static string strContactoTelefono = "989059808";

        public static int intPerfilId = 0;
        public static int intMenuId = 23;
        public static string strNomPerfil = "";
        public static int intUsuarioId = 0;
        public static int intPeriodo = DateTime.Today.Year;
        public static string strUsuarioLogin = "";
        public static string strUsuarioNombres = "";
        public static string strUsuarioApellidos = "";
        public static int intEmpresaId = 1;
        public static int intUnidadMineraId = 1;
        public static int intAreaId = 1;
        public static int intPersonaId = 1;
        public static int intTiendaId = 1;
        public static string strDescTienda = "";
        public static string strEmpresaNombre = "";
        public static string strUnidadNombre = "";
        public static int intNinguno = 0;


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
        public static int intTblTipoInvestigacion = 14;
        public static int intTblSituacionAccionCorrectiva = 17;
        public static int intTblSituacionDetalleInspeccionTrabajo = 18;
        public static int intTblTipoDocumentoProveedor = 19;
        public static int intTblDañoAccidente = 20;
        public static int intTblTipoInspeccionExtintor = 21;
        public static int intTblSituacionEPS = 22;
        public static int intTblSituacionSeguroViaje = 23;
        public static int intTblSituacionSeguroSCTR = 24;
        public static int intTblOrdenInterna = 25;
        //TIPO DE EMPRESA

        public static int intTECorporativo = 1;
        public static int intTEContratista = 2;
        public static int intTEProveedor = 3;

        //SITUACION PERSONA
        public static int intSPActivo = 14;
        public static int intSPCesado = 15;

        //SITUACION SOLICITUD EPP

        public static int intSLCPendiente = 9;
        public static int intSLCAtendido = 10;
        public static int intSLCAnulado = 11;
        
        //TIPO DE ENTREGA EPP
        public static int intTENuevo = 1;
        public static int intTEPerdido = 2;
        public static int intTEReposicion = 3;

        //TIPO DE CAPACITACION
        public static int intTCCapacitacionGeneral = 1;
        public static int intTCCapacitacionEspecifica = 5;
        public static int intTCEntrenamiento = 4;
        public static int intTCSensibilizacion = 2;

        //CLASIFICACION CAPACITACION
        public static int intCCSeguridadIndustrial = 29;
        public static int intCCSaludOcupacional = 30;
        public static int intCCMedioAmbiente = 31;
        public static int intCCOtros = 32;

        //SITUACION PROGRAMA ANUAL DE CAPACITACION
        public static int intSCPendiente = 40;
        public static int intSCCerrado = 41;

        //POTENCIAL DAÑO
        public static int intPDMortal = 42;
        public static int intPDIncapacitante = 43;
        public static int intPDLeve = 44;

        //GRADO DEL ACCIDENTE
        public static int intGATotalPermanente = 45;
        public static int intGAParcialPermanente = 46;
        public static int intGAParcialTemporal = 47;
        public static int intGATotalTemporal = 48;
        public static int intGANinguno = 49;

        //PROBABILIDAD DE OCURRENCIA
        public static int intPOAlta = 50;
        public static int intPOMedia = 51;
        public static int intPOBaja = 52;

        //TIPO DE INVESTIGACION
        public static int intTIIncidente = 53;
        public static int intTIAccidente = 54;
        public static int intTIIncidentePeligroso = 61;

        //SITUACION ACCION CORRECTIVA
        public static int intACCPendiente = 55;
        public static int intACCEjecutado = 56;
        public static int intACCProceso = 66;

        //SITUACION DETALLE INSPECCION TRABAJO
        public static int intDITPendiente = 57;
        public static int intDITEjecutado = 58;
        public static int intDITProceso = 59;

        //TIPO DE INSPECCION
        public static int intTIPlaneada = 1;
        public static int intTINoPlaneada = 2;

        //TIPO DOCUMENTO PROVEEDOR
        public static int intPROVRuc = 59;

        //DAÑO ACCIDENTE
        public static int intDACTrabajador = 62;
        public static int intDACTMaterial = 63;

        //TIPO DE INSPECCION EXTINTOR
        public static int intTIEPlaneada = 64;
        public static int intTIENoPlaneada = 65;

        //CONDICION DESCANSO MEDICO
        public static int intDMActico = 1;
        public static int intDMCesado = 2;
        public static int intDMVacaciones = 3;
        public static int intDM = 4;


        //SITUACIÓN SOLICITUD DE INFORMACIÓN DE EPS
        public static int intSCEPSGenerada = 67;
        public static int intSCEPSAtendida = 68;
        public static int intSCEPSAnulada = 69;

        //SITUACIÓN SEGURO DE VIAJE
        public static int intSVJGenerada = 70;
        public static int intSVJSAtendida = 71;
        public static int intSVJSAnulada = 72;

        //SITUACIÓN SEGURO DE SCTR
        public static int intSCTRGenerada = 73;
        public static int intSCTRAtendida = 74;
        public static int intSCTRAnulada = 75;

        //EMPRESA CONTRISTA
        public static int intEmpresaContratistaNinguno = 13;

    }
}
