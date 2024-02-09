function init() {
  const DOM = {
    tabla: document.querySelector("#datos_tabla"),
    cabecera: document.getElementsByTagName("th"),
    filas: document.getElementsByTagName("tr"),
    columnas: document.getElementsByTagName("td"),
    imagen: document.getElementById("escudo"),
    filasCuerpo: document.querySelectorAll("tbody tr"),
    tfoot: document.querySelector("tfoot"),
  };

  actividad1(DOM);
  actividad2(DOM);
  limpiar_blancos((fila = 1), DOM);
  actividad3(DOM);
  actividad4(DOM);
  actividad5(DOM);
  actividad7(DOM);
  actividad8(DOM);
}

// Actividad 1
function actividad1(DOM) {
  // Aplica la clase "cabecera" a las celdas de cabecera
  for (const item of DOM.cabecera) {
    item.className = "cabecera";
  }

  // Aplica las clases "filaPar" y "filaImpar" a filas alternas
  // Profe se que hay un bucle for de toda la vida, pero asi lo entiendo mas :)
  for (let i = 0; i < DOM.filas.length; i++) {
    if (i % 2 == 0) {
      DOM.filas[i].className = "filaPar";
    } else {
      DOM.filas[i].className = "filaImpar";
    }
  }

  // Aplica la clase "primeraColumna" a celdas en la primera columna de la tabla
  DOM.filasCuerpo.forEach((fila) => {
    fila.querySelector("td:nth-child(1)").className = "primeraColumna";
  });
}

// Actividad 2
function actividad2(DOM) {
  let filasPolicia = [];

  // Encuentra las filas cuyo responsable sea policía y las almacena en un array el index
  DOM.filasCuerpo.forEach((fila, index) => {
    const responsable = fila.querySelector("td:nth-child(4)").textContent;

    if (responsable.toLowerCase() === "policía") {
      filasPolicia.push(index);
    }
  });

  // Aplica clases y transformaciones a las filas que cumplen el criterio
  filasPolicia.forEach((index) => {
    DOM.filasCuerpo[index].className = "policia";
  });

  for (const item of DOM.columnas) {
    if (item.textContent.toLowerCase() === "presidente") {
      item.className = "presidente";
    }
  }
}

// Función para eliminar contenido de una fila especificada
function limpiar_blancos(fila, DOM) {
  const i = fila - 1;
  const longitud = DOM.filas[i].childNodes.length;

  // Elimina todos los nodos hijos de la fila
  DOM.filas[i].childNodes.forEach((item) => {
    DOM.filas[i].removeChild(item);
  });

  alert(
    `El número de nodos de la fila ${fila} eran ${longitud}, ahora hay ${DOM.filas[i].childNodes.length}`
  );
}

// Actividad 3
function actividad3(DOM) {
  // Selecciona todas las filas del cuerpo de la tabla
  let filasConJResponsable = [];

  // Encuentra las filas cuyo responsable comienza por "J" y las almacena en un array
  DOM.filasCuerpo.forEach((fila) => {
    const responsable = fila.querySelector("td:nth-child(3)").textContent;

    if (responsable.startsWith("J")) {
      filasConJResponsable.push(fila);
    }
  });

  // Aplica clases y transformaciones a las filas que cumplen el criterio
  filasConJResponsable.forEach((item) => {
    const colId = item.querySelector("td:nth-child(1)");
    const colResponsables = item.querySelector("td:nth-child(3)");
    const colVotosBlanco = item.querySelector("td:nth-child(7)");

    colId.className = "borde_rojo";
    colVotosBlanco.className = "borde_rojo";

    colResponsables.textContent = colResponsables.textContent.toUpperCase();

    // Aplica la clase "destaca" a celdas específicas.
    colResponsables.nextElementSibling.nextElementSibling.className = "destaca";
    colResponsables.previousElementSibling.className = "destaca";
  });
}

// Actividad 4
function actividad4(DOM) {
  DOM.imagen.setAttribute("src", "img/objeto_dom.gif");
  DOM.imagen.setAttribute("alt", "Logotipo del Gobierno");
}

// Actividad 5
function actividad5(DOM) {
  // Selecciona todas las filas del cuerpo de la tabla
  let filaConIdOcho = [];

  // Encuentra las fila cuyo id sea 8 y lo almacena en un array
  DOM.filasCuerpo.forEach((fila) => {
    const id = fila.querySelector("td:nth-child(1)").textContent;

    if (id === "8") {
      filaConIdOcho.push(fila);
    }
  });

  filaConIdOcho.forEach((item) => {
    const colEmail = item.querySelector("td:nth-child(5)");
    const textoEmail = document.createTextNode("jaqueline.power@yahoo.com");
    colEmail.appendChild(textoEmail);
  });

  let columnaEmail = [];

  // Encuentra la columna de email y lo almacena en un array
  DOM.filasCuerpo.forEach((fila) => {
    const colEmail = fila.querySelector("td:nth-child(5)");
    columnaEmail.push(colEmail);
  });

  // Si el email no coincide con el pattern lo establezco como cadena vacia
  const patterEmail = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;

  columnaEmail.forEach((email) => {
    if (!email.textContent.match(patterEmail)) email.textContent = "";
  });

  // Clonar la cabecera y agregar a la tabla
  const nodoCabecera = DOM.tabla.querySelector("thead");
  const clonCabecera = nodoCabecera.cloneNode(true);
  DOM.tabla.appendChild(clonCabecera);
}

// Actividad 6
function crearColumna() {
  // Nueva columna
  for (let i = 0; i < 11; i++) {
    let texto = "Edad";
    const tabla = document.getElementById("datos_tabla").rows[i];
    const celda = tabla.insertCell(3);

    if (i >= 2) {
      texto = prompt("Introduce una edad: ");
    } else {
      celda.className = "cabecera";
    }

    celda.textContent = texto;
  }
}

// Actividad 7
function actividad7(DOM) {
  // Selecciona todas las filas del cuerpo de la tabla
  let filasConMoGJunta = [];

  // Encuentra las filas cuyo responsable comienza por "M" o "G" y las almacena en un array
  DOM.filasCuerpo.forEach((fila) => {
    const juntaProvicional = fila.querySelector("td:nth-child(2)").textContent;

    if (juntaProvicional.startsWith("M") || juntaProvicional.startsWith("G")) {
      filasConMoGJunta.push(fila);
    }
  });

  filasConMoGJunta.forEach((item) => {
    const colJuntaProvicional = item.querySelector("td:nth-child(2)");
    // text-align: right;
    colJuntaProvicional.style.textAlign = "right";
  });
}

// Actividad 8
function actividad8(DOM) {
  // Borrar la primera fila de la tabla
  const tabla = document.getElementById("datos_tabla");
  tabla.deleteRow(1);

  let sumVotos = 0,
    sumVotosBlancos = 0;

  DOM.filasCuerpo.forEach((fila) => {
    const votos = fila.querySelector("td:nth-child(6)").textContent;
    const votosBlancos = fila.querySelector("td:nth-child(7)").textContent;

    sumVotos += parseInt(votos);
    sumVotosBlancos += parseInt(votosBlancos);
  });

  DOM.tfoot.className = "cabecera";

  DOM.tfoot.innerHTML = `<tr>
                            <td colspan="5">TOTAL:</td>
                            <td>${sumVotos}</td>
                            <td>${sumVotosBlancos}</td>
  </tr>`;
}

window.onload = function () {
  init();
};
