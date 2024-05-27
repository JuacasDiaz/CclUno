# CclUno
Proyecto Backend, con una api rest, enfocado a cumplir los requisitos de la prueba tecnica.

Manual de Endpoints del Backend - CclInventoryApp

   1. Autenticación de Usuarios

       Usuarios existentes en la base de datos:
       {usuario1, contraseña: password1}.
       {usuario2, contraseña: password2}

       Todos los metodos esta protegidos via [Autorize], para autenticarse, ingresar token.

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
{
  "data": [
    {
      "id": 1,
      "productId": 2,
      "userId": 1,
      "quantity": 20,
      "method": "compra",
      "date": "2024-05-28T15:00:00Z",
      "createdAt": "2024-05-26T21:40:05.991985Z",
      "product": {
        "id": 2,
        "name": "Producto 2",
        "description": "Descripción del Producto 2",
        "price": 29.99,
        "createdAt": "2024-05-26T17:17:09.470896Z",
        "updatedAt": "2024-05-26T17:17:09.470896Z"
      },
      "user": {
        "id": 1,
        "username": "usuario1",
        "createdAt": "2024-05-26T17:30:29.770867Z",
        "updatedAt": "2024-05-26T17:30:29.770867Z"
      }
    },
    {
      "id": 2,
      "productId": 2,
      "userId": 1,
      "quantity": 20,
      "method": "compra",
      "date": "2024-05-28T15:00:00Z",
      "createdAt": "2024-05-26T22:40:26.269702Z",
      "product": {
        "id": 2,
        "name": "Producto 2",
        "description": "Descripción del Producto 2",
        "price": 29.99,
        "createdAt": "2024-05-26T17:17:09.470896Z",
        "updatedAt": "2024-05-26T17:17:09.470896Z"
      },
      "user": {
        "id": 1,
        "username": "usuario1",
        "createdAt": "2024-05-26T17:30:29.770867Z",
        "updatedAt": "2024-05-26T17:30:29.770867Z"
      }
    },
    {
      "id": 3,
      "productId": 2,
      "userId": 1,
      "quantity": 20,
      "method": "compra",
      "date": "2024-05-26T22:45:43.128171Z",
      "createdAt": "2024-05-26T22:45:43.128172Z",
      "product": {
        "id": 2,
        "name": "Producto 2",
        "description": "Descripción del Producto 2",
        "price": 29.99,
        "createdAt": "2024-05-26T17:17:09.470896Z",
        "updatedAt": "2024-05-26T17:17:09.470896Z"
      },
      "user": {
        "id": 1,
        "username": "usuario1",
        "createdAt": "2024-05-26T17:30:29.770867Z",
        "updatedAt": "2024-05-26T17:30:29.770867Z"
      }
    }
  ]
}

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

5.4 Productos

    Endpoint: /api/v1/products

Metodo: Get

Descripción: Trae los productos.



Respuesta:

{
  "data": [
    {
      "id": 1,
      "name": "Producto 1",
      "description": "Descripción del Producto 1",
      "price": 19.99,
      "createdAt": "2024-05-26T17:17:09.470896Z",
      "updatedAt": "2024-05-26T17:17:09.470896Z"
    },
    {
      "id": 2,
      "name": "Producto 2",
      "description": "Descripción del Producto 2",
      "price": 29.99,
      "createdAt": "2024-05-26T17:17:09.470896Z",
      "updatedAt": "2024-05-26T17:17:09.470896Z"
    },
    {
      "id": 3,
      "name": "Producto 3",
      "description": "Descripción del Producto 3",
      "price": 39.99,
      "createdAt": "2024-05-26T17:17:09.470896Z",
      "updatedAt": "2024-05-26T17:17:09.470896Z"
    },
    {
      "id": 4,
      "name": "Producto 4",
      "description": "Descripción del Producto 4",
      "price": 49.99,
      "createdAt": "2024-05-26T17:17:09.470896Z",
      "updatedAt": "2024-05-26T17:17:09.470896Z"
    },
    {
      "id": 5,
      "name": "Producto 5",
      "description": "Descripción del Producto 5",
      "price": 59.99,
      "createdAt": "2024-05-26T17:17:09.470896Z",
      "updatedAt": "2024-05-26T17:17:09.470896Z"
    },
    {
      "id": 6,
      "name": "Producto A",
      "description": "Descripción del Producto A",
      "price": 10.99,
      "createdAt": "2023-01-15T17:17:09.470896Z",
      "updatedAt": "2023-01-15T17:17:09.470896Z"
    },
    {
      "id": 7,
      "name": "Producto B",
      "description": "Descripción del Producto B",
      "price": 20.99,
      "createdAt": "2023-02-20T17:17:09.470896Z",
      "updatedAt": "2023-02-20T17:17:09.470896Z"
    },
    {
      "id": 8,
      "name": "Producto C",
      "description": "Descripción del Producto C",
      "price": 30.99,
      "createdAt": "2023-03-10T17:17:09.470896Z",
      "updatedAt": "2023-03-10T17:17:09.470896Z"
    },
    {
      "id": 9,
      "name": "Producto D",
      "description": "Descripción del Producto D",
      "price": 40.99,
      "createdAt": "2023-04-05T17:17:09.470896Z",
      "updatedAt": "2023-04-05T17:17:09.470896Z"
    },
    {
      "id": 10,
      "name": "Producto E",
      "description": "Descripción del Producto E",
      "price": 50.99,
      "createdAt": "2023-05-01T17:17:09.470896Z",
      "updatedAt": "2023-05-01T17:17:09.470896Z"
    }
  ]
}
•	204 No Content - Producto eliminado con éxito.
•	401 Unauthorized - Token no válido o expirado.
•	404 Not Found - Producto no encontrado.


   
