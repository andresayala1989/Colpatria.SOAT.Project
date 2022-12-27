# Colpatria.SOAT.Project

# Prueba Técnica - Info adicional

Colpatria.postman_collection.json: Json de Postamn que permite abrir la collection que cree para consumir los 3 servicios]:
https://localhost:44300/Home/Authenticate: Obtiene el token
https://localhost:44300/Poliza/Get: Obtiene segun numero de placa los datos de la poliza y tomador 
https://localhost:44300/Poliza/Post: Crea la poliza y el usuario o solo crea la nueva poliza con las reglas establecidas en la prueba

Colpatria.SOAT.Solution: Solución completa con una arquitectura monolitica de 3 capas Api(Servicio), DAL (Viewmodels), BLL (Logica de Negocio)

Evidencias Postman.docx: Muestro evidencias en la respuesta segun POSTMAN

Nota.txt: Las credenciales de BDs del usuario que se conecta a la aplicación

script completo.sql: Script para la creación mediante ejecución de script

SOAT.bak: O un backup de la BD

Dando respuesta a las consideraciones técnicas:
El Api se realizo con OAUTH 2.0 para el consumo de los servicios menos el de Bienvenida y el que Autoriza el ingreso que genera el tokenDesarrollada en C# .NET CORE 3.1 Conexión con ORM EntityFramework Core Con una arquitectura MVC monolítica de 3 capas (Con principios SOLID e Inyección de dependencias)Se adjuntan pantallas y un archivo descargado desde POSTMAN para el consumo de los servicios 