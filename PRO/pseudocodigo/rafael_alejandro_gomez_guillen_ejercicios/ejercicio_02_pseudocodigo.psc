Algoritmo Ejercicio02Pseudocodigo
	Escribir "Se van a introducir tres numeros, introduzca el primer limite: ";
	Leer limite_01;
	Escribir "Introduzca el segundo limite: ";
	Leer limite_02;
	Escribir "Introduzca el numero para comprobar que esta dentro del intervalo: ";
	Leer numero_01;
	
	Si (((limite_01 >= numero_01) Y (limite_02 <= numero_01)) O ((limite_01 <= numero_01) Y (limite_02 >= numero_01))) Entonces
		Escribir "Pertenece."
	SiNo
		Escribir "Error.";
	FinSi
FinAlgoritmo
