# CclUno
Proyecto Backend, con una api rest, enfocado a cumplir los requisitos de la prueba tecnica.


Manual de Endpoints del Backend - CclInventoryApp

1. Autenticación de Usuarios

Usuarios existentes en la base de datos: {usuario1, contraseña: password1}.{usuario2, contraseña: password2}

direccion del servidor en render para probar endpoints: https://ccluno.onrender.com/api/v1/

Endpoint: /api/v1/auth/login
Método: POST
Descripción: Autentica un usuario y devuelve un token JWT.

Parámetros del Cuerpo de la Solicitud:

{
    "username": "usuario1",
    "password": "password1"
}

Respuesta:
json
Copiar código
{
    "token": "string"
}

•	200 OK - Inicio de sesión exitoso.
•	401 Unauthorized - Credenciales incorrectas.

-----------------------------------------------------------------------------------------------------------------------

2. Consulta de Inventario

2.1 Entrada Inventario

Endpoint: /api/v1/inventoryentries

Método: GET

Descripción: Devuelve una lista de todos los productos en el inventario.

Parámetros de la Solicitud:

•	Authorization: Bearer {token}
Respuesta:
json
Copiar código

[
   "productId": 2,
   "quantity": 20,
   "method": "compra",
   "userId": 1
]

•	200 OK - Lista de productos obtenida con éxito.
•	401 Unauthorized - Token no válido o expirado.

---------------------------------------------------------------------------------------------------------------------------

3. Ingreso de Mercancía

3.1 Registrar Ingreso

Endpoint: /api/v1/inventoryentries

Método: POST

Descripción: Registra el ingreso de mercancía al inventario.

Parámetros del Cuerpo de la Solicitud:

json
Copiar código
{
   
  "productId": 5,
  "userId": 2,
  "quantity": 10,
  "reason": "venta"
}
}

Respuesta: 

•	201 Created - Ingreso registrado con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.

----------------------------------------------------------------------------------------------------------------------------------------------------------------

4. Salida de Mercancía

4.1 Registrar Salida

Endpoint: api/v1/inventoryexits

Método: POST

Descripción: Registra la salida de mercancía del inventario.

Parámetros del Cuerpo de la Solicitud:

json
Copiar código
{

  "productId": 5,
  "userId": 2,
  "quantity": 10,
  "reason": "venta"

}
Respuesta:
•	201 Created - Salida registrada con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.

--------------------------------------------------------------------------------------------------------------------------------------------------------

5. Gestión de Productos

5.1 Crear Producto

Endpoint: /api/v1/products

Método: POST

Descripción: Crea un nuevo producto en el inventario.

Parámetros del Cuerpo de la Solicitud:

json
Copiar código
{
  "name": "String",
  "description": "String",
  "price": decimal
}
Respuesta:
•	201 Created - Producto creado con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.


5.2 Actualizar Producto

Endpoint: /api/v1/products/{id}

Método: PUT

Descripción: Actualiza la información de un producto existente.

Parámetros del Cuerpo de la Solicitud:

json
Copiar código

{
    "productName": "string",
    "quantity": "int"
}

Respuesta:

•	200 OK - Producto actualizado con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.
•	404 Not Found - Producto no encontrado.

5.3 Eliminar Producto

Endpoint: /api/v1/products/{id}

Método: DELETE

Descripción: Elimina un producto del inventario.

Respuesta:
•	204 No Content - Producto eliminado con éxito.
•	401 Unauthorized - Token no válido o expirado.
•	404 Not Found - Producto no encontrado.

