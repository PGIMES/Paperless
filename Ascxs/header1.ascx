<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header1.ascx.cs" Inherits="Ascxs_header1" %>
<%@ Register TagPrefix="Views" Namespace="CYBERAKT.WebControls.Navigation" Assembly="ASPnetMenu" %>

<TABLE id="Table1" height="85" cellSpacing="0" cellPadding="0" width="100%" border="0" runat=server>
	<TR>
		<TD bgColor="lightgrey" colSpan="2" height="2"></TD>
	</TR>
	<TR>
		<TD bgColor="white" colSpan="2" height="1"></TD>
	</TR>
	<TR>
		<TD vAlign="middle" align="center" width="180">
			<OBJECT codeBase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
				height="60" width="120" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" VIEWASTEXT>
				<PARAM NAME="_cx" VALUE="3175">
				<PARAM NAME="_cy" VALUE="1588">
				<PARAM NAME="FlashVars" VALUE="">
				<PARAM NAME="Movie" VALUE="/Images/logo.swf">
				<PARAM NAME="Src" VALUE="/Images/logo.swf">
				<PARAM NAME="WMode" VALUE="Window">
				<PARAM NAME="Play" VALUE="-1">
				<PARAM NAME="Loop" VALUE="-1">
				<PARAM NAME="Quality" VALUE="High">
				<PARAM NAME="SAlign" VALUE="">
				<PARAM NAME="Menu" VALUE="-1">
				<PARAM NAME="Base" VALUE="">
				<PARAM NAME="AllowScriptAccess" VALUE="always">
				<PARAM NAME="Scale" VALUE="ShowAll">
				<PARAM NAME="DeviceFont" VALUE="0">
				<PARAM NAME="EmbedMovie" VALUE="0">
				<PARAM NAME="BGColor" VALUE="">
				<PARAM NAME="SWRemote" VALUE="">
				<PARAM NAME="MovieData" VALUE="">
				<embed src="/Images/logo.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer"
					type="application/x-shockwave-flash" width="120" height="60"> </embed>
			</OBJECT>
		</TD>
		<TD vAlign="middle" align="center"><asp:Image ID=IMG runat =server ImageUrl="~/Images/advertimg.gif" /></TD>
	</TR>
	<TR>
		<TD bgColor="white" colSpan="2" height="1"></TD>
	</TR>
	<TR>
		<TD vAlign="middle" align="center" bgColor="lightgrey" colSpan="2"><table width="100%" cellpadding="0" cellspacing="0" border="0" height="100%">
				<tr>
					
					<td width="1" bgcolor="white"></td>
					
					<td><VIEWS:ASPNETMENU id="ASPnetMenu1" runat="server" ShadowEnabled="True" MenuData="~/Ascxs/menuData.xml"
							BorderStyle="Solid" BorderWidth="1px" BorderColor="White" BackColor="Silver" ExpandDelay="100"
							Height="100%"></VIEWS:ASPNETMENU>
							
							</td>
				</tr>
			</table>
		</TD>
	</TR>
	<TR>
		<TD height="1" colspan="2" bgcolor="white"></TD>
	</TR>
</TABLE>
