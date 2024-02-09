package es.cifpcm.GomezRafaelMiAliSec.data.repository;

import es.cifpcm.GomezRafaelMiAliSec.model.Group;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface GroupRepository extends JpaRepository<Group, Integer>, JpaSpecificationExecutor<Group> { }
