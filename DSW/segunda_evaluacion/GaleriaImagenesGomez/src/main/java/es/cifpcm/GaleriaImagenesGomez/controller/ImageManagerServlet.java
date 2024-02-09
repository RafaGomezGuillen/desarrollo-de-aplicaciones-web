package es.cifpcm.GaleriaImagenesGomez.controller;
import es.cifpcm.GaleriaImagenesGomez.data.PersistenciaImplementada;
import es.cifpcm.GaleriaImagenesGomez.model.Imagen;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

@Controller
@RequestMapping("/imagen")
public class ImageManagerServlet {
    @Autowired
    @Qualifier("PersistenciaImplementada")
    private PersistenciaImplementada pst;

    // Vista que muestra la lista de imágenes subida
    @GetMapping("")
    public String listaImagenes(Model model) {
        model.addAttribute("listaImagenes", pst.list());
        return "lista-imagenes";
    }

    // Vista para subir la imagen
    @GetMapping("/subir-imagen")
    public String subirImagenGet() {
        return "subir-imagen";
    }

    // Subir imagen POST
    @PostMapping("/imageManager")
    public String subirImagenPost(@RequestParam("img") MultipartFile img) {
        Imagen imagen = new Imagen();
        imagen.setNombreUrl(img.getOriginalFilename());

        try {
            pst.guardarImagen(img, imagen);
        } catch (Exception e) {
            e.printStackTrace();
        }

        return "redirect:/imagen";
    }
}