package es.cifpcm.GomezRafaelMiAli.data.repository;
import es.cifpcm.GomezRafaelMiAli.model.Pedido;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

public interface PedidoRepository extends JpaRepository<Pedido, Integer>, JpaSpecificationExecutor<Pedido> {
}
