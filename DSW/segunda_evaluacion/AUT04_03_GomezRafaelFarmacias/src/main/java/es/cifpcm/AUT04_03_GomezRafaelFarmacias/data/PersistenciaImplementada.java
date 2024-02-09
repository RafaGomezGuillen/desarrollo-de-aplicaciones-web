package es.cifpcm.AUT04_03_GomezRafaelFarmacias.data;
import es.cifpcm.AUT04_03_GomezRafaelFarmacias.model.Farmacia;

import com.google.gson.*;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class PersistenciaImplementada implements Persistencia {
    private static List<Farmacia> gomez_farm = new ArrayList<>(); // Contexto
    private static final String RUTA_ARCHIVO = System.getProperty("java.io.tmpdir") + "/farmacias_web.json";
    private static Gson gson = new GsonBuilder().setPrettyPrinting().create(); // Gson en formato legible

    @Override
    public void openJson() {
        try {
            File archivo = new File(RUTA_ARCHIVO);
            // Si no existe el archivo JSON se crea
            if (!archivo.exists()) {
                try {
                    if (archivo.createNewFile()) {
                        escribirJson();
                        return;
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            } else {
                // Obtener el array de farmacias
                JsonParser parser = new JsonParser();
                JsonElement jsonElement = parser.parse(new FileReader(RUTA_ARCHIVO));
                JsonArray farmaciasArray = jsonElement.getAsJsonArray();

                for (JsonElement farmaciaElement : farmaciasArray) {
                    // Convertir el elemento JSON a un objeto Farmacia
                    Farmacia farmacia = gson.fromJson(farmaciaElement, Farmacia.class);
                    gomez_farm.add(farmacia);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public List<Farmacia> list() {
        return gomez_farm;
    }

    // Método para escribir la lista de farmacias en el archivo JSON
    private void escribirJson() {
        gomez_farm.addAll(generarFarmacias());

        // Se genera un nuevo JSON llamado "temp_farmaciasweb.json"
        try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
            JsonArray farmaciasArray = new JsonArray();

            for (Farmacia farmacia : gomez_farm) {
                JsonObject farmaciaJson = gson.toJsonTree(farmacia).getAsJsonObject();
                farmaciasArray.add(farmaciaJson);
            }

            gson.toJson(farmaciasArray, fileWriter);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    // Generar farmacias si no encuentra el JSON
    private List<Farmacia> generarFarmacias() {
        List<Farmacia> farmacias = new ArrayList<>();

        farmacias.add(new Farmacia("www.farmacia1.com", "Lunes a Viernes de 9:00 a 20:00", "+34 928 111 111", "Farmacia 1", 1000, 5000));
        farmacias.add(new Farmacia("www.farmacia2.com", "Lunes a Sábado de 8:00 a 22:00", "+34 928 222 222", "Farmacia 2", 2000, 10000));
        farmacias.add(new Farmacia("www.farmacia3.com", "Abierto 24 horas", "+34 928 333 333", "Farmacia 3", 3000, 15000));
        farmacias.add(new Farmacia("www.farmacia4.com", "Lunes a Viernes de 8:00 a 19:00", "+34 928 444 444", "Farmacia 4", 4000, 20000));
        farmacias.add(new Farmacia("www.farmacia5.com", "Lunes a Domingo de 10:00 a 18:00", "+34 928 555 555", "Farmacia 5", 5000, 25000));

        return farmacias;
    }
}
