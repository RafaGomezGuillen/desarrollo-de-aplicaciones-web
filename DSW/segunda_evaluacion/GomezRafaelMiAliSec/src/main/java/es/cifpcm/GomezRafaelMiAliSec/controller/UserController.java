package es.cifpcm.GomezRafaelMiAliSec.controller;

import es.cifpcm.GomezRafaelMiAliSec.data.service.GroupService;
import es.cifpcm.GomezRafaelMiAliSec.data.service.UserService;
import es.cifpcm.GomezRafaelMiAliSec.model.User;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

@Controller
@RequestMapping("/usuario")
public class UserController {
    @Autowired
    private UserService userService;
    @Autowired
    private GroupService groupService;

    // Vista para mostrar la lista de usuarios
    @GetMapping("")
    public String listUser(Model model) {
        List<User> userList = userService.listAll();

        // Ordenar la lista de manera descendente por el id
        userList = userList.stream()
                .sorted(Comparator.comparing(User::getId).reversed())
                .collect(Collectors.toList());

        model.addAttribute("userList", userList);
        return "usuario/usuarios";
    }

    // Vista para la creacion de un usuario
    @GetMapping("/create")
    public String createUser(Model model) {
        User user = new User();
        model.addAttribute("user", user);

        return "usuario/create";
    }

    // Metodo POST para la gestion del usuario creado
    @PostMapping("/saveUser")
    public String createUserPost(@ModelAttribute("user") User user, Model model) {
        if (userService.usernameExists(user.getUserName())) {
            model.addAttribute("errorMessage", "El nombre de usuario ya existe");
            return "usuario/create";
        }

        userService.save(user);
        return "redirect:/login";
    }

    // Vista para editar el usuario
    @RequestMapping("/update/{id}")
    public ModelAndView updateUserGet(@PathVariable(name = "id") int id, Model modelAdd) {
        ModelAndView model = new ModelAndView("usuario/edit");

        User user = userService.get(id);
        model.addObject("user", user);
        modelAdd.addAttribute("listGroups", groupService.listAll());

        return model;
    }

    // Metodo post para editar el usuario
    @PostMapping("/updateUser")
    public String updateUserPost(@ModelAttribute("user") User updateUser, Model model) {
        model.addAttribute("listGroups", groupService.listAll());
        User originalUser = userService.get(updateUser.getId());

        // Primero, actualiza solo el nombre de usuario y guarda el usuario
        originalUser.setUserName(updateUser.getUserName());
        originalUser.getGroups().clear();
        originalUser.setGroups(updateUser.getGroups());
        userService.update(originalUser);

        return "redirect:/usuario";
    }

    // Metodo para eliminar un usuario
    @RequestMapping("/delete/{id}")
    public String deleteUser(@PathVariable(name = "id") int id) {
        userService.delete(id);

        return "redirect:/usuario";
    }
}
