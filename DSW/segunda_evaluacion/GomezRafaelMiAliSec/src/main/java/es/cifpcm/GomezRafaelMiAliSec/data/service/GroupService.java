package es.cifpcm.GomezRafaelMiAliSec.data.service;

import es.cifpcm.GomezRafaelMiAliSec.data.repository.GroupRepository;
import es.cifpcm.GomezRafaelMiAliSec.model.Group;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class GroupService {
    @Autowired
    private GroupRepository groupRepository;

    public List<Group> listAll() {
        return groupRepository.findAll();
    }

    public Group get(int id) { return groupRepository.findById(id).get(); }
}
