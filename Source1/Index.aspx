<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Source1_Index" Theme ="menu" %>

<%@ Register TagPrefix="Partners" TagName="userinfor" Src="~/Ascxs/UserInfor.ascx" %>
<%@ Register TagPrefix="Partners" TagName="foothead" Src="~/Ascxs/footheard.ascx" %>

<%@ Register TagPrefix="Partners" TagName="tophead" Src="~/Ascxs/tophead.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD id="HEAD1" runat ="server" >
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Styles/mflex.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/default.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/skmMenuStyles.css" type="text/css" rel="stylesheet">
		<SCRIPT src="../js/js_leftmenu_go.js"></SCRIPT>
		<SCRIPT src="../js/js_hide_loading.js"></SCRIPT>
		<SCRIPT src="../js/techserv_right.js"></SCRIPT>
		<style type="text/css">.tablestyle1 { BORDER-RIGHT: #4e4e4e 1px solid; BORDER-TOP: #e4e4e4 1px solid; BACKGROUND: #fdfdfd; FONT: 12px "Ш蔨", Arial; VERTICAL-ALIGN: middle; BORDER-LEFT: #e4e4e4 1px solid; COLOR: #777777; BORDER-BOTTOM: #4e4e4e 1px solid; TEXT-ALIGN: center; TEXT-DECORATION: none }
	.Tdstyle1 { BORDER-RIGHT: #e6e6e6 1px solid; BORDER-TOP: #e6e6e6 1px solid; BACKGROUND: #fdfdfd; BORDER-LEFT: #e6e6e6 1px solid; CURSOR: hand; BORDER-BOTTOM: #e6e6e6 1px solid; TEXT-DECORATION: none }
	.Titledivstyle { TEXT-JUSTIFY: distribute-all-lines; TEXT-ALIGN: justify }
	.inf1 { COLOR: #edb905 }
	.inf2 { COLOR: #107460 }
	BODY { MARGIN-TOP: 0px; MARGIN-LEFT: 0px }
		</style>
	</HEAD>
	<BODY background="../Images/techserv_right_files/bottom_bg.gif" >
		<!--onload="body_load()"-->
		<FORM id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TBODY>
				
				<tr>
												<td>
												
												<TABLE cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													<TR vAlign="bottom">
														<TD  style="height: 65px"><PARTNERS:TOPHEAD id="tophead" runat="server"></PARTNERS:TOPHEAD></TD>
													</TR>
													<TR>
														<TD background="../Images/topbg.gif">
															<TABLE height="28" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TBODY>
																	<TR>
																		<TD width="9" height="2">
																		</TD>
																		<TD vAlign="bottom" >
																			<TABLE class="menustyle" id="topmenu" style="Z-INDEX: 1000; BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-COLLAPSE: collapse; BORDER-BOTTOM-STYLE: solid"
																				cellSpacing="0" cellPadding="0" border="0">
																				<TBODY>
																					<TR >
																						<td  class ="td1" >
                                                                                        <div  class ="td1"><asp:Menu ID=menu runat =server     DataSourceID="XmlDataSource1" >
                                                                                          
                                                                                            <DataBindings>
                                                                                                <asp:MenuItemBinding DataMember="menuItem" NavigateUrlField="url" TextField="title"  />
                                                                                            </DataBindings>
                                                                                            <StaticMenuItemStyle Font-Size="X-Small" />
                                                                                           
                                                                                        </asp:Menu>
                                                                                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Ascxs/menuXml.xml" XPath="/*/*">
                                                                                            </asp:XmlDataSource></div>
                                                                                        </td>
																					</TR>
																				</TBODY>
																			</TABLE>
																		</TD>
																		
																		<TD ></TD>
																	</TR>
																</TBODY>
															</TABLE>
														</TD>
													</TR>
												</TBODY>
											</TABLE>
												</td>
												
												
												
												</tr>
					<TR>
						<TD vAlign="top">
							<TABLE height="250" cellSpacing="0" cellPadding="5" width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
												<TBODY>
													<TR>
													<td align =left><asp:SiteMapPath ID=site runat =server  >
                                                            
                                                        </asp:SiteMapPath></td>
														
													</TR>
												</TBODY>
											</TABLE>
											<IMG height="8" src="../Images/techserv_right_files/Spacer.gif" width="1"><BR>
											<asp:panel id="ppladduser" Runat="server">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD id="inf1" align="center" bgColor="#ffffff">
															<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
																<TR align="center" bgColor="#ffffff">
																	<TD>
																		<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
																			<TR>
																				<TD bgColor="#d7dfe8"><FONT color="#999999"><FONT class="download_from" color="#000000"></FONT><FONT class="download_name3" color="#4d4d4d"></FONT></FONT></TD>
																			</TR>
																		</TABLE>
																		<TABLE cellSpacing="1" cellPadding="5" width="100%" bgColor="#d7dfe8" border="0">
																			<TR>
																				<TD bgColor="#ffffff">
																					<TABLE cellSpacing="5" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD vAlign="top">
																								
																								
																								
																								 
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" align="center" height="320">
				<TR>
					<TD valign="top" align="center" width="1"></TD>
					<TD valign="top" align="center">
						<TABLE id="tblWelcome" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0"
							runat="server">
							<TR>
								<TD valign="middle" align="center" style="FONT-WEIGHT:bold;FONT-SIZE:20px;COLOR:red">
                                    欢迎使用PGI领料管理系统</TD>
							</TR>
							<TR>
								<TD height="30" align="center">本管理系统为公司内部管理系统。</TD>
							</TR>
						</TABLE>
						<TABLE id="tblNavigator" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0"
							runat="server">
							<TR>
								<TD height="30" valign="middle" align="center">PGI管理系统</TD>
							</TR>
							
						</TABLE>
					</TD>
				</TR>
			</TABLE>
																							</TD>
																						</TR>
																					</TABLE>
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><IMG height="8" src="../Images/techserv_right_files/Spacer.gif" width="1"><BR>
											<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													<TR align="center" bgColor="#ffffff">
														<TD>
															
														</TD>
													</TR>
													<TR align="center" bgColor="#ffffff">
														<TD vAlign="top">
															
															
															   <table >
				   	<tr>
				 <td> 
                  
				 </td>
				</tr>
				</table>
															
															
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<IMG height="8" src="../Images/Spacer.gif" width="1" >
							
							<TABLE cellSpacing="0" cellPadding="5" width="100%" border="0">
								<TBODY>
								</TBODY>
							</TABLE>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			</FORM>
	</BODY>
</HTML>


