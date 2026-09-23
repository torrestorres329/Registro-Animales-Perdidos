# Casos de Uso
## Registro de Animales Perdidos

### 1. Actores

**Usuario:** Persona que utiliza el sistema para registrar y consultar información de animales perdidos.

### 2. Caso de Uso: Registrar animal perdido

**Descripción:**  
Permite al usuario ingresar la información de un animal perdido.

**Precondición:**  
El sistema debe estar disponible.

**Flujo principal:**
1. El usuario ingresa al sistema.
2. Selecciona la opción para registrar un animal.
3. Ingresa los datos solicitados.
4. El sistema valida la información.
5. El sistema guarda el registro en la base de datos.
6. El sistema informa que el registro fue realizado correctamente.

### 3. Caso de Uso: Consultar animales

**Descripción:**  
Permite al usuario consultar los animales que se encuentran registrados.

**Flujo principal:**
1. El usuario ingresa al sistema.
2. Selecciona la opción de consultar animales.
3. El sistema obtiene los registros desde la base de datos.
4. El sistema muestra la información de los animales registrados.

### 4. Caso de Uso: Buscar animal

**Descripción:**  
Permite localizar un animal registrado utilizando información disponible del registro.

**Flujo principal:**
1. El usuario selecciona la opción de búsqueda.
2. Ingresa el dato que desea utilizar para buscar.
3. El sistema consulta la base de datos.
4. El sistema muestra los resultados encontrados.

### 5. Caso de Uso: Actualizar información

**Descripción:**  
Permite modificar los datos de un animal que ya se encuentra registrado.

**Flujo principal:**
1. El usuario selecciona un registro.
2. Selecciona la opción de actualizar.
3. Modifica la información necesaria.
4. El sistema valida los datos.
5. El sistema actualiza la información en la base de datos.
6. El sistema confirma la actualización.

### 6. Caso de Uso: Eliminar registro

**Descripción:**  
Permite eliminar un registro de animal cuando ya no sea necesario.

**Flujo principal:**
1. El usuario selecciona el registro.
2. Selecciona la opción de eliminar.
3. El sistema solicita confirmación.
4. El usuario confirma la eliminación.
5. El sistema elimina el registro de la base de datos.

### 7. Resumen de casos de uso

| Caso de uso | Descripción |
|---|---|
| Registrar animal | Permite ingresar un nuevo animal perdido. |
| Consultar animales | Permite visualizar los registros existentes. |
| Buscar animal | Permite localizar información de un animal. |
| Actualizar información | Permite modificar los datos de un registro. |
| Eliminar registro | Permite eliminar un registro existente. |

Diagrama UML de Casos de Uso

flowchart LR
    Usuario([Usuario])
    Registrar[Registrar animal perdido]
    Consultar[Consultar animales perdidos]
    Buscar[Buscar animal]
    Actualizar[Actualizar información]
    Eliminar[Eliminar registro]
    Validar[Validar información]
    Usuario --> Registrar
    Usuario --> Consultar
    Usuario --> Buscar
    Usuario --> Actualizar
    Usuario --> Eliminar
    Usuario --> Validar