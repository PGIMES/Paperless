function hide_loading() {
  if (parent.document.getElementById("loading").style.display == "none")
    clearInterval(timerID);
  else
    parent.hide_loading();
}

function parent_hide_loading() {
  if (parent.parent.document.getElementById("loading").style.display == "none")
    clearInterval(timerID);
  else
    parent.parent.hide_loading();
}
