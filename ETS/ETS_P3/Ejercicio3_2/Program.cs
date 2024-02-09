Console.Write("Introduzca el numero de veces: ");
int veces = Convert.ToInt32(Console.ReadLine());

while (veces > 0) {
  Console.WriteLine("Hola! me quedan " + veces + " instantes de vida");
  veces--;
}
Console.WriteLine("Adios :(");
veces = 4;

for (int vueltas = 0; vueltas < veces; vueltas++) {
  Console.WriteLine("Esta es mi vuelta número " + vueltas);
}

Console.WriteLine("Hasta luego :)");
Console.ReadKey();