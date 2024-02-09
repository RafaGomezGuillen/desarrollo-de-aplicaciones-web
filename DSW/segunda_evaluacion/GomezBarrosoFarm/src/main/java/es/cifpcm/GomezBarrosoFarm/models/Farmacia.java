package es.cifpcm.GomezBarrosoFarm.models;

import com.google.gson.annotations.SerializedName;

public class Farmacia implements  farmaciaClase{
    private int id;

    @SerializedName("NOMBRE")
    private String nombre;

    @SerializedName("DIRECCION")
    private String direccion;

    @SerializedName("WEB")
    private String web;

    @SerializedName("LUNES")
    private String lunes;

    @SerializedName("TELEFONO")
    private String telefono;

    @SerializedName("UTM_X")
    private float X;

    @SerializedName("UTM_Y")
    private float Y;

    public Farmacia() {
    }

    public Farmacia(int id, String nombre, String direccion, String web, String lunes, String telefono, float X, float Y) {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.web = web;
        this.lunes = lunes;
        this.telefono = telefono;
        this.X = X;
        this.Y = Y;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getWeb() {
        return web;
    }

    public void setWeb(String web) {
        this.web = web;
    }

    public String getLunes() {
        return lunes;
    }

    public void setLunes(String lunes) {
        this.lunes = lunes;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public float getX() {
        return X;
    }

    public void setX(float x) {
        X = x;
    }

    public float getY() {
        return Y;
    }

    public void setY(float y) {
        Y = y;
    }
}
