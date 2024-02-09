package es.cifpcm.GomezRafael_SPRING.controller;

import es.cifpcm.GomezRafael_SPRING.data.service.ArtistService;
import es.cifpcm.GomezRafael_SPRING.model.Artist;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Controller
@RequestMapping("/artist")
public class ArtistController {
    @Autowired
    private ArtistService artistService;

    // Vista para mostrar la lista de artistas
    @GetMapping("")
    public String listArtist(Model model) {
        List<Artist> artistList = artistService.listAll();

        // Ordenar la lista de manera descendente por el id
        artistList = artistList.stream()
                .sorted(Comparator.comparing(Artist::getId).reversed())
                .collect(Collectors.toList());

        model.addAttribute("artistList", artistList.stream().limit(15));
        model.addAttribute("artistListTotal", artistService.listAll());
        model.addAttribute("message", "Elige un artista para ver sus discos");
        return "artist/artist-list";
    }

    // Método para manejar la selección de artistas y albumes
    @GetMapping("/getArtistAlbums")
    public String comboArtist(@RequestParam("artist") int artistId) {
        return "redirect:/artist/" + artistId;
    }

    // Vista para detalles del artista
    @RequestMapping("/{id}")
    public ModelAndView detailsArtist(@PathVariable(name = "id") int id) {
        ModelAndView model = new ModelAndView("artist/details");

        Artist artist = artistService.get(id);
        model.addObject("artist", artist);

        return model;
    }

    // Vista para la creacion de un artista
    @RequestMapping("/create")
    public String saveArtistGet(Model model) {
        Artist artist = new Artist();
        model.addAttribute("artist", artist);

        return "artist/create";
    }

    // Metodo post para la creacion de un artista
    @PostMapping("/saveArtist")
    public String saveArtistPost(@Valid @ModelAttribute("artist") Artist artist, BindingResult result) {
        if (result.hasErrors()) {
            return "artist/create";
        } else {
            artistService.save(artist);
            return "redirect:/artist/" + artist.getId();
        }
    }

    // Vista para editar el artista
    @RequestMapping("/update/{id}")
    public ModelAndView updateArtistGet(@PathVariable(name = "id") int id) {
        ModelAndView model = new ModelAndView("artist/edit");

        Artist artist = artistService.get(id);
        model.addObject("artist", artist);

        return model;
    }

    // Metodo post para editar un artista
    @PostMapping("/updateArtist")
    public String updateArtistPost(@Valid @ModelAttribute("artist") Artist artist, BindingResult result) {
        if (result.hasErrors()) {
            return "artist/edit";
        } else {
            artistService.save(artist);
            return "redirect:/artist/" + artist.getId();
        }
    }

    // Metodo para eliminar un artista
    @RequestMapping("/delete/{id}")
    public String deleteArtist(@PathVariable(name = "id") int id) {
        artistService.delete(id);

        return "redirect:/artist";
    }
}
