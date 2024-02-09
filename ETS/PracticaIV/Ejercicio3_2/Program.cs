/* Programa que calcula el sumatorio de un número
 * El sumatorio es la suma de todos los números que hay entre el 1 y
 * el número final.
 * Por ejemplo, el sumatorio de 6 es 1 + 2 + 3 + 4 + 5 + 6 = 21.
 */

Console.WriteLine("Introduce un numero, mayor que 0:");

int numero = Int32.Parse(Console.ReadLine());

int suma = 0;

for (int i = 0; i <= numero; i++) {
    suma  = suma + i;
}

Console.WriteLine("El resultado es {0}", suma);