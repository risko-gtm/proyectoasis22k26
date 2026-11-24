use dbsistemaembutidos;

-- 1. Tabla Directores
CREATE TABLE Directores (
    id_director INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    nacionalidad VARCHAR(50),
    fecha_nacimiento DATE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 2. Tabla Generos
CREATE TABLE Generos (
    id_genero INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 3. Tabla Peliculas (referencia a Directores y Generos)
CREATE TABLE Peliculas (
    id_pelicula INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(150) NOT NULL,
    anio_estreno INT NOT NULL,
    duracion_min INT,
    calificacion DECIMAL(3,1),
    id_director INT NOT NULL,
    id_genero INT NOT NULL,
    CONSTRAINT fk_peliculas_director
        FOREIGN KEY (id_director) REFERENCES Directores(id_director)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_peliculas_genero
        FOREIGN KEY (id_genero) REFERENCES Generos(id_genero)
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 4. Tabla Actores
CREATE TABLE Actores (
    id_actor INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE,
    pais_origen VARCHAR(50)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- 5. Tabla Elenco (tabla intermedia N:M entre Peliculas y Actores)
CREATE TABLE Elenco (
    id_elenco INT AUTO_INCREMENT PRIMARY KEY,
    id_pelicula INT NOT NULL,
    id_actor INT NOT NULL,
    personaje VARCHAR(100) NOT NULL,
    es_protagonista BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_elenco_pelicula
        FOREIGN KEY (id_pelicula) REFERENCES Peliculas(id_pelicula)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_elenco_actor
        FOREIGN KEY (id_actor) REFERENCES Actores(id_actor)
        ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT uq_elenco_pelicula_actor_personaje
        UNIQUE (id_pelicula, id_actor, personaje)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;