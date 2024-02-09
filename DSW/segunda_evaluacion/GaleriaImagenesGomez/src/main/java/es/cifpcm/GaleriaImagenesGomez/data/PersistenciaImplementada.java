package es.cifpcm.GaleriaImagenesGomez.data;
import es.cifpcm.GaleriaImagenesGomez.model.Imagen;

import org.springframework.stereotype.Service;
import org.springframework.util.ResourceUtils;
import org.springframework.web.multipart.MultipartFile;

import java.io.*;

import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

import java.util.ArrayList;
import java.util.List;

@Service("PersistenciaImplementada")
public class PersistenciaImplementada implements Persistencia {
    private static List<Imagen> imagenList = new ArrayList<>(); // Contexto
    private static final String RUTA_UPLOADS = "src/main/resources/static/uploadsGomez";
    private static final String RUTA_UPLOADS_TARGET = "static/uploadsGomez";
    // Guardar imágenes en la carpeta
    @Override
    public void guardarImagen(MultipartFile file, Imagen imagen) throws IOException {
        // Subir a la carpeta "uploadsGomez" dentro del directorio "static"
        File uploadDirStatic = ResourceUtils.getFile(RUTA_UPLOADS);

        if (!uploadDirStatic.exists()) {
            uploadDirStatic.mkdirs();  // Crea directorios si no existen
        }

        Path pathStatic = Paths.get(uploadDirStatic.getAbsolutePath(), file.getOriginalFilename());
        Files.write(pathStatic, file.getBytes());

        // Subir a la carpeta target
        File uploadDirTarget = ResourceUtils.getFile("classpath:" + RUTA_UPLOADS_TARGET);

        if (!uploadDirTarget.exists()) {
            uploadDirTarget.mkdirs();  // Crea directorios si no existen
        }

        Path pathTarget = Paths.get(uploadDirTarget.getAbsolutePath(), file.getOriginalFilename());
        Files.write(pathTarget, file.getBytes());
        imagenList.add(imagen);
    }

    @Override
    public List<Imagen> list() {
        return imagenList;
    }
}