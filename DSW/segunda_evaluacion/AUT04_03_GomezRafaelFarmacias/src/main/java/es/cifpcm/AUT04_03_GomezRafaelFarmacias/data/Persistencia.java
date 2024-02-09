package es.cifpcm.AUT04_03_GomezRafaelFarmacias.data;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.model.Farmacia;
import java.util.List;

public interface Persistencia {
    public void openJson();
    public List<Farmacia> list();
}
