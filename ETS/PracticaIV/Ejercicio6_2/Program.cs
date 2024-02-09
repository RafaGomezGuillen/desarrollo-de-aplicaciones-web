/*
	 * Programa que, recibiendo dos strings de entrada y el genero del bebé (M o F), devuelve el nombre recomendado para el bebé
	 * El nombre se calcula cogiendo la mitad de los nombres de los padres, y concatenandolos en diferente orden, segun el hijo.
	 * Ejemplo:
	 * Danielle y John con hija genera JODANI
	 * Danielle y John con hijo generan DANIJO
	 */
// Hay 2 errores

Console.WriteLine("Nombre del primer familiar ");
String nombre1 = Console.ReadLine();
nombre1 = nombre1.TrimEnd();
Console.WriteLine("Nombre del segundo familiar ");
String nombre2 = Console.ReadLine();
nombre2 = nombre2.TrimEnd();  
Console.WriteLine("Sexo del bebé? M o F ");
String genero = Console.ReadLine();

String mitad1 = sacarMitadNombre(nombre1);
String mitad2 = sacarMitadNombre(nombre2);
String nombre = "";

if (genero.ToUpper().StartsWith("M") || genero.ToUpper().StartsWith("F")) {
  if (genero.ToUpper().StartsWith("M")) {
    nombre = mitad1 + mitad2;
  } else  {
    nombre = mitad2 + mitad1;
  }
    Console.WriteLine("Nombre sugerido: " + nombre.ToUpper());
} else {
  Console.WriteLine("Debe colocar M o F");
}

static String sacarMitadNombre(String nombre) {
  int indiceMedio = nombre.Length / 2;
  String mitad = nombre.Substring(0, indiceMedio);
  return mitad;
}
