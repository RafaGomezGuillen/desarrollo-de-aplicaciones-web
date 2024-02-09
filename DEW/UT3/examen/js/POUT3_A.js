function init() {
  const DOM = {
    tabla: document.querySelector("table"),
    cabecera: document.querySelector("thead"),
    columnasPar: document.querySelectorAll("td:nth-child(odd)"),
    columnasImpar: document.querySelectorAll("td:nth-child(even)"),
    filasCuerpo: document.querySelectorAll("tbody tr"),
    tbody: document.querySelector("tbody"),
    tfoot: document.querySelector("tfoot"),
  };

  actividad1(DOM);
  actividad2(DOM);
  actividad3(DOM);
  actividad4(DOM);
  actividad5(DOM);
}

// Actividad 1
function actividad1(DOM) {
  DOM.cabecera.className = "cabecera";

  DOM.columnasPar.forEach((columna) => {
    columna.classList.add("columnaPar");
  });

  DOM.columnasImpar.forEach((columna) => {
    columna.classList.add("columnaImpar");
  });
}

// Actividad 2
function actividad2(DOM) {
  // Lo conviero a array para utilizar el metodo sort
  const arrayFilas = Array.from(DOM.filasCuerpo);

  arrayFilas.sort((a, b) => {
    const celdasA = a.querySelector("td");
    const celdasB = b.querySelector("td");

    // Para ordenar necesito pasarlo a entero
    const celdaIdA = parseInt(celdasA.textContent);
    const celdaIdB = parseInt(celdasB.textContent);

    return celdaIdA - celdaIdB;
  });

  arrayFilas.forEach((fila) => {
    DOM.tbody.appendChild(fila);
  });
}

// Actividad 3
function actividad3(DOM) {
  DOM.filasCuerpo.forEach((fila) => {
    const celdas = fila.querySelectorAll("td");

    if (celdas.length === 9) {
      const octavaCelda = celdas[7];
      octavaCelda.parentNode.removeChild(octavaCelda);
    }
  });
}

// Actividad 4
function actividad4(DOM) {
  DOM.tfoot.className = "pie";

  for (let i = 0; i < 1; i++) {
    const fila = document.createElement("tr");

    for (let j = 0; j < 1; j++) {
      const celda = document.createElement("td");
      celda.setAttribute("colspan", "8");
      celda.textContent = "La media de las mensualidades de las hipotecas es ";

      fila.appendChild(celda);
    }

    DOM.tfoot.appendChild(fila);
  }

  DOM.tabla.appendChild(DOM.tfoot);
}

function actividad5(DOM) {
  let mensualidades = [];

  DOM.filasCuerpo.forEach((fila) => {
    // Hago replace quitando el caracter €
    fila.querySelector("td:nth-child(7)").textContent = fila
      .querySelector("td:nth-child(7)")
      .textContent.replace("€", "");

    const columna = parseFloat(
      fila.querySelector("td:nth-child(7)").textContent
    );

    if (!isNaN(columna)) {
      mensualidades.push(columna);
    }
  });

  let suma = 0;

  mensualidades.map((item) => {
    suma += item;
  });

  const media = suma / mensualidades.length;

  document.querySelector(
    "body > div > table > tfoot > tr > td"
  ).textContent += ` ${media}€`;
}

window.onload = function () {
  init();
};
