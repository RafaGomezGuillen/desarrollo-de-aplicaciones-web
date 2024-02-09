Algoritmo Centenas
	Escribir  "Dado un número por teclado, devolver la cifra correspondiente a las centenas.";
	
	Escribir  "Introduzca un numero: ";
	Leer numero_01;
	
	centenass = (numero_01 % 1000 - numero_01 % 100) / 100;
	// decenas = (numero_01 % 100 - numero_01 % 10) / 10;
	// unidades = numero_01 % 10;

	Escribir "La centena de un numero = " centenass;
FinAlgoritmo
