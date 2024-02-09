function init() {
  const DOM = {
    zonadibujo: document.getElementById("zonadibujo"),
    filaColores: document.querySelectorAll(
      "#paleta > tbody > tr:nth-child(1) td"
    ),
    estado: document.getElementById("pincel"),
  };

  DOM.filaColores.forEach((celda) => {
    celda.addEventListener("click", () => {
      DOM.filaColores.forEach((item) => item.classList.remove("seleccionado"));
      celda.classList.add("seleccionado");
    });
  });

  crearTabla(DOM.zonadibujo);
  pincel(DOM.estado);
}

function crearTabla(zonadibujo) {
  // Crear la tabla
  const tabla = document.createElement("table");

  // Configurar el ancho de borde de la tabla
  tabla.setAttribute("border", "1");

  for (let i = 0; i < 30; i++) {
    const fila = document.createElement("tr");

    for (let j = 0; j < 30; j++) {
      const celda = document.createElement("td");

      // Configurar el ancho y alto de la celda
      celda.style.width = "10px";
      celda.style.height = "10px";

      // Añadir la celda a la fila
      fila.appendChild(celda);
    }

    // Añadir la fila a la tabla
    tabla.appendChild(fila);
  }

  // Añadir la tabla al contenedor especificado
  zonadibujo.appendChild(tabla);
}

function pincel(estado) {
  const tabla = document.querySelector("#zonadibujo > table");
  const celdas = document.querySelectorAll("#zonadibujo > table td");

  const pintar = (evento) => {
    const colorSeleccionado = document.querySelector("#paleta .seleccionado")
    .classList[0];
    evento.target.className = colorSeleccionado;
  };
  
  // Click a la tabla pincel activado
  tabla.addEventListener("click", () => {
    estado.textContent = "PINCEL ACTIVADO";

    // Hacer hover sobre celda cambia la clase
    celdas.forEach((celda) => {
      celda.addEventListener("mouseover", pintar);
    });
  });

  // Doble click a la tabla = pincel desactivado
  tabla.addEventListener("dblclick", () => {
    estado.textContent = "PINCEL DESACTIVADO";
    celdas.forEach((celda) => {
      celda.removeEventListener("mouseover", pintar);
    });
  });
}

window.onload = function () {
  init();
};
