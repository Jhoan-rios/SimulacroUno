-- Active: 1716925452360@@beyvscqr6ablfsmiuf4x-mysql.services.clever-cloud.com@3306@beyvscqr6ablfsmiuf4x

/* Tablas Activas */
CREATE TABLE authors(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(125),
    LastName VARCHAR(45),
    Email VARCHAR(125) UNIQUE,
    Nationality VARCHAR(125),
    State VARCHAR(45) DEFAULT 'Activo'
);

CREATE TABLE edithorials(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(125),
    Address VARCHAR(125),
    Phone VARCHAR(35),
    Email VARCHAR(125) UNIQUE,
    State VARCHAR(45) DEFAULT 'Activo'
);

CREATE TABLE books(
    Id INTEGER AUTO_INCREMENT PRIMARY KEY,
    Title VARCHAR(225) UNIQUE,
    Pages INTEGER(10),
    Language VARCHAR(125),
    PublicationDate DATE,
    Description TEXT,
    State VARCHAR(45) DEFAULT 'Activo',
    EdithorialsId INTEGER,
    AuthorsId INTEGER,
    FOREIGN KEY (EdithorialsId) REFERENCES edithorials(Id),
    Foreign Key (AuthorsId) REFERENCES authors(Id)
);

/* Datos para las tablas */

INSERT INTO authors (Name, LastName, Email, Nationality) VALUES
('Gabriel', 'García Márquez', 'gabriel.marquez@example.com', 'Colombiana'),
('Isabel', 'Allende', 'isabel.allende@example.com', 'Chilena'),
('Haruki', 'Murakami', 'haruki.murakami@example.com', 'Japonesa'),
('J.K.', 'Rowling', 'jk.rowling@example.com', 'Británica'),
('George', 'Orwell', 'george.orwell@example.com', 'Británica');

INSERT INTO edithorials (Name, Address, Phone, Email) VALUES
('Editorial Sudamericana', 'Av. Santa Fe 1234, Buenos Aires', '+54-11-1234-5678', 'contacto@sudamericana.com'),
('Alfaguara', 'Calle Mayor 45, Madrid', '+34-91-234-5678', 'info@alfaguara.com'),
('Tusquets Editores', 'Calle Balmes 123, Barcelona', '+34-93-234-5678', 'editorial@tusquets.com'),
('Penguin Random House', '20 Vauxhall Bridge Rd, London', '+44-20-7840-8400', 'info@penguinrandomhouse.co.uk'),
('Kodansha', '2-12-21 Otowa, Bunkyo-ku, Tokyo', '+81-3-3942-6000', 'support@kodansha.co.jp');

INSERT INTO books (Title, Pages, Language, PublicationDate, Description, EdithorialsId, AuthorsId) VALUES
('Cien Años de Soledad', 417, 'Español', '1967-05-30', 'Una obra maestra de la literatura hispanoamericana.', 1, 1),
('La Casa de los Espíritus', 368, 'Español', '1982-01-01', 'Una novela emblemática de la literatura latinoamericana.', 2, 2),
('Kafka en la Orilla', 505, 'Japonés', '2002-09-12', 'Una fascinante historia de magia y realismo.', 5, 3),
('Harry Potter y la Piedra Filosofal', 223, 'Inglés', '1997-06-26', 'El inicio de la serie de Harry Potter.', 4, 4),
('1984', 328, 'Inglés', '1949-06-08', 'Una novela distópica que explora el totalitarismo.', 4, 5);
