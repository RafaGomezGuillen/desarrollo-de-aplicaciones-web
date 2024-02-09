Algoritmo SegundosAReloj
	Escribir "Paso de segundos a minutos y horas.";
	Leer numero_segundos;
	
	numero_minutos = numero_segundos / 60;
	numero_horas = numero_minutos / 60;
	
	Escribir "Horas = " numero_horas " minutos = " numero_minutos " segundos = " numero_segundos;
	
	Escribir "Reloj: "
	
	segundos = trunc(numero_segundos % 60);
	minutos = trunc((numero_segundos % 3600) / 60);
	horas = trunc(numero_segundos / 3600);
	
	Escribir horas " : " minutos " : " segundos; 
	
FinAlgoritmo
