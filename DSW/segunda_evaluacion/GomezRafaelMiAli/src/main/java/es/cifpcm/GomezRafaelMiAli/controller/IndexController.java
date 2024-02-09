package es.cifpcm.GomezRafaelMiAli.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class IndexController {
    @RequestMapping("/")
    public String index() {
        return "inicio";
    }

    @RequestMapping("/login")
    public String login() {
        return "login";
    }

    @RequestMapping("/usuario/create")
    public String createUser() {
        return "/usuario/create";
    }
}
