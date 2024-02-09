# EJE0503 Pair Programming.

## Enunciado del ejercicio:

Nos han propuesto calcular las personas que están por encima y por debajo de la media de altura en una muestra realizada. Dicha muestra se almacena en un array de estructura que se define:

**class Personal {
  public struct Personas {
    public string nombre;
    public string apelllidos;
    public decimal altura;
  }
}**

La cantidad de personas a las que se preguntó no es siempre la misma para diferentes ejecuciones del programa. Este número de personas se debe solicitar el principio del programa.

## Primera fase:

Desarrollar los siguientes métodos:

### Clase: CSFunciones.
- Llamada: **int SolicitarNumeroPersonas()**
- Solicita el número de personas que va a tener la muestra a tratar.

### Clase: CSFunciones.
- Llamada: **Personas[] LeerDatosMuestra(int personasMuestra)**
- Solicita y rellena la información de nombres de personas y su altura. Los nombres no pueden estar vacíos, y las alturas no pueden ser negativos ni mayores de 3 metros. La altura se representa en metros.

### Clase: CSFunciones.
- Llamada: **void MostrarDatosMuestra(Personas[] listaPersonas)**
- Muestra los datos de la muestra por pantalla.

## Segunda Fase:

Crear un nuevo fichero de clase denominado CSAlturas. En él, desarrollar los métodos:

### Clase: CSAlturas.
- Llamada: **string[] PersonasPorEncimaMedia(Personas[] listaPersonas)**
- Devuelve un string[] con los nombres de las personas que tienen una altura por encima de la media de la muestra.

### Clase: CSAlturas.
- Llamada: **string[] PersonasPorDebajoMedia(Personas[] listaPersonas)**
- Devuelve un string[] con los nombres de las personas que tienen una altura por debajo de la media de la muestra.

### Clase: CSAlturas.
- Llamada: **void MostrarPersonas(string[] personasFiltradas, string mensajeFiltro)**
- Muestra por pantalla los nombres de las personas que reúnen una condición. La condición se le pasa al método mediante el string mensaje, que en nuestros datos será estar por encima de la media, o estar por debajo de la media. 
