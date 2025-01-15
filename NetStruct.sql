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
    Cordenadas VARCHAR(255) NOT NULL,
    Reseña VARCHAR(MAX),
    Horario VARCHAR(100),
    TelefonoContacto VARCHAR(20),
    EmailContacto VARCHAR(100),
    UrlWeb VARCHAR(100),
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