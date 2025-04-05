```markdown
# OldPhonePadApp

[![My Skills](https://skillicons.dev/icons?i=csharp,dotnet,git,vscode&theme=dark)](https://skillicons.dev)

## Descripción

OldPhonePadApp es una aplicación desarrollada para resolver el desafío de codificación de Iron Software, basado en el antiguo teclado telefónico. La aplicación decodifica secuencias numéricas, interpretando múltiples pulsaciones, pausas y la tecla de retroceso para corregir errores, generando el mensaje resultante en mayúsculas.

## Características

- **Decodificación Inteligente:** Convierte secuencias numéricas en letras según el antiguo teclado telefónico.
- **Pausas y Retroceso:** Maneja espacios para separar pulsaciones y el carácter '*' para eliminar el último carácter.
- **Casos de Prueba Integrados:** Verifica la funcionalidad mediante pruebas predefinidas.
- **Código Modular y Documentado:** Facilita la comprensión, el mantenimiento y la ampliación futura del proyecto.

## Instalación

1. **Clona el repositorio:**

   ```bash
   git clone https://github.com/Jose985537/OldPhonePadApp.git
   ```

2. **Navega al directorio del proyecto:**

   ```bash
   cd OldPhonePadApp
   ```

3. **Abre el proyecto en Visual Studio Code (o tu IDE preferido).**

4. **Ejecuta el proyecto utilizando .NET CLI:**

   ```bash
   dotnet run
   ```

## Estructura del Proyecto

- **Program.cs:** Contiene el método `Main` que inicia la aplicación y ejecuta los casos de prueba.
- **OldPhonePadDecoder.cs:** Implementa la lógica de decodificación del antiguo teclado telefónico.
- **OldPhonePadTests.cs:** Define y ejecuta los casos de prueba para garantizar la funcionalidad del decodificador.

## Uso

La aplicación espera una cadena de entrada que debe terminar en el carácter `#`. Los espacios actúan como pausas entre secuencias, y el carácter `*` representa una tecla de retroceso. Ejemplos de entrada y salida:

- `"33#"` se decodifica a **E**
- `"227*#"` se decodifica a **B**
- `"4433555 555666#"` se decodifica a **HELLO**
- `"8 88777444666*664#"` se decodifica a **TURING**

## Contribuciones

Las contribuciones son bienvenidas. Si deseas mejorar la aplicación o agregar nuevas funcionalidades, por favor crea un _issue_ o envía un _pull request_.

## Licencia

Este proyecto se distribuye bajo la licencia MIT. Consulta el archivo `LICENSE` para más detalles.

## Contacto

Para consultas o sugerencias, por favor contacta a [turing@ironsoftware.com](mailto:turing@ironsoftware.com).

---

<p align="center">
  <a href="https://skillicons.dev">
    <img src="https://skillicons.dev/icons?i=csharp,dotnet,git,vscode&theme=dark&perline=4" alt="My Skills" />
  </a>
</p>
```