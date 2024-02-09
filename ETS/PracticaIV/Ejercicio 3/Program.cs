
/*
 *  Programa que pide por teclado una cadena y una letra, de manera que
 *  elimina las 3 primeras ocurrencias de la letra que encuentre en la cadena y lo muestre
    por pantalla.
 *  Por ejemplo, alejandra y a debería devolver lejndr
 */

String cadena, letra, nuevaCadena = "";
int i, cont = 0;
Console.WriteLine("Introduzca una cadena: ");
cadena = Console.ReadLine();
Console.WriteLine("Introduzca una letra: ");
letra = Console.ReadLine();
for (i = 0; i < cadena.Length; i++) {
  if ((cadena.ElementAt(i) == letra.ElementAt(0)) && (cont != 3)) {
    cont++;
  }
  else {
    nuevaCadena = nuevaCadena + cadena.ElementAt(i);
  }
}
Console.WriteLine(nuevaCadena);
