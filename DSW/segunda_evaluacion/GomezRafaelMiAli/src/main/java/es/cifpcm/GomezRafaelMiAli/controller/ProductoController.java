package es.cifpcm.GomezRafaelMiAli.controller;
import es.cifpcm.GomezRafaelMiAli.data.service.MunicipioService;
import es.cifpcm.GomezRafaelMiAli.data.service.PedidoService;
import es.cifpcm.GomezRafaelMiAli.data.service.ProductoService;
import es.cifpcm.GomezRafaelMiAli.data.service.ProvinciaService;
import es.cifpcm.GomezRafaelMiAli.model.Municipio;
import es.cifpcm.GomezRafaelMiAli.model.Productoffer;

import es.cifpcm.GomezRafaelMiAli.model.Provincia;
import jakarta.validation.Valid;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;

import org.springframework.web.bind.annotation.*;

import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;

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
        model.addAttribute("listProductsCarrito", PedidoController.listProducts);

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
    @RequestMapping("/{id}")
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
}

