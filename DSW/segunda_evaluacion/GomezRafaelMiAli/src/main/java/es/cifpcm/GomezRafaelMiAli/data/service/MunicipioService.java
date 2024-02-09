package es.cifpcm.GomezRafaelMiAli.data.service;
import es.cifpcm.GomezRafaelMiAli.data.repository.MunicipioRepository;
import es.cifpcm.GomezRafaelMiAli.model.Municipio;

import es.cifpcm.GomezRafaelMiAli.model.Productoffer;
import es.cifpcm.GomezRafaelMiAli.model.Provincia;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class MunicipioService {
    @Autowired
    private MunicipioRepository municipioRepository;

    public List<Municipio> listAll() {
        return municipioRepository.findAll();
    }

    public Municipio get(int id) {
        return municipioRepository.findById(id).get();
    }

    public List<Municipio> getMunicipiosByProvincias(Provincia provincia) {
        return listAll()
                .stream()
                .filter(municipio -> municipio.getIdProvincia().equals(provincia))
                .collect(Collectors.toList());
    }
}
