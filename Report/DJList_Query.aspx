<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DJList_Query.aspx.cs" Inherits="Report_DJList_Query"  Theme="menu"%>

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
		              
            .style8
            {
                width: 64px;
            }
            .style11
            {
                width: 41px;
            }
            .style12
            {
                width: 222px;
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
<script language="javascript" type="text/javascript">
    function deleteConfirm() {
        return window.confirm("确定要关闭该领用记录吗？");
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
															<TABLE height="28" cellSpacing="0" cellPadding="0" width="1750px" border="0">
																<TBODY>
																	<TR>
																		<TD width="9" height="2">
																		</TD>
																		<TD vAlign="bottom" height="2">
																			<TABLE class="menustyle" id="topmenu" style="Z-INDEX: 1000; BORDER-TOP-STYLE: solid; BORDER-RIGHT-STYLE: solid; BORDER-LEFT-STYLE: solid; BORDER-COLLAPSE: collapse; BORDER-BOTTOM-STYLE: solid"
																				cellSpacing="0" cellPadding="0" border="0">
																				<TBODY>
																					<TR >
																						<td  class ="td1"><asp:Menu ID=menu runat =server     DataSourceID="XmlDataSource1"  >
                                                                                          
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
													<td ><asp:SiteMapPath ID=site runat =server>
                                                            
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
																				<TD bgColor="#d7dfe8"><FONT color="#999999"><FONT class="download_from" color="#000000">
                                                                                    <IMG height="25" src="../Images/techserv_right_files/arrow-001db.gif" width="22" 
                                                                                        align="absMiddle"></FONT><FONT class="download_name3" color="#4d4d4d">刀具清单查询条件</FONT></FONT></TD>
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
                                                                                                                    项目号：</td>
                                                                                                                <td class="style12">
                                                                                                                    <asp:TextBox ID="txt_pgixmh" runat="server" Width="150px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    版本号：</td>
                                                                                                                <td class="style11">
                                                                                                                    <asp:TextBox ID="txt_bb" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                               
                                                                                                                <td class="style8" colspan="2">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    群组号：</td>
                                                                                                                <td class="style12">
                                                                                                                    <asp:TextBox ID="txt_group_part" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="150px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    群组描述：</td>
                                                                                                                <td class="style11">
                                                                                                                    <asp:TextBox ID="txt_group_ms" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                
                                                                                                                <td  class="style8" colspan="2">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    物料号：</td>
                                                                                                                <td class="style12">
                                                                                                                    <asp:TextBox ID="txt_part" runat="server" 
                                                                                                                        style="margin-left: 0px" Width="150px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    工序号：</td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:TextBox ID="txt_gxh" runat="server" style="margin-left: 0px" Width="100px"></asp:TextBox>
                                                                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                </td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:Button ID="Button5" runat="server" class="STYLE1" onclick="Button5_Click" 
                                                                                                                        Text="查询" Width="95px" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    默认版本:</td>
                                                                                                                <td class="style12">
                                                                                                                    <asp:DropDownList ID="DropVersion" runat="server">
                                                                                                                        <asp:ListItem Value="0">最新版本</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">所有版本</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td colspan="2">
                                                                                                                    &nbsp;</td>
                                                                                                                <td colspan="2">
                                                                                                                    <asp:Button ID="Button6" runat="server" class="STYLE1" 
                                                                                                                        Text="导出" Width="95px" onclick="Button6_Click" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    公司代码：</td>
                                                                                                                <td class="style12">
                                                                                                                    <asp:DropDownList ID="DropDownList5" runat="server">
                                                                                                                        <asp:ListItem>200</asp:ListItem>
                                                                                                                        <asp:ListItem>100</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td colspan="2">
                                                                                                                    &nbsp;</td>
                                                                                                                <td colspan="2">
                                                                                                                    &nbsp;</td>
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
											
				
											<TABLE cellSpacing="7" cellPadding="0" width=2100px bgColor="#ffffff" border="0" style=" overflow:scroll">
												<TBODY>
													<TR align="center" bgColor="#ffffff">
														<TD>
															<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#fff5d7" border="0">
																<TBODY>
																	<TR>
																		<TD width="75%"><FONT color="#666666"><IMG height="25" 
                                                                                src="../Images/techserv_right_files/arrow-001O.gif" width="22" 
                                                                                align="absMiddle"><FONT class="download_name3" face="Ш蔨">清单
																		</TBODY>
															</TABLE>
														</TD>
													</TR>
													<TR align="left" bgColor="#ffffff">
														<TD vAlign="top">
															
															
															   <table width="1050px"  >
				   	<tr>
                    <td vAlign="top" width="20%"> 
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                         Width="99%" 
                         AllowPaging="True" onpageindexchanging="GridView2_PageIndexChanging" 
                         PageSize="100" style="margin-right: 7px">
                         <Columns>
                             <asp:TemplateField HeaderText="项目号">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        ForeColor="Blue" OnClick="LinkButton1_Click" Text='<%#Eval("PGIXMH") %>' 
                                        Width="60"></asp:LinkButton>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <ItemStyle CssClass="size1" ForeColor="Blue" HorizontalAlign="Left" 
                                    Wrap="False" />
                            </asp:TemplateField>
                             <asp:BoundField DataField="LJH" HeaderText="零件号">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:BoundField DataField="LJMC" HeaderText="零件名称">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CPCZ" HeaderText="产品材质" >
                             </asp:BoundField>
                         </Columns>
                         
                         <FooterStyle HorizontalAlign="Right" />
                         <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                             Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                         <PagerStyle ForeColor="Red" />
                     </asp:GridView>
				 </td>
				<td   vAlign="top" width=1200px > 
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AutoGenerateColumns="False" Height="99px" 
                        onpageindexchanging="GridView1_PageIndexChanging" PageSize="100" 
                        style="margin-left: 0px; margin-right: 0px" Width=1400px>
                        <Columns>
                            <asp:BoundField DataField="xzgxh" HeaderText="工序号" >
                            <HeaderStyle HorizontalAlign="Left" Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TD" HeaderText="是否替代">
                            <HeaderStyle Wrap="False" HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="gxmc" HeaderText="工序描述">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dh" HeaderText="刀号" >
                            <HeaderStyle HorizontalAlign="Left" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DC" HeaderText="刀长">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SM" HeaderText="寿命" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="xzDJGROUPBH" HeaderText="刀具群组号" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="group_pt_desc1" 
                                HeaderText="刀具群组描述1">
                          
                            <HeaderStyle HorizontalAlign="Left" Width="120px" />
                          
                            </asp:BoundField>
                            <asp:BoundField DataField="group_pt_desc2" 
                                HeaderText="刀具群组描述2">
                        
                            <HeaderStyle HorizontalAlign="Left" />
                        
                            </asp:BoundField>
                            <asp:BoundField DataField="xzdjbh" HeaderText="子件编码" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MS2" HeaderText="子件编码描述1">
                          
                            <HeaderStyle HorizontalAlign="Left" />
                          
                            </asp:BoundField>
                            <asp:BoundField DataField="MS1" HeaderText="子件编码描述2">
                           
                            <HeaderStyle HorizontalAlign="Left" />
                           
                            </asp:BoundField>
                            <asp:BoundField DataField="ZJSL" HeaderText="子件数量" HtmlEncode="False">
                           
                            <HeaderStyle HorizontalAlign="Left" Width="70px" />
                           
                            </asp:BoundField>
                            <asp:BoundField DataField="PP" HeaderText="品牌" >
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="VD1" HeaderText="厂商">
                        
                            <HeaderStyle HorizontalAlign="Left" />
                        
                            </asp:BoundField>
                            <asp:BoundField DataField="BB" HeaderText="版本" >
                            <HeaderStyle HorizontalAlign="Left" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="xmcs" 
                                HeaderText="修磨&lt;br&gt;次数" HtmlEncode="False" >
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="djjs" DataFormatString="{0:F0}" 
                                HeaderText="角数" />
                            <asp:BoundField DataField="AQKC" 
                                HeaderText="安全&lt;br&gt;库存" HtmlEncode="False">
                            <HeaderStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="xs" HeaderText="系数" />
                        </Columns>
                        <FooterStyle HorizontalAlign="Right" />
                        <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                            Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                        <PagerStyle ForeColor="Red" />
                    </asp:GridView>
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

