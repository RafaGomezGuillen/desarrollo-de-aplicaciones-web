/*
	 *  Programa que llama a la funcion sumarDigitos(int num), la cual devuelve la suma
	 *  de cada uno de los digitos del valor que se le pasa por parametro
	 *  sumarDigitos(1223) devuelve 1 + 2 + 2 + 3 = 8
*/

int res;
res = sumarDigitos(1223);
Console.WriteLine("La suma de los digitos es: " + res);

static int sumarDigitos(int num)
{
    int suma = 0;
    int aux;
    while (num >= 1)
    {
        aux = num % 10;
        num /= 10;
        suma += aux;
    }
    return suma;
}
