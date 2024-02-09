package es.cifpcm.GomezRafaelMiAliSec.data.service;
import es.cifpcm.GomezRafaelMiAliSec.data.repository.UserRepository;
import es.cifpcm.GomezRafaelMiAliSec.model.Group;
import es.cifpcm.GomezRafaelMiAliSec.model.User;
import es.cifpcm.GomezRafaelMiAliSec.security.AppUserPrincipal;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Sort;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserService implements UserDetailsService {
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private GroupService groupService;

    public List<User> listAll() {
        return userRepository.findAll();
    }

    public User get(int id) { return userRepository.findById(id).get(); }
    public void save(User user)  {
        // Obtener la lista de usuarios ordenada por id de forma descendente
        List<User> userList = userRepository.findAll(Sort.by(Sort.Order.desc("id")));

        // Obtener el último id + 1
        Short nextId = (short) (userList.isEmpty() ? 1 : userList.get(0).getId() + 1);

        // Establecer el nuevo id al usuario antes de guardarlo
        user.setId(nextId);

        // Se encripta la contraseña
        String encodedPassword = new BCryptPasswordEncoder().encode(user.getPassword());
        user.setPassword(encodedPassword);

        // Crear un nuevo grupo con ID 3 "clientes", cambiar a ID 1 si "administradores"
        Group group = groupService.get(3);
        List<Group> groups = new ArrayList<>();
        groups.add(group);

        // Agregar el grupo al usuario y el usuario al grupo
        user.setGroups(groups);

        userRepository.save(user);
    }

    public void insertUsers(User newUser, List<Group> groupList) {
        if (!usernameExists(newUser.getUserName())) {
            // Obtener la lista de usuarios ordenada por id de forma descendente
            List<User> userList = userRepository.findAll(Sort.by(Sort.Order.desc("id")));

            // Obtener el último id + 1
            Short nextId = (short) (userList.isEmpty() ? 1 : userList.get(0).getId() + 1);

            // Establecer el nuevo id al usuario antes de guardarlo
            newUser.setId(nextId);

            // Se encripta la contraseña
            String encodedPassword = new BCryptPasswordEncoder().encode(newUser.getPassword());
            newUser.setPassword(encodedPassword);

            // Agregar el grupo al usuario y el usuario al grupo
            newUser.setGroups(groupList);

            userRepository.save(newUser);
        }
    }

    public void update(User user) {
        userRepository.save(user);
    }

    public void delete(int id) { userRepository.deleteById(id); }

    public AppUserPrincipal loadUser() {
        // Obtenemos la autenticación actual desde el contexto de seguridad
        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        User user = userRepository.findByUserName(authentication.getName());

        return new AppUserPrincipal(user);
    }

    // Método para verificar si el nombre de usuario ya existe
    public boolean usernameExists(String username) {
        List<User> userList = listAll();

        // Utilizando stream y anyMatch para verificar si el nombre de usuario ya existe
        return userList.stream()
                .anyMatch(user -> user.getUserName().equals(username));
    }

    @Override
    public UserDetails loadUserByUsername(String username) {
        User user = userRepository.findByUserName(username);

        if (user == null) {
            throw new UsernameNotFoundException(username);
        }

        return new AppUserPrincipal(user);
    }
}

