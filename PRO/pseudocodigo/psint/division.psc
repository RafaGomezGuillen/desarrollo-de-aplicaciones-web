Algoritmo DivisionDeDosNumeros
	Escribir 'Presenta por pantalla la división de dos números solicitados por teclado.'
	Escribir 'Introduzca un numero: '
	Leer numero_01
	Escribir 'Introduzca otro numero: '
	Leer numero_02
	Mientras (numero_02 == 0) Hacer
		Escribir 'No se puede dividir entre cero, introduzca otro numero: '
		Leer numero_02
	FinMientras
	
	division <- numero_01/numero_02
	Escribir 'La division entre ',numero_01,' / ',numero_02,' = ',division
FinAlgoritmo
