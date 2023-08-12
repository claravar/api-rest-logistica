# api-rest-logistica - Clara Varela

# Demo
https://api-rest-logistics.azurewebsites.net/api/login/authenticate

Postman Collection: https://drive.google.com/file/d/1SZJPCewttB5P59DSrbywjZbrZveXrKQl/view?usp=drive_link

# Instalación

Fuente para clonar código desde git

$  git clone https://github.com/claravar/api-rest-logistica

# Pruebas

https://api-rest-logistics.azurewebsites.net/api/Clientes/1

La respuesta debería de ser:

` {
    "IdCliente": 1,
    "Nombre": "Luis Gutierrez Mod",
    "Telefono": "+503 5447 8890",
    "Direccion": "San Miguel, El Salvador"
 } `

 # Entidades
 
 - GET /api/Clientes 
  - GET /api/TipoProductos
  - GET /api/Transportes
 - GET /api/Bodegas
 - GET /api/Puertos
 - GET /api/Entregas
 - GET /api/EntregaTipoProductos

  # Seguridad

    POST /api/auth
  
  ## Credenciales

    {
        "Username": "admin",
        "Password": "admin"
    }

   ## Respuesta Bearer Token:
        "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwicm9sZSI6IkRldmVsb3BlciIsIm5iZiI6MTY5MTg1NzM4NiwiZXhwIjoxNjkxODYwOTg2LCJpYXQiOjE2OTE4NTczODYsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAyNTYiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjUwMjU2In0.wYh6TALO64khMJSdd_V0nGpsW2JU6LnZ5I73D5eXP2k"
