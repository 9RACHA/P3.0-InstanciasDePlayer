# P3.0-InstanciasDePlayer

## Cantas instancias de player existen? 

Logo de facer o Get started with NGO xurdiu a dúbida de cantas instancias de player existen con dous xogadores, un deles en modo host (client + server) e o outro en modo client. 

Da a túa resposta de forma razoada e utilizando as ferramentas pertinentes.

Entregables:

Breve informe coa xustificación e as capturas se é o caso

#

Al principio la respuesta seria que hay 2 jugadores y por lo tanto hay 2 instancias de player (jugador). Una de las instancias actúa como Anfitrión en modo Host (Cliente + Servidor), mientras que la otra instancia actúa como cliente. Por lo tanto, hay 2 instancias de player en total. Pero esta no es la respuesta correcta.

La instancia del host en Unity actuaría como el servidor y ejecutaría una instancia de player que funciona como el servidor del juego. Esta instancia se encargaría de gestionar la lógica del juego y de recibir y procesar las acciones enviadas por los clientes.

En la máquina del cliente, al ejecutar la build del juego, se crearía una instancia de player para el cliente. Esta instancia se comunica con el servidor (instancia del host) para enviar y recibir información actualizada del juego.

Dado que hay dos jugadores visibles en el juego (host y cliente), se necesitarían dos instancias en cada máquina para permitir la interacción entre ellos. En total, habría 4 instancias de player: una instancia de servidor en la máquina del host y una instancia de cliente en la máquina del host, y una instancia de servidor en la máquina del cliente y una instancia de cliente en la máquina del cliente.

En definitiva si se ejecuta el ejecuta el proyecto desde Unity como Host:


![image](https://github.com/9RACHA/P3.0-InstanciasDePlayer/assets/66274956/3bfefebe-bd71-4dbb-8569-6e7458dca449)


Al iniciar el proyecto como Host desde Unity, despues al hacer la build en la que esta seremos los clientes aparecera por consola de Unity lo siguiente:

![image](https://github.com/9RACHA/P3.0-InstanciasDePlayer/assets/66274956/bd9e4704-9603-48bb-bbc2-54f6b4825a9b)
Esto aparece asi porque El host tendrá 2 instancias una por cada jugador

Sin embargo si hacemos el proceso inverso y mediante la Build seleccionamos Host, y despues mediante Unity seleccionamos Cliente el resultado sera diferente:

![image](https://github.com/9RACHA/P3.0-InstanciasDePlayer/assets/66274956/0afaf2c1-bb54-4910-aa91-06b63f09158d)

Para finalizar la respuesta seria 4 instancias de player: si existe 1 Host y 1 Cliente ya que se generan 2 instancias por cada uno respectivamente.









