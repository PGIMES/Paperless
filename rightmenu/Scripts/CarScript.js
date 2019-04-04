
//大小写转换  Ctype为Upper时转大写，为Lower时转小写
function UpLowCaseValue1(Ctype)
{
	var source=event.srcElement;
	if(Ctype=='Upper')
		source.value=source.value.toUpperCase();
	if(Ctype=='Lower')
		source.value=source.value.toLowerCase();
}
function OpenWin(WinUrl,WinName,Width,Height,WinFeature)
{
	if(!WinName)
		WinName="_blank";
	return OpenWindow(WinUrl,WinName,Width,Height);
	if(!WinFeature)
		WinFeature="height="+(Height?Height:400)+",width="+(Width?Width:400)+",menubar=no,resizable=no,status=no,toolbar=no";
	window.open(WinUrl,WinName,WinFeature);
}
function ShutDown(IsClose)
{
	if(IsClose)
	{
		window.parent=this;
		window.close();
	}
}
function fPopUpCalendarDlg(ctrlobj)
{
    showx = event.screenX - event.offsetX - 4 - 210 ; // + deltaX;
	showy = event.screenY - event.offsetY - 150; // + deltaY;
	newWINwidth = 210 + 4 + 18;

	retval = window.showModalDialog("/Maintaince/CalendarDlg.htm", "", "dialogWidth:197px; dialogHeight:206px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no; ");
	if( retval != null ){
		var iChildLen=ctrlobj.parentElement.all.length;
		var oDateInput=null;
		var blFindMe=false;
		for(var i=iChildLen-1;i>=0;i--)
		{
			oDateInput=ctrlobj.parentElement.all[i];
			if(blFindMe)
			{
				if(oDateInput.tagName=="INPUT"&&oDateInput.type.toUpperCase()=="TEXT")
				{
					oDateInput.value=retval;
					break;
				}
			}
			else
			{
				if(oDateInput==ctrlobj)
					blFindMe=true;
			}
		}
		//retvale = Tolocalestring(retval);
		//ctrlobj.dyear.value = 11;
	}else{
		//alert("canceled");
	}
}
function OpenWindow(pageName,winName,wSize,hSize,blUserScroll){        //调用普通窗口
	pop = window.open(pageName,winName,"menubar=no,status=no,scrollbars="+(blUserScroll!=null&&blUserScroll==true?"1":"0")+",dependent=no");
	pop.resizeTo(wSize,hSize);
	pop.moveTo((screen.width-wSize)/2,(screen.height-hSize)/2);
	pop.focus();
} 
function MM_openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}
function Quit()
{
	if(confirm("您真的要退出系统吗？"))
	{
		window.opener=window;
		window.close();
	}
}
var theTimeSpan;
function ShowTime(obj)
{
	theTimeSpan=obj;
	UpdateTime();
}
function UpdateTime()
{
	var curDate=Date();
	theTimeSpan.innerText=/*"日期："+*/curDate;//curDate.getYear()+"年"+curDate.getMonth()+"月"+curDate.getDay()+"日 "+curDate.getHour()+":"+curDate.getMinute()+":"+curDate.getSecond();
	setTimeout(UpdateTime,500);
}
function fPopUpCalendarDlg(ctrlobj)
{
    showx = event.screenX - event.offsetX - 4 - 210 ; 
	showy = event.screenY - event.offsetY - 150; 
	newWINwidth = 210 + 4 + 18;
	retval = window.showModalDialog("../Ascxs/PickDate/CalendarDlg.htm", "", "dialogWidth:197px; dialogHeight:206px; dialogLeft:"+showx+"px; dialogTop:"+showy+"px; status:no; directories:yes;scrollbars:no;Resizable=no; ");
	if( retval != null ){
		var iChildLen=ctrlobj.parentElement.all.length;
		var oDateInput=null;
		for(var i=0;i<iChildLen;i++)
		{
			oDateInput=ctrlobj.parentElement.all[i];
			if(oDateInput.tagName=="INPUT"&&oDateInput.type.toUpperCase()=="TEXT")
			{
				oDateInput.value=retval;
				break;
			}
		}
	}
}
