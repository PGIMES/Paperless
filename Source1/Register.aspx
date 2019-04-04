<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Source1_Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <title>Register</title>
    <style type="text/css">
<!--
.unnamed1 {
	font-size: 12px;
}
.1 {
	font-size: 9px;
}
        .style1
        {
            height: 19%;
            width: 34%;
        }
        .style2
        {
            height: 219px;
            width: 34%;
        }
        .style3
        {
            height: 18%;
            width: 34%;
        }
-->
</style>

    

</head>
<body id="pgLogin" bgcolor="#FFFFFF" topmargin="0" >
    <form id="frmLogin" runat="server">
        <div>
            &nbsp;<table style="width: 100%; height: 100%;">
                <tr height="50%">
                    <td align="center" colspan="1" rowspan="1" class="style1">
                    </td>
                    <td align="center" colspan="1" rowspan="1" style="height: 19%;" valign="middle">
                    </td>
                    <td align="center" colspan="3" rowspan="1" style="width: 30%; height: 19%;">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="1" rowspan="1" class="style2">
                    </td>
                    <td align="center" colspan="1" rowspan="1" style="height: 219px;" valign="middle">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="341">
                            <tr>
                                <td>
                                    <img height="90" src="Images/wl.jpg" width="420" /></td>
                            </tr>
                            <tr>
                                <td background="Images/2.jpg">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="9%" align="left">
                                                <img height="151" src="Images/4.jpg" width="4" /></td>
                                            <td width="91%">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="83%">
                                                    <tr>
                                                        <td class="unnamed1" width="23%" align="left" style="height: 23px">
                                                            <font color="#006699" face="Arial, Helvetica, sans-serif"><strong>
                                                                <asp:Label ID="lbUser" runat="server" Text="用户工号"></asp:Label>：</strong></font></td>
                                                        <td colspan="2" align="left" style="height: 23px">
                                                            <asp:TextBox ID="txtUserName" runat="server" Width="190px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="unnamed1" align="left">
                                                            <font color="#006699" face="Arial, Helvetica, sans-serif"><strong>
                                                                <asp:Label ID="lbPassword" runat="server" Text="用户密码"></asp:Label>：</strong></font></td>
                                                        <td colspan="2" align="left">
                                                            <asp:TextBox ID="txtPassword" runat="server" Width="190px" TextMode="Password"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="unnamed1" align="left">
                                                            &nbsp;</td>
                                                        <td colspan="2" align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td class="unnamed1" rowspan="2">
                                                            &nbsp;</td>
                                                        <td colspan="2">
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 22px; width: 65%;">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 45px; height: 28px;">
                                                                        <asp:ImageButton ID="OKButton" runat="server" ImageUrl="~/Images/b1.gif" OnClick="OKButton_Click"
                                                                           /></td>
                                                                    <td style="height: 28px;" align="center">
                                                                        &nbsp;</td>
                                                                    <td>
                                                                        <asp:ImageButton ID="ReturnButton" runat="server" 
                                                                            ImageUrl="~/Source1/Images/Return.gif" onclick="ReturnButton_Click" 
                                                                            />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td style="height: 22px" width="21%">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 9px">
                                    <img height="9" src="Images/3.jpg" width="420" style="margin-top: 0px" /></td>
                            </tr>
                        </table>
                    </td>
                    <td align="center" colspan="3" rowspan="1" style="width: 30%; height: 219px;">
                    </td>
                </tr>
                <tr height="50%">
                    <td align="center" colspan="1" rowspan="1" class="style3">
                    </td>
                    <td align="center" colspan="1" rowspan="1" style="height: 18%;" valign="middle">
                    </td>
                    <td align="center" colspan="3" rowspan="1" style="width: 30%; height: 18%;">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
