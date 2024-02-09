package es.cifpcm.GaleriaImagenesGomez.model;

public class Imagen {
    private String nombreUrl;

    // Constructorers
    public Imagen() {}
    public Imagen(String nombreUrl) {
        super();
        setNombreUrl(nombreUrl);
    }

    // Getters
    public String getNombreUrl() {
        return nombreUrl;
    }

    // Setter
    public void setNombreUrl(String nombreUrl) {
        this.nombreUrl = nombreUrl;
    }
}
