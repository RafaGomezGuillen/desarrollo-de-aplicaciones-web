// Actividad 1 - Función para calcular divisores de un número
function calcular() {
  event.preventDefault();

  const number = document.getElementById("number").value;
  let divisores = "";

  if (isNaN(number)) {
    alert(`${number} no es un número`);
  } else {
    divisores = document.getElementById("divisores");

    for (let i = number; i >= 0; i--) {
      if (number % i === 0) {
        divisores.innerHTML += `<p>${i} es un divisor</p>`;
      }

      if (i == 0) {
        // Se muestra una imagen de ok
        divisores.innerHTML += `<img src="assets/logo.png" width=100 />`;
      }
    }
  }
}

// Actividad 2 - Función para calcular la serie de Fibonacci
function fibonacci() {
  event.preventDefault();

  const number = document.getElementById("number-fibonacci").value;
  let a = 0;
  let b = 1;
  let suma = 1;

  let fibonacci_resultado = document.getElementById("fibonacci-resultado");

  if (number >= 1) {
    fibonacci_resultado.innerHTML = `<label>0, </label>`;
  }

  for (let i = 0; i < number - 2; i++) {
    suma = a + b;
    fibonacci_resultado.innerHTML += `<label>${suma}, </label>`;
    a = b;
    b = suma;
  }
}

// Actividad 3 - Funciones para calcular la serie de Fibonacci de forma recursiva
function calcularFibonacciRecursivo(n) {
  if (n <= 0) {
    return 0;
  } else if (n === 1) {
    return 1;
  } else {
    return (
      calcularFibonacciRecursivo(n - 1) + calcularFibonacciRecursivo(n - 2)
    );
  }
}

function fibonacciRecursivo() {
  event.preventDefault();
  let number = parseInt(
    document.getElementById("number-fibonacci-recursivo").value
  );
  let fibonacci_resultado_recursivo = document.getElementById(
    "fibonacci-resultado-recursivo"
  );
  if (number === 0) {
    fibonacci_resultado_recursivo.innerHTML = "<label>0</label>";
  } else if (number === 1) {
    fibonacci_resultado_recursivo.innerHTML = "<label>1</label>";
  } else if (number > 1) {
    // Se llama a calcularFibonacciRecursivo pasándole el número
    const resultado = calcularFibonacciRecursivo(number);
    fibonacci_resultado_recursivo.innerHTML =
      "<label>" + resultado + "</label>";
  }
}

// Actividades 4 y 5 - Funciones para una calculadora simple
let numbers = "";

// Muestra los números introducidos
function inputTecla(number) {
  numbers += number;
  display.innerHTML += number;
}

// Limpia el display
function clearDisplay() {
  numbers = "";
  display.innerHTML = "";
}

function randomNumber() {
  const max = 100,
    min = 0;
  display.innerHTML = Math.floor(Math.random() * (max - min + 1)) + min;
}

function exponencial() {
  display.innerHTML = Math.exp(numbers);
}

function arcocoseno() {
  const arcoCoseno = parseInt(Math.acos(numbers));
  display.innerHTML = `arccos(${numbers}) = ${arcoCoseno}º`;
}

function raizCuadrada() {
  display.innerHTML = Math.sqrt(numbers);
}

function calculadora() {
  try {
    display.innerHTML = eval(numbers);
  } catch (error) {
    display.innerHTML = "Error";
  }
}

// Actividad 6 - Funciones para calcular divisores
function divisores() {
  let numerosDividir = "";
  numerosDividir = document.querySelector("#numeros-dividir").value;

  const strEntero = numerosDividir.split(/(\s+)/);
  let numeros = [];

  for (let i = 0; i < strEntero.length; i++) {
    if (!isNaN(parseInt(strEntero[i]))) {
      numeros.push(strEntero[i]);
    }
  }

  let resultado = numeros[0];

  for (let i = 1; i < numeros.length; i++) {
    resultado /= numeros[i];
  }

  resultado_division.innerHTML = parseFloat(resultado).toFixed(2);
}

// Actividad 6 mod - Funciones para calcular divisores
function divisoresMod() {
  let numerosDividir = "";
  numerosDividir = document.querySelector("#numeros-dividir").value;

  const strEntero = numerosDividir.split(" ");

  // Filtro strEntero filtrando cada item si es un número
  const numeros = strEntero.filter((number) => {
    if (!isNaN(parseFloat(number))) {
      return number;
    }
  });

  const resultado = numeros.reduce((acomulador, number) => acomulador / number);

  resultado_division.innerHTML = parseFloat(resultado).toFixed(2);
}

// Actividad 8 - Funciones para la fecha actual
function definirFecha() {
  const fecha = new Date();
  const strFecha = `${fecha.getHours()} : ${fecha.getMinutes()} : ${fecha.getSeconds()} ${fecha.toDateString()}`;

  let fecha_actual = document.getElementById("fecha-actual");

  fecha_actual.innerHTML = strFecha;
}

setInterval(definirFecha, 1000); // Actualiza la fecha cada segundo

// Actividad 10 - Función para calcular la diferencia entre fechas
function esBisiesto(año) {
  return año % 4 == 0 && (año % 100 != 0 || año % 400 == 0);
}

function calcularFecha() {
  event.preventDefault();
  const fechaIntroducida = new Date(
    document.getElementById("fecha-introducida").value
  );
  const fechaActual = new Date();

  const diferenciaMilisegundos = fechaActual - fechaIntroducida;

  // Calcula la diferencia en días
  const diferenciaDias = Math.floor(
    diferenciaMilisegundos / (1000 * 60 * 60 * 24)
  );

  // Calcula la diferencia en años y meses
  let aniosDiferencia =
    fechaActual.getFullYear() - fechaIntroducida.getFullYear();

  let mesesDiferencia = fechaActual.getMonth() - fechaIntroducida.getMonth();

  // Ajusta los años y meses si es necesario
  if (mesesDiferencia < 0) {
    aniosDiferencia--;
    mesesDiferencia += 12;
  }

  let numAñosBisiestos = 0;
  let añoInicial = fechaIntroducida.getFullYear();
  let añoActual = fechaActual.getFullYear();

  while (añoInicial <= añoActual) {
    if (esBisiesto(añoInicial)) {
      numAñosBisiestos++;
    }

    añoInicial++;
  }

  fecha_restante.innerHTML = `
  Diferencia en días: ${diferenciaDias} días<br>
  Diferencia en meses: ${aniosDiferencia} meses<br>
  Diferencia en años: ${mesesDiferencia} años<br>
  Diferencia en años bisiestos: ${numAñosBisiestos} años`;
}

// Actividad 11 - Función para convertir números decimales a binarios
function convertDecToBin(numDecimal) {
  if (numDecimal == 0) return 0;
  else return (numDecimal % 2) + 10 * convertDecToBin(parseInt(numDecimal / 2));
}

function decToBin() {
  event.preventDefault();
  const numDecimal = parseInt(document.getElementById("num-decimal").value);
  num_binario.innerHTML = convertDecToBin(numDecimal);
}

// Actividad 12 - Función para convertir números decimales a hexadecimales
function decToHex() {
  event.preventDefault();
  const numDecimal = parseInt(
    document.getElementById("num-decimal-hexa").value
  );

  num_hexadecimal.innerHTML = numDecimal.toString(16);
}
