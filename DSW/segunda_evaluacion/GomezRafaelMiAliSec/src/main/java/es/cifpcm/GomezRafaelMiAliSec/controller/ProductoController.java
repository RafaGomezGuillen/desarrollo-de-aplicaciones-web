package es.cifpcm.GomezRafaelMiAliSec.controller;
import es.cifpcm.GomezRafaelMiAliSec.data.service.*;
import es.cifpcm.GomezRafaelMiAliSec.model.Municipio;
import es.cifpcm.GomezRafaelMiAliSec.model.Pedido;
import es.cifpcm.GomezRafaelMiAliSec.model.Productoffer;
import es.cifpcm.GomezRafaelMiAliSec.model.Provincia;

import jakarta.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Controller
@RequestMapping("/producto")
public class ProductoController {
    @Autowired
    private ProductoService productoService;
    @Autowired
    private MunicipioService municipioService;
    @Autowired
    private ProvinciaService provinciaService;
    @Autowired
    private PedidoService pedidoService;
    @Autowired
    private UserService userService;
    public static List<Productoffer> listProducts = new ArrayList<>();

    // Vista de lista de productos
    @RequestMapping("")
    public String listProducts(Model model) {
        model.addAttribute("listProvincias", provinciaService.listAll());
        model.addAttribute("message", "Elige una provincia");

        return "producto/producto";
    }

    // Total de listas de productos
    @RequestMapping("total")
    public String listTotalProducts(Model model) {
        model.addAttribute("listProducts", productoService.listAll());
        model.addAttribute("listProductsCarrito", listProducts);

        return "producto/total-productos";
    }

    // Método para manejar la selección de provincias
    @GetMapping("/municipiosByProvincia")
    public String listMunicipiosByProvincia(@RequestParam("provinciaId") int provinciaId, Model model) {
        Provincia provincia = provinciaService.get(provinciaId);
        model.addAttribute("listMunicipios", municipioService.getMunicipiosByProvincias(provincia));
        model.addAttribute("message", "Elige una un municipio de la provincia " + provincia.getNombre());

        return "producto/producto";
    }

    // Método para manejar la selección de municipios
    @GetMapping("/productsByMunicipio")
    public String listProductsByMunicipio(@RequestParam("municipioId") int municipioId, Model model) {
        Municipio municipio = municipioService.get(municipioId);
        model.addAttribute("listProducts", productoService.getProductsByMunicipio(municipioId));
        model.addAttribute("message", "Productos del municipio " + municipio.getNombre());

        return "producto/producto";
    }

    // Vista para la creacion de un producto
    @RequestMapping("/create")
    public String saveProductGet(Model model) {
        Productoffer product = new Productoffer();
        model.addAttribute("product", product);
        model.addAttribute("listMunicipios", municipioService.listAll());

        return "producto/create";
    }

    // Metodo post para la creacion de un producto
    @PostMapping("/saveProduct")
    public String saveProductPost(@Valid @ModelAttribute("product") Productoffer product,
                                  @RequestParam("img") MultipartFile img,
                                  BindingResult result) {
        if (result.hasErrors()) {
            return "producto/create";
        }

        // Establezco el nombre de la imagen
        product.setProductPicture(img.getOriginalFilename());

        try {
            productoService.save(product, img);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return "redirect:/producto/" + product.getId();
    }

    // Vista para editar el producto
    @RequestMapping("/update/{id}")
    public ModelAndView updateProductGet(@PathVariable(name = "id") int id) {
        ModelAndView model = new ModelAndView("producto/edit");

        Productoffer product = productoService.get(id);
        model.addObject("product", product);

        return model;
    }

    // Metodo post para editar el producto
    @PostMapping("/updateProduct")
    public String updateProductPost(@Valid @ModelAttribute("product") Productoffer updateProduct, BindingResult result) {
        if (result.hasErrors()) {
            return "producto/edit";
        }

        Productoffer originalProduct = productoService.get(updateProduct.getId());

        originalProduct.setProductName(updateProduct.getProductName());
        originalProduct.setProductPrice(updateProduct.getProductPrice());
        originalProduct.setIdMunicipio(updateProduct.getIdMunicipio());
        originalProduct.setProductStock(updateProduct.getProductStock());

        try {
            productoService.save(originalProduct, null);
        } catch (Exception e) {
            e.printStackTrace();
        }

        return "redirect:/producto/" + originalProduct.getId();
    }

    // Vista para detalles del producto
    @RequestMapping("/details/{id}")
    public ModelAndView detailsProduct(@PathVariable(name = "id") int id) {
        ModelAndView model = new ModelAndView("producto/details");

        Productoffer product = productoService.get(id);
        model.addObject("product", product);

        return model;
    }

    // Metodo para eliminar un producto
    @RequestMapping("/delete/{id}")
    public String deleteProduct(@PathVariable(name = "id") int id) {
        productoService.delete(id);

        return "redirect:/producto";
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

        return "producto/carrito";
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
        final String username = userService.loadUser().getUsername();

        pedido.setUsuario(username);
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

        return "redirect:/producto/pedido/" + username;
    }

    // Vista para ver el historial de pedidos de un usuario en especifico
    @RequestMapping("/pedido/{username}")
    public ModelAndView getPedidosByUsername(@PathVariable(name = "username") String username) {
        ModelAndView model = new ModelAndView("producto/pedidos-username");

        model.addObject("listPedidos", pedidoService.getPedidosByUsername(username));
        model.addObject("user", username);

        return model;
    }
}

