package es.cifpcm.GomezRafael_SPRING.data.service;

import es.cifpcm.GomezRafael_SPRING.data.repository.ArtistRepository;
import es.cifpcm.GomezRafael_SPRING.model.Artist;
import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.validation.annotation.Validated;

import java.util.List;

@Service
@Validated
public class ArtistService {
    @Autowired
    private ArtistRepository artistRepository;

    public List<Artist> listAll() {
        return artistRepository.findAll();
    }

    public void save (@Valid Artist artist) { artistRepository.save(artist); }

    public Artist get(int id) {
        return artistRepository.findById(id).get();
    }

    public void delete(int id) {
        artistRepository.deleteById(id);
    }
}
