package es.cifpcm.GomezRafael_SPRING.data.repository;

import es.cifpcm.GomezRafael_SPRING.model.Album;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface AlbumRepository extends JpaRepository<Album, Integer>, JpaSpecificationExecutor<Album>{ }
