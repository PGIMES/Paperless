<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Record_Query.aspx.cs" Inherits="Report_Record_Query" Theme="menu" %>


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
		<LINK href="../Styles/mflex.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/default.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/Style.css" type="text/css" rel="stylesheet">
		<LINK href="../Styles/skmMenuStyles.css" type="text/css" rel="stylesheet">
		<SCRIPT src="../js/js_leftmenu_go.js"></SCRIPT>
		<SCRIPT src="../js/js_hide_loading.js"></SCRIPT>
		<SCRIPT src="../js/techserv_right.js"></SCRIPT>
        <script type="text/javascript">
            var prevselitem = null;
            function selectx(row) {
                if (prevselitem != null) {
                    prevselitem.style.backgroundColor = '#ffffff';
                }
                row.style.backgroundColor = 'PeachPuff';
                prevselitem = row;

            }
            

 </script>
		<style type="text/css">.tablestyle1 { BORDER-RIGHT: #4e4e4e 1px solid; BORDER-TOP: #e4e4e4 1px solid; BACKGROUND: #fdfdfd; FONT: 12px "Ш蔨", Arial; VERTICAL-ALIGN: middle; BORDER-LEFT: #e4e4e4 1px solid; COLOR: #777777; BORDER-BOTTOM: #4e4e4e 1px solid; TEXT-ALIGN: center; TEXT-DECORATION: none }
	.Tdstyle1 { BORDER-RIGHT: #e6e6e6 1px solid; BORDER-TOP: #e6e6e6 1px solid; BACKGROUND: #fdfdfd; BORDER-LEFT: #e6e6e6 1px solid; CURSOR: hand; BORDER-BOTTOM: #e6e6e6 1px solid; TEXT-DECORATION: none }
	.Titledivstyle { TEXT-JUSTIFY: distribute-all-lines; TEXT-ALIGN: justify }
	.inf1 { COLOR: #edb905 }
	.inf2 { COLOR: #107460 }
	BODY { MARGIN-TOP: 0px; MARGIN-LEFT: 0px;
                font-weight: 700;
            }
		   
              .hidden { display:none;}
		     .hidden1
            {
            	border:0px; 
            	overflow:hidden
            	
            	}
            	  .size1
            {
            	cursor:hand;
            	text-decoration:underline;
            	
            	}
            
		col{word-break:break-all;}
		    </style>
             <style> 
.Freezing 
   { 
    
   position:relative ; 
   table-layout:fixed;
   top:expression(this.offsetParent.scrollTop);   
   z-index: 10;
   }

.Freezing th{text-overflow:ellipsis;overflow:hidden;white-space: nowrap;padding:2px;}
                
                
                 .style1
                
                
                
             </style> 
	</HEAD>
	<BODY background="../Images/techserv_right_files/bottom_bg.gif" >
		<!--onload="body_load()"-->
		<FORM id="Form1" method="post" runat="server">
		
				
<script language="javascript">
    function refresh() {
        this.location = this.location;
    }
	</script>
 <input type="hidden" name="__SCROLLPOS" value="" />
   <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
			<TABLE cellSpacing="0" cellPadding="3" width="100%" border="0">
				<TBODY>
				
				<tr>
												<td>
												
												<TABLE cellSpacing="0" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													
													<TR>
														<TD background="../Images/topbg.gif">
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
							<TABLE height="250" cellSpacing="0" cellPadding="5"  width="100%" border="0">
								<TBODY>
									<TR>
										<TD vAlign="top" align="center">
											
											<asp:panel id="ppladduser" Runat="server">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD id="inf1" align="center" bgColor="#ffffff">
															<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
																<TR align="center" bgColor="#ffffff">
																	<TD>
																		<TABLE cellSpacing="0" cellPadding="3" width="100%" bgColor="#ffffff" border="0">
																			<TR>
																				<TD bgColor="#d7dfe8">
                                                                                <table width=100%>
                                                                                <tr>
                                                                                <td>
                                                                                  <font color="#999999"><font class="download_name3" color="#4d4d4d">
                                                                                 选择:
                                                                                 &nbsp;&nbsp;
                                                                                                <asp:DropDownList ID="txtyear" runat="server">
                                                                                                </asp:DropDownList>&nbsp;&nbsp;
                                                                                 &nbsp;&nbsp; <asp:DropDownList ID="txttype" runat="server">
                                                                                                    <asp:ListItem Value="1">日</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">周</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">月</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                &nbsp; &nbsp; 工厂:&nbsp;&nbsp;
                                                                                                <asp:DropDownList ID="txtfactory" runat="server">
                                                                                                    <asp:ListItem Value=" ">ALL</asp:ListItem>
                                                                                                    <asp:ListItem>200</asp:ListItem>
                                                                                                    <asp:ListItem>100</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                &nbsp; &nbsp; &nbsp; &nbsp;领用类型：
                                                                                                <asp:DropDownList ID="lylx" runat="server">
                                                                                                     
                                                                                                </asp:DropDownList>
                                                                                                &nbsp; &nbsp; 领料人：<font color="#999999"><font class="download_name3" 
                                                                                        color="#4d4d4d"><asp:TextBox ID="txtllr" runat="server" Width="100"></asp:TextBox>
                                                                                    </font></font>&nbsp;<asp:Button ID="btnOK" runat="server" 
                                                                                        Text=" 确定 " onclick="btnOK_Click" />
                                                                                                &nbsp; &nbsp; &nbsp;</font></td>
                                                                                <td align=right class="style1">
                                                                               
                                                                                    <asp:Label ID="Label2" runat="server" Text="领料记录报表分析" ForeColor=Blue 
                                                                                        Font-Bold=True></asp:Label></td>
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
												
												
											</asp:panel>
											
				
											<TABLE cellSpacing="7" cellPadding="0" width="100%" bgColor="#ffffff" border="0">
												<TBODY>
													
													<TR align="left" bgColor="#ffffff">
														<TD vAlign="top">
															<table width=100%>
                                                            <tr>
                                                            <td>
                                                                <asp:UpdatePanel runat="server" ID="UpdatePanel10"  >
                                                                        <ContentTemplate>
                                                                <table width=1300>
                                                                    <tr>
                                                                        
                                                                        <%--图表二开始--%>
                                                                           <td width="650">
                                                                           <asp:Chart id="C1" runat="server" Palette="none" BackColor="#F3DFC1" 
                                                                                ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="650px" 
                                                                                Height="200px" BorderDashStyle="Solid" BackGradientStyle="TopBottom" 
                                                                                BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								 <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" TitleAlignment="Center"
                        Font="Trebuchet MS, 8.25pt, style=Bold" MaximumAutoSize="20" >
                    </asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								
							    <asp:Series BorderWidth="3" ChartArea="ChartArea1" Legend="Default" 
                                    Name="Series1" ShadowOffset="3" LegendText="领用数量" ChartType="Line" 
                                    LabelBorderWidth="9" MarkerSize="8" MarkerStyle="Circle">
                                </asp:Series>
								
							</series>
                           
							 <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                        BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False"></Area3DStyle>
                        <AxisY LineColor="64, 64, 64, 64" TitleAlignment="Far">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                       <AxisX LineColor="64, 64, 64, 64" Interval="1">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
						</asp:Chart>
                                                                     
                                                                           <%--图表二结束--%>
                                                                            </td>
                                                                            <td width=650>
                                                                                <%-- 图表一开始--%>
                                                                           
                                                                                <%-- 图表一结束--%>
                                                                           
                                                                                 <asp:Chart id="C2" runat="server" Palette="none" BackColor="#F3DFC1" 
                                                                                ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" Width="650px" 
                                                                                Height="200px" BorderDashStyle="Solid" BackGradientStyle="TopBottom" 
                                                                                BorderWidth="2" BorderColor="181, 64, 1">
							<legends>
								 <asp:Legend IsTextAutoFit="False" Name="Default" BackColor="Transparent" TitleAlignment="Center"
                        Font="Trebuchet MS, 8.25pt, style=Bold" MaximumAutoSize="20" >
                    </asp:Legend>
							</legends>
							<borderskin SkinStyle="Emboss"></borderskin>
							<series>
								
							    <asp:Series BorderWidth="3" ChartArea="ChartArea1" Legend="Default" 
                                    Name="Series1" ShadowOffset="3" LegendText="总成本" ChartType="Line" 
                                    LabelBorderWidth="9" MarkerSize="8" MarkerStyle="Circle">
                                </asp:Series>
								
							</series>
                           
							 <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                        BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                        BackGradientStyle="TopBottom">
                        <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                            WallWidth="0" IsClustered="False"></Area3DStyle>
                        <AxisY LineColor="64, 64, 64, 64" TitleAlignment="Far">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisY>
                       <AxisX LineColor="64, 64, 64, 64" Interval="1">
                            <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                            <MajorGrid LineColor="64, 64, 64, 64" />
                        </AxisX>
                    </asp:ChartArea>
                </ChartAreas>
						</asp:Chart>
                                                                           </td>
                                                                        
                                                                    </tr>
                                                                     <tr>
                                                                        <td width=50%>
                                                                         
                                                                           </td>
                                                                       
                                                                           <td width="50%">
                                                                     
                                                                         
                                                                            </td>
                                                                    </tr>
                                                                </table>
                                                                </ContentTemplate></asp:UpdatePanel>
                                                                </td>
                                                           
                                                            </tr>
                                                            <tr>
                                                            <td>
                                                                <table >
                                                                <tr>
                                                                 <td>
                                                                 
                                                                   <div style=" overflow: scroll; height: 400px;width:221px; margin-right: 0px;" 
                                                                         id="Div4" runat="server">
                                                                             <asp:UpdatePanel runat="server" ID="UpdatePanel4"  >
                                                                        <ContentTemplate>
                   <asp:GridView ID="gv1" runat="server"    AutoGenerateColumns="False" CellPadding="3" 
                                                                                     BackColor="White" BorderColor="#CCCCCC" 
                                                                              BorderStyle="None" BorderWidth="1px" Font-Size="12px"
                                                                                     AllowSorting="True" ShowFooter="True"  onrowcreated="gv1_RowCreated" 
                                                                                Width="196px" onsorting="gv1_Sorting" 
                                                                                
                                                                                     >
                        <Columns>


                        <asp:TemplateField HeaderText="日期"  >                   
                    <ItemTemplate>
                   <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                            OnClick="LinkButton1_Click" Text='<%#Eval("date") %>' Width="35" ForeColor=Blue ></asp:LinkButton>   
                </ItemTemplate>
                       <ItemStyle Width="35px" Wrap="False"  ForeColor="Blue" CssClass="size1"/>
                </asp:TemplateField> 

                 <asp:BoundField DataField="quantity" HeaderText="领用数量" 
                                HeaderStyle-ForeColor="Brown">
                           
                            <HeaderStyle ForeColor="Brown" />
                           
                            </asp:BoundField>

                            
                          
                            <asp:BoundField DataField="totalamount" HeaderText="总成本" />

                            
                          
                        </Columns>
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left"  CssClass="ms-formlabel DataGridFixedHeader"/>
                        <HeaderStyle BackColor="#cccccc" Font-Bold="True" ForeColor="White" CssClass="Freezing"/>
                    </asp:GridView>
                    
                                                                         
                    </ContentTemplate></asp:UpdatePanel>

                       
                  
        </div>
                                                                 </td>
                                                                 <td >
                                                                 
                                                                 
                                                                         <asp:UpdatePanel runat="server" ID="UpdatePanel5" >
                                                                       
                                                                        <ContentTemplate>
                                                                            <div style="height: 400px; width: 450px;" id="Div1"  runat="server">
                                                                                <div ID="Div5" runat="server" 
                                                                                    style="overflow: scroll; height: 400px;width:413px">
                                                                                    <asp:GridView ID="gv2" runat="server" AllowSorting="True" 
                                                                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                                                                        BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                                                                                        ShowFooter="True" style="margin-left: 0px" onrowcreated="gv2_RowCreated" 
                                                                                        Width="386px" >
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="date" HeaderStyle-ForeColor="Brown" HeaderText="日期">
                                                                                            <ControlStyle CssClass="hidden" Width="0px" />
                                                                                            <FooterStyle CssClass="hidden" Width="0px" />
                                                                                            <HeaderStyle ForeColor="Brown" CssClass="hidden" Width="0px" />
                                                                                            <ItemStyle CssClass="hidden" Width="0px" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="ljh" HeaderStyle-ForeColor="Brown" 
                                                                                                HeaderText="零件号">
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="gxh" HeaderText="工序号" />
                                                                                            <asp:BoundField DataField="quantity" HeaderText="领用数量" />
                                                                                            <asp:BoundField DataField="totalamount" HeaderText="领用金额" />
                                                                                            <asp:BoundField DataField="scsl" HeaderText="生产数量" />
                                                                                            <asp:BoundField DataField="djcb" HeaderText="单件成本" />
                                                                                        </Columns>
                                                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="White" CssClass="ms-formlabel DataGridFixedHeader" 
                                                                                            ForeColor="#000066" HorizontalAlign="Left" />
                                                                                        <HeaderStyle BackColor="#cccccc" CssClass="Freezing" Font-Bold="True" 
                                                                                            ForeColor="White" />
                                                                                    </asp:GridView>
                                                                                </div>
                    
        </div></ContentTemplate></asp:UpdatePanel>
                                                                 </td>
                                                                    
                                                                     <td>
                                                                    <div style=" overflow: scroll; height: 393px; margin-left: 5px; width: 296px; margin-right: 5px;" id="Div2" 
                                                                             runat="server">
                                                                             <asp:UpdatePanel runat="server" ID="UpdatePanel6"  >
                                                                                 <ContentTemplate>
                                                                                     <asp:GridView ID="gv6" runat="server" AllowSorting="True" 
                                                                                         AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                                                                         BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                                                                                         ShowFooter="True" Width="262px" onrowcreated="gv6_RowCreated">
                                                                                         <Columns>
                                                                                             <asp:BoundField DataField="date" HeaderStyle-ForeColor="Brown" 
                                                                                                 HeaderText="日期" >
                                                                                             <ControlStyle CssClass="hidden" Width="0px" />
                                                                                             <FooterStyle CssClass="hidden" Width="0px" />
                                                                                             <HeaderStyle ForeColor="Brown" CssClass="hidden" Width="0px" />
                                                                                             <ItemStyle CssClass="hidden" Width="0px" />
                                                                                             </asp:BoundField>
                                                                                             <asp:TemplateField HeaderText="机器号"  >                   
                                                                                                <ItemTemplate>
                                                                                               <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" 
                                                                                                        OnClick="LinkButton4_Click" Text='<%#Eval("mo_key") %>' Width="35" ForeColor=Blue ></asp:LinkButton>   
                                                                                            </ItemTemplate>
                                                                                                   <ItemStyle Wrap="False"  ForeColor="Blue"/>
                                                                                            </asp:TemplateField> 
                                                                                             <asp:BoundField DataField="quantity" HeaderStyle-ForeColor="Brown" 
                                                                                                 HeaderText="领用数量 ">
                                                                                             <HeaderStyle ForeColor="Brown" />
                                                                                             </asp:BoundField>
                                                                                         </Columns>
                                                                                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                         <PagerStyle BackColor="White" CssClass="ms-formlabel DataGridFixedHeader" 
                                                                                             ForeColor="#000066" HorizontalAlign="Left" />
                                                                                         <HeaderStyle BackColor="#cccccc" CssClass="Freezing" Font-Bold="True" 
                                                                                             ForeColor="White" />
                                                                                     </asp:GridView>
                                                                                 </ContentTemplate>
                                                                             </asp:UpdatePanel>

                       
                  
        </div>
        </td>
                                                                    
                                                                  
                                                                    <td>
                                                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                            <ContentTemplate>
                                                                                
                                                                                    <div ID="Div7" runat="server" 
                                                                                        style="overflow: scroll; height: 400px;width:554px; margin-left: 8px;">
                                                                                        <asp:GridView ID="gv3" runat="server" AllowSorting="True" 
                                                                                            AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
                                                                                            BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Size="12px" 
                                                                                            ShowFooter="True" style="margin-left: 0px" Width="532px" 
                                                                                            onrowcreated="gv3_RowCreated">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="group_part" HeaderText="刀具群组号" >
                                                                                                <ControlStyle CssClass="hidden" Width="0px" />
                                                                                                <FooterStyle CssClass="hidden" Width="0px" />
                                                                                                <HeaderStyle CssClass="hidden" Width="0px" />
                                                                                                <ItemStyle CssClass="hidden" Width="0px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="part" HeaderStyle-ForeColor="Brown" 
                                                                                                    HeaderText="物料编码">
                                                                                                <HeaderStyle ForeColor="Brown" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="desc1" HeaderText="描述" />
                                                                                                <asp:BoundField DataField="quantity" HeaderText="领用数量" />
                                                                                                <asp:BoundField DataField="unit" HeaderText="单位" >
                                                                                                <ControlStyle CssClass="hidden" Width="0px" />
                                                                                                <FooterStyle CssClass="hidden" Width="0px" />
                                                                                                <HeaderStyle CssClass="hidden" Width="0px" />
                                                                                                <ItemStyle CssClass="hidden" Width="0px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="create_uid" HeaderText="领料人" >
                                                                                                <ControlStyle CssClass="hidden" Width="0px" />
                                                                                                <FooterStyle CssClass="hidden" Width="0px" />
                                                                                                <HeaderStyle CssClass="hidden" Width="0px" />
                                                                                                <ItemStyle CssClass="hidden" Width="0px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="price" HeaderText="参考价格" />
                                                                                                <asp:BoundField DataField="totalamount" HeaderText="总价" />
                                                                                                <asp:BoundField DataField="date" HeaderText="日期">
                                                                                                <ControlStyle CssClass="hidden" Width="0px" />
                                                                                                <FooterStyle CssClass="hidden" Width="0px" />
                                                                                                <HeaderStyle CssClass="hidden" Width="0px" />
                                                                                                <ItemStyle CssClass="hidden" Width="0px" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="lldh" HeaderText="领料单号" >
                                                                                                </asp:BoundField>
                                                                                            </Columns>
                                                                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                                            <PagerStyle BackColor="White" CssClass="ms-formlabel DataGridFixedHeader" 
                                                                                                ForeColor="#000066" HorizontalAlign="Left" />
                                                                                            <HeaderStyle BackColor="#cccccc" CssClass="Freezing" Font-Bold="True" 
                                                                                                ForeColor="White" />
                                                                                        </asp:GridView>
                                                                                  
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    
                                                                  
                                                                 </tr>
                                                                    <tr>
                                                                        <td>
                                                                        
                                                                   
                                                                        </td>
                                                                        <td class="style3" >
                                                                            </td>

          <td class="style4">
              
                                                                         </td>

          <td class="style5">
              
                                                                         &nbsp;</td>
                                                                    </tr>



                                                                    <%--  <asp:BoundField DataField="gfsl">
                            <ControlStyle CssClass="hidden" Width="0px" />
                            <FooterStyle CssClass="hidden" Width="0px"/>
                            <HeaderStyle CssClass="hidden" Width="0px"/>
                            <ItemStyle CssClass="hidden" Width="0px"/>
                            </asp:BoundField>

                              <asp:BoundField DataField="lfsl">
                            <ControlStyle CssClass="hidden" Width="0px" />
                            <FooterStyle CssClass="hidden" Width="0px"/>
                            <HeaderStyle CssClass="hidden" Width="0px"/>
                            <ItemStyle CssClass="hidden" Width="0px"/>
                            </asp:BoundField>--%>
                                                                      <tr>
                                                                       
                                                                        <td class="style2">
                                                                            &nbsp;</td>
         <td >
                                                                        
                                                                             &nbsp;</td>
          <td class="style4">
              
                                                                         &nbsp;</td>
         <td class="style3">
                                                                 
                                                                 
                                                                         &nbsp;</td>
                                                                    </tr>
                                                                   

                                                                      </table>
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

