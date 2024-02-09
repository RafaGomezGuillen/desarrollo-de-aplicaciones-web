Algoritmo PosicionNumero
	Escribir "Dado un numero y una posicion, decir la posicion del digito.";

	Escribir  "Introduzca un numero: ";
	Leer numero_01;
	
	Escribir "Introduzca posicion (de derecha a izquierda): ";
	Leer posicion;

	Si (abs(numero_01) >= 10^(posicion - 1)) Entonces
		digito = (numero_01 % 10^posicion - numero_01 % 10^(posicion-1)) / 10^(posicion-1);
		Escribir "El numero " digito " esta en la posicion " posicion;
	SiNo
		Escribir "Posicion mayor que numero introducido.";
	FinSi	
FinAlgoritmo