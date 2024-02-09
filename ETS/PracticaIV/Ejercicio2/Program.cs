/* Programa que pide un numero hasta que introduce 0.
 * El programa pasará de kilogramos a gramos
 * 
 */
double kg;
int numero = 1;
while (numero != 0) {

       Console.WriteLine("Introduce los kg");
        kg = Double.Parse(Console.ReadLine());

        double gramos = kg * 1000;
       Console.WriteLine(gramos + " Gramos");

       Console.WriteLine("Introduce los kg");
        numero = Int32.Parse(Console.ReadLine());
}