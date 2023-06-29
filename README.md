# Challenge Galicia Seguros - Squad :rocket:

API de Consulta del Clima

## Instalación y Despliegue

1. Clonar el repositorio de Git:   
   - git clone https://github.com/FrancoNatanael/challenge-squad.git

2. Acceder al directorio del proyecto dentro de la carpeta ApiChallenge donde se encuentra el archivo docker-compose.yml

3. Desplegar el servicio utilizando Docker, mantener abierta la aplicación Docker Desktop y ejecutar el siguiente comando en una terminar PowerShell:
   - docker-compose up

4. Acceder a la aplicación a través de la siguiente URL y ejecutar las consultas a los endpoints mostrados en el la vista de swagger(se utiliza una db en memoria con entity framework que se carga con datos cuando se ejecuta la aplcación):
   - http://localhost:8080/swagger/index.html
  
## Tecnologías y herramientas utilizadas en el proyecto

- C#
- ASP.NET Core
- Entity Framework
- xUnit (Tests)
- Docker
- Serilog
   
## Datos para probar los endpoints 

- Usuario:
  - Mail: usuario@gmail.com
  - Password: 999
- Paises:
  - Argentina
  - Estados Unidos
- Ciudades:
  - Buenos Aires
  - Nueva York
