using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SSOMA.BusinessEntity
{
    [DataContract]
    public class AccidenteCostoBE
    {
        #region "Atributos"
        [DataMember]
        public Int32 IdAccidenteCosto { get; set; }
        [DataMember]
        public Int32 IdAccidente { get; set; }
        [DataMember]
        public Int32 DiasPerdido { get; set; }
        [DataMember]
        public Decimal CostoDia { get; set; }
        [DataMember]
        public Decimal TotalCostoDia { get; set; }
        [DataMember]
        public Int32 HorasExtra { get; set; }
        [DataMember]
        public Decimal CostoHorasExtra { get; set; }
        [DataMember]
        public Decimal TotalCostoHorasExtra { get; set; }
        [DataMember]
        public Decimal CostoEnergia { get; set; }
        [DataMember]
        public Int32 TiempoTrabajado { get; set; }
        [DataMember]
        public Decimal Salario { get; set; }
        [DataMember]
        public Decimal SubTotalReemplazo { get; set; }
        [DataMember]
        public Decimal ReadaptacionTrabajo { get; set; }
        [DataMember]
        public Decimal ReingresoAccidentado { get; set; }
        [DataMember]
        public Decimal ParalizacionMaquina { get; set; }
        [DataMember]
        public Decimal ManoObra { get; set; }
        [DataMember]
        public Decimal Repuestos { get; set; }
        [DataMember]
        public Decimal TiempoPerdidoTotal { get; set; }
        [DataMember]
        public Int32 NumeroTrabajadores { get; set; }
        [DataMember]
        public Decimal SalarioPromedio { get; set; }
        [DataMember]
        public Decimal SubTotalSalario { get; set; }
        [DataMember]
        public Int32 TiempoPerdidoSupervisor { get; set; }
        [DataMember]
        public Decimal CostoHoraSupervisor { get; set; }
        [DataMember]
        public Decimal CostoTotalSupervisor { get; set; }
        [DataMember]
        public Decimal CostoTotalAccidentado { get; set; }
        [DataMember]
        public Decimal CostoAdministrativo { get; set; }
        [DataMember]
        public Decimal CostoTraslado { get; set; }
        [DataMember]
        public Decimal CostoEnfermo { get; set; }
        [DataMember]
        public Decimal CostoMaterial { get; set; }
        [DataMember]
        public Decimal CostoParamedico { get; set; }
        [DataMember]
        public Decimal CostoDiverso { get; set; }
        [DataMember]
        public Decimal CostoTotal { get; set; }
        [DataMember]
        public Boolean FlagEstado { get; set; }
        [DataMember]
        public String Usuario { get; set; }
        [DataMember]
        public String Maquina { get; set; }
        [DataMember]
        public Int32 IdEmpresa { get; set; }
        [DataMember]
        public Int32 TipoOper { get; set; }
        #endregion
    }
}
