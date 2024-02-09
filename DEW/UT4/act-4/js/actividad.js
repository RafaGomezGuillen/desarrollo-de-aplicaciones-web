let num_registros = 21;

// Ocultar el formulario y resetear los valores de los campos
const ocultarFormulario = () => {
  document.querySelector("#formulario").style.display = "none";
  limpiarInputs();
};

const limpiarInputs = () => {
  document.querySelectorAll("#formulario input").forEach((input) => {
    input.value = "";
    input.checked = false;
  });
};

const cargarDatos = async () => {
  try {
    const response = await fetch(
      "https://jsonplaceholder.typicode.com/users/1/todos"
    );
    const json = await response.json();

    // Por cada elemento en el JSON, agregar una fila a la tabla
    json.forEach((item) => {
      agregarFila([item.userId, item.id, item.title, item.completed]);
    });
  } catch (error) {
    console.error("Error al cargar datos:", error);
  }
};

// Agregar una nueva fila a la tabla con los datos de los campos
const agregarFila = (datos) => {
  const fila = document.createElement("tr");

  datos.forEach((dato, index) => {
    const celda = document.createElement("td");

    // Valores booleanos se convierten a "Si" o "No"
    celda.textContent = dato === true ? "Si" : dato === false ? "No" : dato;

    // Atributo "scope"
    if (index === 1) celda.setAttribute("scope", "row");

    fila.appendChild(celda);
  });

  fila.addEventListener("click", () => {
    editarFila(fila);
  });

  // Añadir la fila a la tabla
  document.querySelector("tbody").appendChild(fila);
};

// Creación de un nuevo elemento
const nuevoItem = () => {
  const nuevoBtn = document.getElementById("nuevo");
  const formulario = document.querySelector("#formulario");
  const formBotones = document.querySelectorAll("#formulario button");
  const userId = document.getElementById("userId");

  // Formulario se muestra al pulsar el boton nuevo
  nuevoBtn.addEventListener("click", () => {
    formulario.style.display = "block";

    // Limpio inputs al crear un item
    limpiarInputs();
  });

  // Boton aceptar
  formBotones[0].addEventListener("click", () => {
    // Crear item
    if (userId.value !== "1") {
      const datos = [
        "1",
        num_registros++,
        document.getElementById("title").value,
        document.getElementById("completed").checked,
      ];
      agregarFila(datos);
      ocultarFormulario();
    }
  });

  // Se definira el evento sobre el botón cancelar
  formBotones[1].addEventListener("click", ocultarFormulario);
};

// Editar fila 
const editarFila = (fila) => {
  const formulario = document.querySelector("#formulario");
  const inputs = document.querySelectorAll("#formulario input");
  const formBotones = document.querySelectorAll("#formulario button");

  // Se muestra el formulario
  formulario.style.display = "block";

  // Guardo el el texto de las celdas de la fila
  let textoCeldas = [];
  fila.childNodes.forEach((celda) => {
    textoCeldas.push(celda.textContent);
  });

  // Los value / checked de los inputs son el contenido de las celdas
  inputs.forEach((input, index) => {
    if (index < 3) {
      input.value = textoCeldas[index];
    } else {
      let estaChecked = textoCeldas[index] === "Si" ? true : false;
      input.checked = estaChecked;
    }
  });

  // Boton aceptar
  formBotones[0].addEventListener("click", () => {
    // Editar item
    if (userId.value === "1") {
      fila.childNodes.forEach((celda, index) => {
        if (index < 3) {
          celda.textContent = inputs[index].value;
        } else {
          let completado = inputs[index].checked ? "Si" : "No";
          celda.textContent = completado;
        }
      });
      ocultarFormulario();
    }
  });
};

// Guardar los datos de la tabla en un JSON
const guardarEnJSON = () => {
  const datos = [];
  const filas = document.querySelectorAll("tbody tr");

  filas.forEach((fila) => {
    const celdas = fila.querySelectorAll("td");
    const contenidoCelda = {
      IdUsuario: celdas[0].textContent,
      Id: celdas[1].textContent,
      Titulo: celdas[2].textContent,
      Completado: celdas[3].textContent === "Si",
    };
    datos.push(contenidoCelda);
  });

  const jsonData = JSON.stringify(datos, null, 2);

  // Guardo los datos en un archivo JSON
  const blob = new Blob([jsonData], { type: "application/json" });
  const link = document.createElement("a");
  link.href = URL.createObjectURL(blob);
  link.download = "datos.json";
  link.click();
};

const iniciar = () => {
  // Deshabilitar campos de ID (no hace falta que el usuario introduza IDs)
  // Prefiero esto en lugar de ocultarlos
  document.querySelectorAll("#formulario input").forEach((input, index) => {
    if (index < 2) {
      input.setAttribute("disabled", "");
    }
  });

  ocultarFormulario();
  cargarDatos();
  nuevoItem();

  // Guardar los datos de la tabla en un JSON
  document.getElementById("guardar").addEventListener("click", guardarEnJSON);
};

window.addEventListener("load", iniciar, false);
