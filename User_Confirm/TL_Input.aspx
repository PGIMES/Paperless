<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TL_Input.aspx.cs" Inherits="User_Confirm_TL_Input" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 203px;
        }
        .style2
        {
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 322px">
    <tr>
    <td class="style2" style="font-size: small">退料数量：</td>
    <td class="style1">
        <asp:TextBox ID="txt_tlnum" runat="server" Width="80px"></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToValidate="txt_tlnum" ErrorMessage="数量必须是整数!" Font-Size="Small" 
            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
    <td class="style2">&nbsp;</td>
    <td class="style1">
        <asp:Button ID="Button1" runat="server" Text="确认" onclick="Button1_Click" />
        </td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
