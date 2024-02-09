Algoritmo ParImpar
	Escribir "Introducir un número por teclado y mostrar el mensaje de si es par o impar.";
	
	Escribir  "Introduzca un numero: ";
	Leer numero_01;
	
	Si numero_01 MOD 2 == 0 entonces 
		Escribir numero_01 " es par" ;
	SiNo
		Escribir numero_01 " es impar" ;
	FinSi
FinAlgoritmo
