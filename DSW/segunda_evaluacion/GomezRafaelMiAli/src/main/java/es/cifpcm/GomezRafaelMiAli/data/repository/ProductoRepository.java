package es.cifpcm.GomezRafaelMiAli.data.repository;
import es.cifpcm.GomezRafaelMiAli.model.Productoffer;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface ProductoRepository extends JpaRepository<Productoffer, Integer>, JpaSpecificationExecutor<Productoffer> { }