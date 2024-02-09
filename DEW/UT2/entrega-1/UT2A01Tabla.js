const alimentacion = [
  { alimento: "Arandano", tipo: "Fruta", calorias: "41", proteinas: "0,6" },
  { alimento: "Ciruela", tipo: "Fruta", calorias: "36", proteinas: "0,5" },
  { alimento: "Frambuesa", tipo: "Fruta", calorias: "-", proteinas: "1" },
  { alimento: "Fresa", tipo: "Fruta", calorias: "27", proteinas: "0,9" },
  { alimento: "Piñón", tipo: "Fruto Seco", calorias: "568", proteinas: "29,6" },
  { alimento: "Pistacho", tipo: "Fruto Seco", calorias: "600", proteinas: "-" },
  {
    alimento: "Ciruela pasa",
    tipo: "Fruto Seco",
    calorias: "177",
    proteinas: "",
  },
  {
    alimento: "Dátil seco",
    tipo: "Fruto Seco",
    calorias: "256",
    proteinas: "2,7",
  },
  { alimento: "Aguacate", tipo: "Fruta", calorias: "", proteinas: "1,9" },
  { alimento: "Cereza", tipo: "Fruta", calorias: "48", proteinas: "0,8" },
  {
    alimento: "Higo seco",
    tipo: "Fruto Seco",
    calorias: "270",
    proteinas: "3,5",
  },
  { alimento: "Nuez", tipo: "Fruto Seco", calorias: "670", proteinas: "15,6" },
  { alimento: "Albaricoque", tipo: "Fruta", calorias: "52,4", proteinas: "0" },
];

// Actividad 1
alimentacion.map((item) => {
  document.querySelector("tbody").innerHTML += `<tr> 
  <td>${item.alimento}</td>
  <td>${item.tipo}</td> 
  <td>${item.calorias.replace(",", ".")}</td>
  <td>${item.proteinas.replace(",", ".")}</td>
  </tr>`;
});

// Actividad 2

// Orderno cada array de menor a mayor
const maxCaloriaFrutoSecoArray = alimentacion
  .filter((item) => item.tipo === "Fruto Seco")
  .sort((a, b) => a.calorias - b.calorias);

const maxCaloriaFrutaArray = alimentacion
  .filter((item) => item.tipo === "Fruta")
  .sort((a, b) => a.calorias - b.calorias);

// Guardo en una variable el ultimo objeto
const maxCaloriaFrutoSeco =
  maxCaloriaFrutoSecoArray[maxCaloriaFrutoSecoArray.length - 1];

const maxCaloriaFruta = maxCaloriaFrutaArray[maxCaloriaFrutaArray.length - 1];

const respuesta = `<h1>Productos calóricos</h1><p>La fruta con más calorias es ${maxCaloriaFruta.alimento} con ${maxCaloriaFruta.calorias.replace(",", ".")}.</p><p>El fruto seco con más calorias es ${maxCaloriaFrutoSeco.alimento} con ${maxCaloriaFrutoSeco.calorias.replace(",", ".")}.</p>`;

document.querySelector("div[title='calcular']").innerHTML = respuesta;

// Actividad 3
let ventanaEmergente;
let esVentanaEmergenteAbierta = false;
let intervalId;

function configTimer() {
  let segundos = document.getElementById("numSeg").value;
  if (isNaN(segundos)) {
    alert("Debe introducir un número válido para indicar los segundos.");
    return;
  }

  // Si la ventana está abierta la cierro
  if (ventanaEmergente && !ventanaEmergente.closed) {
    ventanaEmergente.close();
  }

  const ventanaAncho = 300;
  const ventanaAlto = 300;
  const min = 0;
  const tiempoEnMilisegundos = segundos * 1000;

  const left = Math.floor(Math.random() * (screen.availWidth - min + 1)) + min;
  const top = Math.floor(Math.random() * (screen.availHeight - min + 1)) + min;

  const windowFeatures = `left=${left},top=${top},width=${ventanaAncho},height=${ventanaAlto}`;

  ventanaEmergente = window.open("", "Ventana en blanco", windowFeatures);

  if (intervalId) {
    clearInterval(intervalId); // Detener el intervalo si ya estaba configurado
  }

  // Cada segundo indicado muevo la ventana
  intervalId = setInterval(function () {
    if (ventanaEmergente && !ventanaEmergente.closed) {
      // Mueve la ventana a una nueva posición aleatoria
      const nuevoLeft =
        Math.floor(Math.random() * (screen.availWidth - min + 1)) + min;
      const nuevoTop =
        Math.floor(Math.random() * (screen.availHeight - min + 1)) + min;
      ventanaEmergente.moveTo(nuevoLeft, nuevoTop);
    }
  }, tiempoEnMilisegundos);
}

function stopTimer() {
  esVentanaEmergenteAbierta = false;
  if (ventanaEmergente && !ventanaEmergente.closed) {
    ventanaEmergente.close();
  }
  if (intervalId) {
    clearInterval(intervalId);
  }
}
