DROP TABLE IF EXISTS errores;

CREATE TABLE errores (
    id SERIAL PRIMARY KEY,
    modulo varchar(50),
    texto_error TEXT NOT NULL,
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);