# N5APAC

<p>
  El ejercicio lo resolvi en la parte 1, decidi hacer la inyeccion de dependencias en el constructor del controller.
  builder.Services.AddScoped<IStudentLogic, StudentLogic>();

  Las otras posibilidades eran con
  AddTransient 
  Una nueva instancia cada vez que se resuelve el servicio: Cada vez que se solicita un servicio, se crea una nueva instancia.
  
  y 

  AddSingleton
  Una única instancia para toda la aplicación: Se crea una sola instancia del servicio y se comparte en toda la aplicación.

</p>

<p>
  Observación sobre los controllers: 
  Para hacer esto de una forma mas efectiva, se podrian haber usado modelos de UserBasicInfo, que asegura "privacidad en la información".
  No se revelan datos mayores.
</p>
