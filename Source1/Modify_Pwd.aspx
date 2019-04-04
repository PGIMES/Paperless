<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify_Pwd.aspx.cs" Inherits="Source1_Modify_Pwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
    <title>Paperless System</title>
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
                                    <img height="90" src="../Images/wl.jpg" width="420" /></td>
                            </tr>
                            <tr>
                                <td background="Images/2.jpg">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="9%" align="left">
                                                <img height="151" src="../Images/4.jpg" width="4" /></td>
                                            <td width="91%">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="83%">
                                                    <tr>
                                                        <td class="unnamed1" width="23%" align="left" style="height: 23px">
                                                            <font color="#006699" face="Arial, Helvetica, sans-serif"><strong>
                                                                <asp:Label ID="lbUser" runat="server" Text="密&#30721;: &#26087;"></asp:Label></strong></font></td>
                                                        <td colspan="2" align="left" style="height: 23px">
                                                            <asp:TextBox ID="txtPassword_Old" runat="server" Width="190px" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td  width="23%" align="left" style=" height:5px">
                                                            </td>
                                                        <td colspan="2" align="left" style=" height:5px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="unnamed1" align="left">
                                                            <font color="#006699" face="Arial, Helvetica, sans-serif"><strong>
                                                                <asp:Label ID="lbPassword" runat="server" Text="密&#30721;: 新建"></asp:Label></strong></font></td>
                                                        <td colspan="2" align="left">
                                                            <asp:TextBox ID="txtPassword_New" runat="server" Width="190px" TextMode="Password"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left" colspan="2" style="height: 5px;">
                                                            <asp:CompareValidator ID="covPass" runat="server" 
                                                                ControlToCompare="txtPassword_New" ControlToValidate="txtPassword_Confirm" 
                                                                ErrorMessage="&#20004;次密&#30721;不一致" Font-Size="12px"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        
                                                         <td class="unnamed1" align="left">
                                                            <font color="#006699" face="Arial, Helvetica, sans-serif"><strong>
                                                                <asp:Label ID="Label1" runat="server" Text="确&#35748;密&#30721;"></asp:Label></strong></font></td>
                                                        <td align="left" colspan="2" style="height: 21px;">
                                                            <asp:TextBox ID="txtPassword_Confirm" runat="server" Width="190px" 
                                                                TextMode="Password"></asp:TextBox></td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td class="unnamed1">
                                                            &nbsp;</td>
                                                        <td style="height: 22px; width: 65%;">
                                                            <table>
                                                                <tr>
                                                                    <td style="width: 45px; height: 28px;">
                                                                        &nbsp;</td>
                                                                    <td style="width: 70px; height: 28px;" align="center">
                                                                        <asp:ImageButton ID="OKButton" runat="server" ImageUrl="~/Images/b1.gif" OnClick="OKButton_Click"
                                                                           /></td>
                                                                    <td style="width: 70px; height: 28px;" align="center">
                                                                        <asp:ImageButton ID="ReturnButton" runat="server" 
                                                                            ImageUrl="~/Source1/Images/Return.gif" onclick="ReturnButton_Click" />
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
                                    <img height="9" src="../Images/3.jpg" width="420" style="margin-top: 0px" /></td>
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
