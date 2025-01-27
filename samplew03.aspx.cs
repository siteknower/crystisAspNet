using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using CrystisWeb;

public partial class samplew03 : System.Web.UI.Page
{
    public DataSet dst;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind the GridView with data from the DataSet
            dst = GetData();
            ViewState["ItemsData"] = dst; // Store the dataset in ViewState
            GridView1.DataSource = dst.Tables["InvItems"];
            GridView1.DataBind();

            DataTable dtd = dst.Tables["Dummy"];
            txtCustomer.Text = dtd.Rows[0]["Text1"].ToString();
        }
        else
        {
            // Retrieve the dataset from ViewState on postback
            dst = (DataSet)ViewState["ItemsData"];
        }
    }

    private DataSet GetData()
    {
        DataSet dsInvoice = new DataSet();
        dsInvoice.Tables.Add(new DataTable("InvItems"));
        DataTable dt = dsInvoice.Tables["InvItems"];
        dt.Columns.Add("Id", typeof(string));
        dt.Columns.Add("Code", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Amount", typeof(double));
        dt.Columns.Add("Price", typeof(double));
        dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };

        dsInvoice.Tables.Add(new DataTable("Dummy"));
        DataTable dtd = dsInvoice.Tables["Dummy"];
        dtd.Columns.Add("Text1", typeof(string));

        DataRow dr;
        dr = dt.NewRow();
        dr["Id"] = Guid.NewGuid().ToString();
        dr["Code"] = "BB8527";
        dr["Name"] = "Bread";
        dr["Amount"] = 1;
        dr["Price"] = 2.15;
        dsInvoice.Tables["InvItems"].Rows.Add(dr);
        dr.EndEdit();
        dr = dt.NewRow();
        dr["Id"] = Guid.NewGuid().ToString();
        dr["Code"] = "SA482";
        dr["Name"] = "Chocolate";
        dr["Amount"] = 2;
        dr["Price"] = 7.65;
        dsInvoice.Tables["InvItems"].Rows.Add(dr);
        dr.EndEdit();
        dr = dt.NewRow();
        dr["Id"] = Guid.NewGuid().ToString();
        dr["Code"] = "QCI24";
        dr["Name"] = "Cheese";
        dr["Amount"] = 1;
        dr["Price"] = 2.08;
        dsInvoice.Tables["InvItems"].Rows.Add(dr);
        dr.EndEdit();
        dr = dt.NewRow();
        dr["Id"] = Guid.NewGuid().ToString();
        dr["Code"] = "MOX58";
        dr["Name"] = "Juice";
        dr["Amount"] = 1;
        dr["Price"] = 3.55;
        dsInvoice.Tables["InvItems"].Rows.Add(dr);
        dr.EndEdit();
        dr = dt.NewRow();
        dr["Id"] = Guid.NewGuid().ToString();
        dr["Code"] = "PB154";
        dr["Name"] = "Milk";
        dr["Amount"] = 3;
        dr["Price"] = 7.87;
        dsInvoice.Tables["InvItems"].Rows.Add(dr);
        dr.EndEdit();

        dr = dtd.NewRow();
        dr["Text1"] = "Phoenixer inc.";
        dsInvoice.Tables["Dummy"].Rows.Add(dr);
        dr.EndEdit();

        return dsInvoice;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

        clsCrystisClassWeb tsi = new clsCrystisClassWeb();

        dst.Tables["Dummy"].Rows[0]["Text1"] = txtCustomer.Text;

        tsi.dsRPT = dst;
        string binPath = HttpContext.Current.Server.MapPath("~/bin");
        tsi.ReportFullName = System.IO.Path.Combine(binPath, "InvoiceReport.rpt");

        tsi.AccountCode = "DEMO1";
        tsi.UserCode = "0000";

        tsi.ShowWindow(this, HttpContext.Current);
    }

    protected void btnSaveSchema_Click(object sender, EventArgs e)
    {
        string schemaXml = "";

        // Generate the XML schema as a string
        using (StringWriter sw = new System.IO.StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(sw))
            {
                // Assuming dsInvoice is your DataSet
                dst.WriteXmlSchema(xmlWriter);
            }
            schemaXml = sw.ToString();
        }

        // Prepare the file for download
        Response.Clear();
        Response.ContentType = "application/xml";
        Response.AddHeader("Content-Disposition", "attachment; filename=schema.xml");
        Response.Write(schemaXml);
        Response.End();
    }


    //The simplest example for displaying a Crystal Report from a web page.
}
