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



