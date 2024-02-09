package es.cifpcm.AUT04_03_GomezRafaelFarmacias.controller;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.data.Persistencia;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.data.PersistenciaImplementada;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.model.Farmacia;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import java.util.List;
import java.util.ArrayList;

@Controller
@RequestMapping("/farmacias")
public class FarmaciaController {
    private static Persistencia pst = new PersistenciaImplementada();
    @GetMapping("")
    public String listarFarmacias(Model model) {
        model.addAttribute("farmacias", pst.list()); // Añade la lista al modelo

        return "lista-farmacias"; // Devuelve el nombre de la vista a mostrar (farmacia-lista.html, por ejemplo)
    }

    @GetMapping("/buscar")
    public String buscarFarmacia() {
        return "buscar-farmacia";
    }

    @PostMapping("/listado")
    public String buscarFarmaciasPorNombre(@RequestParam("nombreFarmacia") String nombreFarmacia, Model model) {
        Farmacia farmaciaBuscada = buscarFarmaciaPorNombre(nombreFarmacia);

        if (farmaciaBuscada != null) {
            List<Farmacia> farmaciasCercanas = buscarFarmaciasCercanas(farmaciaBuscada);

            if (!farmaciasCercanas.isEmpty()) {
                model.addAttribute("nombreFarmacia", "Listado de farmacias cercanas a " + nombreFarmacia);
                model.addAttribute("farmacias", farmaciasCercanas);
            } else {
                model.addAttribute("mensaje", "No hay farmacias cercanas a " + farmaciaBuscada.getNombre() + ".");
            }

        } else {
            model.addAttribute("mensaje", "No se encontró ninguna farmacia con el nombre proporcionado.");
        }

        return "buscar-farmacia";
    }

    private Farmacia buscarFarmaciaPorNombre(String nombreFarmacia) {
        for (Farmacia farmacia : pst.list()) {
            if (farmacia.getNombre().equalsIgnoreCase(nombreFarmacia)) {
                return farmacia;
            }
        }

        return null;
    }

    private List<Farmacia> buscarFarmaciasCercanas(Farmacia farmacia) {
        List<Farmacia> farmaciasCercanas = new ArrayList<>();

        for (Farmacia otraFarmacia : pst.list()) {
            if (!otraFarmacia.getNombre().equals(farmacia.getNombre()) &&
                    Math.abs(otraFarmacia.getUTM_X() - farmacia.getUTM_X()) < 1600 &&
                    Math.abs(otraFarmacia.getUTM_Y() - farmacia.getUTM_Y()) < 16000) {
                farmaciasCercanas.add(otraFarmacia);
            }
        }

        return farmaciasCercanas;
    }
}
