# CclUno
Proyecto Backend, con una api rest, enfocado a cumplir los requisitos de la prueba tecnica.


Manual de Endpoints del Backend - CclInventoryApp

1. Autenticación de Usuarios
1.1 Registro de Usuario


Usuarios existentes en la base de datos: {usuario1, contraseña: password1}.{usuario2, contraseña: password2}

direccion del servidor en render para probar endpoints: https://ccluno.onrender.com/api/v1/

Endpoint: /api/auth/register
Método: POST
Descripción: Registra un nuevo usuario en el sistema.
Parámetros del Cuerpo de la Solicitud:
json
Copiar código

{
    "username": "string",
    "password": "string"
}



Respuesta:

•	201 Created - Usuario registrado con éxito.
•	400 Bad Request - Error en la solicitud.

1.2 Inicio de Sesión
Endpoint: /api/auth/login
Método: POST
Descripción: Autentica un usuario y devuelve un token JWT.
Parámetros del Cuerpo de la Solicitud:
json
Copiar código

{
    "username": "string",
    "password": "string"
}

Respuesta:
json
Copiar código

{
    "token": "string"
}
•	200 OK - Inicio de sesión exitoso.
•	401 Unauthorized - Credenciales incorrectas.

2. Consulta de Inventario

2.1 Obtener Inventario


Endpoint: /api/inventory
Método: GET
Descripción: Devuelve una lista de todos los productos en el inventario.
Parámetros de la Solicitud:
•	Authorization: Bearer {token}
Respuesta:
json
Copiar código


[

{
        "productId": "int",
        "productName": "string",
        "quantity": "int",
        "lastUpdated": "string"
    },
    ...
]
•	200 OK - Lista de productos obtenida con éxito.
•	401 Unauthorized - Token no válido o expirado.


3. Ingreso de Mercancía

3.1 Registrar Ingreso

Endpoint: /api/entry

Método: POST

Descripción: Registra el ingreso de mercancía al inventario.
Parámetros del Cuerpo de la Solicitud:
json

Copiar código

{
    "productId": "int",
    "quantity": "int",
    "entryType": "string"  // Ejemplo: "purchase", "transfer"
}

Respuesta:


•	201 Created - Ingreso registrado con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.


4. Salida de Mercancía


4.1 Registrar Salida
Endpoint: /api/exit
Método: POST
Descripción: Registra la salida de mercancía del inventario.
Parámetros del Cuerpo de la Solicitud:
json
Copiar código

{
    "productId": "int",
    "quantity": "int",
    "exitType": "string"  // Ejemplo: "sale", "damage", "transfer"
}

Respuesta:
•	201 Created - Salida registrada con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.

5. Gestión de Productos

5.1 Crear Producto

Endpoint: /api/products
Método: POST
Descripción: Crea un nuevo producto en el inventario.
Parámetros del Cuerpo de la Solicitud:
json
Copiar código

{
    "productName": "string",
    "initialQuantity": "int"
}
Respuesta:
•	201 Created - Producto creado con éxito.
•	400 Bad Request - Error en la solicitud.
•	401 Unauthorized - Token no válido o expirado.

5.2 Actualizar Producto

Endpoint: /api/products/{id}

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
Endpoint: /api/products/{id}
Método: DELETE
Descripción: Elimina un producto del inventario.
Respuesta:
•	204 No Content - Producto eliminado con éxito.
•	401 Unauthorized - Token no válido o expirado.
•	404 Not Found - Producto no encontrado.