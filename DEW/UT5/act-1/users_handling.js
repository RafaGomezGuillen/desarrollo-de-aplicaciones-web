const DOM = {
  newUserBtn: document.querySelector(
    "#unlogged_user_dialog > li:nth-child(6) > button"
  ),
  newUserDiv: document.querySelector("#new_user"),
  sendNewUserBtn: document.querySelector("#send_new_user"),
  nameInputRegister: document.querySelector(
    "#new_user > ul > li:nth-child(2) > input[type=text]"
  ),
  lastNameInput: document.querySelector(
    "#new_user > ul > li:nth-child(3) > input[type=text]"
  ),
  emailInput: document.querySelector(
    "#new_user > ul > li:nth-child(4) > input[type=text]"
  ),
  repeatEmailInput: document.querySelector(
    "#new_user > ul > li:nth-child(5) > input[type=text]"
  ),
  userInput: document.querySelector(
    "#new_user > ul > li:nth-child(6) > input[type=text]"
  ),
  dateInput: document.querySelector(
    "#new_user > ul > li:nth-child(7) > input[type=date]"
  ),
  phoneInput: document.querySelector(
    "#new_user > ul > li:nth-child(8) > input[type=text]"
  ),
  loginBtn: document.querySelector("#loggin_button"),
  nameInputLogin: document.querySelector("#loggin_form > input[type=text]"),
  pswLogin: document.querySelector(
    "#unlogged_user_dialog > li:nth-child(2) > input[type=text]"
  ),
  dialog: document.querySelector("body > div:nth-child(2)"),
  dialogMessage: document.querySelector("body > div:nth-child(2) > span"),
  logoutBtn: document.querySelector("#sign_out"),
  forgotPasswordBtn: document.querySelector(
    "#unlogged_user_dialog > li:nth-child(4) > a"
  ),
  forgotPasswordDiv: document.querySelector("#frgttn_psswrd"),
  emailForgotPassword: document.querySelector(
    "#frgttn_psswrd > ul > li > input[type=text]"
  ),
  forgotPasswordSendBtn: document.querySelector(
    "#frgttn_psswrd > button:nth-child(4)"
  ),
};
// Si presiono el boton "new user" muestro el formulario
DOM.newUserBtn.addEventListener("click", () => {
  DOM.newUserDiv.style.display = "block";
});

// Si presiono el boton "send" del formulario
DOM.sendNewUserBtn.addEventListener("click", () => {
  sendUserDataRegister();
});

// Funcion para enviar los values de los inputs al servidor usando fetch
function sendUserDataRegister() {
  const user = {
    firstName: DOM.nameInputRegister.value,
    lastName: DOM.lastNameInput.value,
    email: DOM.emailInput.value,
    user: DOM.userInput.value,
    datebirth: DOM.dateInput.value,
    phone: DOM.phoneInput.value,
  };

  return fetch("new_user.php", {
    method: "POST",
    headers: {
      "Content-type": "application/x-www-form-urlencoded",
    },
    body: `new_user=${JSON.stringify(user)}`,
  });
}

// Si presiono el boton de login
DOM.loginBtn.addEventListener("click", () => {
  sendUserDataLogin();
});

// Funcion para comprobar si el usuario que hace login existe
function sendUserDataLogin() {
  const user = {
    user: DOM.nameInputLogin.value,
    password: DOM.pswLogin.value,
  };

  let xhttp = new XMLHttpRequest();

  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      if (this.responseText.includes("1")) {
        // Mensaje de bienvenida al usuario logueado
        DOM.dialog.style.display = "block";
        DOM.dialogMessage.textContent = `Bienvenido ${DOM.nameInputLogin.value}.`;

        // Oculto y muestro los elementos correspondientes
        document.querySelector("#unlogged_user_dialog").style.display = "none";
        document.querySelector("#logged_user_dialog").style.display = "block";
      } else {
        DOM.dialog.style.display = "block";
        DOM.dialogMessage.textContent = "Los datos introducidos no existen.";
      }
    }
  };

  xhttp.open("POST", "check_user.php");
  xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
  xhttp.send(`user=${user.user}&psswrd=${user.password}`);
}

// Si presiono el boton de logout
DOM.logoutBtn.addEventListener("click", () => {
  logout();
});

// Metodo al presionar el boton de logout
function logout() {
  DOM.dialog.style.display = "block";
  DOM.dialogMessage.textContent = "Cierre de sesión realizado con exito.";

  // Oculto y muestro los elementos correspondientes
  document.querySelector("#unlogged_user_dialog").style.display = "block";
  document.querySelector("#logged_user_dialog").style.display = "none";

  // Limpio el form de login
  DOM.nameInputLogin.value = "";
  DOM.pswLogin.value = "";
}

// Si presiono "click here" muestro el div para recuperar la contraseña
DOM.forgotPasswordBtn.addEventListener("click", () => {
  DOM.forgotPasswordDiv.style.display = "block";
});

// Si presiono "Send" en el formulario para la recuperacion de contraseña
DOM.forgotPasswordSendBtn.addEventListener("click", () => {
  forgotPassword();
});

function forgotPassword() {
  return new Promise(() => {
    let xhttp = new XMLHttpRequest();
    const email = DOM.emailForgotPassword.value;

    xhttp.onreadystatechange = function () {
      if (this.readyState == 4 && this.status == 200) {
        const lenght = this.responseText.length;
        // Recupero los ultimos caracteres olvidandome del mensaje de error
        const response = this.responseText.substring(lenght - 14, lenght); 

        // Si el correo no existe...
        if (response.includes("/b><br />")) {
          DOM.forgotPasswordDiv.style.display = "none";
          DOM.dialog.style.display = "block";
          DOM.dialogMessage.textContent =
            "El correo no existe en nuestra base de datos.";
        } else {
          DOM.forgotPasswordDiv.style.display = "none";
          DOM.dialog.style.display = "block";
          DOM.dialogMessage.textContent = `Tu contraseña es: ${response}`;
        }
      }
    };

    xhttp.open("POST", "psswrd_recover.php");
    xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
    xhttp.send(`email=${email}`);
  });
}
