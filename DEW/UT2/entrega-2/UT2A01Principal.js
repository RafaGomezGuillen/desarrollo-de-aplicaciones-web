const enlacesDoc = document.querySelectorAll("#info > ul:nth-child(3) > li a");
const enlaces = [];

enlacesDoc.forEach((enlace) => {
  enlaces.push(enlace.getAttribute("href"));
});

let ventanasEmergentes = [];

function abrirVentanas() {
  const ventanaAncho = 300;
  const ventanaAlto = 300;
  let left = 100;
  let top = 100;
  let windowFeatures = "";

  enlaces.forEach((enlace) => {
    windowFeatures = `left=${left},top=${top},width=${ventanaAncho},height=${ventanaAlto}`;

    const ventanaEmergente = window.open(
      enlace,
      "Ventana en blanco",
      windowFeatures
    );

    left *= 2;
    top *= 2;

    ventanasEmergentes.push(ventanaEmergente);
  });
}

function cerrarVentanas() {
  if (ventanasEmergentes) {
    ventanasEmergentes.forEach((ventana) => {
      if (!ventana.closed) {
        ventana.close();
      }
    });
  }
}

function pedirNumeroEnteroPositivo() {
  let numero;

  do {
    numero = parseFloat(prompt("Introduce un número:"));

    if (isNaN(numero) || numero <= 0 || !Number.isInteger(numero)) {
      alert("Por favor, introduce un número entero positivo.");
    }
  } while (isNaN(numero) || numero <= 0 || !Number.isInteger(numero));

  return Math.floor(numero);
}

function calculaMedida() {
  const numeroInput = Math.floor(document.getElementById("numOper").value);

  if (
    isNaN(numeroInput) ||
    numeroInput <= 0 ||
    !Number.isInteger(numeroInput)
  ) {
    alert("Debe introducir un número entero positivo.");
    return;
  }

  let numeros = [];
  let suma = 0;

  for (let i = 0; i < numeroInput; i++) {
    numeros.push(pedirNumeroEnteroPositivo());
  }

  numeros.map((numero) => {
    suma += numero;
  });

  const resultado = `La media de ${numeros} es ${(
    suma / numeros.length
  ).toFixed(2)}`;

  document.querySelector("body > div:nth-child(4)").innerHTML = resultado;
}
