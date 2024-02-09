package es.cifpcm.GomezRafaelMiAli.data.repository;

import es.cifpcm.GomezRafaelMiAli.model.Provincia;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
public interface ProvinciaRepository extends JpaRepository<Provincia, Integer>, JpaSpecificationExecutor<Provincia> { }