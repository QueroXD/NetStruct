USE master;
DROP DATABASE IF EXISTS NetStruct;
GO;

CREATE DATABASE NetStruct;
GO;
USE NetStruct;
GO;

CREATE TABLE Continente (
    idContinente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Paises (
    idPais INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    idContinente INT NOT NULL,
    FOREIGN KEY (idContinente) REFERENCES Continente(idContinente)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Ciudades (
    idCiudad INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    idPais INT NOT NULL,
    FOREIGN KEY (idPais) REFERENCES Paises(idPais)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE Infraestructura (
    idInfraestructura INT PRIMARY KEY IDENTITY(1,1),
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
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE CategoriaTipo (
    idCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);

CREATE TABLE Clasifica (
    idInfraestructura INT NOT NULL,
    idCategoria INT NOT NULL,
    PRIMARY KEY (idInfraestructura, idCategoria),
    FOREIGN KEY (idInfraestructura) REFERENCES Infraestructura(idInfraestructura)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (idCategoria) REFERENCES CategoriaTipo(idCategoria)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE GaleriaDeImagenes (
    idImagen INT PRIMARY KEY IDENTITY(1,1),
    Imagen VARCHAR(MAX) NOT NULL,
    idInfraestructura INT NOT NULL,
    FOREIGN KEY (idInfraestructura) REFERENCES Infraestructura(idInfraestructura)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


-- Tabla Continente
INSERT INTO Continente (Nombre) VALUES
    ('Europa'),
    ('Asia'),
    ('África'),
    ('América del Norte'),
    ('América del Sur'),
    ('Oceanía'),
    ('Antártida');

-- Tabla Paises
INSERT INTO Paises (Nombre, idContinente) VALUES
    ('España', 1),
    ('Francia', 1),
    ('Japón', 2),
    ('Egipto', 3),
    ('Estados Unidos', 4),
    ('Brasil', 5),
    ('Australia', 6);

-- Tabla Ciudades
INSERT INTO Ciudades (Nombre, idPais) VALUES
    ('Madrid', 1),
    ('Barcelona', 1),
    ('París', 2),
    ('Tokio', 3),
    ('El Cairo', 4),
    ('Nueva York', 5),
    ('Río de Janeiro', 6),
    ('Sídney', 7);

-- Tabla Infraestructura
INSERT INTO Infraestructura (Nombre, Direccion, Reseña, Horario, TelefonoContacto, EmailContacto, MiniaturaWeb, Valoracion, idCiudad) VALUES
    ('Museo del Prado', 'Calle de Ruiz de Alarcón 23', 'Uno de los museos de arte más importantes del mundo.', 'Lunes a sábado: 10:00-20:00; Domingo: 10:00-19:00', '+34 913 30 28 00', 'informacion@museodelprado.es', NULL, 4.8, 1),
    ('Sagrada Familia', 'Carrer de Mallorca 401', 'Basílica diseñada por Antoni Gaudí, aún en construcción.', 'Lunes a domingo: 9:00-18:00', '+34 932 08 04 14', 'informacion@sagradafamilia.org', NULL, 4.7, 2),
    ('Torre Eiffel', 'Champ de Mars, 5 Avenue Anatole France', 'El ícono de París, construido en 1889.', 'Lunes a domingo: 9:30-22:45', '+33 892 70 12 39', 'contact@toureiffel.paris', NULL, 4.7, 3),
    ('Templo Sens?-ji', '2-3-1 Asakusa, Taito City', 'El templo más antiguo de Tokio.', 'Lunes a domingo: 6:00-17:00', '+81 3-3842-0181', NULL,NULL,4.8, 4),
    ('Pirámides de Guiza', 'Al Haram, Nazlet El-Semman, Guiza', 'La maravilla del mundo antiguo mejor conservada.', 'Lunes a domingo: 7:00-17:00', '+20 2 3377 6633', NULL, NULL,4.9, 5),
    ('Estatua de la Libertad', 'Liberty Island', 'Regalo de Francia, símbolo de la libertad.', 'Lunes a domingo: 9:00-16:00', '+1 212-363-3200', 'info@libertyellisfoundation.org', NULL, 4.7, 6),
    ('Cristo Redentor', 'Parque Nacional da Tijuca', 'Estatua de 38 metros en el cerro del Corcovado.', 'Lunes a domingo: 8:00-19:00', '+55 21 2551-2026', NULL, NULL, 4.8, 7),
    ('Ópera de Sídney', 'Bennelong Point', 'Uno de los edificios más icónicos del siglo XX.', 'Lunes a domingo: 9:00-17:00', '+61 2 9250 7111', 'info@sydneyoperahouse.com', NULL, 4.7, 8);

-- Tabla CategoriaTipo
INSERT INTO CategoriaTipo (Nombre) VALUES
    ('Museo'),
    ('Monumento'),
    ('Templo'),
    ('Edificio Histórico'),
    ('Maravilla del Mundo');

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