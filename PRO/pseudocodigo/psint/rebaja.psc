Algoritmo Rebaja
	Escribir "Dados un precio inicial y un porcentaje de descuento calcular el descuento.";
		
	Escribir "Introduzca el precio inicial: ";
	Leer precio_inicial;
		
	Escribir "Introduzca el porcentaje de descuento: ";
	Leer porcentaje_descuento;
		
	descuento = precio_inicial - ((precio_inicial * porcentaje_descuento) / 100);
		
	Escribir "La rebaja es de " precio_inicial " a " descuento;
FinAlgoritmo
