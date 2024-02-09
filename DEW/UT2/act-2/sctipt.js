// Actividad 3 - Función para multiplicar dos números
function multiplicar() {
  event.preventDefault();

  const num1 = document.getElementsByTagName("input")[0].value;
  const num2 = document.getElementsByName("num")[0].value;

  if (isNaN(num1) || isNaN(num2)) {
    alert("Alguno de los valores no es un número");
  } else {
    const multiplicacion = num1 * num2;
    const producto = document.getElementById("producto");
    producto.innerHTML = multiplicacion;
  }
}

// Actividad 4 - Función para determinar el estado académico según una nota
function Corresponde() {
  event.preventDefault();

  const notas = ["Suspenso", "Aprobado", "Notable", "Sobresaliente", "ERROR"];

  for (let i = 0; i < notas.length; i++) {
    document.getElementById(notas[i]).style.display = "none";
  }

  let nota = document.getElementById("nota").value;
  let estado = "";

  if (isNaN(nota)) {
    alert(`${nota} no es un número`);
  } else {
    nota = parseInt(nota);
  }

  if (nota >= 0 && nota < 5) {
    estado = "Suspenso";
  } else if (nota >= 5 && nota < 7) {
    estado = "Aprobado";
  } else if (nota >= 7 && nota < 9) {
    estado = "Notable";
  } else if (nota >= 9 && nota <= 10) {
    estado = "Sobresaliente";
  } else {
    estado = "ERROR! Indique un número del rango 0 a 10";
  }

  switch (estado) {
    case "Suspenso":
      const suspenso = document.getElementById("Suspenso");
      suspenso.style.display = "block";
      suspenso.innerHTML = estado;
      break;
    case "Aprobado":
      const aprobado = document.getElementById("Aprobado");
      aprobado.style.display = "block";
      aprobado.innerHTML = estado;
      break;
    case "Notable":
      const notable = document.getElementById("Notable");
      notable.style.display = "block";
      notable.innerHTML = estado;
      break;
    case "Sobresaliente":
      const sobresaliente = document.getElementById("Sobresaliente");
      sobresaliente.style.display = "block";
      sobresaliente.innerHTML = estado;
      break;
    default:
      const error = document.getElementById("ERROR");
      error.style.display = "block";
      error.innerHTML = estado;
      break;
  }
}

// Actividad 5 - Función para determinar la estación según el mes
function Meses() {
  const estaciones = ["Invierno", "Primavera", "Verano", "Otoño"];
  let mes = document.getElementById("mes").value;
  let estacion = "";

  switch (mes) {
    case "Enero":
    case "Febrero":
    case "Marzo":
      estacion = estaciones[0];
      break;
    case "Abril":
    case "Mayo":
    case "Junio":
      estacion = estaciones[1];
      break;
    case "Julio":
    case "Agosto":
    case "Septiembre":
      estacion = estaciones[2];
      break;
    case "Octubre":
    case "Noviembre":
    case "Diciembre":
      estacion = estaciones[3];
      break;
    default:
      estacion = "Estación por defecto";
      break;
  }

  let resultado = document.getElementById("estacion");
  resultado.innerHTML = estacion;
}

// Actividad 6 - Función para contar la cantidad de letras 'a' y 'o' en un texto
function contar() {
  event.preventDefault();

  let texto = "";
  texto = document.getElementById("input-texto").value;

  const cont_aArray = texto.toLowerCase().split("a");
  const cont_oArray = texto.toLowerCase().split("o");

  const cont_a = cont_aArray.length - 1;
  const cont_o = cont_oArray.length - 1;

  alert(`Podemos encontrar:\n- ${cont_a} vocales "a"\n- ${cont_o} vocales "o"`);
}
