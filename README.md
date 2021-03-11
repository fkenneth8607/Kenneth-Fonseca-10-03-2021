# Kenneth Fonseca 10 de Marzo de 2021
Applicacion en Net Core para obtener json de varias url y mostrar en una Tabla
Se abre el menu de Opciones y deben hacer clic en Album de Fotos
posteriormente las acciones solicitadas estan en los botones correspondientes


Se Estructura el Codigo en distintos proyectos por lo siguiente

Proyecto MyAlbumApplication
  Es un proyecto Por Defecto que se crea en Net Core,
  Solo elimine modelos por que lo pase al Core


Proyecto MyAlbumApplication.Core
  Contiene los Modelos E Interfaces que lleva la Aplicacion, si se va a realizar un
  proyecto grande es bueno tener los modelos en otro proyecto con las interfaces a 
  implementar para separar los mismos
  
  
Proyecto MyAlbumApplication.Infrasctructure
  Contiente los Servicios que Implementan las Interfaces de Core, estos servicios contienen mas logica a la hora de procesar Informacion
  Para Evitar este codigo en los controladores
  Contiene tambien los Helpers que vayan surgiendo por ejemplo un EmailHelper, un PdfHelper los colocaria aqui y los llamaria desde un servicio
  En esteProyecto cree un metodo para la inyeccion de dependencias e insertarlas aqui, asi solo en el startup llamamos a AddInfraestructureService y no estamos llenando el statup
  con AddScoped, o AddTransient Por Ejemplo
  
  
  
