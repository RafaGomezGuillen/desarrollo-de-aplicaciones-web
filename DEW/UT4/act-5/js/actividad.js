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

    celda.addEventListener("dblclick", () => {
      editarCelda(celda);
    });

    fila.appendChild(celda);
  });

  // Añadir la fila a la tabla
  document.querySelector("tbody").appendChild(fila);
};

// Creación de un nuevo elemento
const nuevoItem = () => {
  const nuevoBtn = document.getElementById("nuevo");
  const formulario = document.querySelector("#formulario");
  const formBotones = document.querySelectorAll("#formulario button");

  // Formulario se muestra al pulsar el boton nuevo
  nuevoBtn.addEventListener("click", () => {
    formulario.style.display = "block";

    // Limpio inputs al crear un item
    limpiarInputs();
  });

  // Boton aceptar
  formBotones[0].addEventListener("click", () => {
    const datos = [
      "1",
      num_registros++,
      document.getElementById("title").value,
      document.getElementById("completed").checked,
    ];
    agregarFila(datos);
    ocultarFormulario();
  });

  // Se definira el evento sobre el botón cancelar
  formBotones[1].addEventListener("click", ocultarFormulario);
};

// Editar fila
const editarCelda = (celda) => {
  // Guardo el texto de la celda
  const texto = celda.textContent;

  // Se crea un elemento de tipo texto y como valor le aplico el texto de la celda y unos estilos
  const input = document.createElement("input");
  input.setAttribute("value", texto);
  input.style.width = "100%";

  celda.textContent = "";

  // La celda tiene como hijo el input
  celda.appendChild(input);

  input.addEventListener("focusout", (event) => {
    // Focus out input se desaparece
    event.target.style.display = "none";

    // La celda ahora tiene como texto el value del input
    celda.textContent = event.target.value;
  });
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
};

window.addEventListener("load", iniciar, false);
