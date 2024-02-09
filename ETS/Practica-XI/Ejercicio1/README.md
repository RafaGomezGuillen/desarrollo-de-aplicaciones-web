# Ejercicio 1
## Apartado 1
Desde el instituto te piden que, como el mejor alumno de la historia de los ciclos de informática, realices un sistema de matriculación de los diversos alumnos. Antes de ponerte a programar en C#, como buen ingeniero de software que eres, vas a realizar un diagrama de clases. Las restricciones son:

- Se quieren guardar profesores, de los cuales guardaremos su nombre, apellidos, fecha de nacimiento, y asignaturas que imparte.

- De los alumnos guardaremos el nombre, los apellidos, el nacimiento y las notas.

- Se quiere almacenar un contador tanto de alumnos como de profesores.

- Los alumnos pueden ser de ciclo, o de fp básica. De los de ciclo queremos saber el grado al que pertenece y qué curso (primero, segundo) junto con su modalidad (presencial, semipresencial). De los de fp básica hay que almacenar el nombre de su madre y de su padre.

- Los alumnos pueden ser escolarizados en un curso, pudiendo tanto matricularse o desmatricularse del mismo. Los profesores también pueden matriculares o desmatricularse de un curso, lo que en este caso representa que pueden ser (o dejar de ser) tutores de un curso.

## Apartado 2
En un juego de ordenador existen 2 tipos de jugadores: los principiantes y los avanzados. Todos ellos deben tener un nombre y un número de vidas. Los principiantes se desplazan andando a unas coordenadas (x,y). Los jugadores avanzados además de andar también pueden conducir un vehículo para desplazarse más rápido a unas coordenadas. Cada vehículo tiene asociada una velocidad que puede ser leída y ajustada a un valor dado, pero no puede superar una velocidad máxima dada. La velocidad máxima sólo se podrá asignar una vez y no podrá ser modificada. Todos los atributos de las clases serán privados y tendrán métodos públicos para acceder a ellos (get/set) salvo que los requisitos indiquen lo contrario. Debe existir un método que se llame andar y otro conducir. 

## Apartado 3
Desde el centro de astrofísica de Tenerife se te encomienda la tarea de generar un programa que gestione el envío y recepción de información de pequeños satélites que orbitan alrededor de las Islas Canarias:

- Se trabaja con la idea de cuerpo sólido, del cual queremos almacenar una imagen, la dirección, posición y velocidad.
- Un satélite, que es un tipo de cuerpo sólido, se puede controlar desde el observatorio, pudiendo aumentar, disminuir, girar hacia la izquierda, girar hacia la derecha y apagar el satélite.
- Para medir los diferentes valores (velocidad, dirección, imagen…) se usarán diferentes instrumentos, como una brújula, un velocímetro y un GPS. Cada uno de los instrumentos tratará la información de diferente forma.
- Los instrumentos se recogen en un panel de instrumentos, desde donde podemos activar, desactivar y visualizar la información obtenida.
- Para la obtención de la información se utiliza el patrón de arquitectura Observador, en el cual, podemos definir un mecanismo de suscripción de eventos para notificar a múltiples objetos (los subscriptores) sobre cualquier evento que esté ocurriendo sobre un objeto (llamado observador, o publicador). En este caso hay que modelar el concepto de Publicador y de Suscriptor.
  - Un publicador puede notificar a sus suscriptores, y permitir suscripciones o bajas. El publicador almacena una lista de los suscriptores.
  - Un suscriptor tendrá el método de actualización, que será llamado por el publicador cuando el evento que se está observando ocurra.
  - Un satélite es un publicador, pero podría ser que, si algún día se despliega un dron, o un cohete, también sean publicadores.
  - Los suscriptores a los datos serán cualquiera de los instrumentos que tenemos en el sistema, pero teniendo en cuenta que cada instrumento procesará los datos de diferente forma
