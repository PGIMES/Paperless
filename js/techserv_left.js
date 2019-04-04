function body_load() {

  parent.adjust_iframe_left_height(document.body.scrollHeight);
}

function searchword_mouseover() {
  if (document.getElementById("searchword").value == document.getElementById("hld_keyword").value)
    document.getElementById("searchword").value = "";
}

function searchword_mouseout() {
  if (document.getElementById("searchword").value == "")
    document.getElementById("searchword").value = document.getElementById("hld_keyword").value;
}

function search_click() {
	keyword = document.getElementById("searchword").value;
  hld_keyword = document.getElementById("hld_keyword").value;
	
	if(keyword == "" || keyword == hld_keyword) {
		return;
	}
	else {
		parent.show_loading();
		parent.document.getElementById("ifr_user_right").src = "../faq/faq_right_second.aspx?keyword=" + escape(keyword) + "&search_type=0&SLanguage=" + document.getElementById("langNormal").value;
	}	
}


///ап╠М©Р
 function add()
        { 
            var objres = document.getElementById("exc_zb");
            var objsel = document.getElementById("exc_zb2");

            var customOptions;
            for(var i = objres.options.length - 1 ;i >= 0;i--)
            {
            if(objres.options[i].selected)
            {
            customOptions = document.createElement("OPTION");
            customOptions.text = objres.options[i].text;
            customOptions.value = objres.options[i].value;
            objsel.add(customOptions,0);
            //objres.remove(i); 
            }
            }
            return false; 
        }
            // delete zb
        function del()
        {
        //alert (1);
        var objdel=document.getElementById("exc_zb2");
       // var objadd=document.getElementById("exc_zb");
        alert (objdel.options.length);
        var dellength=objdel.options.length;
        var addleft;
            for (var j=dellength-1;j>=0;j--)
            {
                if (objdel.options[j].selected)
                {
                    addleft=document.createElement("option");
                    addleft.text=objdel.options[j].text;
                    addleft.value=objdel.options[j].value;
                   // objadd.add(addleft,0);
                    objdel.remove(j);
                    
                }
            }
        }
        //clear zb all
        function clearall()
        {
           var objdel=document.getElementById("exc_zb2");
       // var objadd=document.getElementById("exc_zb");
        var dellength=objdel.options.length;
        var addleft;
            for (var j=dellength-1;j>=0;j--)
            {
                
                    addleft=document.createElement("option");
                    addleft.text=objdel.options[j].text;
                    addleft.value=objdel.options[j].value;
                  //  objadd.add(addleft,0);
                    objdel.remove(j);
                    
                
            }

        }
        
 function getvalue()
  {
  
         var ListLength=document.getElementById("exc_zb2").options.length;
 
         var ListValue;
         for (var i=0;i<ListLength;i++)
      {
  
          ListValue=document.getElementById("exc_zb2").options[i].value;
   
          document.getElementById("getlistvalue").value+=ListValue+",";
      }
  }
  
  
  
  function add1()
        { 
            var objres = document.getElementById("ListBox1");
            var objsel = document.getElementById("ListBox2");

            var customOptions;
            for(var i = objres.options.length - 1 ;i >= 0;i--)
            {
            if(objres.options[i].selected)
            {
            customOptions = document.createElement("OPTION");
            customOptions.text = objres.options[i].text;
            customOptions.value = objres.options[i].value;
            objsel.add(customOptions,0);
            //objres.remove(i); 
            }
            }
            return false; 
        }
            // delete zb
        function del1()
        {
        //alert (1);
        var objdel=document.getElementById("ListBox2");
       // var objadd=document.getElementById("exc_zb");
        //alert (objdel.options.length);
        var dellength=objdel.options.length;
        var addleft;
            for (var j=dellength-1;j>=0;j--)
            {
                if (objdel.options[j].selected)
                {
                    addleft=document.createElement("option");
                    addleft.text=objdel.options[j].text;
                    addleft.value=objdel.options[j].value;
                    //objadd.add(addleft,0);
                    objdel.remove(j);
                    
                }
            }
        }
        //clear zb all
        function clearall1()
        {
           var objdel=document.getElementById("ListBox2");
       // var objadd=document.getElementById("exc_zb");
        var dellength=objdel.options.length;
        var addleft;
            for (var j=dellength-1;j>=0;j--)
            {
                
                    addleft=document.createElement("option");
                    addleft.text=objdel.options[j].text;
                    addleft.value=objdel.options[j].value;
                  //  objadd.add(addleft,0);
                    objdel.remove(j);
                    
                
            }

        }
        
 function getvalue1()
  {
  
         var ListLength=document.getElementById("ListBox2").options.length;
 
         var ListValue;
         for (var i=0;i<ListLength;i++)
      {
  
          ListValue=document.getElementById("exc_zb2").options[i].value;
   
          document.getElementById("getlistvalue").value+=ListValue+",";
      }
  }


