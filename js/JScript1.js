

      
      function body_load() {
        //document.getElementById("txt_search").onkeydown = txt_search_KeyDown;
       // document.getElementById("ibtn_search").onclick = ibtn_search_Click;
        
        hide_loading();
      }
      
      function txt_search_KeyDown(e) {
        var keyCode;
        
        if (NN)
          keyCode = e.keyCode;
        else
          keyCode = event.keyCode;
        
        if (keyCode == 13) {
          ibtn_search_Click();
          return false;
        }
      }
      
      function ibtn_search_Click() {
        keyword = alltrim(document.getElementById("txt_search").value.toLowerCase());
        lang_id = document.getElementById("langNormal").value;
        
        if (keyword == "")
          return;
        
        show_loading();
        
        document.getElementById("ifr_user_left").src = "../search/search_left.aspx?SLanguage=" + lang_id + "&global=1";
        document.getElementById("ifr_user_right").src = "../search/search_right.aspx?keyword=" + escape(keyword) + "&SLanguage=" + lang_id;
      }
      
      function alltrim() {
        return arguments[0].replace(/(^ +)|( +$)/g,'');
      } 
      
      function adjust_iframe_left_height(h) {
        if (h==0)
          document.getElementById("ifr_user_left").src = document.getElementById("ifr_user_left").src;
          
        document.getElementById("ifr_user_left").style.height = h;
      }
      
      function adjust_iframe_right_height(h) {
        if (h==0)
          document.getElementById("ifr_user_right").src = document.getElementById("ifr_user_right").src;
          
        document.getElementById("ifr_user_right").style.height = h;
      }
      
      function scroll_top() {
        window.scrollTo(0,0);
      }
      
      function body_resize() {
       if (document.body.clientWidth>=778) {
          document.getElementById("contact").style.left = document.body.clientWidth - 384;
          document.getElementById("search").style.left = document.body.clientWidth - 384;
          document.getElementById("sitemap").style.left = document.body.clientWidth - 384;
          document.getElementById("home").style.left = document.body.clientWidth - 384;
          document.getElementById("home").style.left = document.body.clientWidth - 384;
          document.getElementById("asus").style.left = document.body.clientWidth - 384;
        }
        else {
          document.getElementById("contact").style.left = 394 + 40;
          document.getElementById("search").style.left = 394 + 40;
          document.getElementById("sitemap").style.left = 394 + 40;
          document.getElementById("home").style.left = 394 + 40;
          document.getElementById("home").style.left = 394 + 40;
          document.getElementById("asus").style.left = 394 + 40;
        }
      }
      
      function show_loading() { 
        IE = (document.all && navigator.userAgent.indexOf("Opera") == -1)
        
        if (IE) {
          document.getElementById("loading").style.display = "inline";
          document.getElementById("loading").offsetHeight;
          document.getElementById("loading").style.pixelTop = (document.body.clientHeight/2)-(document.getElementById("loading").offsetHeight/2)+(document.body.scrollTop); 
          document.getElementById("loading").style.pixelLeft = (document.body.clientWidth/2)-(document.getElementById("loading").offsetWidth/2)+(document.body.scrollLeft); 
        }
      } 
      
      function hide_loading() {
        document.getElementById("loading").style.display = "none";
      }
      
      function go(url) {
        show_loading();
        location.href = url;
      }
      
      function replace(as,as_rex,as_out) {
        var ls_rex;
        ls_rex = new RegExp(as_rex,"g");
        as = as.replace(ls_rex, as_out);
        return as;
      }
      
      function switch_lang(lang_id) {
        s = location.href;
        
        if (s.indexOf(document.getElementById("langNormal").value) != -1)
          location.href = replace(s,document.getElementById("langNormal").value,lang_id);
        else
          location.href = s + '?SLanguage=' + lang_id;
      }
		