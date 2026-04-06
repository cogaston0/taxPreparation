# taxPreparation

Repositorio de agentes de flujo de trabajo para la preparación de impuestos corporativos.

---

## Agentes Disponibles

| Agente    | Tipo de Entidad | Idioma  | Jurisdicciones                        |
|-----------|-----------------|---------|---------------------------------------|
| [Tagercom](agents/tagercom/README.md) | Corporación | Español | Federal, New York, Puerto Rico |

---

## Tagercom — Agente de Impuestos Corporativos

**Tagercom** es un agente de inteligencia artificial diseñado para gestionar el flujo de trabajo completo de preparación de impuestos corporativos en español, cubriendo las jurisdicciones de **Federal (IRS)**, **New York (NY DTF)** y **Puerto Rico (Hacienda PR)**.

### Árbol de Archivos

```
taxPreparation/
├── README.md                                   ← Este archivo
└── agents/
    └── tagercom/
        ├── README.md                           ← Descripción general del agente
        ├── system_prompt.md                    ← Instrucciones del sistema (prompt de agente)
        ├── workflow.md                         ← Flujo de trabajo paso a paso
        └── templates/
            ├── proconnect_report.md            ← Reporte estructurado para ProConnect Tax
            ├── missing_items.md                ← Reporte de documentos/datos faltantes
            ├── status_summary.md               ← Resumen de estatus del caso
            └── client_email_es.md              ← Borradores de email al cliente en español
```

### Qué Hace Cada Archivo

| Archivo                             | Descripción                                                                                   |
|-------------------------------------|-----------------------------------------------------------------------------------------------|
| `agents/tagercom/README.md`         | Descripción completa del agente: propósito, entradas, salidas, jurisdicciones y uso rápido.  |
| `agents/tagercom/system_prompt.md`  | Define la identidad, capacidades y reglas de comportamiento del agente Tagercom.             |
| `agents/tagercom/workflow.md`       | Flujo de trabajo de 7 pasos: desde la recepción de datos hasta la comunicación con el cliente.|
| `templates/proconnect_report.md`    | Plantilla para organizar datos fiscales listos para ingresar en ProConnect Tax.              |
| `templates/missing_items.md`        | Plantilla para listar documentos faltantes por jurisdicción, categoría y prioridad.          |
| `templates/status_summary.md`       | Plantilla de resumen de estatus con progreso por fase, resultados y calendario de vencimientos.|
| `templates/client_email_es.md`      | Plantilla con 6 tipos de borradores de email profesional en español para comunicación con el cliente.|

---

## Configuración y Uso

### Requisitos Previos

No se requiere software adicional para usar los archivos de plantilla y documentación de este repositorio. Los archivos están en formato **Markdown** y pueden ser usados con:

- Cualquier editor de texto o IDE (VS Code, Obsidian, Typora, etc.)
- Un LLM o plataforma de agentes de IA (ChatGPT, Claude, Copilot, etc.)
- Un sistema de gestión de proyectos que soporte Markdown (Notion, Confluence, etc.)

### Cómo Usar Tagercom con un LLM

1. **Cargar el system prompt:**
   - Abrir `agents/tagercom/system_prompt.md`.
   - Copiar su contenido y usarlo como el **System Prompt** o **instrucciones del sistema** de su sesión de LLM.

2. **Iniciar la sesión:**
   - Proporcionar al agente los datos del cliente:
     - Nombre de la corporación
     - EIN
     - Año fiscal
     - Tipo de corporación (C-Corp / S-Corp)
     - Jurisdicciones aplicables
     - Documentos disponibles

3. **Seguir el flujo de trabajo:**
   - Consultar `agents/tagercom/workflow.md` para guiar el proceso paso a paso.

4. **Usar las plantillas:**
   - Al llegar a la fase de generación de reportes (Paso 6 del workflow), usar las plantillas correspondientes en `agents/tagercom/templates/`:
     - Llenar `proconnect_report.md` con los datos extraídos y validados.
     - Completar `missing_items.md` con los ítems que aún no han sido recibidos.
     - Actualizar `status_summary.md` con el estatus actual del caso.
     - Seleccionar el tipo de email adecuado en `client_email_es.md` y completarlo.

5. **Entregar los reportes:**
   - Revisar todos los documentos generados antes de compartirlos con el cliente o ingresar los datos en ProConnect Tax.

### Entradas Aceptadas por Tagercom

| Tipo de entrada             | Descripción                                                     |
|-----------------------------|-----------------------------------------------------------------|
| Datos de QuickBooks         | Exportaciones de P&L, Balance Sheet, Trial Balance              |
| Datos de ProConnect         | Información de preparación previa del cliente                   |
| Correos electrónicos/Gmail  | Texto de correos del cliente o avisos de agencias fiscales      |
| PDFs/Avisos subidos         | Cartas del IRS, NY DTF, Hacienda PR, estados de cuenta, etc.   |

### Salidas Generadas por Tagercom

| Salida                          | Plantilla                       |
|---------------------------------|---------------------------------|
| Reporte para ProConnect         | `templates/proconnect_report.md`|
| Reporte de faltantes            | `templates/missing_items.md`    |
| Resumen de estatus              | `templates/status_summary.md`   |
| Calendario de cumplimiento      | Generado dentro del resumen     |
| Borradores de email en español  | `templates/client_email_es.md`  |

---

## Jurisdicciones Cubiertas

| Jurisdicción  | Agencia       | Formulario corporativo principal  |
|---------------|---------------|-----------------------------------|
| Federal       | IRS           | Form 1120 / Form 1120-S           |
| New York      | NY DTF        | Form CT-3 / Form CT-3-S           |
| Puerto Rico   | Hacienda PR   | Planilla Corporativa              |

---

## Licencia

Consultar el archivo [LICENSE](LICENSE) para detalles sobre la licencia de este proyecto.
