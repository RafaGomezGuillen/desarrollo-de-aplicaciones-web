Algoritmo NotasAlumnos
	Escribir "Dada la nota de un alumno/a, pasar ese dato numérico a nota por nombre.";
	
	Escribir  "Introduzca su nota: ";
	Leer nota;
	
	Mientras (nota < 0) | (nota > 10) Hacer
		Escribir  "Nota no valida, introduzca una nota entre 0 y 10: ";
		Leer nota;
	FinMientras
	
	Si (nota < 4.9) & (nota > 0) entonces 
		Escribir nota " es suspenso";
	FinSi
	
	Si (nota < 6.9) & (nota > 4) entonces 
		Escribir nota " es aprobado";
	FinSi
	
	Si (nota < 8.9) & (nota > 7) entonces 
		Escribir nota " es notable";
	FinSi
	
	Si (nota < 9.9) & (nota > 9) entonces 
		Escribir nota " es sobresaliente";
	FinSi
	
	Si nota == 10 entonces 
		Escribir nota " es matricula de honor";
	FinSi
FinAlgoritmo
