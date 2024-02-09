package es.cifpcm.GomezBarrosoFarm.controllers;

import com.google.gson.*;
import es.cifpcm.GomezBarrosoFarm.models.Farmacia;
import jakarta.annotation.PostConstruct;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Controller
@RequestMapping("/farmacias")
public class FarmaciaController {

    private List<Farmacia> listaFarmacias = new ArrayList<>();
    int id = 1;
    private static final String RUTA_ARCHIVO = System.getProperty("java.io.tmpdir") + "/farmacias_web.json";

    private static Gson gson = new GsonBuilder().setPrettyPrinting().create(); // Gson en formato legible
    @PostConstruct
    public void init() {
        File file = new File(RUTA_ARCHIVO);
        if (file.exists()) {
            try {
                // Obtener el array de farmacias
                JsonParser parser = new JsonParser();
                JsonElement jsonElement = parser.parse(new FileReader(RUTA_ARCHIVO));
                JsonArray farmaciasArray = jsonElement.getAsJsonArray();

                for (JsonElement farmaciaElement : farmaciasArray) {
                    // Convertir el elemento JSON a un objeto Farmacia
                    Farmacia farmacia = gson.fromJson(farmaciaElement, Farmacia.class);
                    farmacia.setId(id++);
                    listaFarmacias.add(farmacia);
                }

            } catch (IOException e) {
                e.printStackTrace();
            }
        } else {
            try {
                if (file.createNewFile()) {
                    escribirJson();
                    return;
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private void escribirJson() {
        listaFarmacias.add(new Farmacia(1, "Farmacia 1", "Dirección 1", "WebFarmacia1.com", "07:00 - 14:00", "123456789", 33.1f, 33.1f));
        listaFarmacias.add(new Farmacia(2, "Farmacia 2", "Dirección 2", "WebFarmacia2.com", "08:00 - 00:00", "987654321", 33.2f, 33.2f));
        listaFarmacias.add(new Farmacia(3, "Farmacia 3", "Dirección 3", "WebFarmacia3.com", "07:00 - 15:00", "129876789", 2000.5f, 10000.10f));
        listaFarmacias.add(new Farmacia(4, "Farmacia 4", "Dirección 4", "WebFarmacia4.com", "08:00 - 20:00", "987611311", 2500.5f, 11000.10f));

        // Se genera un nuevo JSON llamado "temp_farmaciasweb.json"
        try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
            JsonArray farmaciasArray = new JsonArray();

            for (Farmacia farmacia : listaFarmacias) {
                JsonObject farmaciaJson = gson.toJsonTree(farmacia).getAsJsonObject();
                farmaciasArray.add(farmaciaJson);
            }

            gson.toJson(farmaciasArray, fileWriter);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @GetMapping("/listar")
    public String listarFarmacias(Model model) {
        model.addAttribute("farmacias", listaFarmacias);
        model.addAttribute("farmaciasTotal", listaFarmacias.size());
        return "listarFarmacias";
    }

    @GetMapping("/form")
    public String mostrarFormulario() {
        return "añadirFarmacias";
    }

    @GetMapping("/eliminar/{nombre}")
    public String eliminarFarmacia(@PathVariable String nombre) {
        try {
            JsonArray farmaciasArray = gson.fromJson(new FileReader(RUTA_ARCHIVO), JsonArray.class);

            // Buscar la farmacia en el array y eliminarla
            for (JsonElement farmaciaElement : farmaciasArray) {
                Farmacia farmaciaActual = gson.fromJson(farmaciaElement, Farmacia.class);
                if (farmaciaActual.getNombre().equals(nombre)) {
                    farmaciasArray.remove(farmaciaElement);
                    break;
                }
            }

            // Escribir el array actualizado al archivo JSON
            try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
                gson.toJson(farmaciasArray, fileWriter);
                listaFarmacias.removeIf(f -> f.getNombre().equals(nombre));
            } catch (IOException e) {
                e.printStackTrace();
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
        return "redirect:/farmacias/listar";
    }

    @PostMapping("/listarFarmaciasCercanas")
    public String listarFarmaciasCercanas(@RequestParam String nombreFarmacia, Model model) {


        if (nombreFarmacia != null) {
            List<Farmacia> resultados = listaFarmacias.stream()
                    .filter(f -> f.getNombre().equalsIgnoreCase(nombreFarmacia))
                    .collect(Collectors.toList());
            List<Farmacia> farmaciasCercanas = new ArrayList<>();
            if (resultados.size() == 1) {
                Farmacia farmaciaUnica = resultados.get(0);
                float coordenadaX = farmaciaUnica.getX();
                float coordenadaY = farmaciaUnica.getY();
                farmaciasCercanas = listaFarmacias.stream()
                        .filter(f -> Math.abs(f.getX() - coordenadaX) < 1600 && Math.abs(f.getY() - coordenadaY) < 16000)
                        .collect(Collectors.toList());
            }

            if (!farmaciasCercanas.isEmpty()) {
                model.addAttribute("farmacias", farmaciasCercanas);
                model.addAttribute("farmaciasTotal", farmaciasCercanas.size());
            } else {
                model.addAttribute("mensaje", "No hay farmacias cercanas a " + nombreFarmacia + ".");
            }

        } else {
            model.addAttribute("mensaje", "No se encontró ninguna farmacia con el nombre proporcionado.");
        }

        return "listarFarmacias";
    }

    @PostMapping("/agregar")
    public String agregarFarmacia(@ModelAttribute Farmacia farmacia) {
        try {
            // Convertir la farmacia a un objeto JsonObject
            JsonArray farmaciasArray = gson.fromJson(new FileReader(RUTA_ARCHIVO), JsonArray.class);
            JsonObject farmaciaJson = gson.toJsonTree(farmacia).getAsJsonObject();

            // Agregar la farmacia al array
            farmaciasArray.add(farmaciaJson);

            // Escribir el array actualizado al archivo JSON
            try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
                gson.toJson(farmaciasArray, fileWriter);
                farmacia.setId(id++);
                listaFarmacias.add(farmacia);
            } catch (IOException e) {
                e.printStackTrace();
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
        // Redirigir a la página de listado de farmacias después de agregar
        return "redirect:/farmacias/listar";
    }
}