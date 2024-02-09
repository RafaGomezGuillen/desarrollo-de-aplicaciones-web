package es.cifpcm.GomezRafaelMiAliSec.data.service;
import es.cifpcm.GomezRafaelMiAliSec.data.repository.ProductoRepository;
import es.cifpcm.GomezRafaelMiAliSec.model.Municipio;
import es.cifpcm.GomezRafaelMiAliSec.model.Productoffer;

import jakarta.annotation.Nullable;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.util.ResourceUtils;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import java.util.stream.Collectors;

@Service
@Validated
public class ProductoService {
    private static final String ROUTE_UPLOADS_TARGET = "static/img";

    @Autowired
    private ProductoRepository productoRepository;

    @Autowired
    private MunicipioService municipioService;

    public List<Productoffer> listAll() {
        List<Productoffer> productos = productoRepository.findAll();

        // Cargar municipios para cada producto
        productos.forEach(producto -> {
            Municipio municipio = municipioService.get(producto.getIdMunicipio());
            producto.setMunicipio(municipio);
        });

        return productos;
    }

    public void save(@Valid Productoffer producto, @Nullable MultipartFile img) throws IOException {
        if (img != null) {
            saveImage(img);
        }
        productoRepository.save(producto);
    }

    // Guardar imágenes en la carpeta
    public void saveImage(MultipartFile file) throws IOException {
        // Subir a la carpeta target
        File uploadDirTarget = ResourceUtils.getFile("classpath:" + ROUTE_UPLOADS_TARGET);

        if (!uploadDirTarget.exists()) {
            uploadDirTarget.mkdirs();  // Crea directorios si no existen
        }

        Path pathTarget = Paths.get(uploadDirTarget.getAbsolutePath(), file.getOriginalFilename());
        Files.write(pathTarget, file.getBytes());
    }

    public Productoffer get(int id) {
        return productoRepository.findById(id).get();
    }

    public List<Productoffer> getProductsByMunicipio(int idMunicipio) {
        return listAll()
                .stream()
                .filter(producto -> producto.getIdMunicipio().equals(idMunicipio))
                .collect(Collectors.toList());
    }

    public void delete(int id) {
        productoRepository.deleteById(id);
    }
}
