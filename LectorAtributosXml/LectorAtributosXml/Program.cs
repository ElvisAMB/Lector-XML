using System;


namespace LectorAtributosXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Se procede a leer el archivo xml");
            DocumentoElectronico documento = new LectorXml().LeerXML(@"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml");
            if (documento != null)
            {
                Console.WriteLine("Autorizacion:" + documento.Autorizacion + "\r");
                Console.WriteLine("Secuencia:" + documento.NumeroSecuencia + "\r");
                Console.WriteLine("Establecimiento:" + (documento.Establecimiento == "001" ? "Guayaquil" : (documento.Establecimiento == "002" ? "Quito" : (documento.Establecimiento == "003" ? "Cuenca" : ""))) + "\r");
                Console.WriteLine("FechaEmision:" + documento.FechaEmision + "\r");
                Console.WriteLine("Direccion:" + documento.Direccion + "\r");
                Console.WriteLine("TipoDocumento:" + documento.TipoDocumento + "\r");
                Console.WriteLine("BaseImponibleFuente:" + documento.BaseImponibleFuente + "\r");
                Console.WriteLine("BaseImponibleIva:" + documento.BaseImponibleIva + "\r");
                Console.WriteLine("PorcentajeRetencionFuente:" + documento.PorcentajeRetencionFuente + "\r");
                Console.WriteLine("PorcentajeRetencionIva:" + documento.PorcentajeRetencionIva + "\r");
                Console.WriteLine("ValorRetencionFuente:" + documento.ValorRetencionFuente + "\r");
                Console.WriteLine("ValorRetencionIva:" + documento.ValorRetencionIva + "\r");
            }

            Console.ReadLine();

            var tabla = new LectorXml().BuildDataTableFromXml("", "", @"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml");

            Console.ReadLine();

            var tuple = Tuple.Create("cat", 2, true);

            // Test value of string.
            string value = tuple.Item1;
            if (value == "cat")
            {
                Console.WriteLine(true);
            }

            // Test Item2 and Item3.
            Console.WriteLine(tuple.Item2 == 10);
            Console.WriteLine(!tuple.Item3);

            // Write string representation.
            Console.WriteLine(tuple);

            Console.ReadLine();

        }
    }
}
