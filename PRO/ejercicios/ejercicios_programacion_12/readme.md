# Ejercicios de Programación - POO.
1. Queremos informatizar una lista de clientes, de los que queremos saber el nombre y sus apellidos, que no deben ser nulos. A cada cliente le asignaremos un número que irá correlativo.
- Generaremos un menú que nos permita crear un cliente, buscar si un cliente pertenece a la lista, mostrar los clientes de la lista y eliminar un cliente de la lista.

2. Tenemos una máquina expendedora de comida, en la que tenemos espacio para un máximo de 20 productos distintos que se sitúan en cada línea de distribución. Cada una de las líneas podrá tener un máximo de 10 elementos del mismo producto. Generar las clases relacionadas para controlar el stock de la máquina y los métodos de extraer (damos un producto, vemos si está, y si tiene stock, bajamos el stock en uno) y rellenar la máquina (llenar todas las líneas de productos hasta su máximo). 

3. Modificar el proyecto anterior para que la máquina sea capaz de, teniendo los precios, averiguar qué cantidad monetaria debemos devolver al cliente por la compra del producto que ha realizado.

4. Una tienda quiere controlar las compras de sus clientes. Por cada 3 productos que se compren, quiere regalar el de precio inferior. Se van introduciendo los productos mediante la solicitud de su nombre y su precio. Por cada 3 productos, se regala un producto, comenzando por los que tengan menor precio del todos los productos. Mostrar al final cada uno de los productos, el precio que tenía y el precio que se aplica. También dar el precio final a pagar por todos los productos.

5. Objeto de tipo Juego, que tiene un atributo de tipo Género, los getters están correctos, listas mejoradas.
- Añadir juego.
- Mostrar juegos.
- Borrar juego.

6. Maquina definitivo. Gettes, Setters, Constructores de todo... Si te vas a copiar hazlo de aquí.

- Tendrá que existir una clase Maquina que sea quien contenga y gestione el conjunto de productos que esta tiene, así como su número máximo de líneas y la capacidad de estas.

- El menú, aparte de facilitar la opción de compra de productos, tendrá que ofrecer opciones para añadir un producto a la máquina (indicando nombre de producto, precio y cantidad) siempre que quede hueco, y para quitar productos que no se quieran seguir vendiendo. Todas las funciones relacionadas con añadir/quitar productos de la máquina, así como comprobar si hay hueco para añadir nuevo producto, tendrán que estar contenidos en la clase Maquina.

- Para la venta de productos se tendrá que indicar en primer lugar el dinero que se va a introducir en la máquina, para poder mostrar al cliente los productos que puede comprar con el dinero introducido. En caso de elegir un producto de importe menor al introducido se tendrá que indicar cuánto dinero se ha de devolver. 

7. La cafetería del centro nos ha pedido que realicemos un programa que permita gestionar los pedidos que realiza el alumnado. 

- Estos pedidos se componen de una serie de productos, tantos como quiera el usuario, a elegir entre los que ofrece la cafetería en su menú. Los productos que contiene el menú se especificarán en el código. 

- La cafetería tendrá que ir anotando los pedidos en una cola de pedidos que solo admite un máximo de 5, de manera que si la cola está llena no se podrán añadir más pedidos hasta que se sirva alguno de los pendientes. 

- Los pedidos han de registrar un conjunto de productos y la fecha en la que fue pedido (dia, mes, año y hora).

- Los pedidos se sirven por orden de llegada, cuando el usuario así lo elija en el menú, teniendo que mostrar el coste que tenía el pedido servido. 

- El programa tendrá que permitir “hacer caja” mostrando todos los pedidos servidos hasta el momento, con sus productos y precio de pedido, y el total de dinero recaudado hasta el momento.

8. Crear un programa que permita registrar figuras geométricas, calcular su área y mostrarlas en su conjunto. 

- Todas las figuras tendrán un color propio indicado por el usuario al registrarlas. 

- Las figuras serán de un tipo de los siguientes, cada una con su propia definición de sus dimensiones: Rectángulo (definido por su ancho y largo), Círculo (definido por su radio) o Triángulo (definido por su base y su altura).

- A la hora de crear una nueva figura se tendrá que dar a elegir al usuario cuál de los 3 tipos quiere crear, así como su color y dimensiones.

- Utilizar mecanismos que ofrece la herencia para realizar este ejercicio.