<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LL_Query.aspx.cs" Inherits="LL_Query"  Theme="menu"%>

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
		    .style5
            {
                width: 156px;
            }
          
            .style14
            {
                width: 95px;
            }
                      
            .style17
            {
                width: 99px;
            }
            .style18
            {
                width: 105px;
            }
            .style19
            {
                width: 96px;
            }
          
            .style26
            {
                width: 975px;
            }
          
            </style>
	</HEAD>
	<BODY background="../Images/techserv_right_files/bottom_bg.gif" >
		<!--onload="body_load()"-->
       
		<FORM id="Form1" method="post" runat="server">
		 <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
  
<%--<script type="text/javascript">

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

</script>--%>

<script type="text/javascript">

    function checkAll(checked, lstName) {
        var input = document.getElementsByTagName("INPUT");
        for (var i = 0; i < input.length; i++) {
            if (lstName == null) {
                input[i].checked = checked;
            }
            else if (input[i].type == "checkbox" && input[i].id.length > lstName.length && input[i].id.indexOf(lstName) > 0) {
                input[i].checked = checked;
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
																						<td  class ="td1"><div class="td1"><asp:Menu ID=menu runat =server     DataSourceID="XmlDataSource1"  >
                                                                                          
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
			<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TBODY>
				
				
					<TR>
						<TD vAlign="top">
							<TABLE cellSpacing="0" cellPadding="5" border="0" 
                                style="height: 1633px; width: 105%; margin-right: 43px">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
												<TBODY>
													<TR>
													<td align="left"><asp:SiteMapPath ID=site runat =server  >
                                                            
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
                                                                                    <IMG height="25" src="Images/techserv_right_files/arrow-001db.gif" 
                                                                                        align="absMiddle" style="width: 22px">领料查询条件</FONT></FONT></TD>
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

                                                                                                <td  align="left">
                                                                                                    <asp:Panel ID="Panel4" runat="server">
                                                                                                        领料类型：&nbsp;
                                                                                                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                                                                                            Height="19px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                                                                                            Width="150px">
                                                                                                           
                                                                                                        </asp:DropDownList>
                                                                                                        
                                                                                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                                                                                            ImageUrl="~/Images/fdj.gif" onclick="ImageButton1_Click" />

                                                                                                   
                                                                                                        <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                                                                                                     
                                                                                                            Text="费用类领用请填写物料编码前缀">   </asp:Label>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                                <td class="style5">
                                                                                                    &nbsp;</td>
                                                                                                <td class="style1">&nbsp;</td>
                                                                                              
                                                                                                
                                                                                        </tr>
                                                                                            <tr>
                                                                                                <td class="style3" colspan="3">
                                                                                                    <asp:Panel ID="Panel2" runat="server" GroupingText="刀具领料查询" Width="1000px">
                                                                                                        <table width="1000">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    刀具组合号：</td>
                                                                                                                <td width="130px">
                                                                                                                    <asp:TextBox ID="txt_djzhh" runat="server" Height="19px" Width="130px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 100px">
                                                                                                                    &nbsp;项目号： 
                                                                                                                </td>
                                                                                                                <td width="100px">
                                                                                                                    <asp:TextBox ID="txt_cpmc" runat="server" Height="19px" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td width="100px">
                                                                                                                    零件号：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_ljh" runat="server" style="margin-left: 0px" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td  width="80px">
                                                                                                                    工序号：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_gxh" runat="server" style="margin-left: 0px" Width="80px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    公司代码：</td>
                                                                                                                <td style="width: 100px">
                                                                                                                    <asp:DropDownList ID="DropDownList3" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td style="width: 100px">
                                                                                                                    子件编码：</td>
                                                                                                                <td width="100px">
                                                                                                                    <asp:TextBox ID="txt_djzjbm" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td >
                                                                                                                    子件规格：</td>
                                                                                                                <td width="100px">
                                                                                                                    <asp:TextBox ID="txt_djzjgg" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="Button2" runat="server" class="STYLE1" onclick="Button2_Click" 
                                                                                                                        Text="查询" Width="64px" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </asp:Panel>
                                                                                                    <asp:Panel ID="Panel3" runat="server" GroupingText="设备领料查询" Width="1000px">
                                                                                                        <table width="1000">
                                                                                                            <tr>
                                                                                                                <td class="style19">
                                                                                                                    物料编码： 
                                                                                                                </td>
                                                                                                                <td width="130px">
                                                                                                                    <asp:TextBox ID="txt_sbwlbm" runat="server" Height="19px" Width="130px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td width="100px">
                                                                                                                    &nbsp;物料名称：</td>
                                                                                                                <td width="100px">
                                                                                                                    <asp:TextBox ID="txt_sbwlmc" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td class="style14">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    
                                                                                                                   
                                                                                                                    </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="style17">
                                                                                                                    公司代码：</td>
                                                                                                                <td class="style18">
                                                                                                                    <asp:DropDownList ID="DropDownList4" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td class="style19">
                                                                                                                    规格型号：</td>
                                                                                                                <td width="100px">
                                                                                                                    <asp:TextBox ID="txt_sbggxh" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td class="style14">
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="Button3" runat="server" class="STYLE1" onclick="Button3_Click" 
                                                                                                                        Text="查询" />
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
														<TD class="style26">
															<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#fff5d7" border="0">
																<TBODY>
																	<TR>
																		<TD width="75%" align="left"><FONT color="#666666" ><IMG height="25" 
                                                                                src="Images/techserv_right_files/arrow-001O.gif" width="22" align="absMiddle"><FONT class="download_name3" face="Ш蔨">库存清单
															</TABLE>
														</TD>
													</TR>
													<TR align="left" bgColor="#ffffff">
														<TD vAlign="top" class="style26">
															
															
															   <table  >
				   	<tr>
				 <td  colspan="2"> 
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                         <ContentTemplate>
                         <tr><td>
                            
                             <asp:Button ID="Button5" runat="server" Text="查看我的领料车"  
                                 style="margin-left: 665px" onclick="Button5_Click" Visible="False"  />
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                
                                 Width="100%" AllowPaging="True" 
                                 onpageindexchanging="GridView1_PageIndexChanging" PageSize="150">
                                 <Columns>
                                     <asp:BoundField DataField="pt_part" HeaderText="物料编码">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_desc1" HeaderText="物料名称">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_desc2" HeaderText="规格型号">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_um" HeaderText="单位">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="ld_qty_oh" HeaderText="数量" />
                                     <asp:BoundField DataField="domain" HeaderText="公司">
                                     <ControlStyle CssClass="hidden" Width="0px" />
                                     <FooterStyle CssClass="hidden" Width="0px" />
                                     <HeaderStyle CssClass="hidden" Width="0px" />
                                     <ItemStyle CssClass="hidden" Width="0px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_sfty_stk" HeaderText="安全库存量">
                                     </asp:BoundField>
                                     <asp:BoundField DataField="loc" HeaderText="库位" />
                                     <asp:TemplateField HeaderText="操作">
                                         <ItemTemplate>
                                             <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
                                                 Text="加入我的领料车" />
                                             <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/lyc.JPG" 
                                                 Visible="False" />
                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>
                                 
                                 <FooterStyle HorizontalAlign="Right" />
                                 <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                                     Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                                 <PagerStyle ForeColor="Red" />
                              
                             </asp:GridView>
                             </td></tr>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                        </td>
				</tr>
                <tr>
                 <td  colspan="2"> 
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                         <ContentTemplate>
                         <tr><td>
                            
                             <asp:Button ID="Button6" runat="server" Text="加入我的领料车"  
                                 style="margin-left: 665px"  Visible="False" onclick="Button6_Click"  />
                             &nbsp;&nbsp;&nbsp;
                             <asp:Button ID="Button1" runat="server" onclick="Button5_Click" 
                                 Text="查看我的领料车" Visible="false" />
                             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                
                                 Width="100%" AllowPaging="true"
                                 onpageindexchanging="GridView2_PageIndexChanging" PageSize="150">
                                 <Columns>
                                  <asp:TemplateField HeaderText="选择">
                                 <HeaderTemplate>
                         <asp:CheckBox ID="CheckAll" runat="server" onclick="checkAll(this.checked)"/>
                         <asp:Label ID="Label1" runat="server" Text="全选"></asp:Label>



                                                        </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:CheckBox ID="chkSelect" runat="server" />
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" Wrap="False" Width="60px" />
                                 <ItemStyle Wrap="False" />
                             </asp:TemplateField>
                                     <asp:BoundField DataField="pt_group_part" HeaderText="刀具组合号" />
                                     <asp:BoundField DataField="pt_part" HeaderText="物料编码">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_desc1" HeaderText="物料名称">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_desc2" HeaderText="规格型号">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="LJH" HeaderText="零件号" />
                                     <asp:BoundField DataField="pgixmh" HeaderText="项目号" />
                                     <asp:BoundField DataField="pt_um" HeaderText="单位">
                                     <HeaderStyle ForeColor="Brown" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="ld_qty_oh" HeaderText="数量" />
                                     <asp:BoundField DataField="domain" HeaderText="公司">
                                     <ControlStyle CssClass="hidden" Width="0px" />
                                     <FooterStyle CssClass="hidden" Width="0px" />
                                     <HeaderStyle CssClass="hidden" Width="0px" />
                                     <ItemStyle CssClass="hidden" Width="0px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="pt_sfty_stk" HeaderText="安全&lt;br&gt;库存量" 
                                         HtmlEncode="False">
                                     </asp:BoundField>
                                     <asp:BoundField DataField="bb" HeaderText="版本">
                                     <ControlStyle CssClass="hidden" Width="0px" />
                                     <FooterStyle CssClass="hidden" Width="0px" />
                                     <HeaderStyle CssClass="hidden" Width="0px" />
                                     <ItemStyle CssClass="hidden" Width="0px" />
                                     </asp:BoundField>
                                     <asp:BoundField DataField="xzgxh" HeaderText="工序号">
                                     </asp:BoundField>
                                     <asp:BoundField DataField="TD" HeaderText="是否&lt;br&gt;替代" HtmlEncode="False" />
                                     <asp:BoundField DataField="loc" HeaderText="库位" />
                                 </Columns>
                                 
                                 <FooterStyle HorizontalAlign="Right" />
                                 <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                                     Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                                 <PagerStyle ForeColor="Red" />
                             
                             </asp:GridView>
                             </td></tr>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                        </td>
                </tr>
                <tr>
                <td>
                    <asp:Label ID="lbs_Message" runat="server" ForeColor="Red" Visible="False"></asp:Label>
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

