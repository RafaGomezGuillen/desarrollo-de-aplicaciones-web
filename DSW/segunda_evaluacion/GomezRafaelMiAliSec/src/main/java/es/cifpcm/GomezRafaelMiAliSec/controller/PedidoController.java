package es.cifpcm.GomezRafaelMiAliSec.controller;
import es.cifpcm.GomezRafaelMiAliSec.data.service.PedidoService;
import es.cifpcm.GomezRafaelMiAliSec.model.Pedido;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import java.util.List;

@Controller
@RequestMapping("/pedido")
public class PedidoController {
    @Autowired
    private PedidoService pedidoService;

    // Vista de lista de pedidos
    @RequestMapping("")
    public String listPedidos(Model model) {
        List<Pedido> listPedidos = pedidoService.listAll();
        model.addAttribute("listPedidos", listPedidos);

        return "pedido/pedido";
    }
}
