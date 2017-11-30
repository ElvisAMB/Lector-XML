namespace Dominio
{
    public class DocumentoElectronico
    {
        public string Autorizacion { get; set; }
        public string Ambiente { get; set; }
        public string Estado { get; set; }
        public string Comprobante { get; set; }
        public string FechaAutorizacion { get; set; }
        public string InformacionTributaria { get; set; }
        public string ClaveAcceso { get; set; }
        public string IdentificacionEmisor { get; set; }
        public string Establecimiento { get; set; }
        public string PuntoEmision { get; set; }
        public string FechaEmision { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroSecuencia { get; set; }
        public string RazonSocialComprador { get; set; }
        public string IdentificacionComprador { get; set; }
        public string Objeto { get; set; }
        //Campos Adicionales
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string ValorEnLetras { get; set; }
        public string Motivo { get; set; }
        //Para los datos de los impuestos (Retenciones)
        public float BaseImponibleFuente { get; set; }
        public float BaseImponibleIva { get; set; }
        public float PorcentajeRetencionFuente { get; set; }
        public float PorcentajeRetencionIva { get; set; }
        public float ValorRetencionFuente { get; set; }
        public float ValorRetencionIva { get; set; }

        public override string ToString()
        {
            return "-----------------Retención------------------\n ID= " + Autorizacion; // + "\n Nombre=" + NombreJuego + "\n Genero= " + GeneroJuego + "\n Compañia= " + CompaniaCreadora + "\n----------------------------------------";
        }


    }
}
