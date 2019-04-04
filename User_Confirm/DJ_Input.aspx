<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DJ_Input.aspx.cs" Inherits="User_Confirm_DJ_Input" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>
    <form id="form1" runat="server">
     <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    <div>
    
        <asp:Panel ID="Panel1" runat="server" GroupingText="请填入如下刀具领用资讯：" Width="508px" 
            Font-Size="Small">
            <table style="width: 400px; text-align: center;">
                <tr>
                    <td class="style7" style="font-size: small">
                        零件号：</td>
                    <td class="style6">
                        <asp:TextBox ID="txt_ljh" runat="server" ReadOnly="True" 
                Width="100px"></asp:TextBox>
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        领用位置：</td>
                    <td class="style6" style="color: #FF0000">
                        <asp:DropDownList ID="ddlposition" runat="server" 
                            Width="100px" >
                        </asp:DropDownList>
                        *</td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        项目号</td>
                    <td class="style6">
                        <asp:TextBox ID="txt_lycp" runat="server" ReadOnly="True" 
                            Width="100px"></asp:TextBox>
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        状态：</td>
                    <td class="style6">
                        <asp:TextBox ID="txt_status" runat="server" ReadOnly="True" 
                            Width="100px"></asp:TextBox>
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        研发项目：</td>
                    <td class="style6">
                        <asp:TextBox ID="txt_yfxm" runat="server" ReadOnly="True" 
                            Width="100px"></asp:TextBox>
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        领用产品：</td>
                    <td class="style6" style=" color:Red">
                     <asp:DropDownList ID="drop_lycp" runat="server"  Width="100px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="drop_lycp_SelectedIndexChanged" >
                        </asp:DropDownList>

                        *</td>
                    <td class="style1" colspan="2">
                        <asp:TextBox ID="txt_lycp_tz" runat="server" Visible="false"  
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        预计领用日期：</td>
                    <td class="style6">
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtyjly_date" runat="server" Width="100px" />
                      
                        <asp:ImageButton ID="Image1" runat="server" 
                            AlternateText="Click to show calendar" 
                            ImageUrl="~/Images/Calendar_scheduleHS.png" />
                        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" 
                            Enabled="True" Format="yyyy/MM/dd" PopupButtonID="Image1" 
                            TargetControlID="txtyjly_date" />
                    </td>
                    <td >
                        <asp:CompareValidator ID="CompareValidator11" runat="server" 
                            ControlToValidate="txtyjly_date" ErrorMessage="ERROR" Operator="DataTypeCheck" 
                            Type="Date"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style7" style="font-size: small">
                        领用类型</td>
                    <td class="style6">
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                Width="100px">
                            <asp:ListItem>新刀领用</asp:ListItem>
                            <asp:ListItem>以旧换新</asp:ListItem>
                            <asp:ListItem>仓库调整</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style1" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style7" colspan="4" style="font-size: small">
                        <asp:Label ID="lb_gc" runat="server" ForeColor="Red"  Visible="False"
                            Text="若新产品无刀具清单，请填写领用产品后的空白项进行调整!!" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style7">
                        &nbsp;</td>
                    <td class="style6">
                        <asp:Button ID="Button1" runat="server" 
                onclick="Button1_Click" Text="确认" Height="25px" Width="73px" />
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
