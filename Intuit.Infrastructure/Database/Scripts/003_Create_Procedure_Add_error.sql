DROP PROCEDURE IF EXISTS AddError;

CREATE PROCEDURE AddError(
    IN p_modulo VARCHAR(50),
    IN p_texto_error TEXT
)
BEGIN
    INSERT INTO errores (modulo, texto_error)
    VALUES (p_modulo, p_texto_error);
END