use dbsistemaembutidos;

create table if not exists tbl_proveedor(
pk_idProveedor int not null,
nombreProveedor varchar(50),
direccionProveedor varchar(30),
telefonoProveedor varchar(20),
estadoProveedor int );

select * from tbl_proveedor;