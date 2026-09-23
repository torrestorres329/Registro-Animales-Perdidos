# Requerimientos - Registro de Animales Perdidos

## 1. Nombre del proyecto

Registro de Animales Perdidos

## 2. Problemática

Actualmente, cuando una persona pierde una mascota, puede resultar difícil
mantener organizada la información relacionada con el animal y realizar un
seguimiento de los casos.

La información puede quedar registrada de manera informal, dificultando la
consulta, actualización y seguimiento de los animales perdidos.

Por esta razón, se propone desarrollar un sistema que permita registrar y
gestionar información de animales perdidos de manera organizada.

## 3. Objetivo general

Desarrollar un sistema para registrar, consultar, actualizar y eliminar
información relacionada con animales perdidos, manteniendo los datos
organizados y disponibles para su gestión.

## 4. Alcance

El sistema permitirá gestionar los registros de animales perdidos mediante
operaciones CRUD:

- Registrar un animal perdido.
- Consultar animales registrados.
- Actualizar información de un animal.
- Eliminar un registro.
- Validar los datos ingresados.
- Mantener la información almacenada en una base de datos.

## 5. Usuario del sistema

El sistema será utilizado por un usuario encargado de gestionar los registros
de animales perdidos.

---

# 6. Requerimientos funcionales

## RF01 - Registrar animal perdido

**Rol/Usuario:** Usuario encargado.

**Necesidad/Acción:** Registrar un nuevo animal perdido ingresando la
información correspondiente.

**Criterio de aceptación/seguridad:** El sistema debe validar que los datos
obligatorios estén completos antes de guardar el registro.

---

## RF02 - Consultar animales perdidos

**Rol/Usuario:** Usuario encargado.

**Necesidad/Acción:** Consultar los animales perdidos que se encuentran
registrados en el sistema.

**Criterio de aceptación/seguridad:** El sistema debe mostrar únicamente
registros existentes y permitir visualizar su información de manera
organizada.

---

## RF03 - Actualizar información

**Rol/Usuario:** Usuario encargado.

**Necesidad/Acción:** Modificar la información de un animal previamente
registrado.

**Criterio de aceptación/seguridad:** El sistema debe verificar que el
registro exista y validar los datos antes de realizar la modificación.

---

## RF04 - Eliminar registro

**Rol/Usuario:** Usuario encargado.

**Necesidad/Acción:** Eliminar un registro de animal perdido cuando corresponda.

**Criterio de aceptación/seguridad:** El sistema debe solicitar confirmación
antes de eliminar el registro y evitar la eliminación de información no
existente.

---

## RF05 - Validar información

**Rol/Usuario:** Usuario encargado.

**Necesidad/Acción:** Ingresar información válida al momento de registrar o
modificar un animal.

**Criterio de aceptación/seguridad:** El sistema debe informar los errores de
ingreso y evitar guardar información que no cumpla con las validaciones
definidas.

---

# 7. Requerimientos no funcionales

## RNF01 - Seguridad

El sistema debe proteger la información registrada y controlar el acceso a
las operaciones disponibles.

## RNF02 - Integridad de los datos

La información almacenada debe mantener consistencia y relaciones correctas
entre los datos.

## RNF03 - Disponibilidad

El sistema debe permitir realizar las operaciones del mantenedor cuando la
aplicación y la base de datos se encuentren disponibles.

## RNF04 - Manejo de errores

El sistema debe manejar errores de la aplicación y de la base de datos,
mostrando mensajes comprensibles al usuario.

## RNF05 - Mantenibilidad

El sistema debe estar organizado mediante una arquitectura de cuatro capas:
UI, BLL, DAL y Entidades.

---
## 8. Seguridad e ISO/IEC 27001

Para el desarrollo del sistema se consideran aspectos relacionados con la
seguridad de la información, buscando proteger los datos registrados,
mantener su integridad y controlar el acceso a las operaciones del sistema.

Los principales aspectos de seguridad considerados son:

| Requerimiento | Medida de seguridad |
|---|---|
| RF01 - Registrar animal perdido | Validar los datos obligatorios antes de guardar la información. |
| RF02 - Consultar animales perdidos | Permitir la consulta de la información almacenada de manera controlada. |
| RF03 - Actualizar información | Verificar que el registro exista y validar los datos antes de modificarlo. |
| RF04 - Eliminar registro | Solicitar confirmación antes de eliminar y controlar la operación. |
| RF05 - Validar información | Evitar que datos incorrectos o incompletos sean almacenados. |

Aspectos de seguridad considerados

* Confidencialidad: controlar el acceso a las operaciones del sistema y a
    la información almacenada.
* Integridad: validar los datos y mantener relaciones correctas en la base
    de datos para evitar información inconsistente.
* Disponibilidad: mantener la información disponible para las operaciones
    del sistema cuando la aplicación y la base de datos estén funcionando.
* Control de acceso: restringir las operaciones de modificación y
    eliminación a usuarios autorizados.
* Manejo de errores: evitar mostrar información técnica de la base de
    datos o de la aplicación directamente al usuario.

Estos aspectos serán considerados durante el diseño de la aplicación, la base
de datos y las diferentes capas del sistema, tomando como referencia los
principios de seguridad de la información asociados a ISO/IEC 27001.

---

# 9. Operaciones CRUD

El sistema contará con las siguientes operaciones principales:

| Operación | Descripción |
|---|---|
| Crear | Registrar un nuevo animal perdido |
| Leer | Consultar los animales registrados |
| Actualizar | Modificar información existente |
| Eliminar | Eliminar un registro |

---

# 10. Resumen

El sistema de Registro de Animales Perdidos permitirá gestionar de manera
organizada la información de animales registrados como perdidos, utilizando
operaciones CRUD y una estructura de aplicación dividida en capas.
