<%@ Page Language="C#" AutoEventWireup="true" CodeFile="My_Car.aspx.cs" Inherits="My_Car"  Theme="menu" MaintainScrollPositionOnPostback="true"  enableEventValidation="false"%>

<%@ Register TagPrefix="Partners" TagName="userinfor" Src="~/Ascxs/UserInfor.ascx" %>
<%@ Register TagPrefix="Partners" TagName="foothead" Src="~/Ascxs/footheard.ascx" %>

<%@ Register TagPrefix="Partners" TagName="tophead" Src="~/Ascxs/tophead.ascx" %>

<%@ Register assembly="DevExpress.Web.v17.2, Version=17.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

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
        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/layer.js" type="text/javascript"></script>
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
            {                height: 26px;
            }
            .style3
            {
            }
		    .style5
            {
                width: 156px;
            }
          
            .style6
            {
                width: 1300px;
            }
          
            .style7
            {
                width: 140px;
            }
          
            .style8
            {
                width: 124px;
            }
          
            .style9
            {
                width: 141px;
            }
          
            .GridViewCssClass
            {}
          
            </style>
	</HEAD>
	<BODY background="http://localhost:60130/Images/techserv_right_files/bottom_bg.gif" >
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

 <script   language="javascript" type="text/javascript"> 
        function   Setdisabled(object1) 
        { 
            object1.disabled=true;        //变灰 ，使提交按钮不可连续点击
            __doPostBack(object1.name,"");     //执行服务器端button1的click事件  这里特别要注意是object1.name 而不能是 object1.id, 因为页面可能含有母版页
        } 
     </script> 

<script type="text/javascript">
    $(document).ready(function () {
        var uid_role = '<%=role%>';
        uid_comp = '<%=uid_comp%>';
        //  alert(uid_role);
        if (uid_role != "调试组") {
            $("#btn_lycode").css("display", "none");
            $("#Button4").hide();
            $("#Button2").show();
        }
        else {
            $("#Button4").show();
            $("#Button2").hide();
        }
        $("#btn_lycode").click(function () {
            var totalRow = $("#<%=GridView2.ClientID %> tr").length - 1;
            if (totalRow < 0) {
                alert("请先查询领用清单!");
                return false;
            }
            else {
                $("#Div_daoju").css("display", "block");
                $("#dropOthercode").empty();
                if ($("#dropCode").val() == "其它" || $("#dropCode").val() == "仓库调整") {
                    $('#txt_othercode').css('display', 'block');
                    $('#dropOthercode').css('display', 'none');
                }
            }

        });

        $("#btn_set").click(function () {
            if (($("#dropCode").val() == "")) {
                alert("请选择领用原因!");
                return false;
            }
            if ($('#txt_othercode').css('display') == 'block' && $('#txt_othercode').val() == "") {
                alert("请选择领用原因!");
                return false;
            }
            if ($('#dropOthercode').css('display') == 'block' && $('#dropOthercode').val() == "--请选择--") {
                alert("请选择领用原因!");
                return false;
            }

        });
        $("select[id*='dropCode']").change(function () {
            bindSelect($("#dropCode").val());
            if ($("#dropCode").val() == "其它" || $("#dropCode").val() == "仓库调整") {
                $("select[id*='dropOthercode']").css("display", "none");
                $("#txt_othercode").css("display", "block");
            }
            else {
                $("select[id*='dropOthercode']").css("display", "block");
                $("#txt_othercode").css("display", "none");
            }

        });

        $("input[id*='txtCount']").change(function () {
            if ($(this).val() == "0") {
                alert("领用数量至少为1个,不可为0！");
                $(this).val(1);
            }
        });

    });

    function Add(e) {
          var ss = e.id.split("_"); // 在每个逗号(,)处进行分解。 GridView2_ctl02_txtCount
        //  var t = $("input[id*='GridView2_" + ss[1] + "_txtCount']").val();
          var t = $("input[id*='"+ss[0]+"_" + ss[1] + "_txtCount']").val();
          $("input[id*='" + ss[0] + "_" + ss[1] + "_txtCount']").val(parseInt(t) + 1);
      }

      function Remove(e) {
          var ss = e.id.split("_"); // 在每个逗号(,)处进行分解。 GridView2_ctl02_txtCount
          //  var t = $("input[id*='GridView2_" + ss[1] + "_txtCount']").val();
          var t = $("input[id*='" + ss[0] + "_" + ss[1] + "_txtCount']").val();
          if (parseInt(t) >= 2) {
              $("input[id*='" + ss[0] + "_" + ss[1] + "_txtCount']").val(parseInt(t) - 1)
          }
          else {
              $("input[id*='" + ss[0] + "_" + ss[1] + "btnRemoveOne']").attr("disabled", "disabled");
          }
      }
     </script>

     

<script type="text/javascript">

        function SelectAllCheckboxes(spanChk) {
            elm = document.forms[0];
            for (i = 0; i < elm.length; i++) {
               
                if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                    if (elm.elements[i].checked != spanChk.checked)
                        elm.elements[i].click();
                }
            }
        }


    function bindSelect(sel) {
        $.ajax({
            type: "Post", async: false,
            url: "My_Car.aspx/SetOtherCode",
            //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字
            //P1:wlh P2：  
            data: "{'sel':'" + sel + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {//返回的数据用data.d获取内容//      
                $("#dropOthercode").empty();
                $("#dropOthercode").append($("<option>").val("--请选择--").text("--请选择--"));
                $.each(eval(data.d), function (i, item) {
                    var option = $("<option>").val(item.value).text(item.text);
                    $("#dropOthercode").append(option);
                   
                })
            },
            error: function (err) {
                layer.alert(err);
            }
        });
    }
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

//    function Getmove_code(dept, part, comp, status, vi) {
//        var movecode = eval('ddl_mcode' + vi);
//        //alert(movecode);
//        $.ajax({
//            type: "Post", async: false,
//            url: "My_Car.aspx/GetMoveCode",
//            //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字
//            //P1:wlh P2： 
//            data: "{'dept':'" + dept + "','part':'" + part + "','comp':'" + comp + "','status':'" + status + "'}",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (data) {//返回的数据用data.d获取内容//      
//               // $("#dropOthercode").empty();

//                $("#GridView1_ctl03_ddlcode").append($("<option>").val("--请选择--").text("--请选择--"));
//                $.each(eval(data.d), function (i, item) {
//                    var option = $("<option>").val(item.value).text(item.text);
//                    $("#dropOthercode").append(option);

//                })
//            },
//            error: function (err) {
//                layer.alert(err);
//            }
//        });
//    }

    //自动获取研发项目号
    function Getyf_code(vi) {
        var xmh = eval('xmh_select' + vi);
        codevalue = $.trim(xmh.GetValue());
        var comp = $("#viscomp").val();
        var dept = $("#visdept").val();
        var yfxm_code = eval('txt_yfxm' + vi);
        var yfxm_status = eval('txt_status' + vi);
        $.ajax({
            type: "post",
            url: "My_Car.aspx/Getcode",
            data: "{'code':'" + codevalue + "','comp':'" + comp + "','dept':'" + dept + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false, //默认是true，异步；false为同步，此方法执行完在执行下面代码
            success: function (data) {//返回的数据用data.d获取内容// 
                var obj = eval(data.d);
                var code = obj[0].yfcode;
                var status = obj[0].status;
                yfxm_code.SetText(code);
                yfxm_status.SetText(status);
               //Getmove_code(dept, part, comp, status, vi)
            },
            error: function (err) {
                layer.alert(err);
            }
        });

    }

</script>
<script language="javascript" type="text/javascript">
    function deleteConfirm() {
        return window.confirm("确定要删除此物料领用吗？");
    }
	</script>

<script language="javascript">
    function refresh() {
        this.location = this.location;
    }
    function btn_lycode_onclick() {

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
                                                                                            </asp:XmlDataSource>
                                                                                        </td>
                                                                                        </div>
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
                                                                                    <IMG height="25" src="Images/techserv_right_files/arrow-001db.gif" width="22" 
                                                                                        align="absMiddle">领料</FONT><FONT class="download_name3" color="#4d4d4d">类型选择</FONT></FONT></TD>
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

                                                                                                <td class="style3" align="left">
                                                                                                    <asp:Panel ID="Panel4" runat="server">
                                                                                                        领料类型：&nbsp;
                                                                                                        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" 
                                                                                                            Height="19px" onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                                                                                                            Width="150px">
                                                                                                        </asp:DropDownList>
                                                                                                        <asp:TextBox ID="viscomp" runat="server" CssClass=" hidden" 
                                                                                                            Width="40" />
                                                                                                             <asp:TextBox ID="visdept" runat="server" CssClass=" hidden" 
                                                                                                            Width="40" />
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                                <td class="style5">
                                                                                                    &nbsp;</td>
                                                                                                <td class="style1">&nbsp;</td>
                                                                                              
                                                                                                
                                                                                        </tr>
                                                                                            <tr>
                                                                                                <td class="style3" colspan="3">
                                                                                                    <asp:Panel ID="Panel2" runat="server" GroupingText="刀具领料查询" Width="800px">
                                                                                                        <table width="800">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    刀具组合号： 
                                                                                                                </td>
                                                                                                                <td class="style7">
                                                                                                                    <asp:TextBox ID="txt_djzhh" runat="server" Height="19px" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    子件编码：</td>
                                                                                                                <td class="style8">
                                                                                                                    <asp:TextBox ID="txt_zjbm" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    子件规格：</td>
                                                                                                                <td class="style7">
                                                                                                                    <asp:TextBox ID="txt_zjgg" runat="server" style="margin-left: 0px" 
                                                                                                                        Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    &nbsp;</td>
                                                                                                                <td class="style8">
                                                                                                                    <asp:Button ID="Button4" runat="server" class="STYLE1" 
                                                                                                                        onclick="Button4_Click" Text="查询领料车" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="Button2" runat="server" class="STYLE1" onclick="Button2_Click" 
                                                                                                                        Text="查询领料车" />
                                                                                                                </td>

                                                                                                                <td>
                                                                                                                    &nbsp;</td>
                                                                                                                <td>
                                                                                                                    <input id="btn_lycode" type="button" value="批量设置领用原因" onclick="return btn_lycode_onclick()" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                          <div id="Div_daoju"  runat="server"  style=" display:none">
                                                                                                    <table>
                                                                                                    <tr>
                                                                                                    <td style="width: 100px">领用原因:</td>
                                                                                                    <td><asp:DropDownList ID="dropCode" runat="server">
                                                                                                    </asp:DropDownList></td>
                                                                                                     <td><asp:DropDownList ID="dropOthercode" runat="server"> 
                                                                                                     </asp:DropDownList>
                                                                                                     <asp:TextBox ID="txt_othercode" runat="server"  style=" display:none" ></asp:TextBox></td>
                                                                                                       <td><asp:Button ID="btn_set" runat="server" Text="确认"  Width="60px"  
                                                                                                             onclick="btn_set_Click" />
                                                                                                     </td>
                                                                                                    </tr>
																								 </table>
                                                                                                    </div>
                                                                                                    </asp:Panel>
                                                                                                    <asp:Panel ID="Panel3" runat="server" GroupingText="设备/其他领料查询" Width="800px">
                                                                                                        <table width="800">
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    物料编码： 
                                                                                                                </td>
                                                                                                                <td class="style9">
                                                                                                                    <asp:TextBox ID="txt_sbwlbm" runat="server"  Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                    物料名称：</td>
                                                                                                                <td>
                                                                                                                    <asp:TextBox ID="txt_sbwlmc" runat="server" style="margin-left: 0px"  Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td style="width: 100px">
                                                                                                                    规格型号：</td>
                                                                                                                <td class="style9">
                                                                                                                    <asp:TextBox ID="txt_sbggxh" runat="server" Width="100px"></asp:TextBox>
                                                                                                                </td>
                                                                                                                <td style="width: 87px">
                                                                                                                  
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="Button3" runat="server" class="STYLE1" onclick="Button3_Click" 
                                                                                                                        Text="查询领料车" />
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
                                                                                src="Images/techserv_right_files/arrow-001O.gif" width="22" align="absMiddle"><FONT class="download_name3" face="Ш蔨">领料车清单
																		</TBODY>
															</TABLE>
														</TD>
													</TR>
													<TR align="left" bgColor="#ffffff">
														<TD vAlign="top">
															
															
															   <table  >
				   	                                               <tr>
				 <td class="style6"> 
                     <asp:GridView ID="GridView1" runat="server"  
                         AutoGenerateColumns="False" CssClass="GridViewCssClass" 
                         Width="1350px" Height="70px" 
                         onpageindexchanging="GridView1_PageIndexChanging" PageSize="200"  BorderWidth=1
                         onrowdatabound="GridView1_RowDataBound" 
                         onrowcreated="GridView1_RowCreated">
                         <Columns>
                             <asp:TemplateField HeaderText="选择">
                                 <HeaderTemplate>
                         <asp:CheckBox ID="CheckAll0" runat="server" 
                                         AutoPostBack="True" 
                                         oncheckedchanged="CheckAll0_CheckedChanged"/>
                         <asp:Label ID="Label2" runat="server" Text="全选"></asp:Label>



                                                        </HeaderTemplate>
                                 <ItemTemplate>
                                     &nbsp;
                                     <asp:CheckBox ID="chkSelect0" runat="server" AutoPostBack="True" />
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" Wrap="False" Width="30px" />
                                 <ItemStyle Wrap="False" />
                             </asp:TemplateField>
                             <asp:BoundField DataField="part" HeaderText="物料编码" />
                             <asp:BoundField DataField="desc1" HeaderText="物料名称">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:BoundField DataField="desc2" HeaderText="规格型号">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:BoundField DataField="unit" HeaderText="单位">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:TemplateField HeaderText="数量">
                                 <ItemTemplate>
                                     &nbsp;<asp:LinkButton ID="btnRemoveOne_sb" runat="server" 
                                         CommandArgument='<%# Eval("part") %>' CommandName="RemoveOne" 
                                         OnClientClick="Remove(this);" ToolTip="减少">﹣</asp:LinkButton>
                                     <asp:TextBox ID="txtCount1" runat="server" AutoPostBack="True"    Width="40px"
                                         CssClass="NumberInput" Text='<%# Eval("quantity") %>'></asp:TextBox>
                                     <asp:LinkButton ID="btnAddOne_sb" runat="server" 
                                         CommandArgument='<%# Eval("part") %>' CommandName="AddOne" 
                                         OnClientClick="Add(this);" ToolTip="增加">＋</asp:LinkButton>
                                    
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="工单号">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_gdh0" runat="server" Width="80px" 
                                         CssClass="NumberInput" AutoPostBack="True" ontextchanged="txt_gdh0_TextChanged" 
                                        ></asp:TextBox>
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="设备位置">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_sbpos" runat="server" Width="60px"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="项目号">
                                 <ItemTemplate>
                                     <dx:ASPxComboBox ID="xmh_select" runat="server"    ClientInstanceName='<%#"xmh_select"+Container.DataItemIndex.ToString() %>'  
                                     ClientSideEvents-SelectedIndexChanged='<%# "function(s,e){Getyf_code("+Container.DataItemIndex+");}" %>' 
                                         ValueType="System.String" AutoPostBack="True" 
                                         onselectedindexchanged="xmh_select_SelectedIndexChanged">
                                     </dx:ASPxComboBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="研发项目">
                                 <ItemTemplate>
                                     <dx:ASPxTextBox ID="txt_yfxm" Width="60px" runat="server" 
                                                            ReadOnly="true" ClientInstanceName='<%# "txt_yfxm"+Container.DataItemIndex.ToString() %>'>
                                                        </dx:ASPxTextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="状态">
                                 <ItemTemplate>
                                     <dx:ASPxTextBox ID="txt_status" Width="60px" runat="server" 
                                                            ReadOnly="true" ClientInstanceName='<%# "txt_status"+Container.DataItemIndex.ToString() %>'>
                                                        </dx:ASPxTextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="模具号">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_mojuno" runat="server" Width="60"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领料代理人">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_dlr_sb" runat="server"  Width="70px"
                                         CssClass="NumberInput"></asp:TextBox>
                                 </ItemTemplate>
                                 <ControlStyle CssClass="hidden" Width="0px" />
                                 <FooterStyle CssClass="hidden" Width="0px" />
                                 <HeaderStyle CssClass="hidden" Width="0px" />
                                 <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用日期">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtyjly_date" runat="server" CssClass="Normal" Width="85px"></asp:TextBox>
                                     <asp:ImageButton ID="Image1" runat="server" 
                                         AlternateText="Click to show calendar" 
                                         ImageUrl="~/Images/Calendar_scheduleHS.png" />
                                     <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" 
                                         Enabled="True" Format="yyyy/MM/dd" PopupButtonID="Image1" 
                                         TargetControlID="txtyjly_date" />
                                 </ItemTemplate>
                                 <HeaderStyle Width="110px" />
                                 <ItemStyle Width="110px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用位置">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ddlposition" runat="server" Width="80px">
                                     </asp:DropDownList>
                                 </ItemTemplate>
                                 <HeaderStyle Width="80px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用原因">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ddl_remark" runat="server" 
                                         Width="80px" AutoPostBack="True" 
                                         onselectedindexchanged="ddl_remark_SelectedIndexChanged">
                                     </asp:DropDownList>
                                     <asp:DropDownList ID="ddl_lycode" runat="server" 
                                         Width="100px">
                                     </asp:DropDownList>
                                      <asp:TextBox ID="txt_lycode" runat="server"  Width="80px"  Visible=false
                                         ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用类型">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ddl_type" runat="server">
                                         <asp:ListItem></asp:ListItem>
                                         <asp:ListItem>新刀领用</asp:ListItem>
                                         <asp:ListItem>以旧换新</asp:ListItem>
                                         <asp:ListItem>仓库调整</asp:ListItem>
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="移动代码">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ddlcode" runat="server" Width="100px" 
                                         AutoPostBack="True" 
                                         onselectedindexchanged="ddlcode_SelectedIndexChanged"
                                         >
                                     </asp:DropDownList><%----%>
                                  <%--   <dx:ASPxComboBox ID="ddl_mcode" runat="server" ValueType="System.String"  Width="80px"
                                      ClientInstanceName='<%# "ddl_mcode"+Container.DataItemIndex.ToString() %>'>
                                     </dx:ASPxComboBox>--%>
                                 </ItemTemplate>
                                 <HeaderStyle Width="100px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="操作">
                                 <ItemTemplate>
                                     &nbsp;&nbsp;
                                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/del.gif" 
                                         onclick="ImageButton1_Click"  OnClientClick='javascript:return deleteConfirm();'/>
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:BoundField DataField="comp" HeaderText="公司">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="sftnum" HeaderText="安全库存量">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="currentkc" HeaderText="当前库存">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="loc">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                         </Columns>
                       
                         <FooterStyle HorizontalAlign="Right" />
                         <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                             Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                         <PagerStyle ForeColor="Red" />
                         <RowStyle Height="35px" />
                     </asp:GridView>
                    <asp:Label ID="lbs_Message_sb" runat="server" ForeColor="Red"></asp:Label>
                     <br />
                    
                    <asp:Button ID="btn_submit_sb" runat="server" Text="提交" 
                        style="margin-left: 900px" onclick="btn_submit_sb_Click" Visible="False" 
                         Width="120px" />
				 </td>
				                                                   </tr>
				   	<tr>
				 <td class="style6"> 
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                         CssClass="GridViewCssClass" 
                         Width="1300px" Height="70px" 
                         onpageindexchanging="GridView2_PageIndexChanging" PageSize="200" 
                         onrowdatabound="GridView2_RowDataBound">
                         <Columns>
                             <asp:TemplateField HeaderText="选择">
                                 <HeaderTemplate>
                         <asp:CheckBox ID="CheckAll" runat="server" 
                                         oncheckedchanged="CheckAll_CheckedChanged" 
                                         AutoPostBack="True"   />
                                    
                                     <br />
                         <asp:Label ID="Label1" runat="server" Text="全选"></asp:Label>



                                                        </HeaderTemplate>
                                 <ItemTemplate>
                                     <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="True" />
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" Wrap="False" />
                                 <ItemStyle Wrap="False" />
                             </asp:TemplateField>
                             <asp:BoundField DataField="group_part" HeaderText="刀具群组号" >
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
                             <ItemStyle Width="80px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="desc2" HeaderText="规格型号">
                             <HeaderStyle ForeColor="Brown" />
                             <ItemStyle Width="80px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="unit" HeaderText="单位">
                             <HeaderStyle ForeColor="Brown" />
                             </asp:BoundField>
                             <asp:TemplateField HeaderText="数量">
                                 <ItemTemplate>
                                     <asp:LinkButton ID="btnRemoveOne" runat="server" 
                                         CommandArgument='<%# Eval("part") %>' CommandName="RemoveOne" 
                                           OnClientClick="Remove(this);" ToolTip="减少">﹣</asp:LinkButton>
                                     <asp:TextBox ID="txtCount" runat="server" AutoPostBack="True"    Width="40px"
                                         CssClass="NumberInput" Text='<%# Eval("quantity") %>' ></asp:TextBox>
                                     <asp:LinkButton ID="btnAddOne" runat="server" 
                                         CommandArgument='<%# Eval("part") %>' CommandName="AddOne"  OnClientClick="Add(this);"
                                         
                                          ToolTip="增加">＋</asp:LinkButton>
                                 
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用位置">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_position" runat="server" Width="60px" 
                                         CssClass="Normal"   Text='<%# Eval("position") %>'  ></asp:TextBox>
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="项目号">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_xmh" runat="server" CssClass="Normal" Width="65px"   
                                         Text='<%# Eval("xmh") %>' AutoPostBack="True" 
                                         ontextchanged="txt_xmh_TextChanged" ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="研发项目">
                                  <ItemTemplate>
                                      <asp:TextBox ID="txtdj_yfxm" runat="server"  Text='<%# Eval("yfxm") %>'  Width="60px" ReadOnly="true"></asp:TextBox>
                                  </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="状态">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txtdj_status" runat="server"  Text='<%# Eval("status") %>'  Width="60px" ReadOnly="true"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                              <asp:TemplateField HeaderText="产品名称">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_ljh" runat="server" CssClass="Normal" Width="80px"   
                                         Text='<%# Eval("ljh") %>' ReadOnly="True"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用类型">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_lylx" runat="server" CssClass="Normal"  Width="60px" 
                                         Text='<%# Eval("type") %>' ReadOnly="True"></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领用原因">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ly_remark" runat="server" Width="70px" AutoPostBack="True" 
                                         onselectedindexchanged="ly_remark_SelectedIndexChanged">
                                     </asp:DropDownList>
                                     <asp:DropDownList ID="ly_code" runat="server" 
                                         Width="100px">
                                     </asp:DropDownList>
                                      <asp:TextBox ID="txt_ly_code" runat="server"  Width="80px"  Visible=false
                                         ></asp:TextBox>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="移动代码">
                                 <ItemTemplate>
                                     <asp:DropDownList ID="ddl_code" runat="server" Width="140px" >
                                     </asp:DropDownList>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="领料代理人">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_dlr_dj" runat="server" CssClass="NumberInput" Width="60px"></asp:TextBox>
                                 </ItemTemplate>
                                 <ControlStyle CssClass="hidden" Width="0px" />
                                 <FooterStyle CssClass="hidden" Width="0px" />
                                 <HeaderStyle Width="0px" CssClass="hidden" />
                                 <ItemStyle Width="0px" CssClass="hidden" />
                             </asp:TemplateField>
                             <asp:BoundField DataField="yjlydate" HeaderText="预计领用日期" >
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:TemplateField HeaderText="操作">
                                 <ItemTemplate>
                                     &nbsp;&nbsp;
                                     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/del.gif" 
                                         onclick="ImageButton2_Click"  OnClientClick='javascript:return deleteConfirm();'/>
                                 </ItemTemplate>
                                 <HeaderStyle ForeColor="Brown" />
                             </asp:TemplateField>
                             <asp:BoundField DataField="comp" HeaderText="公司">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="sftnum" HeaderText="安全库存">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="version" HeaderText="版本号">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="gxh" HeaderText="工序号">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="currentkc" HeaderText="当前库存">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="loc">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="zt" HeaderText="是否&lt;br&gt;可替代" 
                                 HtmlEncode="False">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="xwlh">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                             <asp:BoundField DataField="tdwlh">
                             <ControlStyle CssClass="hidden" Width="0px" />
                             <FooterStyle CssClass="hidden" Width="0px" />
                             <HeaderStyle CssClass="hidden" Width="0px" />
                             <ItemStyle CssClass="hidden" Width="0px" />
                             </asp:BoundField>
                         </Columns>
                       
                         <FooterStyle HorizontalAlign="Right" />
                         <PagerSettings FirstPageText="首页" LastPageText="尾页" 
                             Mode="NextPreviousFirstLast" NextPageText="下页" PreviousPageText="上页" />
                         <PagerStyle ForeColor="Red" />
                         <RowStyle Height="35px" />
                     </asp:GridView>
				     <br />
				 </td>
				</tr>
                <tr><td class="style6">
                    <asp:Label ID="td_desc" runat="server" ForeColor="Red"></asp:Label><br />
                    <asp:Label ID="lbs_Message" runat="server" ForeColor="Red"></asp:Label><br />
                     <asp:Label ID="error_msg" runat="server" ForeColor="Red"></asp:Label>
                     
                    <br />
                    
                    <br />
                    <asp:Button ID="btn_submit" runat="server" Text="提交"   
                        style="margin-left: 1000px" onclick="btn_submit_Click" Visible="False" 
                        Width="120px" /></td></tr>
                <tr><td class="style6">
                    &nbsp;</td></tr>
				</table>
															
															
														</TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<IMG height="8" 
                                src="http://localhost:60130/Images/Spacer.gif" width="1" >
							
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

