document.addEventListener('DOMContentLoaded', function () {
  const toggleBtn = document.getElementById('toggleBtn');
  const navLinks = document.querySelectorAll('nav a');

  function toggleNav() {
    const screenWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

    if (screenWidth <= 576) {
      navLinks.forEach(link => {
        link.style.display = link.style.display === 'block' ? 'none' : 'block';
      });
    } else if (screenWidth > 576 && screenWidth <= 768) {
      navLinks.forEach(link => {
        link.style.display = 'block';
      });
    } else {
      navLinks.forEach(link => {
        link.style.display = 'block';
      });
    }
  }

  toggleBtn.addEventListener('click', function () {
    toggleNav();
  });

    window.addEventListener('resize', function () {
      toggleNav();
    });

  toggleNav();
});
