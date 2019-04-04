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
