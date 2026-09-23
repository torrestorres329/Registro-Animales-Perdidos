Modelo de Base de Datos - Registro de Animales Perdidos

1. Entidades principales

El sistema utiliza dos entidades principales:

* Personas: contiene los datos de la persona responsable de registrar o informar la pérdida del animal.
* AnimalesPerdidos: contiene la información de los animales registrados como perdidos.

Existe una relación entre ambas entidades mediante la clave foránea IdPersona.

2. Entidad Personas

Atributo	Tipo de dato	Clave	Descripción
IdPersona	INT	PK	Identificador único de la persona.
Nombre	VARCHAR(100)		Nombre de la persona.
Telefono	VARCHAR(20)		Número de teléfono.
Correo	VARCHAR(100)		Correo electrónico.

3. Entidad AnimalesPerdidos

Atributo	Tipo de dato	Clave	Descripción
IdAnimal	INT	PK	Identificador único del animal.
Nombre	VARCHAR(50)		Nombre del animal.
Especie	VARCHAR(30)		Especie del animal.
Raza	VARCHAR(50)		Raza del animal.
Color	VARCHAR(50)		Color del animal.
Descripcion	VARCHAR(200)		Características adicionales del animal.
FechaPerdida	DATE		Fecha en que se perdió.
LugarPerdida	VARCHAR(150)		Lugar donde se perdió.
Estado	VARCHAR(30)		Estado del registro del animal.
IdPersona	INT	FK	Persona relacionada con el registro.

4. Primera Forma Normal (1FN)

La base de datos cumple con la Primera Forma Normal porque cada campo contiene un único valor y no existen grupos repetitivos de información.

Los datos de las personas y de los animales se encuentran organizados en tablas separadas.

5. Segunda Forma Normal (2FN)

La base de datos cumple con la Segunda Forma Normal porque los atributos de cada tabla dependen de su respectiva clave primaria.

En Personas, los datos dependen de IdPersona.

En AnimalesPerdidos, los datos dependen de IdAnimal.

6. Tercera Forma Normal (3FN)

La estructura cumple con la Tercera Forma Normal porque los atributos dependen directamente de la clave primaria de su tabla y no existen dependencias innecesarias entre atributos que no sean claves.

La separación entre Personas y AnimalesPerdidos permite evitar la repetición de los datos de una persona en cada registro de animal.

7. Claves primarias y foráneas

La tabla Personas utiliza IdPersona como clave primaria.

La tabla AnimalesPerdidos utiliza IdAnimal como clave primaria.

Además, IdPersona en AnimalesPerdidos funciona como clave foránea y referencia a Personas(IdPersona).

8. Integridad referencial

La integridad referencial se implementa mediante la clave foránea:

AnimalesPerdidos.IdPersona → Personas.IdPersona

Esto permite mantener una relación válida entre los animales registrados y las personas asociadas.

9. Relación entre las entidades

La relación entre las tablas es de uno a muchos (1:N).

Una persona puede estar asociada a varios animales perdidos, mientras que cada registro de animal perdido está asociado a una persona.

Personas
   1
   |
   |----< 
   |
   N
AnimalesPerdidos

10. Conclusión

El modelo de base de datos permite almacenar de manera organizada la información de las personas y de los animales perdidos. Además, utiliza claves primarias, clave foránea e integridad referencial para mantener la consistencia de los datos.