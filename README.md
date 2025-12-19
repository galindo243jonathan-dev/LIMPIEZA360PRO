# Limpieza 360Pro

Proyecto web profesional para gestión de limpieza y mantenimiento de propiedades.

## Estructura
- **backend/**: ASP.NET Core (C#), Entity Framework, ASP.NET Identity, JWT, SignalR, Azure Blob Storage
- **frontend/**: React, Bootstrap 5, responsive, idioma español

## Funcionalidades principales
- Autenticación y roles: Dueño, Manager, Empleado
- Sincronización en tiempo real (SignalR)
- Almacenamiento de archivos preparado para Azure Blob Storage
- Base de datos SQL Server con tablas: Users, Properties, Tasks, Inventory, ShoppingList, Reminders
- Preparado para despliegue en IIS/Azure con HTTPS

## Despliegue
- Backend: IIS/Azure
- Frontend: Deploy automático en GitHub Pages (rama main) con dominio limpieza360pro.com
- Workflow: `.github/workflows/deploy-frontend.yml`
- Para forzar deploy: haz commit en `frontend/` y push a `main`
## Notificaciones Push
- Configura las credenciales de Firebase y la VAPID key en los archivos indicados del frontend.
- El Service Worker ya está listo para recibir notificaciones en tiempo real.

## Subida de fotos
- Azure Blob Storage debe estar configurado y la cadena de conexión activa en el backend.
- Las fotos se suben desde el frontend y quedan accesibles vía URL.

## Pruebas y compatibilidad
- La app es responsive y funciona en móvil y PC.
- Prueba login, subida de fotos, notificaciones y navegación en distintos dispositivos.

## Administración
- Los usuarios y roles se gestionan desde el backend (API o base de datos).
- Las tareas, inventario y lista de compras pueden ser gestionadas desde el frontend.

## Soporte
- Para dudas técnicas, revisa este README o contacta al desarrollador principal.

## Idioma
- Español por defecto

## Instalación y configuración
1. Configurar la base de datos SQL Server
2. Configurar Azure Blob Storage
3. Instalar dependencias en frontend y backend
4. Compilar y ejecutar ambos proyectos

---
Este archivo se actualizará conforme avance el desarrollo.