# EJE0406.

1. Una tienda quiere controlar las compras de sus clientes. Por cada 3 productos que se compren, quiere regalar el de precio inferior.
  - La aplicación debe preguntar el número de productos a comprar. Para cada producto, preguntar su nombre y su precio.
  - Por cada 3 productos, se regala un producto, comenzando por los que tengan menor precio del todos los productos.
  - Mostrar al final cada uno de los productos, el precio que tenía y el precio que se aplica.
  - También dar el precio final a pagar por todos los productos.

2. En España cada persona está identificada con un Documento Nacional de Identidad (DNI) en el que figura un número y una letra, por ejemplo 56999545W.
  - Crear un programa que calcule la letra de un DNI a partir de un número introducido por el usuario. El número se solicitará en una sola petición y se comprobará que
  - cumple con el formato necesario (8 dígitos y una letra). El programa comprobará que lo introducido es un DNI correcto, calculando el valor de la letra y comprobando 
  - con lo introducido por el usuario.
  - Para calcular la letra, se debe tomar el resto de dividir nuestro número de DNI entre 23. El resultado debe estar por tanto entre 0 y 22. Este número refleja una posición del siguiente array de caracteres:

- Posición     0   1   2   3  4   5   6  7  8  9  10  11  12  13  14  15  16  17  18  19  20  21  22
- Letra            T   R  W A  G  M  Y  F  P  D  X    B   N    J    Z    S   Q    V   H    L   C   K   E

  - Por ejemplo, si introducimos el  DNI 20267079P, extraemos el número (20267079) y el resto de dividirlo por 23 sería 8. Mirando en la tabla dada, el elemento de la posición 8 es la P, se comprueba con lo introducido y vemos que el DNI es correcto.

3.	Escriba un programa para representar mediante barras de asteriscos 10 números recogidos por teclado con valores enteros entre 1 y 20. Los 10 números se introducen separados por un espacio mediante un string.
Por ejemplo:

- Entrados los números:
- 1 8 3 14 5 10 7 11 9 10
- el resultado es:
- 1	*
- 8	********
- 3	***
- 14	**************
- 5	*****
- 10	**********
- 7	*******
- 11	***********
- 9	*********
- 10	**********

4.	Escriba un programa que lea 10 números enteros positivos de una cifra y los coloque dentro de un vector. A continuación lea un nuevo número entero positivo de una cifra. Finalmente, creamos un nuevo vector en el que, si la cifra a tratar es mayor que el número dado, introduce el número, y si la cifra es menor o igual que el número dado, introduce un cero. Muestre el vector resultante.

- Por ejemplo: 
- Entrados los números: 2 2 5 1 5 8 4 2 3 9
- Valor a buscar: 3
- el resultado es:
- 2 2 5 1 5 8 4 2 3 9
- 0 0 5 0 5 8 4 0 0 9

5. Escriba un programa que lea desde teclado valores para un vector con 20 números enteros positivos que representan las notas de alumnado (entre 0 y 10) y muestre por pantalla su contenido. A continuación, debe contar el número de alumn@s aproba@s y el número de alumn@s suspendid@s, así como la media de notas del grupo.
  - Vector inicial: 5 4 3 5 2 9 6 8 10 3 5 6 4 2 4 9 7 3 4 7
  - Número de aprobados: 11
  - Número de suspendidos: 9	
  - Media del grupo: 5,30


6.  Escriba un programa que solicite 20 números enteros positivos, y los vaya insertando ordenados en un vector. Cada vez que insertamos un número, presentamos todos 
los elementos que ya hemos insertado hasta ese momento.

7. Realizar el algoritmo que, solicitada una cantidad de elementos de un vector, y el límite superior e inferior de los datos a calcular, rellenar con elementos aleatorios dentro de los límites pedidos dicho vector y lo presente por pantalla. A continuación, pida por teclado un nuevo valor  que debe cumplir las mismas condiciones de los anteriores y una posición que debe estar dentro de los límites del vector inicial. Crear un nuevo vector que contenga la información del vector inicial pero insertando el valor pedido en la posición pedida. Finalmente, mostrar ambos vectores al final.

- Solicita el número de posiciones iniciales: 15
- Límite inferior: 2
- Límite superior:10
- Vector inicial: 5 4 3 5 2 9 4 8 10 3 5 6 4 2 4
- Dato nuevo: 5
- Posición: 7
- Vector inicial: 5 4 3 5 2 9 4 8 10 3 5 6 4 2 4
- Vector final: 5 4 3 5 2 9 5 4 8 10 3 5 6 4 2 4
