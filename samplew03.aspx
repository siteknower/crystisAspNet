<%@ Page Language="C#" AutoEventWireup="true" CodeFile="samplew03.aspx.cs" Inherits="samplew03" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>samplew03</title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <a href="samplew01.aspx">Sample1</a> <br />
                <a href="samplew02.aspx">Sample3</a>
                  <br />
                <span>Sample3</span> <br />
            </div>
            <br /> 

           <div>
               Customer:
            </div>

             <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>

             <br /><br />
             <div id="grid-container">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="false"> 
                
                 <Columns>                  
                     <asp:TemplateField HeaderText="Code" SortExpression="Code">
                         <ItemStyle Width="150px" /> 
                         <HeaderStyle Width="150px" /> 
                         <HeaderStyle HorizontalAlign = "Left" /> 
                         <ItemTemplate>
                             <%# Eval("Code") %>
                         </ItemTemplate>
                     </asp:TemplateField>

                     <asp:TemplateField HeaderText="Name" SortExpression="Name">
                         <ItemStyle Width="150px" /> 
                         <HeaderStyle Width="150px" /> 
                         <HeaderStyle HorizontalAlign = "Left" /> 
                         <ItemTemplate>
                             <%# Eval("Name") %> 
                          </ItemTemplate>
                      </asp:TemplateField>
                                       
                     <asp:TemplateField HeaderText="Amount" SortExpression="Amount">
                         <ItemStyle Width="150px" /> 
                         <ItemStyle HorizontalAlign = "Right" /> 
                         <HeaderStyle Width="150px" /> 
                         <HeaderStyle HorizontalAlign = "Right" /> 
                         <ItemTemplate>
                             <%# Eval("Amount") %>
                         </ItemTemplate>                        
                     </asp:TemplateField>

                      <asp:TemplateField HeaderText="Price" SortExpression="Price">
                         <ItemStyle Width="150px" /> 
                         <ItemStyle HorizontalAlign = "Right" /> 
                         <HeaderStyle Width="150px" /> 
                         <HeaderStyle HorizontalAlign = "Right" /> 
                         <ItemTemplate>
                             <%# Eval("Price") %>
                         </ItemTemplate>                   
                     </asp:TemplateField>

                   
                 </Columns>
             </asp:GridView>
         </div>

         <br /><br />
         <asp:Button ID="Button1" runat="server" Text="Print" OnClick="btnPrint_Click"   />
         <br /><br />
         <asp:Button ID="Button2" runat="server" Text="Save schema" OnClick="btnSaveSchema_Click"   />

    </form>
</body>
</html>


<%--https://www.aspsnippets.com/Articles/1591/GridView-RowUpdating-event-example-in-ASPNet-using-C-and-VBNet/--%>
