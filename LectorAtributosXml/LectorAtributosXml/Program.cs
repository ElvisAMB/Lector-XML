using Dominio;
using System;


namespace LectorAtributosXml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Se procede a leer el archivo xml");
            //DocumentoElectronico documento = new LectorXml().LeerXML(@"H:\CONFIANZA\Retenciones SIP contra Dax\Comprobante de Retención Cliente Externo.xml");
            //DocumentoElectronico documento = new LectorXml().LeerXML(@"H:\CONFIANZA\Retenciones SIP contra Dax\FacturaPrueba.xml");
            //DocumentoElectronico documento = new LectorXml().LeerXML(@"H:\ArchivosXml\Canje\Fact_002_007_0030135.xml");
            DocumentoElectronico documento = new LectorXml().LeerXML(@"H:\ArchivosXml\Prueba Canje NotaCredito\IEXT_00000000000000000100_2016519_1681.xml");

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
                Console.WriteLine("PuntoEmision:" + documento.PuntoEmision + "\r");
                Console.WriteLine("Número de Retención:" + documento.Establecimiento + "-" + documento.PuntoEmision + "-" + documento.NumeroSecuencia + "\r");
            }

            Console.ReadLine();

            //    var tabla = new LectorXml().BuildDataTableFromXml("", "", @"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml");

            //    Console.ReadLine();

            //    var tuple = Tuple.Create("cat", 2, true);

            //    // Test value of string.
            //    string value = tuple.Item1;
            //    if (value == "cat")
            //    {
            //        Console.WriteLine(true);
            //    }

            //    // Test Item2 and Item3.
            //    Console.WriteLine(tuple.Item2 == 10);
            //    Console.WriteLine(!tuple.Item3);

            //    // Write string representation.
            //    Console.WriteLine(tuple);

            //    Console.ReadLine();

            //    var opcion = true;
            //    do
            //    {
            //        Console.WriteLine("Por favor ingrese una fecha:\n\r");
            //        var horaIngresada = Console.ReadLine();
            //        DateTime horaConvertida;
            //        if (DateTime.TryParse(horaIngresada, out horaConvertida))
            //        {
            //            Console.WriteLine(horaIngresada);
            //        }
            //        else
            //        {
            //            Console.WriteLine("La hora ingresada " + horaIngresada + ", no es válida.");
            //        }

            //        Console.WriteLine("¿Desea volver a intentarlo s[SI] o n [NO]?");
            //        var caracter = Console.ReadLine();

            //        opcion = true;
            //        if (caracter.ToUpper() == "N")
            //        {
            //            opcion = false;
            //        }

            //        Console.Clear();
            //    } while (opcion);
            //}


            //DocumentoElectronico x = new LectorXml().ObtenerXml();
            //new LectorXml().ObtenerDatosXml();
            /*
            foreach (Juego juego in new XMLReader().leerXML())
            {
                Console.WriteLine(juego);
            }//Fin de foreach.
            */

            //foreach (DocumentoElectronico doc in new XMLReader().LeerXMLElectrónico())
            //{
            //    Console.WriteLine(doc);
            //}//Fin de foreach.

            //new LectorXml().leerXml();

            Console.ReadLine();

        }
    }
}