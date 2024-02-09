package es.cifpcm.data;
import java.util.List;
import es.cifpcm.model.Farmacia;

public interface Persistence {
    public void openJson();
    public void add(Farmacia farmacia);
    public void delete(Farmacia farmacia);
    public List<Farmacia> list();

    /*
    *
    * Para cerrar el archivo JSON, en realidad, no es necesario un método específico para "cerrar" el archivo en Java,
    * ya que las operaciones de lectura y escritura gestionan automáticamente la apertura y cierre del archivo.
    * */
}
