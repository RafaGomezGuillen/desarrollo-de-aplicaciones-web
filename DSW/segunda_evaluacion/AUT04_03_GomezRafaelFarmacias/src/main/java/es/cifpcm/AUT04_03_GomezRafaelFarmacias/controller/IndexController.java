package es.cifpcm.AUT04_03_GomezRafaelFarmacias.controller;

import es.cifpcm.AUT04_03_GomezRafaelFarmacias.data.Persistencia;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.data.PersistenciaImplementada;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class IndexController {
    private static Persistencia pst = new PersistenciaImplementada();
    private static boolean jsonAbierto = false;

    @RequestMapping("/")
    public String index() {
        if (!jsonAbierto) {
            pst.openJson(); // Abre el archivo JSON y carga las farmacias
            jsonAbierto = true; // Marca que el archivo ya se ha abierto
        }

        return "index";
    }
}
