var timerID;
function body_load() {
 parent.adjust_iframe_right_height(document.body.scrollHeight);
  //timerID = setInterval("hide_loading()",500);
}
      
function btn_search_click() {
  if (document.getElementById("select3").disabled)
    return;
          
  document.getElementById("div_detail").style.display = "inline";
  document.getElementById("msg_model").innerText = document.getElementById("select3").value;
  
  document.getElementById("a_enter_faq").href = "javascript:parent.go('../faq/faq.aspx?model=" + escape(document.getElementById("select3").value) + "&SLanguage=" + document.getElementById("langNormal").value + "')";
  document.getElementById("a_enter_download").href = "javascript:parent.go('../download/download.aspx?modelname=" + escape(document.getElementById("select3").value) + "&SLanguage=" + document.getElementById("langNormal").value + "')";
  try {
    document.getElementById("a_enter_forum").href = "http://vip.asus.com/forum/topic.aspx?model=" + escape(document.getElementById("select3").value) + "&SLanguage=" + document.getElementById("langNormal").value;
  }
  catch(e){};
    document.getElementById("a_form").href = "http://vip.asus.com/eservice/techserv.aspx?ptype=" + escape(document.getElementById("select3").value) + "&pmodel=" + escape(document.getElementById("select3").value) + "&SLanguage=" + document.getElementById("langNormal").value;
  
  
  parent.adjust_iframe_right_height(document.body.scrollHeight);
}
