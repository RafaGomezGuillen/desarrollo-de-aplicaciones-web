package es.cifpcm.GomezRafaelMiAliSec.data.service;

import es.cifpcm.GomezRafaelMiAliSec.data.repository.PedidoRepository;
import es.cifpcm.GomezRafaelMiAliSec.model.Pedido;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class PedidoService {
    @Autowired
    private PedidoRepository pedidoRepository;

    public List<Pedido> listAll() {
        return pedidoRepository.findAll();
    }

    public void save (Pedido pedido) { pedidoRepository.save(pedido); }

    public void delete(int id) {
        pedidoRepository.deleteById(id);
    }

    public List<Pedido> getPedidosByUsername(String username) {
        return listAll()
                .stream()
                .filter(pedido -> pedido.getUsuario().equals(username))
                .collect(Collectors.toList());
    }
}
