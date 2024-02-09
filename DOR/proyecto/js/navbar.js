function navbar() {
  var x = document.getElementById("myTopnav");
  if (x.className === "topnav") {
    x.className += " responsive";
    window.scrollTo(0, 0);
  } else {
    x.className = "topnav";
  }
}