package es.cifpcm.GomezRafael_SPRING.controller;

import es.cifpcm.GomezRafael_SPRING.data.service.AlbumService;
import es.cifpcm.GomezRafael_SPRING.data.service.ArtistService;
import es.cifpcm.GomezRafael_SPRING.model.Album;
import es.cifpcm.GomezRafael_SPRING.model.Artist;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Controller
@RequestMapping("/album")
public class AlbumController {
    @Autowired
    private AlbumService albumService;
    @Autowired
    private ArtistService artistService;

    // Vista para mostrar la lista de albumes
    @GetMapping("")
    public String listAlbum(Model model) {
        List<Album> albumList = albumService.listAll();

        // Ordenar la lista de manera descendente por el id
        albumList = albumList.stream()
                .sorted(Comparator.comparing(Album::getId).reversed())
                .collect(Collectors.toList());

        model.addAttribute("albumList", albumList.stream().limit(15));
        return "album/album-list";
    }

    // Vista para detalles del album
    @RequestMapping("/{id}")
    public ModelAndView detailsAlbum(@PathVariable(name = "id") int id) {
        ModelAndView model = new ModelAndView("album/details");

        Album album = albumService.get(id);
        model.addObject("album", album);

        return model;
    }

    // Vista para la creacion de un album
    @RequestMapping("/create")
    public String saveAlbumGet(Model model) {
        Album album = new Album();
        model.addAttribute("album", album);
        model.addAttribute("listArtist", artistService.listAll());

        return "album/create";
    }

    // Metodo post para la creacion de un album
    @PostMapping("/saveAlbum")
    public String saveAlbumPost(@ModelAttribute("album") Album album) {
        Artist artist = artistService.get(album.getArtistaId());
        album.setArtist(artist);
        albumService.save(album);
        return "redirect:/album/" + album.getId();
    }

    // Vista para editar el album
    @RequestMapping("/update/{id}")
    public ModelAndView updateAlbumGet(@PathVariable(name = "id") int id, Model modelAdd) {
        ModelAndView model = new ModelAndView("album/edit");

        Album album = albumService.get(id);
        model.addObject("album", album);
        modelAdd.addAttribute("listArtist", artistService.listAll());

        return model;
    }

    // Metodo post para editar un album
    @PostMapping("/updateAlbum")
    public String updateAlbumPost(@ModelAttribute("album") Album album) {
        Artist artist = artistService.get(album.getArtistaId());
        album.setArtist(artist);
        albumService.save(album);
        return "redirect:/album/" + album.getId();
    }

    // Metodo para eliminar un album
    @RequestMapping("/delete/{id}")
    public String deleteAlbum(@PathVariable(name = "id") int id) {
        albumService.delete(id);

        return "redirect:/album";
    }
}
