class Personaje {
  constructor(
    name,
    vida_max,
    ataque,
    defensa,
    distancia_min,
    distancia_max,
    velocidad,
    raza,
    equipamiento,
    fecha_nac,
    fecha_deseo
  ) {
    this.name = name;
    this.nivel_experiencia = 0;
    this.vida = 100;
    this.vida_max = vida_max;
    this.ataque = ataque;
    this.defensa = defensa;
    this.distancia_min = distancia_min;
    this.distancia_max = distancia_max;
    this.velocidad = velocidad;
    this.raza = raza;
    this.equipamiento = equipamiento;
    this.fecha_nac = fecha_nac;
    this.fecha_deseo = fecha_deseo;
  }

  setNivelExp(exp) {
    if (exp > 0 && exp <= 100) {
      this.nivel_experiencia = exp;
    } else {
      console.error("El nivel de experiencia es entre 0 y 100.");
      this.nivel_experiencia = 0;
    }
  }

  setVida(vida) {
    this.vida = vida;
  }

  setRaza(raza) {
    if (razaArray.includes(raza)) {
      this.raza = raza;
    } else {
      console.error("Solo exiten tres razas: Pyxis, Musca, Lyris");
      this.raza = "Pyxis";
    }
  }

  mostrarPersonaje() {
    const caracteristicas = `
      Nombre: ${this.name}
      Experiencia: ${this.nivel_experiencia}
      Vida: ${this.vida}%
      Vida Máxima: ${this.vida_max}
      Ataque: ${this.ataque}
      Defensa: ${this.defensa}
      Distancia Mínima: ${this.distancia_min}
      Distancia Máxima: ${this.distancia_max}
      Velocidad: ${this.velocidad}
      Raza: ${this.raza}
      Equipamiento: ${this.equipamiento.join(", ")}
      Fecha de Nacimiento: ${this.fecha_nac}
      Fecha de Muerte: ${this.fecha_deseo || "No ha muerto"}
    `;

    return caracteristicas;
  }
}

class Mago extends Personaje {
  constructor(
    name,
    vida_max = 80,
    ataque = 20,
    defensa = 10,
    distancia_min = 0,
    distancia_max = 10,
    velocidad = 5,
    raza,
    equipamiento,
    fecha_nac,
    fecha_deseo
  ) {
    super(
      name,
      vida_max,
      ataque,
      defensa,
      distancia_min,
      distancia_max,
      velocidad,
      raza,
      equipamiento,
      fecha_nac,
      fecha_deseo
    );
  }
}

class Guerrero extends Personaje {
  constructor(
    name,
    vida_max = 100,
    ataque = 30,
    defensa = 20,
    distancia_min = 0,
    distancia_max = 5,
    velocidad = 10,
    raza,
    equipamiento,
    fecha_nac,
    fecha_deseo
  ) {
    super(
      name,
      vida_max,
      ataque,
      defensa,
      distancia_min,
      distancia_max,
      velocidad,
      raza,
      equipamiento,
      fecha_nac,
      fecha_deseo
    );
  }
}

class Arquero extends Personaje {
  constructor(
    name,
    vida_max = 80,
    ataque = 10,
    defensa = 10,
    distancia_min = 5,
    distancia_max = 20,
    velocidad = 5,
    raza,
    equipamiento,
    fecha_nac,
    fecha_deseo
  ) {
    super(
      name,
      vida_max,
      ataque,
      defensa,
      distancia_min,
      distancia_max,
      velocidad,
      raza,
      equipamiento,
      fecha_nac,
      fecha_deseo
    );
  }
}

const razaArray = ["Pyxis", "Musca", "Lyris"];

let merlin = new Mago(
  "Merlin el mago",
  70,
  11,
  5,
  5,
  8,
  3,
  razaArray[0],
  ["Pociones", "Varita mágica"],
  new Date("1950-08-09"),
  new Date("2028-03-25")
);

merlin.setNivelExp(55);
merlin.setVida(12);
merlin.setRaza(razaArray[0]);

console.log(merlin.mostrarPersonaje());

let rufus = new Guerrero(
  "Rufus el Guerrero",
  89,
  44,
  20,
  0,
  4,
  10,
  razaArray[0],
  ["Espada", "Escudo"],
  new Date("1992-01-01"),
  new Date("2025-04-21")
);

rufus.setNivelExp(55);
rufus.setVida(12);
rufus.setRaza(razaArray[0]);

console.log(rufus.mostrarPersonaje());

let antares = new Arquero(
  "Antares la arquera",
  70,
  10,
  10,
  11,
  19,
  5,
  razaArray[0],
  ["Flechas", "Arco"],
  new Date("2001-05-12"),
  new Date("2056-01-10")
);

// Error en vida a proposito
antares.setNivelExp(-5);
antares.setVida(12);
antares.setRaza(razaArray[0]);

console.log(antares.mostrarPersonaje());
