package es.cifpcm.GomezRafaelMiAliSec.data.repository;

import es.cifpcm.GomezRafaelMiAliSec.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface UserRepository extends JpaRepository<User, Integer>, JpaSpecificationExecutor<User>{
    User findByUserName(String username);
}