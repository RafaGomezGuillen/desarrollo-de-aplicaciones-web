Algoritmo RestaNoNegativa
	Escribir "Presenta por pantalla la resta de dos números solicitados por teclado. No puede devolver el resultado como un número negativo.";
	
	Escribir  "Introduzca un numero: ";
	Leer numero_01;
	
	Escribir  "Introduzca otro numero: ";
	Leer numero_02;
	
	Mientras (numero_01 - numero_02 < 0) Hacer
		Escribir  "Resta negativa. Introduzca un numero: ";
		Leer numero_01;
		
		Escribir  "Introduzca otro numero: ";
		Leer numero_02;
	FinMientras
	
	resta = numero_01 - numero_02;
	Escribir numero_01 " - " numero_02 " = " resta;
FinAlgoritmo
