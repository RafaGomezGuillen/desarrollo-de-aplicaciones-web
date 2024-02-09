
/*
 * Programa que llama a la funci�n pintar(), la cual muestra por pantalla esto:
 * 1******

   12*****

   123****

   1234***

   12345**

   123456*

   1234567

   Hay 2 errores en el codigo
 */
pintar();

static void pintar() {

    int i, j, k;

    for (i = 1; i <= 7; i++) {
        for (j = 1; j <= i; ++j) {
            Console.Write(j);
        }
        for (k = 6; k >= i; k--) {
            Console.Write("*");
        }
        Console.WriteLine("");
    }
}
