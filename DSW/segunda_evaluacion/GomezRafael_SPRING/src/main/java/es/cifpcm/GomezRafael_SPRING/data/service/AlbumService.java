package es.cifpcm.GomezRafael_SPRING.data.service;

import es.cifpcm.GomezRafael_SPRING.data.repository.AlbumRepository;
import es.cifpcm.GomezRafael_SPRING.model.Album;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class AlbumService {
    @Autowired
    private AlbumRepository albumRepository;

    public List<Album> listAll() {
        return albumRepository.findAll();
    }

    public void save (Album artist) { albumRepository.save(artist); }

    public Album get(int id) {
        return albumRepository.findById(id).get();
    }

    public void delete(int id) {
        albumRepository.deleteById(id);
    }
}
