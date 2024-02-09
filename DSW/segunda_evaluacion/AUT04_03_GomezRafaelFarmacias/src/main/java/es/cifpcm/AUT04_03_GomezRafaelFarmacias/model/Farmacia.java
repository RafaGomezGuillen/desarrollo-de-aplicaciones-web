package es.cifpcm.AUT04_03_GomezRafaelFarmacias.model;

public class Farmacia {
    // Campos
    private String web;
    private String horario;
    private String telefono;
    private String nombre;
    private float UTM_X;
    private float UTM_Y;

    // Constructorers
    public Farmacia() {}
    public Farmacia(String web, String horario, String telefono, String nombre, float UTM_X, float UTM_Y) {
        super();
        setWeb(web);
        setHorario(horario);
        setTelefono(telefono);
        setNombre(nombre);
        setUTM_X(UTM_X);
        setUTM_Y(UTM_Y);
    }

    // Getters
    public String getWeb() {
        return web;
    }
    public String getHorario() {
        return horario;
    }
    public String getTelefono() {
        return telefono;
    }
    public String getNombre() {
        return nombre;
    }
    public float getUTM_X() {
        return UTM_X;
    }
    public float getUTM_Y() {
        return UTM_Y;
    }

    // Setters
    public void setWeb(String web) {
        this.web = web;
    }
    public void setHorario(String horario) {
        this.horario = horario;
    }
    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    public void setUTM_X(float UTM_X) {
        this.UTM_X = UTM_X;
    }
    public void setUTM_Y(float UTM_Y) {
        this.UTM_Y = UTM_Y;
    }
}
