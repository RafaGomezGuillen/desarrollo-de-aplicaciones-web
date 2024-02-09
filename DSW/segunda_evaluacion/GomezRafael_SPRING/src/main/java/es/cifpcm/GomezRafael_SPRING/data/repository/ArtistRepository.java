package es.cifpcm.GomezRafael_SPRING.data.repository;

import es.cifpcm.GomezRafael_SPRING.model.Artist;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface ArtistRepository extends JpaRepository<Artist, Integer>, JpaSpecificationExecutor<Artist> {
}