Diagrama de Clases - Registro de Animales Perdidos

1. Clase Animal

La clase principal del sistema es Animal, ya que representa la información de cada animal perdido que será registrada y administrada por el sistema.

Atributos

Visibilidad	Atributo	Tipo
-	IdAnimal	int
-	Nombre	string
-	Especie	string
-	Raza	string
-	Descripcion	string
-	FechaPerdida	DateTime
-	LugarPerdida	string

Métodos principales

Visibilidad	Método	Descripción
+	Registrar()	Permite registrar un animal perdido.
+	Consultar()	Permite consultar los animales registrados.
+	Actualizar()	Permite modificar la información de un animal.
+	Eliminar()	Permite eliminar un registro.
+	ValidarDatos()	Verifica que la información ingresada sea válida.

2. Relación con el sistema

La clase Animal representa la información que será utilizada por las diferentes capas del sistema. La información se registra, consulta, actualiza y elimina mediante las operaciones CRUD.

3. Visibilidad utilizada

* - significa que el atributo es privado.
* + significa que el método es público.

4. Resumen

El diagrama de clases permite representar la estructura principal del sistema, mostrando los atributos y métodos relacionados con el registro de animales perdidos.

5. Diagrama UML de clases
classDiagram
    class Persona {
        -int IdPersona
        -string Nombre
        -string Telefono
        -string Correo
    }
    class AnimalPerdido {
        -int IdAnimal
        -string Nombre
        -string Especie
        -string Raza
        -string Color
        -string Descripcion
        -DateTime FechaPerdida
        -string LugarPerdida
        -string Estado
        -int IdPersona
        +Registrar()
        +Consultar()
        +Actualizar()
        +Eliminar()
        +ValidarDatos()
    }
    Persona "1" --> "0..*" AnimalPerdido : registra