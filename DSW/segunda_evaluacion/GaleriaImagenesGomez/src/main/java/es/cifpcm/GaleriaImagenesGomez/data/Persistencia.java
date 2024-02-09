package es.cifpcm.GaleriaImagenesGomez.data;
import es.cifpcm.GaleriaImagenesGomez.model.Imagen;

import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.util.List;

public interface Persistencia {
    public void guardarImagen(MultipartFile file, Imagen imagen) throws IOException;
    public List<Imagen> list();
}
