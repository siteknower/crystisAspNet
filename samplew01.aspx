<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeFile="samplew01.aspx.cs" Inherits="samplew01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div>
            <span>Sample1</span> <br />
            <a href="samplew02.aspx">Sample2</a> <br />
            <a href="samplew03.aspx">Sample3</a>
         </div>
         <br />
         <asp:GridView ID="GridView1" runat="server"></asp:GridView>

         <br /><br />
         <asp:Button ID="Button1" runat="server" Text="Print" OnClick="btnPrint_Click"/> &nbsp;&nbsp;  <asp:Button ID="Button2" runat="server" Text="Open URL" OnClick="btnPrint_Click2"   />
    </form>
</body>
</html>
