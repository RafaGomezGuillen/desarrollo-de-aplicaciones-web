package es.cifpcm.GomezRafaelMiAli.data.service;
import es.cifpcm.GomezRafaelMiAli.data.repository.PedidoRepository;
import es.cifpcm.GomezRafaelMiAli.model.Pedido;

import jakarta.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.validation.annotation.Validated;

import java.util.List;

@Service
public class PedidoService {
    @Autowired
    private PedidoRepository pedidoRepository;

    public List<Pedido> listAll() {
        return pedidoRepository.findAll();
    }

    public void save (Pedido pedido) { pedidoRepository.save(pedido);}

    public void delete(int id) {
        pedidoRepository.deleteById(id);
    }
}
