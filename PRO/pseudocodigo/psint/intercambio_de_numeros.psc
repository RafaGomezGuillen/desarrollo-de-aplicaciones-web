Algoritmo IntercambioDeValores
	Escribir "Dadas dos variables numéricas A y B, que el usuario debe teclear, se pide realizar un algoritmo que intercambie los valores de ambas variables y muestre por pantalla cuanto valen al final.";
	
	Escribir "Introduzca A: ";
	Leer A;
	
	Escribir  "Introduzca B: ";
	Leer B;
	
	aux = A;
	A = B
	B = aux;
	
	Escribir "A = " A " B = " B;
FinAlgoritmo
