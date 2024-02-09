# EJE0504. Ejercicios de Programación – Ficheros.
1. Dado un fichero que, en cada una de sus líneas tenga dos números separados por un punto y coma, genere un nuevo fichero que contenga la suma de ambos números.
- Ejemplo:	
```
Fichero de partida: 					Fichero final:
33;15 							          33+15=48
184;23 							          184+23=207
1;29 								          1+29=30
```

2. Generar un programa para el tratamiento de números existentes en un fichero que contenga las siguientes opciones en un menú:
- Crear el fichero: si el fichero no existe, lo crea, y si existe, deberá preguntar si lo queremos sobreescribir.
- Introducir valores numéricos en el fichero: se pedirán por teclado y se incluirán al final del fichero, uno por línea.
- Calcular cuál es el máximo de los valores almacenados en el fichero.
- Calcular cuál es el mínimo de los valores almacenados en el fichero.
- Calcular cuál es la media de los valores almacenados en el fichero.

3. Disponemos de un fichero de datos en el que, en cada línea, se almacena, en texto, los siguientes datos de un/a alumno/a: nombre, apellidos y las tres notas correspondientes a sus evaluaciones. Debemos mostrar por pantalla los datos (tanto nombre como sus notas) de los alumnos/as que hayan suspendido las tres evaluaciones (nota inferior a 5). Tratar la información mediante una estructura de datos.

4. Dados dos ficheros de texto, incluir en un nuevo fichero las líneas de ambos, cogiendo una de cada uno de ellos de forma alternativa. Si los ficheros no son del mismo tamaño, cuando se termine con el más pequeño, se pondrá toda la información que queda en el más grande.

5. Realizar un programa que pida al usuario el nombre de un fichero de origen y el de un fichero de destino, y que vuelque al segundo fichero el contenido del primero, convertido a mayúsculas. Se debe controlar los posibles errores, como que el fichero de origen no exista, o que el fichero de destino no se pueda crear.

6. Dado el fichero Turismo.csv con información de turismo, realizar el tratamiento correcto de los datos que contiene para ofrecer la siguiente funcionalidad al usuario:
- Mostrar la lista de todas las naciones existentes en el fichero de datos para que pueda elegir una. No se pueden mostrar naciones repetidas y esta información se ha de obtener del CSV cada vez que se ejecute, ya que  puede variar.
- Mostrar los años sobre los que hay datos, de todos los que contiene el CSV, para elegir por el usuario. Igualmente, la información del fichero podría variar en el tiempo, aumentando o disminuyendo el número de años de los que se dispone información, por lo que no puede ser un dato estático.
- Con esta información elegida por el usuario (nación y año) mostrar para cada mes las personas alojadas en hoteles de 4 y 5 estrellas, así como la suma de ambas cantidades.
- Tras mostrar la información solicitada terminará la ejecución del programa.

