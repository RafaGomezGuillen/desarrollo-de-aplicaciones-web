package es.cifpcm.GomezRafaelMiAli.data.repository;
import es.cifpcm.GomezRafaelMiAli.model.Municipio;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface MunicipioRepository extends JpaRepository<Municipio, Integer>, JpaSpecificationExecutor<Municipio> { }