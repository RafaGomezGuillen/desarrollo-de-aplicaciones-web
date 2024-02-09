using Pokemon;
using PracticaIX;

namespace Test
{
    [TestClass]
    public class PersonasTests
    {
        [TestMethod]
        public void TestPersonasPorEncimaMediaListaVacia ()
        {
            Personas[] listaVacia = new Personas[] { };

            string[] resultado = CSAlturas.PersonasPorEncimaMedia(listaVacia);

            CollectionAssert.AreEqual(new string[] { }, resultado);
        }

        [TestMethod]
        public void TestPersonasPorEncimaMedia ()
        {
            Personas[] listaPersonas = new Personas[4];
            string[] nombres = { "Juan", "Maria", "Pedro", "Luis" };
            string[] apellidos = { "Gomez", "Guillen", "Perez", "Suarez" };
            decimal[] alturas = { 1.6m, 1.55m, 1.5m, 1.4m };
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                Personas p = new();
                p.Nombre = nombres[i];
                p.Apellidos = apellidos[i];
                p.Altura = alturas[i];
                listaPersonas[i] = p;
            }

            string[] resultado = CSAlturas.PersonasPorEncimaMedia(listaPersonas);

            CollectionAssert.AreEqual(new string[] { "Juan", "Maria" }, resultado);
        }

        [TestMethod]
        public void TestPersonasPorDebajoMediaListaVacia ()
        {
            Personas[] listaVacia = new Personas[] { };

            string[] resultado = CSAlturas.PersonasPorDebajoMedia(listaVacia);

            CollectionAssert.AreEqual(new string[] { }, resultado);
        }

        [TestMethod]
        public void TestPersonasPorDebajoMedia ()
        {
            Personas[] listaPersonas = new Personas[4];
            string[] nombres = { "Juan", "Maria", "Pedro", "Luis" };
            string[] apellidos = { "Gomez", "Guillen", "Perez", "Suarez" };
            decimal[] alturas = { 1.6m, 1.55m, 1.5m, 1.4m };
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                Personas p = new();
                p.Nombre = nombres[i];
                p.Apellidos = apellidos[i];
                p.Altura = alturas[i];
                listaPersonas[i] = p;
            }

            string[] resultado = CSAlturas.PersonasPorDebajoMedia(listaPersonas);

            CollectionAssert.AreEqual(new string[] { "Pedro", "Luis" }, resultado);
        }
  
        [TestMethod]
        public void NombrePersonaMasAlta ()
        {
            Personas[] listaPersonas = new Personas[4];
            string[] nombres = { "Juan", "Maria", "Pedro", "Luis" };
            string[] apellidos = { "Gomez", "Guillen", "Perez", "Suarez" };
            decimal[] alturas = { 1.6m, 1.55m, 1.5m, 1.4m };
            for (int i = 0; i < listaPersonas.Length; i++)
            {
                Personas p = new();
                p.Nombre = nombres[i];
                p.Apellidos = apellidos[i];
                p.Altura = alturas[i];
                listaPersonas[i] = p;
            }

            string resultado = CSAlturas.personaMasAlta(listaPersonas);

            Assert.AreEqual("Juan", resultado);
        }

        [TestMethod]
        public void NoPokemonsEnGeneration ()
        {
            string fichero = "pokemon.csv";
            int generation = 10;

            string result = Ficheros.strongestPokemon(fichero, generation);

            Assert.AreEqual("ERROR: Sequence contains no elements", result);
        }
        [TestMethod]
        public void PokemonsEnGeneration ()
        {
            string fichero = "pokemon.csv";
            int generation = 1;

            string result = Ficheros.strongestPokemon(fichero, generation);

            Assert.AreEqual("PinsirMega Pinsir. GyaradosMega Gyarados. ", result);
        }
        [TestMethod]
        public void TestFilterPokemonWithValidInput ()
        {
            string sourceFile = "pokemonDosTipos.csv";
            string[] lines = {
            "Bulbasaur",
            "Ivysaur",
            "Venusaur",
            "VenusaurMega Venusaur",
            "Charizard",
            "CharizardMega Charizard X",
            "CharizardMega Charizard Y"
        };
            File.WriteAllLines(sourceFile, lines);

            string[] filteredLines = File.ReadAllLines(sourceFile);
            Assert.AreEqual("Bulbasaur", filteredLines[0]);
            Assert.AreEqual("Ivysaur", filteredLines[1]);
            Assert.AreEqual("Venusaur", filteredLines[2]);
            Assert.AreEqual("VenusaurMega Venusaur", filteredLines[3]);
            Assert.AreEqual("Charizard", filteredLines[4]);
            Assert.AreEqual("CharizardMega Charizard X", filteredLines[5]);
            Assert.AreEqual("CharizardMega Charizard Y", filteredLines[6]);
        }
    }
}