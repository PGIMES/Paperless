<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LL_Confirm.aspx.cs" Inherits="LL_Confirm" Theme="menu" %>

<%@ Register TagPrefix="Partners" TagName="userinfor" Src="~/Ascxs/UserInfor.ascx" %>
<%@ Register TagPrefix="Partners" TagName="foothead" Src="~/Ascxs/footheard.ascx" %>

<%@ Register TagPrefix="Partners" TagName="tophead" Src="~/Ascxs/tophead.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD id="HEAD1" runat =server >
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="~/Styles/mflex.css" type="text/css" rel="stylesheet">
		<LINK href="~/Styles/default.css" type="text/css" rel="stylesheet">
		<LINK href="~/Styles/Style.css" type="text/css" rel="stylesheet">
		<LINK href="~/Styles/skmMenuStyles.css" type="text/css" rel="stylesheet">
        <LINK href="~/Images/asus.css" type="text/css" rel="stylesheet">
        <link href="~/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
		<SCRIPT src="~/js/js_leftmenu_go.js"></SCRIPT>
		<SCRIPT src="~/js/js_hide_loading.js"></SCRIPT>
		<SCRIPT src="~/js/techserv_right.js"></SCRIPT>
		<style type="text/css">.tablestyle1 { BORDER-RIGHT: #4e4e4e 1px solid; BORDER-TOP: #e4e4e4 1px solid; BACKGROUND: #fdfdfd; FONT: 12px "Ш蔨", Arial; VERTICAL-ALIGN: middle; BORDER-LEFT: #e4e4e4 1px solid; COLOR: #777777; BORDER-BOTTOM: #4e4e4e 1px solid; TEXT-ALIGN: center; TEXT-DECORATION: none }
	.Tdstyle1 { BORDER-RIGHT: #e6e6e6 1px solid; BORDER-TOP: #e6e6e6 1px solid; BACKGROUND: #fdfdfd; BORDER-LEFT: #e6e6e6 1px solid; CURSOR: hand; BORDER-BOTTOM: #e6e6e6 1px solid; TEXT-DECORATION: none }
	.Titledivstyle { TEXT-JUSTIFY: distribute-all-lines; TEXT-ALIGN: justify }
	.inf1 { COLOR: #edb905 }
	.inf2 { COLOR: #107460 }
	BODY { MARGIN-TOP: 0px; MARGIN-LEFT: 0px }
	
	         .hidden { display:none;}
		     .hidden1
            {
            	border:0px; 
            	overflow:hidden
            	
            	}
		    .style1
            {
            }
            .style3
            {
            }
		              
            .style6
            {
                width: 1145px;
            }
          
            .style9
            {
                width: 141px;
            }
          
            </style>
	</HEAD>
	<BODY background="../Images/techserv_right_files/bottom_bg.gif" >
		<!--onload="body_load()"-->
       
		<FORM id="Form1" method="post" runat="server">
		 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <%
  if (Request["__SCROLLPOS"] != null &&
      Request["__SCROLLPOS"] != String.Empty) {
      int pos = Convert.ToInt32 (Request["__SCROLLPOS"]);
      Response.Write ("<body id=\"theBody\" " +
          "onscroll=\"javascript:document.forms[0].__SCROLLPOS.value = " +
          "theBody.scrollTop;\" " +
          "onload=\"javascript:theBody.scrollTop=" + pos + ";\">");
  }
  else {
      Response.Write ("<body id=\"theBody\" " +
          "onscroll=\"javascript:document.forms[0].__SCROLLPOS.value =" +
          "theBody.scrollTop;\">");
  }
%>
<script type="text/javascript">

    function CheckAll(obj) {

        var theTable = obj.parentElement.parentElement.parentElement;

        var i;

        var j = obj.parentElement.cellIndex;

        for (i = 0; i < theTable.rows.length; i++) {

            var objCheckBox = theTable.rows[i].cells[j].firstChild;

            if (objCheckBox.checked != null) {

                objCheckBox.checked = obj.checked;

            }

        }

    }

</script>



<script language="javascript">
    function refresh() {
        this.location = this.location;
    }
	</script>
 <input type="hidden" name="__SCROLLPOS" value="" />
 <TABLE cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													
													<TR>
														<TD background="../Images/topbg.gif" 
                                                          style="background-image: url('../Images/topbg.gif')">
															<TABLE height="28" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TBODY>
																	<TR>
																		<TD width="9" height="2">
																		</TD>
																		<TD vAlign="bottom" height="2">
																			<TABLE class="menustyle" id="topmenu" style="Z-INDEX: 1000; BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-COLLAPSE: collapse; BORDER-BOTTOM-STYLE: solid"
																				cellSpacing="0" cellPadding="0" border="0">
																				<TBODY>
																					<TR >
																						<td  class ="td1"><div class ="td1" ></div><asp:Menu ID=menu runat =server     DataSourceID="XmlDataSource1"  >
                                                                                          
                                                                                            <DataBindings>
                                                                                                <asp:MenuItemBinding DataMember="menuItem" NavigateUrlField="url" TextField="title"  />
                                                                                            </DataBindings>
                                                                                            <StaticMenuItemStyle Font-Size="X-Small" />
                                                                                           
                                                                                        </asp:Menu>
                                                                                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Ascxs/menuXml.xml" XPath="/*/*">
                                                                                            </asp:XmlDataSource>
                                                                                        </td>
																					</TR>
																				</TBODY>
																			</TABLE>
																		</TD>
																		
																		<TD class="name" vAlign="top" align="right" width="5" height="2"></TD>
																	</TR>
																</TBODY>
															</TABLE>
														</TD>
													</TR>
												</TBODY>
											</TABLE>	
			<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TBODY>
				
				
					<TR>
						<TD vAlign="top">
							<TABLE height="250" cellSpacing="0" cellPadding="5"  width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
												<TBODY>
													<TR>
													<td  align="left"><asp:SiteMapPath ID=site runat =server>
                                                            
                                                        </asp:SiteMapPath></td>
														<TD><asp:Panel ID=panuser runat =server  Visible =false><PARTNERS:USERINFOR id="righmenu1" runat="server"></PARTNERS:USERINFOR></asp:Panel></TD>
														
													</TR>
												</TBODY>
											</TABLE>
											
											<asp:panel id="ppladduser" Runat="server">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD id="inf1" align="center" bgColor="#ffffff">
															<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
																<TR align="center" bgColor="#ffffff">
																	<TD>
																		<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
																			<TR>
																				<TD bgColor="#d7dfe8" align="left"><FONT color="#999999"><FONT class="download_from" color="#000000">
                                                                                    <IMG height="25" src="Images/techserv_right_files/arrow-001db.gif" width="22" 
                                                                                        align="absMiddle">领料</FONT><FONT class="download_name3" color="#4d4d4d">记录查询条件</FONT></FONT></TD>
																			</TR>
																		</TABLE>
																		<TABLE cellSpacing="1" cellPadding="5" width="100%" bgColor="#d7dfe8" border="0">
																			<TR>
																				<TD bgColor="#ffffff">
																					<TABLE cellSpacing="5" cellPadding="0"  border="0">
																						<TR>
																							<TD vAlign="top">
																								
																						<table width="1250">
                                                                                      
                                                                                            <tr>
                                                                                                <td class="style3" colspan="3">
                                                                                                    <asp:Panel ID="Panel2" runat="server" GroupingText="查询条件 " Width="800px">
                                                                                                        <table width="800">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    物料编码：</td>
                                                                                                                <td class="style9">
                                                                                                                    <asp:TextBox ID="txt_wlbm" runat="server" Width="120px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    物料名称：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_cpmc" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    状态：</td>
                                                                                                                <td>
                                                                                                                    <asp:DropDownList ID="DropDownList6" runat="server">
                                                                                                                        <asp:ListItem Selected="True" Value="N">未确认</asp:ListItem>
                                                                                                                        <asp:ListItem Value="Y">已确认</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    公司代码：</td>
                                                                                                                <td class="style9">
                                                                                                                    <asp:DropDownList ID="DropDownList5" runat="server" 
                                                                                                                        onselectedindexchanged="DropDownList4_SelectedIndexChanged">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    规格型号：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_wlxh" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    领用日期：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txtly_date3" runat="server" Width="100" />
                                                                                                                    <ajaxToolkit:CalendarExtender ID="txtly_date3_CalendarExtender" runat="server" 
                                                                                                                        PopupButtonID="Image2" TargetControlID="txtly_date3" />
                                                                                                                    ~<asp:TextBox ID="txtly_date4" runat="server" Width="100" />
                                                                                                                    <ajaxToolkit:CalendarExtender ID="txtly_date4_CalendarExtender" runat="server" 
                                                                                                                        PopupButtonID="Image2" TargetControlID="txtly_date4" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    &nbsp;</td>
                                                                                                                <td class="style9">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td colspan="2">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                    <asp:Button ID="Button5" runat="server" class="STYLE1" onclick="Button5_Click" 
                                                                                                                        Text="查询" Width="95px" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                    <br />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>		
																								
																								 
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
												
												
											</asp:panel>
											
				
											<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													<TR align="center" bgColor="#ffffff">
														<TD>
															<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#fff5d7" border="0">
																<TBODY>
																	<TR>
																		<TD width="75%" align="left"><FONT color="#666666"><IMG height="25" 
                                                                                src="Images/techserv_right_files/arrow-001O.gif" width="22" align="absMiddle"><FONT class="download_name3" face="Ш蔨">领料记录清单
																		</TBODY>
															</TABLE>
														</TD>
													</TR>
													<TR align="left" bgColor="#ffffff">
														<TD vAlign="top">
															
															
															   <table  >
				   	<tr>
				 <td class="style6"> 
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                 Height="99px" 
                                 onrowdatabound="GridView1_RowDataBound" 
                         Width="97%" AllowPaging="True" onpageindexchanging="GridView1_PageIndexChanging">
                                 <Columns>
                                     <asp:BoundField DataField="lldh" HeaderText="领用单号" />
                                     <asp:BoundField DataField="group_part" HeaderText="刀具组合号">
                                     <ControlStyle CssClass="hidden" Width="0px" />
                                     <FooterStyle CssClass="hidden" Width="0px" />
                                     <HeaderStyle CssClass="hidden" Width="0px" />
                                     <ItemStyle CssClass="hidden" Width="0px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="part" HeaderText="物料编码">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="desc1" HeaderText="物料名称">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="desc2" HeaderText="规格型号">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="unit" HeaderText="单位">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="quantity" HeaderText="数量" />
                                     <asp:BoundField DataField="Truename" HeaderText="领用人" />
                                     <asp:BoundField DataField="create_date" HeaderText="领用日期" />
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                             <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="确认领料"  />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                 <FooterStyle HorizontalAlign="Right" />
                                 <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                                     Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                                 <PagerStyle ForeColor="Red" />
                             </asp:GridView>
				 </td>
				</tr>
                <tr><td class="style6">
                    <br />
                    </td></tr>
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

