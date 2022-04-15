# webservice_rest


base de datos 

CREATE DATABASE db_trading;
USE db_trading;

CREATE TABLE tbl_operacion
(
    int_id int not null auto_increment,
	  dt_compra timestamp null,  
    var_criptomoneda varchar (250) null,
	  dbl_inversion double null,
	  int_cantidad int null,
	  dbl_precio_compra double null,
	  dbl_precio_actual double null,
	  dbl_total double null,
	  dbl_rentabilidad double null, 
    dt_modificacion timestamp null,
    bol_estatus boolean not null,
	
    PRIMARY KEY (int_id)
)ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1;
