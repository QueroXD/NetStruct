USE NetStruct
GO

-- Inserciones en la tabla Continente
INSERT INTO Continente (Nombre) VALUES
    ('Europa'),
    ('Asia'),
    ('África'),
    ('América del Norte'),
    ('América del Sur'),
    ('Oceanía'),
    ('Antártida');

-- Inserciones en la tabla Paises
INSERT INTO Paises (Nombre, idContinente) VALUES
    ('España', 1),
    ('Francia', 1),
    ('Japón', 2),
    ('Egipto', 3),
    ('Estados Unidos', 4),
    ('Brasil', 5),
    ('Australia', 6),
    ('Italia', 1),
    ('China', 2),
    ('India', 2),
    ('Perú', 3),
    ('Reino Unido', 6);

-- Inserciones en la tabla Ciudades
INSERT INTO Ciudades (Nombre, idPais) VALUES
    ('Madrid', 1),
    ('Barcelona', 1),
    ('París', 2),
    ('Tokio', 3),
    ('El Cairo', 4),
    ('Nueva York', 5),
    ('Río de Janeiro', 6),
    ('Sídney', 7),
    ('Roma', 8),
    ('Beijing', 9),
    ('Agra', 10),
    ('Cusco', 11),
    ('Amesbury', 12),
    ('Versalles', 2);

-- Inserciones en la tabla Infraestructura
INSERT INTO Infraestructura (Nombre, Direccion, Cordenadas, Reseña, Horario, TelefonoContacto, EmailContacto, MiniaturaWeb, Valoracion, idCiudad) VALUES
    ('Museo del Prado', 'Calle de Ruiz de Alarcón 23', '40.4138,-3.6921', 'Uno de los museos de arte más importantes del mundo.', 'Lunes a sábado: 10:00-20:00; Domingo: 10:00-19:00', '+34 913 30 28 00', 'informacion@museodelprado.es', NULL, 4.8, 1),
    ('Sagrada Familia', 'Carrer de Mallorca 401', '41.4036,2.1744', 'Basílica diseñada por Antoni Gaudí, aún en construcción.', 'Lunes a domingo: 9:00-18:00', '+34 932 08 04 14', 'informacion@sagradafamilia.org', NULL, 4.7, 2),
    ('Torre Eiffel', 'Champ de Mars, 5 Avenue Anatole France', '48.8584,2.2945', 'El ícono de París, construido en 1889.', 'Lunes a domingo: 9:30-22:45', '+33 892 70 12 39', 'contact@toureiffel.paris', NULL, 4.7, 3),
    ('Templo Sens?-ji', '2-3-1 Asakusa, Taito City', '35.7148,139.7967', 'El templo más antiguo de Tokio.', 'Lunes a domingo: 6:00-17:00', '+81 3-3842-0181', 'example@example.com', NULL, 4.8, 4),
    ('Pirámides de Guiza', 'Al Haram, Nazlet El-Semman, Guiza', '29.9792,31.1342', 'La maravilla del mundo antiguo mejor conservada.', 'Lunes a domingo: 7:00-17:00', '+20 2 3377 6633', 'example@example.com', NULL, 4.9, 5),
    ('Estatua de la Libertad', 'Liberty Island', '40.6892,-74.0445', 'Regalo de Francia, símbolo de la libertad.', 'Lunes a domingo: 9:00-16:00', '+1 212-363-3200', 'info@libertyellisfoundation.org', NULL, 4.7, 6),
    ('Cristo Redentor', 'Parque Nacional da Tijuca', '-22.9519,-43.2105', 'Estatua de 38 metros en el cerro del Corcovado.', 'Lunes a domingo: 8:00-19:00', '+55 21 2551-2026', 'example@example.com', NULL, 4.8, 7),
    ('Ópera de Sídney', 'Bennelong Point', '-33.8568,151.2153', 'Uno de los edificios más icónicos del siglo XX.', 'Lunes a domingo: 9:00-17:00', '+61 2 9250 7111', 'info@sydneyoperahouse.com', NULL, 4.7, 8),
    ('Coliseo', 'Piazza del Colosseo, 1', '41.8902,12.4922', 'El anfiteatro más grande de Roma, símbolo de la antigua Roma.', 'Lunes a domingo: 8:30-19:00', '+39 06 3996 7700', 'info@coopculture.it', NULL, 4.7, 9),
    ('Gran Muralla China', 'Huairou District, Beijing', '40.4319,116.5704', 'Una de las estructuras más impresionantes del mundo, construida para proteger la antigua China.', 'Lunes a domingo: 8:00-18:00', '+86 10 6162 0777', 'info@chinagreatwall.org', NULL, 4.6, 10),
    ('Taj Mahal', 'Dharmshala, Agra', '27.1751,78.0421', 'Una de las maravillas del mundo moderno, mausoleo de mármol blanco.', 'Lunes a domingo: 6:00-19:00', '+91 562 222 7261', 'info@tajmahalindia.com', NULL, 4.8, 11),
    ('Machu Picchu', 'Cusco Region, Perú', '-13.1631,-72.5450', 'Antigua ciudad inca en lo alto de los Andes, famosa por su belleza y misterio.', 'Lunes a domingo: 6:00-17:00', '+51 84 211 034', 'info@machupicchu.gob.pe', NULL, 4.9, 12),
    ('Stonehenge', 'A303, Amesbury', '51.1789,-1.8262', 'Antiguo monumento megalítico de la prehistoria, conocido por sus misteriosas piedras.', 'Lunes a domingo: 9:30-19:00', '+44 1980 624 715', 'info@english-heritage.org.uk', NULL, 4.5, 13),
    ('Palacio de Versalles', 'Place d Armes Versailles', '48.8049,2.1204', 'Palacio barroco, antigua residencia real de Francia, famoso por sus jardines.', 'Martes a domingo: 9:00-18:30', '+33 1 30 83 78 00', 'contact@chateauversailles.fr', NULL, 4.8, 14);
