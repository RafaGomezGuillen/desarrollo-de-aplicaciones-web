function openArticle(article) {
  var i, tabcontent;
  tabcontent = document.querySelectorAll(".information article");
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = "none";
  }

  document.getElementById(article).style.display = "block";
}
// Get the element with id="defaultOpen" and click on it
document.getElementById("defaultOpen").click();
