package es.cifpcm.GomezRafaelMiAli.controller;
import es.cifpcm.GomezRafaelMiAli.data.service.PedidoService;
import es.cifpcm.GomezRafaelMiAli.data.service.ProductoService;
import es.cifpcm.GomezRafaelMiAli.model.Pedido;
import es.cifpcm.GomezRafaelMiAli.model.Productoffer;

import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Controller
@RequestMapping("/pedido")
public class PedidoController {
    @Autowired
    private PedidoService pedidoService;
    @Autowired
    private ProductoService productoService;
    public static List<Productoffer> listProducts = new ArrayList<>();

    // Vista de lista de pedidos
    @RequestMapping("")
    public String listPedidos(Model model) {
        List<Pedido> listPedidos = pedidoService.listAll();
        model.addAttribute("listPedidos", listPedidos);

        return "pedido/pedido";
    }

    // Vista de carrito
    @RequestMapping("/carrito")
    public String carrito(Model model) {
        Pedido pedido = new Pedido();
        model.addAttribute("listProducts", listProducts);
        model.addAttribute("pedido", pedido);
        // Sumar el precio de todos los productos en listProducts
        float precioTotal = 0.0f;
        for (Productoffer product : listProducts) {
            if (product.getProductPrice() != null) {
                precioTotal += product.getProductPrice();
            }
        }

        model.addAttribute("precioTotal", precioTotal);

        return "pedido/carrito";
    }

    // Añadir producto al carrito
    @PostMapping("/addToCart")
    public String addToCart(@RequestParam("id") int id) {
        Productoffer product = productoService.get(id);
        listProducts.add(product);
        return "redirect:/producto/total";
    }

    // Eliminar producto del carrito
    @PostMapping("/deleteFromCart")
    public String deleteProductFromCarrito(@RequestParam("index") int index) {
        listProducts.remove(index);
        return "redirect:/producto/total";
    }

    // Metodo POST para realizar un pedido
    @PostMapping("/savePedido")
    public String carritoPost(@ModelAttribute("pedido") Pedido pedido) {
        pedido.setUsuario("Rafa");
        pedido.setFecha(LocalDate.now());
        pedido.setProductos(listProducts);

        // Sumar el precio de todos los productos en listProducts
        float precioTotal = 0.0f;
        for (Productoffer product : listProducts) {
            if (product.getProductPrice() != null) {
                precioTotal += product.getProductPrice();
            }

            // Disminuir el stock de los productos en uno
            product.setProductStock(product.getProductStock() - 1);

            try {
                productoService.save(product, null);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }

        pedido.setPrecioTotal(precioTotal);

        // Guardar el pedido
        pedidoService.save(pedido);

        // Limpiar la lista de productos después de guardar el pedido
        listProducts.clear();

        return "redirect:/pedido";
    }
}
