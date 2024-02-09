// Actividad 1.1 - Obtener la ubicación actual del dispositivo
navigator.geolocation.getCurrentPosition((position) => {
  console.log("Latitud: " + position.coords.latitude);
  console.log("Longitud: " + position.coords.longitude);
});

// Actividad 1.2 - Mostrar información sobre los recursos de hardware
console.log(navigator.hardwareConcurrency + " procesadores.");
console.log(navigator.deviceMemory + " GB de RAM.");

// Actividad 1.3 - Comprobar si se puede acceder a la cámara y el micrófono
if (navigator.mediaDevices.getUserMedia) {
  navigator.mediaDevices
    .getUserMedia({ audio: true, video: true })
    .then(() => {
      console.log("Webcam y dispositivo de salida de audio disponibles");
    })
    .catch(() => {
      console.log("Webcam o dispositivo de salida de audio no disponibles");
    });
} else {
  console.log("getUserMedia no está disponible en este navegador");
}

// Actividad 2 - Mostrar información sobre la pantalla
const screenStr = `${screen.availHeight} Altura de pantalla disponible para las ventanas\n
${screen.availWidth} Anchura de pantalla disponible para las ventanas. \n
${screen.colorDepth} Profundidad de color de la pantalla (32 bits normalmente). \n
${screen.height} Altura total de la pantalla en píxel. \n
${screen.width} Anchura total de la pantalla en píxel. \n`;

console.log(screenStr);

// Actividad 3 - Funciones para mostrar información en la página web
function pantalla() {
  document.getElementById(
    "pantalla"
  ).innerHTML = `<p>Alto disponible: ${screen.availHeight}px</p>
    <p>Ancho disponible: ${screen.availWidth}px</p>
    <p>Alto total: ${screen.height}px</p>
    <p>Ancho total: ${screen.width}px</p>
    <p>Profundidad de color: ${screen.colorDepth}</p>
    <p>Resolución (bits por pixel): ${screen.pixelDepth}`;
}

pantalla();

function ventana() {
  document.getElementById(
    "ventana"
  ).innerHTML = `<p>Alto exterior: ${window.innerWidth}px</p>
      <p>Ancho exterior: ${window.innerHeight}px</p>
      <p>Coordenadas X respecto a la pantalla: ${window.screenX}px</p>
      <p>Coordenadas Y respecto a la pantalla: ${window.screenY}px</p>
      <p>Ha visitado: ${history.length} páginas</p>`;
}

setInterval(ventana, 1000); // Se actualiza la ventana cada segundo

const browser = navigator.appCodeName;

if (browser === "Mozilla") {
  document.write("<link rel='stylesheet' href='firefox.css'></link>");
} else {
  document.write("<link rel='stylesheet' href='styles.css'></link>");
}

// Actividad 4
// Variables globales para la ventana emergente
let ventanaEmergente;

// Función para abrir una nueva ventana
function nuevaVentana() {
  event.preventDefault();

  const ventanaAncho = 400;
  const ventanaAlto = 400;
  const left = (window.screen.width - ventanaAncho) / 2;
  const top = (window.screen.height - ventanaAlto) / 2;

  const windowFeatures = `left=${left},top=${top},width=${ventanaAncho},height=${ventanaAlto}`;
  ventanaEmergente = window.open(
    "https://www.google.com/",
    "Google",
    windowFeatures
  );
}

// Función para cerrar la ventana emergente
function cerrarVentana() {
  event.preventDefault();

  if (ventanaEmergente) {
    ventanaEmergente.close();
  } else {
    alert("No hay ventana que cerrar.");
  }
}

// Variables para el tamaño de la ventana emergente
let ventanaAncho = 400;
let ventanaAlto = 400;

// Función para aumentar el tamaño de la ventana emergente
function ampliarVentana() {
  event.preventDefault();

  ventanaAlto += 30;
  ventanaAncho += 30;
  let windowFeatures = `width=${ventanaAncho},height=${ventanaAlto}`;

  if (screen.availHeight < ventanaAlto || screen.availWidth < ventanaAncho) {
    alert("No se puede seguir aumentando la pantalla");
  } else {
    ventanaEmergente = window.open(
      "https://www.google.com/",
      "Ventana en blanco",
      windowFeatures
    );
  }
}

// Función para reducir el tamaño de la ventana emergente
function reducirVentana() {
  event.preventDefault();

  ventanaAlto -= 30;
  ventanaAncho -= 30;
  let windowFeatures = `width=${ventanaAncho},height=${ventanaAlto}`;

  if (0 > ventanaAlto || 0 > ventanaAncho) {
    alert("No se puede seguir reduciendo la pantalla");
  } else {
    ventanaEmergente = window.open(
      "https://www.google.com/",
      "Ventana en blanco",
      windowFeatures
    );
  }
}

// Función para mover la ventana emergente a una posición específica
function mover() {
  event.preventDefault();
  const posX = document.getElementById("pos-x").value;
  const posY = document.getElementById("pos-y").value;

  const windowFeatures = `left=${posX},top=${posY},width=400,height=400`;

  if (
    posX < 0 ||
    posY < 0 ||
    posX > screen.availWidth ||
    posY > screen.availHeight
  ) {
    alert("No se puede seguir moviendo la pantalla");
  } else {
    ventanaEmergente = window.open(
      "https://www.google.com/",
      "Ventana en blanco",
      windowFeatures
    );
  }
}

// Actividad 5 con SingletonFoo
function SingletonFoo() {
  let fooInstance = null;

  function init() {
    // Do the initialization of the resource-intensive object here and return it
    guardarCarritoEnLocalStorage();
    mostrarProductos();
    return {};
  }

  function createInstance() {
    if (fooInstance == null) {
      fooInstance = init();
    } else {
      console.log("El carrito de compra ya está creado.")
    }
    return fooInstance;
  }

  function closeInstance() {
    fooInstance = null;
    borrarCarrito();
  }

  return {
    initialize: createInstance,
    close: closeInstance,
  };
}

const carritoDeCompra =
  '{ "productos": [ { "nombre": "Coca Cola", "cantidad": 20, "precio": 2 }, { "nombre": "Mano de platano canario", "cantidad": 10, "precio": 3 } ] }';

// Convierto los productos a objeto
let carritoDeCompraObj = JSON.parse(carritoDeCompra);

function guardarCarritoEnLocalStorage() {
  // Convierte carritoDeCompraObj a una cadena JSON
  const carritoJSON = JSON.stringify(carritoDeCompraObj);

  // Almacena la cadena JSON en el almacenamiento local
  localStorage.setItem("carritoDeCompra", carritoJSON);
}

function mostrarProductos() {
  carrito_de_compra_actual.innerHTML = "";

  carritoDeCompraObj.productos.forEach((item) => {
    carrito_de_compra_actual.innerHTML += `<li>Nombre: ${item.nombre}, cantidad: ${item.cantidad}, precio: ${item.precio}</li>`;
  });
}

// Función para cargar los productos desde el almacenamiento local y mostrarlos
function cargarProductosDesdeLocalStorage() {
  const carritoJSON = localStorage.getItem("carritoDeCompra");
  if (carritoJSON) {
    carritoDeCompraObj = JSON.parse(carritoJSON);
    mostrarProductos();
  }
}

cargarProductosDesdeLocalStorage();

function AgregarProducto() {
  event.preventDefault();
  const nombre = document.getElementById("nombre_producto").value;
  const cantidad = document.getElementById("cantidad_producto").value;
  const precio = document.getElementById("precio_producto").value;

  const nuevoProducto = {
    nombre: nombre,
    cantidad: cantidad,
    precio: precio,
  };

  // Agrego el nuevo producto al arrqay de productos en carritoDeCompraObj
  carritoDeCompraObj.productos.push(nuevoProducto);

  guardarCarritoEnLocalStorage(); // Guardar el carrito en localStorage
  mostrarProductos(); // Actualizo los productos mostrados
}

function eliminarProducto() {
  event.preventDefault();
  carritoDeCompraObj.productos.pop();

  guardarCarritoEnLocalStorage(); // Guardar el carrito en localStorage
  mostrarProductos(); // Actualizo los productos mostrados
}

// Función para borrar los productos del local storage
function borrarCarrito() {
  localStorage.removeItem("carritoDeCompra");
  carrito_de_compra_actual.innerHTML = "";
}

// Creo el SingletonFoo
let foo = SingletonFoo();