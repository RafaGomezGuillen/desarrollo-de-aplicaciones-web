function init() {
  const DOM = {
    selectIsla: document.querySelector("#isla"),
    selectMunicipio: document.querySelector("#municipio"),
    formulario: document.querySelector("form"),
    creditRadio: document.querySelector("#credit"),
    debitRadio: document.querySelector("#debit"),
    paypalRadio: document.querySelector("#paypal"),
    tarjetaCreditoDiv: document.querySelector("#tarjeta_credito"),
    nick: document.querySelector("div.col-12 > div > input"),
    continuarBtn: document.querySelector(
      "form > button.w-100.btn.btn-primary.btn-lg"
    ),
  };

  actividad1(DOM);
  actividad2(DOM);
  actividad3(DOM);
  actividad5(DOM);
  actividad6(DOM);
  actividad8(DOM);
}

// Actividad 1: Opciones al elemento selectIsla
function actividad1(DOM) {
  const islas = ["La Gomera", "El hierro"];

  islas.forEach((isla) => {
    const option = document.createElement("option");
    option.value = isla;
    option.textContent = isla;
    DOM.selectIsla.appendChild(option);
  });
}

// Actividad 2: Event listener al cambio en selectIsla
function actividad2(DOM) {
  const municipiosHierro = ["El pinar", "Frontera", "Valverde"];
  const municipiosGomera = [
    "Agulo",
    "Alajeró",
    "Hermiga",
    "San Sebastián de la Gomera",
    "Valle Gran Rey",
    "Vallehermoso",
  ];

  DOM.selectIsla.addEventListener("change", () => {
    let islaSeleccionada = DOM.selectIsla.value;

    // Limpio los campos del municipio
    DOM.selectMunicipio.innerHTML = "";

    // Opciones de municipios segun la isla seleccionada
    if (islaSeleccionada === "La Gomera") {
      municipiosGomera.forEach((municipio) => {
        const option = document.createElement("option");
        option.value = municipio;
        option.textContent = municipio;
        DOM.selectMunicipio.appendChild(option);
      });
    } else if (islaSeleccionada === "El hierro") {
      municipiosHierro.forEach((municipio) => {
        const option = document.createElement("option");
        option.value = municipio;
        option.textContent = municipio;
        DOM.selectMunicipio.appendChild(option);
      });
    } else {
      DOM.selectMunicipio.innerHTML = "Indique un municipio...";
    }
  });
}

// Actividad 3: Limpiar los campos del formulario
function actividad3(DOM) {
  for (let i = 0; i < DOM.formulario.elements.length; i++) {
    if (DOM.formulario.elements[i].type == "text") {
      DOM.formulario.elements[i].value = "";
    }
  }
}

// Actividad 5: PayPal como opción predeterminada y oculta el div
function actividad5(DOM) {
  DOM.paypalRadio.checked = true;
  DOM.tarjetaCreditoDiv.style.display = "none";
}

// Actividad 6: Event listeners al cambio en las opciones de pago
function actividad6(DOM) {
  DOM.creditRadio.addEventListener("change", mostrarOcultarDiv);
  DOM.debitRadio.addEventListener("change", mostrarOcultarDiv);
  DOM.paypalRadio.addEventListener("change", mostrarOcultarDiv);

  // Mostrar u ocultar el div segun la opcion seleccionada
  function mostrarOcultarDiv() {
    if (DOM.creditRadio.checked || DOM.debitRadio.checked) {
      DOM.tarjetaCreditoDiv.style.display = "block";
    } else if (DOM.paypalRadio.checked) {
      DOM.tarjetaCreditoDiv.style.display = "none";
    }
  }
}

// Actividad 8: Event listener para verificar el nick
function actividad8(DOM) {
  DOM.nick.addEventListener("input", comprobarNick);

  function comprobarNick() {
    const regex = /^[a-z][a-z0-9]*$/;

    // Habilita o deshabilita el boton segun el formato del nick
    if (!DOM.nick.value.match(regex)) {
      DOM.continuarBtn.setAttribute("disabled", "");
    } else {
      DOM.continuarBtn.removeAttribute("disabled");
    }
  }
}

window.onload = function () {
  init();
};
