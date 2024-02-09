package es.cifpcm.data;
import es.cifpcm.model.Farmacia;

// Java utils
import java.util.ArrayList;
import java.util.List;

// Libreria Gson
import com.google.gson.Gson;
import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonParser;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonObject;

// Java IO
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.FileReader;

public class ImplementsPersistence implements Persistence {
    private static List<Farmacia> memStore = new ArrayList<>();
    private static final String RUTA_ARCHIVO = System.getProperty("java.io.tmpdir") + "GomezRafael_farmacias.json";
    private static Gson gson = new GsonBuilder().setPrettyPrinting().create(); // Gson en formato legible
    @Override
    public void openJson() {
        try {
            File archivo = new File(RUTA_ARCHIVO);
            // Si no existe el archivo JSON se crea
            if (!archivo.exists()) {
                if (archivo.createNewFile()) {
                    System.out.println("Archivo JSON creado.");

                    // Se crea una farmacia de ejemplo y escribirla en el archivo
                    Farmacia ejemploFarmacia = new Farmacia(
                            "www.ejemplofarmacia.com",
                            "Lunes a Domingo de 8:00 a 22:00",
                            "+34 123 456 789",
                            "Ejemplo Farmacia",
                            28.4698f,
                            -16.2549f
                    );

                    escribirJson(ejemploFarmacia);
                    return;
                } else {
                    System.out.println("No se pudo crear el archivo JSON.");
                    return;
                }
            } else {
                // Obtener el array de farmacias
                JsonParser parser = new JsonParser();
                JsonElement jsonElement = parser.parse(new FileReader(RUTA_ARCHIVO));
                JsonArray farmaciasArray = jsonElement.getAsJsonArray();

                for (JsonElement farmaciaElement : farmaciasArray) {
                    // Convertir el elemento JSON a un objeto Farmacia
                    Farmacia farmacia = gson.fromJson(farmaciaElement, Farmacia.class);
                    memStore.add(farmacia);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    public void add(Farmacia farmacia) {
        try {
            // Convertir la farmacia a un objeto JsonObject
            JsonArray farmaciasArray = gson.fromJson(new FileReader(RUTA_ARCHIVO), JsonArray.class);
            JsonObject farmaciaJson = gson.toJsonTree(farmacia).getAsJsonObject();

            // Agregar la farmacia al array
            farmaciasArray.add(farmaciaJson);

            // Escribir el array actualizado al archivo JSON
            try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
                gson.toJson(farmaciasArray, fileWriter);
                memStore.add(farmacia);
                System.out.println("\nFarmacia " + farmacia.getNombre() + " agregada al archivo JSON.");
            } catch (IOException e) {
                e.printStackTrace();
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public void delete(Farmacia farmacia) {
        try {
            JsonArray farmaciasArray = gson.fromJson(new FileReader(RUTA_ARCHIVO), JsonArray.class);

            // Buscar la farmacia en el array y eliminarla
            for (JsonElement farmaciaElement : farmaciasArray) {
                Farmacia farmaciaActual = gson.fromJson(farmaciaElement, Farmacia.class);
                if (farmaciaActual.getNombre().equals(farmacia.getNombre())) {
                    farmaciasArray.remove(farmaciaElement);
                    break;
                }
            }

            // Escribir el array actualizado al archivo JSON
            try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
                gson.toJson(farmaciasArray, fileWriter);
                memStore.remove(farmacia);
                System.out.println("Farmacia eliminada exitosamente del archivo JSON.");
            } catch (IOException e) {
                e.printStackTrace();
            }

        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public List<Farmacia> list() {
        return memStore;
    }

    // Método para escribir la lista de farmacias en el archivo JSON
    private void escribirJson(Farmacia ejemploFarmacia) {
        memStore.add(ejemploFarmacia);

        try (FileWriter fileWriter = new FileWriter(RUTA_ARCHIVO)) {
            JsonArray farmaciasArray = new JsonArray();

            for (Farmacia farmacia : memStore) {
                JsonObject farmaciaJson = gson.toJsonTree(farmacia).getAsJsonObject();
                farmaciasArray.add(farmaciaJson);
            }

            gson.toJson(farmaciasArray, fileWriter);
            System.out.println("Farmacia de ejemplo escrita en el archivo JSON.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
