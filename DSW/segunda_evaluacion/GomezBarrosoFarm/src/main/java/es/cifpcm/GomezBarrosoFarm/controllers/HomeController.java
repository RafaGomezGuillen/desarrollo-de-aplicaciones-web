package es.cifpcm.GomezBarrosoFarm.controllers;

import org.springframework.web.bind.annotation.GetMapping;

public class HomeController {
    @GetMapping("/")
    public String mostrarPaginaPrincipal() {
        return "index";
    }
}

