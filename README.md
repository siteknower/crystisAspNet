# crystisAspNet Example Application

This repository demonstrates how to integrate Crystal Reports into ASP.NET applications using `crystis for AspNet`, a powerful tool designed for web developers.

## About crystis for AspNet

`crystisAspNet` is an ASP.NET solution that enables you to display Crystal Reports within your web applications seamlessly. This implementation utilizes `CrystisWeb.dll`, which handles all report processing on the server.

### **No Additional Installations Required:**

One of the key benefits of `crystisAspNet` is that **you do not need to have Crystal Reports or Crystal Reports Runtime installed** on your system. The processing is entirely managed by `CrystisWeb.dll`, ensuring a lightweight and hassle-free setup.

### **Required Files**

To use `crystisAspNet`, ensure that the following files are present in your `/bin/` directory on the server:

- `CrystisWeb.dll` (which you can obtain from this repository or install via NuGet)
- `Newtonsoft.Json.dll`
- All `.rpt` files required for your reports

Check out the live demo of **crystisAspNet** [here](https://www.siteknower.com/samples/samplew01.aspx).

## Features

- Display Crystal Reports seamlessly in ASP.NET applications.
- Quick and straightforward setup using `CrystisWeb.dll`.
- No need to install Crystal Reports or Crystal Reports Runtime.
- Example pages for integration:
  1. **Basic Sample**
     - Example of a basic Crystal Report.
  2. **Full Sample**
     - Demonstrates sorting, filtering, and export destinations.
  3. **Invoice Report**
     - Shows a Crystal Report displaying data from multiple tables.

## Getting Started

### Prerequisites

1. ASP.NET Web Forms or MVC application.
2. Access to an account at [siteknower.com](https://www.siteknower.com) to obtain your account code and user code.
   - Demo account code (`DEMO1`) and user code (`0000`) are used in these examples to display demo data.
3. **No need to install Crystal Reports or its runtime. **`Crystis`** takes care of everything.**
4. **Configuring MIME Types for `.rpt` Files**
   - To ensure `.rpt` files are served correctly, configure the MIME type on your web server. Even if `.rpt` files seem to load fine, explicitly setting MIME types prevents potential issues.
   - **IIS (Windows)**: Add the following to your `web.config`:
     ```xml
     <configuration>
       <system.webServer>
         <staticContent>
           <mimeMap fileExtension=".rpt" mimeType="application/octet-stream" />
         </staticContent>
       </system.webServer>
     </configuration>
   - **Apache**: Add to .htaccess or server configuration:
      ```text
      AddType application/octet-stream .rpt
   - **NGINX**: Add to mime.types or server block:
      ```text
      types {
        application/octet-stream rpt;
      }
## Installation

### Option 1: Using This Repository (Recommended for Testing)

If you simply want to explore how crystisAspNet works, you can clone this repository. The required CrystisWeb.dll file is already included, so no additional installation is needed.

   ```bash
   git clone https://github.com/siteknower/crystisAspNet.git
   cd crystisAspNet
   ```
Open the folder using Visual Studio: Open / Web Site

### Option 2: Installing in a New ASP.NET Project

If you want to integrate crystisAspNet into your own ASP.NET project, install CrystisWeb.dll via NuGet:

   ```bash
   Install-Package Crystis.Web
   ```

   Alternatively, you can manually download CrystisWeb.dll from this repository.

Make sure the following files are in your /bin/ directory on the server:

   - `CrystisWeb.dll` (if installed manually)
   - `Newtonsoft.Json.dll`
   - All required `.rpt` files

Configure your `.aspx` page to display reports using `CrystisWeb.dll`.

## Quick Start Example

Below is a basic example demonstrating how to integrate `crystisAspNet` into your ASP.NET application:

```csharp
using System;
using System.Data;
using System.Web;
using CrystisWeb;

public partial class samplew01 : System.Web.UI.Page
{
    public DataSet dst;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Bind the GridView with data from the DataSet
            dst = GetData();
            ViewState["UserData"] = dst; // Store the dataset in ViewState
            GridView1.DataSource = dst.Tables["Users"];
            GridView1.DataBind();
        }
        else
        {
            // Retrieve the dataset from ViewState on postback
            dst = (DataSet)ViewState["UserData"];
        }
    }

    private DataSet GetData()
    {
        DataSet ds = new DataSet();
        ds.Tables.Add(new DataTable("Users"));
        DataTable dt = ds.Tables["Users"];
        dt.Columns.Add("Id", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Town", typeof(string));
        dt.Columns.Add("Country", typeof(string));
        dt.PrimaryKey = new DataColumn[] { dt.Columns["Id"] };

        dt.Rows.Add("ABDEN", "Maria Weiss", "Berlin", "Germany");
        dt.Rows.Add("AXEIS", "Pedro Alvarez", "México D.F.", "Mexico");
        dt.Rows.Add("BENOI", "Anna Tóth", "Szeged", "Hungary");
        dt.Rows.Add("CAZLE", "Jan Eriksson", "Mannheim", "Sweden");
        dt.Rows.Add("DRFOS", "Giulia Donatelli", "Milano", "Italia");
        return ds;
    }

    protected async void btnPrint_Click(object sender, EventArgs e)
    {
        clsCrystisClassWeb tsi = new clsCrystisClassWeb();
        tsi.dsRPT = dst;

        tsi.AccountCode = "DEMO1";  // your account code
        tsi.UserCode = "0000";  // yout user code

        string binPath = HttpContext.Current.Server.MapPath("~/bin");
        tsi.ReportFullName = System.IO.Path.Combine(binPath, "CustomerReport1.rpt");

        await tsi.ShowWindow(this, HttpContext.Current);

        // Alternatively, you can get the URL of the report with this.cs.getReportUrl() and display it in your application in some other way:
        // string turl = await tsi.getReportUrl(this, HttpContext.Current);
        // string script = string.Format("window.open('{0}', '_blank');", turl);
        // ClientScript.RegisterStartupScript(this.GetType(), "OpenNewWindow", script, true);
    }
}


```

## File Placement for `.rpt` Files

- Place all required `.rpt` files in the `/bin/` directory along with `CrystisWeb.dll`.

## First 30 Days Free
- To use CrystisWeb, you need an account code and user code from [Siteknower](https://www.siteknower.com/).
- When you sign up, you get 30 days free with your own account code.
- If you don’t have an account yet, you can test with:
    - **Account Code**: DEMO1
    - **User Code: 0000** (for demo data only)
      
## Running the Application

1. Deploy your ASP.NET project to a web server.
2. Ensure all necessary files (`CrystisWeb.dll`, `Newtonsoft.Json.dll`, `.rpt` files) are in the `/bin/` directory.
3. Access the report pages through your web browser.

## Repository Usage

Feel free to use this repository as:

- A guide to integrating Crystal Reports into your ASP.NET project.
- A base for building your own reporting solutions.

## Advertising crystisAspNet

This repository showcases the unique capabilities of `crystisAspNet`. Its seamless integration of Crystal Reports into ASP.NET applications makes it a valuable tool for developers.

## License

This repository is licensed under the MIT License (LICENSE).

## About Us

This project is maintained by [**Siteknower**](https://www.siteknower.com). For more information about our services, please visit our website.

## Contact

If you have questions, feel free to reach out through our [contact page](https://www.siteknower.com/contact).

