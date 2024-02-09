package es.cifpcm.GomezRafaelMiAli.model;

import es.cifpcm.GomezRafaelMiAli.model.Productoffer;
import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.LocalDate;
import java.util.List;

@Entity
@Table(name = "pedidos")
public class Pedido {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 30, min = 3, message = "Usuario entre 30 y 3 caracteres")
    @NotNull
    @Column(name = "usuario", nullable = false, length = 30)
    private String usuario;

    @ManyToMany
    @JoinTable(
            name = "pedido_productos",
            joinColumns = @JoinColumn(name = "pedido_id"),
            inverseJoinColumns = @JoinColumn(name = "productoffer_id")
    )
    private List<Productoffer> productos;

    @NotNull
    @Column(name = "precio_total", nullable = false)
    private Float precioTotal;

    @NotNull
    @Column(name = "fecha", nullable = false)
    private LocalDate fecha;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public Float getPrecioTotal() {
        return precioTotal;
    }

    public void setPrecioTotal(Float precioTotal) {
        this.precioTotal = precioTotal;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
        this.fecha = fecha;
    }

    public List<Productoffer> getProductos() {
        return productos;
    }

    public void setProductos(List<Productoffer> productos) {
        this.productos = productos;
    }
}