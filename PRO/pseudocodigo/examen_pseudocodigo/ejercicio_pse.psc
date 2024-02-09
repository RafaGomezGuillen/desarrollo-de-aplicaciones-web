Algoritmo EjercicioExamen
	Escribir "Introduzca un numero: "
	Leer numero_01;
		
	Si (trunc(numero_01) == numero_01) Entonces
		Si (numero_01 > 0) Entonces
			Si ((numero_01 >= 100) Y (numero_01 <= 999)) Entonces
				primer_digito = numero_01 % 10;
				segundo_digito = trunc((numero_01 % 100) / 10);
				tercer_digito = trunc((numero_01 % 1000) / 100);
				Si ((primer_digito % 2 == 1) O (segundo_digito % 2 == 1) O (tercer_digito % 2 == 1)) Entonces
					aux = numero_01;
					contador = 0;
					suma = 0;
					Si (primer_digito % 2 == 1) Entonces
						numero_01 = numero_01 - primer_digito;
						contador = contador + 1;
						suma = suma + primer_digito;
					FinSi
					Si (segundo_digito % 2 == 1) Entonces
						numero_01 = numero_01 - segundo_digito;
						contador = contador + 1;
						suma = suma + segundo_digito;
					FinSi
					Si (tercer_digito % 2 == 1) Entonces
						numero_01 = numero_01 - tercer_digito;
						contador = contador + 1;
						suma = suma + tercer_digito;
					FinSi
					Escribir "Hay " contador " cifras/as impar/es y " aux " - " suma  " es " numero_01;
				SiNo
					Escribir "Ningun digito es impar. No cumple.";
				FinSi
			SiNo
				Escribir "Numero distinto de tres cifras. No cumple.";
			FinSi
		SiNo
			Escribir "Numero negativo. No cumple"
		FinSi
	SiNo
		Escribir "Numero no entero. No cumple.";
	FinSi
FinAlgoritmo
