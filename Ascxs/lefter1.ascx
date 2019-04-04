<%@ Control Language="C#" AutoEventWireup="true" CodeFile="lefter1.ascx.cs" Inherits="Ascxs_lefter1" %>


<TABLE id="tblUserLogin" height="100%" cellSpacing="0" cellPadding="0" width="180" bgColor="lightgrey"
	border="0" runat="server">
	<TR>
		<td width="2"></td>
		<TD vAlign="top">
			<table height="2" cellSpacing="0" cellPadding="0">
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" borderColorDark="gainsboro" cellPadding="0" width="100%" borderColorLight="gray"
				border="1">
				<tr>
					<td style="FONT-WEIGHT: bold" vAlign="bottom" align="center" bgColor="silver" height="20">∴∷用户登录∷∴</td>
				</tr>
				<tr>
					<td width="100%" height="75">
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD width="60" height="25">用户帐号：</TD>
								<TD><asp:textbox id="txtUserAccount" runat="server" Width="100%" BorderWidth="1px" MaxLength="16"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="60" height="25">登录密码：</TD>
								<TD><asp:textbox id="txtUserPswd" runat="server" Width="100%" TextMode="Password" BorderWidth="1px"
										MaxLength="16"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="60" height="25"></TD>
								<TD><asp:button id="btnLogin" runat="server" Text="登录" CommandName="LOGIN" 
                                        BorderWidth="1px" onclick="btnLogin_Click"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<table height="2" cellSpacing="0" cellPadding="0">
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" borderColorDark="gainsboro" cellPadding="0" width="100%" borderColorLight="gray"
				border="1">
				<tr>
					<td style="FONT-WEIGHT: bold" vAlign="bottom" align="center" bgColor="silver" height="20">∴∷登录说明∷∴</td>
				</tr>
				<tr>
					<td vAlign="top" width="100%">
						<LI>
						您只有成功登录后才可以使用本管理系统
						<LI>
						如果您还没有用户帐号，请向管理员申请
						<LI>
						如果第一次使用，请使用管理员帐号登录
						<LI>
							请不要轻易使用管理员帐号，以免造成不必要的麻烦
						</LI>
					</td>
				</tr>
			</table>
		</TD>
		<td width="1"></td>
	</TR>
</TABLE>
<TABLE id="tblUserInfo" height="100%" cellSpacing="0" cellPadding="0" width="180" bgColor="lightgrey"
	border="0" runat="server">
	<TR>
		<td width="2"></td>
		<TD vAlign="top">
			<table height="2" cellSpacing="0" cellPadding="0">
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellSpacing="0" borderColorDark="gainsboro" cellPadding="0" width="100%" borderColorLight="gray"
				border="1">
				<tr>
					<td style="FONT-WEIGHT: bold" vAlign="bottom" align="center" bgColor="silver" height="20">∴∷用户信息∷∴</td>
				</tr>
				<tr>
					<td width="100%">
						<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="40" height="20">帐号：</TD>
								<TD><input 
                  style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 98%; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: transparent" 
                  readOnly type=text 
                  
                  ></TD>
							</TR>
							<TR>
								<TD align="center" width="40" height="20">姓名：</TD>
								<TD><input 
                  style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 98%; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: transparent" 
                  readOnly type=text 
                  ></TD>
							</TR>
							<TR>
								<TD align="center" width="40" height="20">部门：</TD>
								<TD><input 
                  style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 98%; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: transparent" 
                  readOnly type=text 
                  ></TD>
							</TR>
							<TR>
								<TD width="40" height="20" align="center">角色：</TD>
								<TD><input type=text readonly style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 98%; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: transparent" ></TD>
							</TR>
							<TR>
								<TD width="40" height="20" align="center">职务：</TD>
								<TD><input type=text readonly  style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; WIDTH: 98%; BORDER-BOTTOM: 0px; BACKGROUND-COLOR: transparent" ></TD>
							</TR>
							<TR>
								<TD align="center" colspan="2" height="25"><asp:button id="btnQuit" runat="server" Text="退出" CommandName="QUIT"></asp:button></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			<table height="2" cellpadding="0" cellspacing="0">
				<tr>
					<td></td>
				</tr>
			</table>
			<table cellspacing="0" bordercolordark="gainsboro" cellpadding="0" width="100%" bordercolorlight="gray"
				border="1">
				<tr>
					<td bgcolor="silver" height="20" align="center" valign="bottom" style="FONT-WEIGHT:bold">∴∷快速通道∷∴</td>
				</tr>
				<tr>
					<td width="100%">
						<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="20" height="25"></TD>
								<TD><a href="UserPswd.Aspx">修改密码</a></TD>
							</TR>
							<TR>
								<TD align="center" width="20" height="25"></TD>
								<TD><a href="MyCarApply.Aspx">我的用车申请</a></TD>
							</TR>
							<TR>
								<TD align="center" width="20" height="25"></TD>
								<TD><a href="MyCarCheck.Aspx">我审批的用车申请</a></TD>
							</TR>
							<TR>
								<TD align="center" width="20" height="25"></TD>
								<TD><a href="MyCarTask.Aspx">我的事务日志</a></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</TD>
		<td width="1"></td>
	</TR>
</TABLE>
