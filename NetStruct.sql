USE master;
DROP DATABASE IF EXISTS NetStruct;
GO;

CREATE DATABASE NetStruct;
GO;
USE NetStruct;
GO;

CREATE TABLE Continente (
    idContinente INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Paises (
    idPais INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    idContinente INT NOT NULL,
    FOREIGN KEY (idContinente) REFERENCES Continente(idContinente)
);

CREATE TABLE Ciudades (
    idCiudad INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    idPais INT NOT NULL,
    FOREIGN KEY (idPais) REFERENCES Paises(idPais)
);

CREATE TABLE Infraestructura (
    idInfraestructura INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    Reseña VARCHAR(MAX),
    Horario VARCHAR(100),
    TelefonoContacto VARCHAR(20),
    EmailContacto VARCHAR(100),
    MiniaturaWeb VARCHAR(MAX),
    Valoracion DECIMAL(3, 2),
    idCiudad INT NOT NULL,
    FOREIGN KEY (idCiudad) REFERENCES Ciudades(idCiudad)
);

CREATE TABLE CategoriaTipo (
    idCategoria INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Clasifica (
    idInfraestructura INT NOT NULL,
    idCategoria INT NOT NULL,
    PRIMARY KEY (idInfraestructura, idCategoria),
    FOREIGN KEY (idInfraestructura) REFERENCES Infraestructura(idInfraestructura),
    FOREIGN KEY (idCategoria) REFERENCES CategoriaTipo(idCategoria)
);

CREATE TABLE GaleriaDeImagenes (
    idImagen INT PRIMARY KEY,
    Imagen VARCHAR(MAX) NOT NULL,
    idInfraestructura INT NOT NULL,
    FOREIGN KEY (idInfraestructura) REFERENCES Infraestructura(idInfraestructura)
);

-- Tabla Continente
INSERT INTO Continente (idContinente, Nombre) VALUES
    (1, 'Europa'),
    (2, 'Asia'),
    (3, 'África'),
    (4, 'América del Norte'),
    (5, 'América del Sur'),
    (6, 'Oceanía'),
    (7, 'Antártida');

-- Tabla Paises
INSERT INTO Paises (idPais, Nombre, idContinente) VALUES
    (1, 'España', 1),
    (2, 'Francia', 1),
    (3, 'Japón', 2),
    (4, 'Egipto', 3),
    (5, 'Estados Unidos', 4),
    (6, 'Brasil', 5),
    (7, 'Australia', 6);

-- Tabla Ciudades
INSERT INTO Ciudades (idCiudad, Nombre, idPais) VALUES
    (1, 'Madrid', 1),
    (2, 'Barcelona', 1),
    (3, 'París', 2),
    (4, 'Tokio', 3),
    (5, 'El Cairo', 4),
    (6, 'Nueva York', 5),
    (7, 'Río de Janeiro', 6),
    (8, 'Sídney', 7);

-- Tabla Infraestructura
INSERT INTO Infraestructura (idInfraestructura, Nombre, Direccion, Reseña, Horario, TelefonoContacto, EmailContacto, MiniaturaWeb, Valoracion, idCiudad) VALUES
    (1, 'Museo del Prado', 'Calle de Ruiz de Alarcón 23', 'Uno de los museos de arte más importantes del mundo.', 'Lunes a sábado: 10:00-20:00; Domingo: 10:00-19:00', '+34 913 30 28 00', 'informacion@museodelprado.es', NULL, 4.8, 1),
    (2, 'Sagrada Familia', 'Carrer de Mallorca 401', 'Basílica diseñada por Antoni Gaudí, aún en construcción.', 'Lunes a domingo: 9:00-18:00', '+34 932 08 04 14', 'informacion@sagradafamilia.org', NULL, 4.7, 2),
    (3, 'Torre Eiffel', 'Champ de Mars, 5 Avenue Anatole France', 'El ícono de París, construido en 1889.', 'Lunes a domingo: 9:30-22:45', '+33 892 70 12 39', 'contact@toureiffel.paris', NULL, 4.7, 3),
    (4, 'Templo Sens?-ji', '2-3-1 Asakusa, Taito City', 'El templo más antiguo de Tokio.', 'Lunes a domingo: 6:00-17:00', '+81 3-3842-0181', NULL,NULL,4.8, 4),
    (5, 'Pirámides de Guiza', 'Al Haram, Nazlet El-Semman, Guiza', 'La maravilla del mundo antiguo mejor conservada.', 'Lunes a domingo: 7:00-17:00', '+20 2 3377 6633', NULL, NULL,4.9, 5),
    (6, 'Estatua de la Libertad', 'Liberty Island', 'Regalo de Francia, símbolo de la libertad.', 'Lunes a domingo: 9:00-16:00', '+1 212-363-3200', 'info@libertyellisfoundation.org', NULL, 4.7, 6),
    (7, 'Cristo Redentor', 'Parque Nacional da Tijuca', 'Estatua de 38 metros en el cerro del Corcovado.', 'Lunes a domingo: 8:00-19:00', '+55 21 2551-2026', NULL, NULL, 4.8, 7),
    (8, 'Ópera de Sídney', 'Bennelong Point', 'Uno de los edificios más icónicos del siglo XX.', 'Lunes a domingo: 9:00-17:00', '+61 2 9250 7111', 'info@sydneyoperahouse.com', NULL, 4.7, 8);

-- Tabla CategoriaTipo
INSERT INTO CategoriaTipo (idCategoria, Nombre) VALUES
    (1, 'Museo'),
    (2, 'Monumento'),
    (3, 'Templo'),
    (4, 'Edificio Histórico'),
    (5, 'Maravilla del Mundo');

-- Tabla Clasifica
INSERT INTO Clasifica (idInfraestructura, idCategoria) VALUES
    (1, 1), -- Museo del Prado - Museo
    (2, 2), -- Sagrada Familia - Monumento
    (3, 2), -- Torre Eiffel - Monumento
    (4, 3), -- Templo Sens?-ji - Templo
    (5, 5), -- Pirámides de Guiza - Maravilla del Mundo
    (6, 2), -- Estatua de la Libertad - Monumento
    (7, 5), -- Cristo Redentor - Maravilla del Mundo
    (8, 4); -- Ópera de Sídney - Edificio Histórico

-- Tabla GaleriaDeImagenes
INSERT INTO GaleriaDeImagenes (idImagen, Imagen, idInfraestructura) VALUES
    (1, NULL, 1),
    (2, NULL, 2),
    (3, NULL, 3),
    (4, NULL, 4),
    (5, NULL, 5),
    (6, NULL, 6),
    (7, NULL, 7),
    (8, NULL, 8);
