﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LectorAtributosXml
{
    public class LectorXml
    {
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
    }
}
