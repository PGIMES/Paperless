<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Confirm_WH.aspx.cs" Inherits="User_Confirm_Confirm_WH" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body style="width: 443px">

    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td style="font-size: small">领料确认：</td>
    <td>
        <asp:TextBox ID="txt_uid" runat="server" Width="80px"></asp:TextBox>
        </td>
        <td style="font-size: small; color: #0066FF">
            (工号)</td>
    </tr>
    <tr>
    <td></td>
    <td>
            <asp:TextBox ID="txt_pwd" runat="server" TextMode="Password" Width="80px"></asp:TextBox>
        </td>
        <td style="font-size: small; color: #0066FF">
            (密码)</td>
    </tr>
    <tr>
    <td>&nbsp;</td>
    <td>
        <asp:Button ID="btn_submit" runat="server" Text="提交" 
            onclick="btn_submit_Click" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
