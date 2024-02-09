package es.cifpcm.GomezRafaelMiAli.model;

import jakarta.persistence.*;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.util.List;

@Entity
@Table(name = "productoffer")
public class Productoffer {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "product_id", nullable = false)
    private Integer id;

    @Size(max = 512, min = 3, message = "El nombre debe tener al menos 3 caracteres.")
    @NotNull
    @Column(name = "product_name", nullable = false, length = 512)
    private String productName;

    @Min(value = 0, message = "El precio del producto no puede ser negativo")
    @Column(name = "product_price")
    private Float productPrice;

    @Size(max = 512)
    @Column(name = "product_picture", length = 512)
    private String productPicture;

    @NotNull
    @Column(name = "id_municipio", nullable = false)
    private Integer idMunicipio;

    @ManyToOne
    @JoinColumn(name = "id_municipio", insertable = false, updatable = false)
    private Municipio municipio;

    @NotNull
    @Min(value = 0, message = "El stock no puede ser negativo")
    @Column(name = "product_stock", nullable = false)
    private Integer productStock;

    @ManyToMany(mappedBy = "productos")
    @OnDelete(action = OnDeleteAction.CASCADE)
    private List<Pedido> pedidos;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getProductName() {
        return productName;
    }

    public void setProductName(String productName) {
        this.productName = productName;
    }

    public Float getProductPrice() {
        return productPrice;
    }

    public void setProductPrice(Float productPrice) {
        this.productPrice = productPrice;
    }

    public String getProductPicture() {
        return productPicture;
    }

    public void setProductPicture(String productPicture) {
        this.productPicture = productPicture;
    }

    public Integer getIdMunicipio() {
        return idMunicipio;
    }

    public void setIdMunicipio(Integer idMunicipio) {
        this.idMunicipio = idMunicipio;
    }

    public Integer getProductStock() {
        return productStock;
    }

    public void setProductStock(Integer productStock) {
        this.productStock = productStock;
    }

    public Municipio getMunicipio() {
        return municipio;
    }

    public void setMunicipio(Municipio municipio) {
        this.municipio = municipio;
    }

    public List<Pedido> getPedidos() {
        return pedidos;
    }

    public void setPedidos(List<Pedido> pedidos) {
        this.pedidos = pedidos;
    }

    @Override
    public String toString() {
        return "Productoffer{" +
                "id=" + id +
                ", productName='" + productName + '\'' +
                ", productPrice=" + productPrice +
                ", productPicture='" + productPicture + '\'' +
                ", idMunicipio=" + idMunicipio +
                ", municipio=" + municipio +
                ", productStock=" + productStock +
                ", pedidos=" + pedidos +
                '}';
    }
}