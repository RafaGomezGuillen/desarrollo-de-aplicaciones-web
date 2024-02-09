// Actividad 3
const info = {
  rango: [
    { rangoMin: 0, rangoMax: 2000, bonificacion: 1 },
    { rangoMin: 2001, rangoMax: 6000, bonificacion: 1.5 },
    { rangoMin: 6001, rangoMax: 15000, bonificacion: 2 },
    { rangoMin: 15001, rangoMax: 25000, bonificacion: 2.25 },
    { rangoMin: 25001, rangoMax: Number.MAX_SAFE_INTEGER, bonificacion: 2.5 },
  ],
};

// Actividad 4
function coeficiente(nVentas) {
  let coeficiente = 0;
  info.rango.map((item) => {
    if (item.rangoMin <= nVentas && item.rangoMax >= nVentas) {
      coeficiente = item.bonificacion;
    }
  });

  return coeficiente;
}

// Actividad 5
function bonificacion(sMensual, coeficiente) {
  return Math.trunc(Math.cbrt(Math.pow(sMensual, coeficiente)));
}

function calcula_bonif() {
  const DOM = {
    nVentas: Math.floor(document.getElementById("numero_ventas").value),
    sMensual: document.getElementById("sueldo_mensual").value,
    resultadoFinal: document.querySelector("body > div > form > p:nth-child(4)"),
  };

  let esInputCorrecto = true;

  // Actividad 1
  if (
    isNaN(DOM.nVentas) ||
    DOM.nVentas <= 0 ||
    !Number.isInteger(DOM.nVentas)
  ) {
    alert("El número de ventas tiene que ser un entero.");
    DOM.nVentas = "";
    esInputCorrecto = false;
  }

  // Actividad 2
  //Expresion regular para comprobar que un numero es real
  const regex = /^-?\d*(\.\d+)?$/;

  if (!DOM.sMensual.match(regex) || parseFloat(DOM.sMensual) <= 0) {
    alert("El sueldo tiene que ser un número real positivo.");
    DOM.sMensual = "";
    esInputCorrecto = false;
  }

  if (esInputCorrecto) {
    const coeficienteTotal = coeficiente(DOM.nVentas);

    const bonificacionTotal = bonificacion(
      parseFloat(DOM.sMensual),
      coeficienteTotal
    );

    const total = parseFloat(DOM.sMensual) + bonificacionTotal;

    // Actividad 6
    const resultado = `El comercial ha realizado ${DOM.nVentas} ventas, por lo que supone un coeficiente ${coeficienteTotal} que le ha generado una bonificación de ${bonificacionTotal}€, lo que hace un total de de ${total}€`;

    DOM.resultadoFinal.innerHTML = resultado;
  } else {
    DOM.resultadoFinal.innerHTML = "Mal ejecutado";
  }
}
