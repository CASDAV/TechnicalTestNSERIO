# Prueba Técnica NSERIO

## Ejecución del proyecto

Este documento proporciona una guía para ejecutar los proyectos SalesDatePrediction.Backend y SalesDatePrediction.Frontend.

### SalesDatePrediction.Backend

El proyecto backend está construido con .NET. Siga estos pasos para ejecutarlo:

1.  **Requisitos previos:**
    *   .NET SDK (versión compatible)
    *   SQL Server (con la base de datos SalesDatePrediction configurada)

2.  **Configuración:**
    *   Asegúrese de que la cadena de conexión en `SalesDatePrediction.API/appsettings.json` y `SalesDatePrediction.API/appsettings.Development.json` sea correcta y apunte a su instancia de SQL Server.
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=SalesDatePrediction;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
    ```
    Reemplace `your_server` con el nombre de su servidor SQL Server.

3.  **Ejecutar la aplicación:**
    *   Abra la solución `SalesDatePrediction.Backend.sln` en Visual Studio.
    *   Seleccione `SalesDatePrediction.API` como el proyecto de inicio.
    *   Ejecute el proyecto (por ejemplo, presionando F5).

4.  **Endpoints de la API:**
    La API se ejecutará en `https://localhost:<puerto>`, donde `<puerto>` es el puerto configurado en `SalesDatePrediction.API/Properties/launchSettings.json`. Los endpoints disponibles son:
    *   `GET /api/SalesDatePrediction`: Obtiene las predicciones de fechas de venta.
    *   `GET /api/SalesDatePrediction/ClientOrders/{id}`: Obtiene los pedidos de un cliente específico.
    *   `GET /api/SalesDatePrediction/Employees`: Obtiene la lista de empleados.
    *   `GET /api/SalesDatePrediction/Products`: Obtiene la lista de productos.
    *   `GET /api/SalesDatePrediction/Shippers`: Obtiene la lista de transportistas.
    *   `POST /api/SalesDatePrediction/Orders`: Crea un nuevo pedido.

### SalesDatePrediction.Frontend

El proyecto frontend está construido con Angular. Siga estos pasos para ejecutarlo:

1.  **Requisitos previos:**
    *   Node.js y npm instalados.
    *   Angular CLI instalado globalmente (`npm install -g @angular/cli`).

2.  **Instalación de dependencias:**
    *   Navegue hasta el directorio `SalesDatePrediction.Frontend/SalesDatePrediction.Client` en la terminal.
    *   Ejecute `npm install` para instalar las dependencias del proyecto.

3.  **Configuración:**
    *   Configure la URL de la API en `SalesDatePrediction.Frontend/SalesDatePrediction.Client/src/config.ts` para que coincida con la URL donde se ejecuta el backend.
    ```typescript
    export const API_BASE_URL = 'https://localhost:<puerto>/api';
    ```
    Reemplace `<puerto>` con el puerto en el que se ejecuta la API backend.

4.  **Ejecutar la aplicación:**
    *   En la terminal, dentro del directorio `SalesDatePrediction.Frontend/SalesDatePrediction.Client`, ejecute `ng serve`.
    *   Abra su navegador y navegue a `http://localhost:4200/` (o la URL que se muestre en la terminal).

### Base de datos
La base de datos se encuentra en la carpeta `SalesDatePrediction.Database` y se llama `SalesDatePrediction.sql`.

### Scripts SQL
La carpeta `SalesDatePrediction.Database` contiene los scripts SQL para crear la base de datos y los procedimientos almacenados.
*   `AddNewOrder.sql`: Script para crear el procedimiento almacenado `NewOrder`.
*   `GetClientOrders.sql`: Script para crear el procedimiento almacenado `ClientOrders`.
*   `GetEmployees.sql`: Script para crear el procedimiento almacenado `Employees`.
*   `GetProducts.sql`: Script para crear el procedimiento almacenado `Products`.
*   `GetShippers.sql`: Script para crear el procedimiento almacenado `Shippers`.
*   `SalesDatePrediction.sql`: Script para crear el procedimiento almacenado `PredictNextOrders`.

### Información Adicional

*   **Angular CLI:** Para obtener más información sobre el uso de Angular CLI, visite [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli).
*   **.NET SDK:** Asegúrese de tener instalada una versión compatible del .NET SDK.
