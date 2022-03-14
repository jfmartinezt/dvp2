Tecnologias y medologias aplicadas: C# .Net Core, Javascript, JQuery, VueJS, Api REST, SOLID, MySQL, Entity Framework, Docker, Repository Pattern, Middleware Exception Handling, file logging.

Requisitos:

1. .Net Framework Runtime 5.0
2. MySQL Server 8.0
3. Docker

Pasos para Windows:

1. Correr el en doc/script db_script.sql para crear la base de datos persons_db y la tablas person y user
2. Correr el en doc/script user_script.sql para crear el usuario con los permisos suficientes para realizar consultas desde .Net con Mysql
3. En el appsettings.json de la solucion configurar el string connection:
	server=192.168.1.8;port=3306;user=monty2;password=some_pass;database=ticket_db;Convert Zero Datetime=True
	
	*En el parametro server debe ir la IPV4 del host.
		
	
5. Ir a ../Server/PersonsSystem/ y correr los siguientes comandos para hacer build e iniciar el contenedor.

docker build -t dockerfile .
docker run -dp 54066:80 dockerfile

6. Ir a ../Site/persons-web/ y correr los siguientes comandos para hacer build e iniciar el sitio web en un server http

npm run build
serve -s dist


7. FIN.


