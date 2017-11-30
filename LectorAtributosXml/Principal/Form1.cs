using System;
using Dominio;
using System.Windows.Forms;
using System.Data;

namespace Principal
{
    public partial class Form1 : Form
    {
        private DataTable dt = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            var ruta = openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == null)
            {

            }
            txtRutaArchivo.Text = openFileDialog1.FileName;

            DocumentoElectronico documento = new LectorXml().LeerXML(txtRutaArchivo.Text);

            if (documento != null)
            {
                DataColumn column;

                #region
                if (dt.Rows.Count == 0)
                {
                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Int32");
                    column.ColumnName = "CodDoc";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "Autorizacion";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "ClaveAcceso";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = System.Type.GetType("System.String");
                    column.ColumnName = "Establecimiento";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "PuntoEmision";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "FechaEmision";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.String");
                    column.ColumnName = "NumeroSecuencia";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "BaseFte";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "PorRetFte";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "ValorFte";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "BaseIva";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "PorRetIva";
                    dt.Columns.Add(column);

                    column = new DataColumn();
                    column.DataType = Type.GetType("System.Decimal");
                    column.ColumnName = "ValorIva";
                    dt.Columns.Add(column);
                }

                #endregion

                DataRow row = dt.NewRow();

                row["CodDoc"] = documento.TipoDocumento;
                row["Autorizacion"] = documento.Autorizacion;
                row["ClaveAcceso"] = documento.ClaveAcceso;
                row["Establecimiento"] = documento.Establecimiento;
                row["PuntoEmision"] = documento.PuntoEmision;
                row["FechaEmision"] = documento.FechaEmision;

                row["NumeroSecuencia"] = documento.NumeroSecuencia;
                row["BaseFte"] = documento.BaseImponibleFuente;
                row["PorRetFte"] = documento.PorcentajeRetencionFuente;
                row["ValorFte"] = documento.ValorRetencionFuente;

                row["BaseIva"] = documento.BaseImponibleIva;
                row["PorRetIva"] = documento.PorcentajeRetencionIva;
                row["ValorIva"] = documento.ValorRetencionIva;

                dt.Rows.Add(row);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
