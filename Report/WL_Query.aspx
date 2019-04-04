<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WL_Query.aspx.cs" Inherits="Report_WL_Query" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>类别查询</title>
    <style type="text/css">
        .style1
        {
            width: 57px;
            height: 27px;
        }
        .style2
        {
            height: 27px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="物料大类查询" style="font-family: 微软雅黑; font-size: 15px">
            <table style="width:100%;">
                <tr>
                    <td class="style1" 
                        style="font-family: 微软雅黑; font-size: 13px">
                        物料号：</td>
                    <td class="style2">
                        <asp:TextBox ID="txt_wlh" runat="server" Width="80px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="查询" 
                            onclick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style1" 
                        style="font-family: 微软雅黑; font-size: 13px">
                        </td>
                    <td class="style2">
                        </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                            ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" 
                                ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                         <EmptyDataTemplate>
            查无数据,请输入条件重新查询.</EmptyDataTemplate>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" 
                                ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" 
                                ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" 
                                HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" 
                                ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
