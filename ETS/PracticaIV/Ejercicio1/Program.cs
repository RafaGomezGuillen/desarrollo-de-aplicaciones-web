int numero = 0;
int divisor = 5;
int resultado = 0;

String nombre = "Leonor de Borbón";
Console.WriteLine("Hola " + nombre + " dime número y te digo si son m�ltiplos de " + divisor);
numero = Int32.Parse(Console.ReadLine());
while (numero != 0) {
    resultado = numero % divisor;
    if (resultado == 0) Console.WriteLine("Si, el numero " + numero + " es divisble por " + divisor);

    else Console.WriteLine("NO!!!, el numero " + numero + " NO es divisble por " + divisor);
    Console.WriteLine("Introduce otro numero");
    numero = Int32.Parse(Console.ReadLine());
}
