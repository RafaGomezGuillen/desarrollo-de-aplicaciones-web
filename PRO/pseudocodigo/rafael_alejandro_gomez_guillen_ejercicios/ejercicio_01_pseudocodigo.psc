Algoritmo Ejercicio01Pseudocodigo
	Escribir "Introduzca un numero entero: ";
	Leer numero_01;
	
	SI (Trunc(numero_01) == numero_01) Entonces
		SI (Trunc(numero_01 / 2) == (numero_01 / 2)) Entonces // Solo se puede hacer MOD con numeros enteros. numero_01 / 2 es para saber la mitad
			Si ((numero_01 / 2) Mod 2 <> 0) Entonces // Compruebo si esa mitad es impar
				Escribir "Si cumple.";
			SiNo
				Escribir "No cumple.";
			FinSi
		SiNo
			Escribir "No cumple.";
		FinSi
	SiNo
		Escribir "No cumple.";
	FinSi
FinAlgoritmo
