package es.cifpcm.GomezRafaelMiAliSec.data.service;

import es.cifpcm.GomezRafaelMiAliSec.data.repository.ProvinciaRepository;
import es.cifpcm.GomezRafaelMiAliSec.model.Provincia;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProvinciaService {
    @Autowired
    private ProvinciaRepository provinciaRepository;

    public List<Provincia> listAll() {
        return provinciaRepository.findAll();
    }

    public Provincia get(int id) {
        return provinciaRepository.findById(id).get();
    }
}
