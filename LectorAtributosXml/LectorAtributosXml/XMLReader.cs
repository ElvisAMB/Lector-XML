using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LectorAtributosXml
{
    public class XMLReader
    {
        public List<Juego> leerXML()
        {
            var consulta =
                from juego in XElement.Load(@"H:\CONFIANZA\Retenciones SIP contra Dax\ArchivoPruebaSencillo.xml").Elements("juego")
                select new Juego
                {
                    IdJuego = Convert.ToInt32(Convert.ToString(juego.Attribute("id").Value).Trim()),
                    NombreJuego = Convert.ToString(juego.Element("nombre").Value).Trim(),
                    GeneroJuego = Convert.ToString(juego.Element("genero").Value).Trim(),
                    PlataformaJuego = Convert.ToString(juego.Element("plataforma").Value).Trim(),
                    CompaniaCreadora = Convert.ToString(juego.Element("companiaCreadora").Value).Trim()
                };//Fin de consulta.
            List<Juego> juegos = consulta.ToList<Juego>();
            return juegos;
        }//Fin de metdo leerXML.

        public List<DocumentoElectronico> LeerXMLElectrónico()
        {
            var consulta =
                from juego in XElement.Load(@"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml").Elements("comprobante")
                select new DocumentoElectronico
                {
                    //Estado = Convert.ToInt32(Convert.ToString(juego.Attribute("estado").Value).Trim()),
                    Autorizacion = Convert.ToString(juego.Element("numeroAutorizacion").Value).Trim(),
                    //GeneroJuego = Convert.ToString(juego.Element("genero").Value).Trim(),
                    //PlataformaJuego = Convert.ToString(juego.Element("plataforma").Value).Trim(),
                    //CompaniaCreadora = Convert.ToString(juego.Element("companiaCreadora").Value).Trim()
                };//Fin de consulta.
            List<DocumentoElectronico> juegos = consulta.ToList<DocumentoElectronico>();

            return juegos;
        }//Fin de metdo leerXML.




    }
}//Fin de clase.}
