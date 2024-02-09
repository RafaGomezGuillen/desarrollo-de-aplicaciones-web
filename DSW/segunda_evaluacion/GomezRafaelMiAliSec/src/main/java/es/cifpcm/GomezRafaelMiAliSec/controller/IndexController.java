package es.cifpcm.GomezRafaelMiAliSec.controller;

import es.cifpcm.GomezRafaelMiAliSec.data.service.UserService;
import es.cifpcm.GomezRafaelMiAliSec.security.AppUserPrincipal;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class IndexController {
    @Autowired
    private UserService userService;

    @RequestMapping("/")
    public String index(Model model) {
        AppUserPrincipal user = userService.loadUser();
        model.addAttribute("user", user);
        return "inicio";
    }
}
