using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Principal
{
    public class LectorXml
    {
        /*
        public DocumentoElectronico LeerXML(string ruta)
        {
            DocumentoElectronico documento = new DocumentoElectronico();
            int codigoRetencion = 0;
            try
            {
                XmlReader xml = XmlReader.Create(ruta);
                XmlReader xmlComprobante = default(XmlReader);
                //XmlReader xmlInfoTributaria = default(XmlReader);

                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        switch (xml.Name)
                        {
                            case "numeroAutorizacion":
                                documento.Autorizacion = xml.ReadElementString();
                                break;
                            case "comprobante":
                                documento.Comprobante = xml.ReadElementString();
                                break;
                            case "ambiente":
                                documento.Ambiente = xml.ReadElementString();
                                break;
                            case "estado":
                                documento.Estado = xml.ReadElementString();
                                break;
                            case "fechaAutorizacion":
                                documento.FechaAutorizacion = xml.ReadElementString();
                                break;
                        }
                    }
                }

                if (documento.Comprobante != null)
                {
                    xmlComprobante = XmlReader.Create(new StringReader(documento.Comprobante));

                    while (xmlComprobante.Read())
                    {
                        if (xmlComprobante.NodeType == XmlNodeType.Element)
                        {
                            //Console.WriteLine("Nombre: " + xmlComprobante.Name + " => " + xmlComprobante.ReadElementString());

                            switch (xmlComprobante.Name)
                            {
                                case "claveAcceso":
                                    documento.ClaveAcceso = xmlComprobante.ReadElementString();
                                    break;
                                case "ruc":
                                        documento.IdentificacionEmisor = xmlComprobante.ReadElementString();
                                        break;
                                case "estab":
                                    documento.Establecimiento = xmlComprobante.ReadElementString();
                                    break;
                                case "ptoEmi":
                                    documento.PuntoEmision = xmlComprobante.ReadElementString();
                                    break;
                                case "fechaEmision":
                                        documento.FechaEmision = xmlComprobante.ReadElementString();
                                        break;
                                case "codDoc":
                                    documento.TipoDocumento = int.Parse(xmlComprobante.ReadElementString());
                                    break;
                                case "secuencial":
                                    documento.NumeroSecuencia = xmlComprobante.ReadElementString();
                                    break;
                                case "razonSocialComprador":
                                    documento.RazonSocialComprador = xmlComprobante.ReadElementString();
                                    break;
                                case "identificacionComprador":
                                    documento.IdentificacionComprador = xmlComprobante.ReadElementString();
                                    break;
                                case "motivo":
                                    documento.Objeto = xmlComprobante.ReadElementString();
                                    break;
                                case "campoAdicional":
                                    if (xmlComprobante.GetAttribute("nombre") == "Direccion")
                                        documento.Direccion = xmlComprobante.ReadElementString();
                                    if (xmlComprobante.GetAttribute("nombre") == "Email")
                                        documento.Email = xmlComprobante.ReadElementString();
                                    if (xmlComprobante.GetAttribute("nombre") == "ValorLetras")
                                        documento.ValorEnLetras = xmlComprobante.ReadElementString();
                                    if (xmlComprobante.GetAttribute("nombre") == "Motivo")
                                        documento.Objeto = xmlComprobante.ReadElementString();
                                    break;
                                case "codigo":
                                    if (documento.TipoDocumento == 7)
                                    {
                                        codigoRetencion = int.Parse(xmlComprobante.ReadElementString());
                                    }
                                    break;
                                case "baseImponible":
                                    if (documento.TipoDocumento == 7)
                                    {
                                        if (codigoRetencion == 1)
                                        {
                                            documento.BaseImponibleFuente = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                        if (codigoRetencion == 2)
                                        {
                                            documento.BaseImponibleIva = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                    }
                                    break;
                                case "porcentajeRetener":
                                    if (documento.TipoDocumento == 7)
                                    {
                                        if (codigoRetencion == 1)
                                        {
                                            documento.PorcentajeRetencionFuente = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                        if (codigoRetencion == 2)
                                        {
                                            documento.PorcentajeRetencionIva = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                    }
                                    break;
                                case "valorRetenido":
                                    if (documento.TipoDocumento == 7)
                                    {
                                        if (codigoRetencion == 1)
                                        {
                                            documento.ValorRetencionFuente = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                        if (codigoRetencion == 2)
                                        {
                                            documento.ValorRetencionIva = float.Parse(xmlComprobante.ReadElementString());
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido un error durante la importacion del XML, por favor cargar un XML adecuado. El Error fue: " + ex.Message);
            }

            return documento;
        }
        */
        public DataTable BuildDataTableFromXml(string Name, string XMLString, string ruta)
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(ruta);
            }
            catch (XmlException e)
            {
                Console.WriteLine(e.Message);
            }
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmlDoc.WriteTo(xw);
            sw.ToString();



            XmlDocument doc = new XmlDocument();

            doc.Load(new StringReader("<ProductInfo><Product><Name>Test1</Name><index>0</index></Product><Product><Name>Test2</Name><index>1</index></Product><Product><Name>Test3</Name><index>2</index></Product></ProductInfo>"));
            DataTable Dt = new DataTable(Name);
            try
            {
                XmlNode NodoEstructura = doc.FirstChild.FirstChild;
                //  Table structure (columns definition) 
                foreach (XmlNode columna in NodoEstructura.ChildNodes)
                {
                    Dt.Columns.Add(columna.Name, typeof(String));
                }

                XmlNode Filas = doc.FirstChild;
                //  Data Rows 
                foreach (XmlNode Fila in Filas.ChildNodes)
                {
                    List<string> Valores = new List<string>();
                    foreach (XmlNode Columna in Fila.ChildNodes)
                    {
                        Valores.Add(Columna.InnerText);
                    }
                    Dt.Rows.Add(Valores.ToArray());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Dt;
        }
        public DocumentoElectronico ObtenerXml()
        {
            DocumentoElectronico datos = new DocumentoElectronico();

            XmlDocument xDoc = new XmlDocument();

            //La ruta del documento XML permite rutas relativas 
            //respecto del ejecutable!

            xDoc.Load(@"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml");

            XmlNodeList personas = xDoc.GetElementsByTagName("autorizacion");

            XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("autorizacion");

            foreach (XmlElement nodo in lista)
            {

                int i = 0;

                XmlNodeList nCodigoDocumento = nodo.GetElementsByTagName("codDoc");

                XmlNodeList nEstablecimiento = nodo.GetElementsByTagName("estab");

                XmlNodeList nPuntoEmision = nodo.GetElementsByTagName("ptoEmi");
                XmlNodeList nSecuencial = nodo.GetElementsByTagName("secuencial");

                Console.WriteLine("Elemento nombre ... {0} {1} {2} {3}", nCodigoDocumento[i].InnerText, nEstablecimiento[i].InnerText, nPuntoEmision[i++].InnerText, nSecuencial[i].InnerText);

            }
            return datos;
        }
        public void ObtenerDatosXml()
        {
            //var consulta = from documento in XmlElement.Load(@"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml").Elements("");

            /*

                    var consulta =
                    from juego in XElement.Load("C:\\Users\\Pablo\\Desktop\\XML\\Juegos.XML").Elements("juego")//Ponemos la direccion del archivo y el nombre de los elementos que queremos obtener
                    select new Juego
                    {
                    IdJuego = Convert.ToInt32(Convert.ToString(juego.Attribute("id").Value).Trim()),
                    NombreJuego = Convert.ToString(juego.Element("nombre").Value).Trim(),
                    GeneroJuego = Convert.ToString(juego.Element("genero").Value).Trim(),
                    PlataformaJuego = Convert.ToString(juego.Element("plataforma").Value).Trim(),
                    CompaniaCreadora = Convert.ToString(juego.Element("companiaCreadora").Value).Trim()
                    };//Fin de consulta.
                    List<Juego> juegos = consulta.ToList<Juego>();
            */
        }
        public void leerXml()
        {
            string path = @"H:\ArchivosXml\RetencionPrueba\IEXT_00000000000000219571_2017821_1540.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(DocumentoElectronico));
            StreamReader reader = new StreamReader(path);

            var libros = (DocumentoElectronico)serializer.Deserialize(reader);
            reader.Close();
        }

        public DocumentoElectronico LeerXML(string ruta)
        {
            DocumentoElectronico _respuesta = new DocumentoElectronico();
            int codigoRetencion = 0;
            try
            {
                XDocument xdoc = XDocument.Load(ruta);

                var node = xdoc.DescendantNodes().Single(el => el.NodeType == XmlNodeType.CDATA);
                var content = node.Parent.Value.Trim();

                var xdoc_cdata = XDocument.Parse(content);

                //Run query
                var comp = from info in xdoc_cdata.Descendants("comprobanteRetencion")
                           select new
                           {
                               TipoDocumento = info.Descendants("infoTributaria").Single().Element("codDoc").Value,
                               Autorizacion = xdoc.Element("autorizacion").Element("numeroAutorizacion").Value,
                               ClaveAcceso = info.Descendants("infoTributaria").Single().Element("claveAcceso").Value,
                               Establecimiento = info.Descendants("infoTributaria").Single().Element("estab").Value,
                               PuntoEmision = info.Descendants("infoTributaria").Single().Element("ptoEmi").Value,
                               FechaEmision = info.Descendants("infoCompRetencion").Single().Element("fechaEmision").Value,
                               NumeroSecuencia = info.Descendants("infoTributaria").Single().Element("secuencial").Value,
                               BaseImponibleFuente = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "1" && s.Element("codigoRetencion").Value == "322").Select(t => t.Element("baseImponible").Value).SingleOrDefault(), //impuestos codigo 1
                               BaseImponibleIva = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "2" ).Select(t => t.Element("baseImponible").Value).SingleOrDefault(), //impuestos codigo 2
                               PorcentajeRetencionFuente = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "1" && s.Element("codigoRetencion").Value == "322").Select(t => t.Element("porcentajeRetener").Value).SingleOrDefault(),
                               PorcentajeRetencionIva = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "2").Select(t => t.Element("porcentajeRetener").Value).SingleOrDefault(),
                               ValorRetencionFuente = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "1" && s.Element("codigoRetencion").Value == "322").Select(t => t.Element("valorRetenido").Value).SingleOrDefault(),
                               ValorRetencionIva = info.Descendants("impuestos").Descendants("impuesto").Where(s => s.Element("codigo").Value == "2").Select(t => t.Element("valorRetenido").Value).SingleOrDefault()
                           };

                if (comp != null)
                {
                    _respuesta.TipoDocumento = int.Parse(comp.Select(x => x.TipoDocumento).FirstOrDefault());
                    _respuesta.Autorizacion = (comp.Select(x => x.Autorizacion).FirstOrDefault());
                    _respuesta.ClaveAcceso = (comp.Select(x => x.ClaveAcceso).FirstOrDefault());
                    _respuesta.Establecimiento = (comp.Select(x => x.Establecimiento).FirstOrDefault());
                    _respuesta.PuntoEmision = (comp.Select(x => x.PuntoEmision).FirstOrDefault());
                    _respuesta.FechaEmision = (comp.Select(x => x.FechaEmision).FirstOrDefault());
                    _respuesta.NumeroSecuencia = (comp.Select(x => x.NumeroSecuencia).FirstOrDefault());
                    _respuesta.BaseImponibleFuente = (comp.Select(x => x.BaseImponibleFuente).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.BaseImponibleFuente).FirstOrDefault()) : 0);
                    _respuesta.BaseImponibleIva = (comp.Select(x => x.BaseImponibleIva).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.BaseImponibleIva).FirstOrDefault()) : 0);
                    _respuesta.PorcentajeRetencionFuente = (comp.Select(x => x.PorcentajeRetencionFuente).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.PorcentajeRetencionFuente).FirstOrDefault()) : 0);
                    _respuesta.PorcentajeRetencionIva = (comp.Select(x => x.PorcentajeRetencionIva).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.PorcentajeRetencionIva).FirstOrDefault()) : 0);
                    _respuesta.ValorRetencionFuente = (comp.Select(x => x.ValorRetencionFuente).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.ValorRetencionFuente).FirstOrDefault()) : 0);
                    _respuesta.ValorRetencionIva = (comp.Select(x => x.ValorRetencionIva).FirstOrDefault() != null ? float.Parse(comp.Select(x => x.ValorRetencionIva).FirstOrDefault()) : 0);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("C:\\log_interop.txt", true))
                {
                    writer.WriteLine("Error en la carga del archivo xml " + ex.Message);
                }
            }

            return _respuesta;
        }
    }
}
