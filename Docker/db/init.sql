CREATE TABLE product(
    product_no SERIAL PRIMARY KEY,
    product_name CHAR(200) NOT NULL,
    model_name CHAR(200) NOT NULL,
    maker CHAR(200)
);

INSERT INTO product(product_name, model_name, maker) VALUES
    ('PIC16F1827', 'PIC16F1827', 'Microchip'),
    ('PIC16F1938', 'PIC16F1938', 'Microchip');
