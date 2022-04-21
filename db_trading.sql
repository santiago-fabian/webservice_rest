CREATE DATABASE db_trading;
USE db_trading;

CREATE TABLE tbl_operacion
(
    int_id int not null auto_increment,
	dt_compra timestamp null,  
    var_moneda varchar (100) null,
	var_intercambio varchar (100) null,
	dbl_inversion double DEFAULT 0,
	dbl_cantidad double DEFAULT 0,
	dbl_precio_compra double DEFAULT 0,
	dbl_precio_actual double DEFAULT 0,
	dbl_comision double DEFAULT 0,
	dbl_total double DEFAULT 0,
	dbl_rentabilidad double DEFAULT 0, 
    dt_modificacion timestamp null,
    bol_estatus boolean not null,
	
    PRIMARY KEY (int_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;

-- estatus
1-compra
2-venta