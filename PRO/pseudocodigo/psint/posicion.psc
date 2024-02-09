Algoritmo PosicionNumero
	Escribir "Dado un numero y una posicion, decir la posicion del digito.";
	Escribir  "Introduzca un numero: ";
	Leer numero_01;
	aux = numero_01;
	
	Si aux < 0 Entonces
		aux = ABS(aux)
	FinSi
	
	Mientras aux > 0 Hacer
		aux = aux / 10;
		contador = contador + 1;
	FinMientras
	
	Escribir "Introduzca posicion (de derecha a izquierda): ";
	Leer posicion;
	
	Si contador >= posicion Entonces
		digito = (numero_01 % 10^posicion - numero_01 % 10^(posicion-1)) / 10^(posicion-1);
		// digito = trunc((numero_01 % 10^posicion) / 10^(posicion - 1));
		Escribir "El numero " digito " esta en la posicion " posicion;
	SiNo
		Escribir "Posicion mayor que numero introducido.";
	FinSi
	
FinAlgoritmo

