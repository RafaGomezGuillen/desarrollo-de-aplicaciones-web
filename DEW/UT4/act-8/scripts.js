// Elementos del DOM
const DOM = {
  nameInput: document.querySelector(
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
    "#new_user > ul > li:nth-child(7) > input[type=text]"
  ),
  phoneInput: document.querySelector(
    "#new_user > ul > li:nth-child(8) > input[type=text]"
  ),
  formButton: document.querySelector("#send_new_user"),
  inputs: document.querySelectorAll("#new_user input"),
  dialog: document.querySelector(".dialog"),
  dialogText: document.querySelector("body > div.dialog > span"),
};

// Array de usuarios que hayan completado el form correctamente
let users = [];

// Funciones de validaciones y mostrando dialogos si estan invalidos
function validate_first_name(name) {
  const nameRegex = /^[a-zA-Z]{2,}$/;
  return nameRegex.test(name);
}

DOM.nameInput.addEventListener("blur", () => {
  if (!validate_last_name(DOM.nameInput.value))
    showDialog("Invalid first name.");
});

function validate_last_name(lastName) {
  const lastNameRegex = /^[a-zA-Z]{2,}$/;
  return lastNameRegex.test(lastName);
}

DOM.lastNameInput.addEventListener("blur", () => {
  if (!validate_last_name(DOM.lastNameInput.value))
    showDialog("Invalid last name.");
});

function validate_email(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailRegex.test(email);
}

DOM.emailInput.addEventListener("blur", () => {
  if (!validate_email(DOM.emailInput.value))
    showDialog("Invalid email.");
});

function validate_repeat_email(email) {
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const validateEmail = DOM.emailInput.value === email;
  return emailRegex.test(email) && validateEmail;
}

DOM.repeatEmailInput.addEventListener("blur", () => {
  if (!validate_repeat_email(DOM.repeatEmailInput.value))
    showDialog("Invalid repeated email.");
});

function validate_user(user) {
  const userRegex = /^(?!.*[.!@#\$%\^&\*]{2,})([a-z]+[^.!@#\$%\^&\*])[a-z]+$/;
  return userRegex.test(user);
}

DOM.userInput.addEventListener("blur", () => {
  if (!validate_user(DOM.userInput.value))
    showDialog("Invalid username.");
});

function validate_birth_date(date) {
  const dateRegex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[012])\/(19|20)\d\d$/;
  return dateRegex.test(date);
}

DOM.dateInput.addEventListener("blur", () => {
  if (!validate_birth_date(DOM.dateInput.value))
    showDialog("Invalid datebirth.");
});

function validate_tfn_number(phone) {
  const phoneRegex = /^\(\+\d{1,3}\)\d{9}$/;
  return phoneRegex.test(phone);
}

DOM.phoneInput.addEventListener("blur", () => {
  if (!validate_tfn_number(DOM.phoneInput.value))
    showDialog("Invalid phone name.");
});

// Funcion para mostrar el dialog con su respectivo mensaje
function showDialog(message) {
  DOM.dialog.setAttribute("style", "display: block;");
  DOM.dialogText.textContent = message;
}

// Añado el usuario y reseteo el form
function addUser() {
  const user = {
    name: DOM.nameInput.value,
    lastName: DOM.lastNameInput.value,
    email: DOM.emailInput.value,
    username: DOM.userInput.value,
    datebirth: DOM.dateInput.value,
    phone: DOM.phoneInput.value,
  };

  users.push(user);
  console.log("User added " + users);

  // Reseteo el form
  DOM.inputs.forEach((input) => {
    input.value = "";
  });

  showDialog("Data Submitted Successfully.");
}

// Si el form es invalido...
function invalidForm() {
  // El boton "send" esta disabled y background rojo
  DOM.formButton.setAttribute("disabled", "");
  DOM.formButton.setAttribute("style", "background: red;");

  // El font de los inputs tienen color rojo
  DOM.inputs.forEach((input) => {
    input.setAttribute("style", "color: red;");
  });
}

// Si el form es valido...
function validForm() {
  // El boton esta disponible para enviar
  DOM.formButton.removeAttribute("disabled");
  DOM.formButton.removeAttribute("style");

  // El color de los inputs vuelven a su color original
  DOM.inputs.forEach((input) => {
    input.removeAttribute("style");
  });

  // Añado los datos de los campos al "servidor"
  DOM.formButton.removeEventListener("click", addUser);
  DOM.formButton.addEventListener("click", addUser);
}

// Validar todos los campos
function validateForm() {
  // Constantes booleanas para comprobar si el value de los inputs es valido
  const nameValid = validate_first_name(DOM.nameInput.value);
  const lastNameValid = validate_last_name(DOM.lastNameInput.value);
  const emailValid = validate_email(DOM.emailInput.value);
  const repeatEmailValid = validate_repeat_email(DOM.repeatEmailInput.value);
  const userValid = validate_user(DOM.userInput.value);
  const dateValid = validate_birth_date(DOM.dateInput.value);
  const phoneValid = validate_tfn_number(DOM.phoneInput.value);

  if (
    !(
      nameValid &&
      lastNameValid &&
      emailValid &&
      repeatEmailValid &&
      userValid &&
      dateValid &&
      phoneValid
    )
  ) {
    invalidForm();
  } else {
    validForm();
  }
}

// Añadir eventos a todos los inputs
const inputEvents = [
  "nameInput",
  "lastNameInput",
  "emailInput",
  "repeatEmailInput",
  "userInput",
  "dateInput",
  "phoneInput",
];

inputEvents.forEach((eventName) => {
  DOM[eventName].addEventListener("input", validateForm);
});
