# Tagercom — Agente de Flujo de Trabajo de Impuestos Corporativos

## Descripción

**Tagercom** es un agente de inteligencia artificial diseñado para gestionar el flujo de trabajo completo de preparación de impuestos corporativos. Opera en español y está especializado en corporaciones (Corporations) bajo las jurisdicciones **Federal**, **New York** y **Puerto Rico**.

---

## Árbol de Archivos

```
agents/tagercom/
├── README.md                          ← Este archivo. Descripción general del agente.
├── system_prompt.md                   ← Instrucciones del sistema que definen el comportamiento de Tagercom.
├── workflow.md                        ← Flujo de trabajo paso a paso que sigue el agente.
└── templates/
    ├── proconnect_report.md           ← Plantilla para el reporte de datos hacia ProConnect.
    ├── missing_items.md               ← Plantilla para el reporte de documentos/datos faltantes.
    ├── status_summary.md              ← Plantilla para el resumen de estatus del caso.
    └── client_email_es.md             ← Plantilla para borradores de email al cliente en español.
```

---

## Propósito

Tagercom centraliza y automatiza las tareas más repetitivas del ciclo fiscal corporativo:

| Entrada                         | Descripción                                          |
|---------------------------------|------------------------------------------------------|
| Datos de QuickBooks             | Exportaciones contables (P&L, balance, transacciones)|
| Datos de preparación ProConnect | Información previa del cliente en ProConnect         |
| Correos electrónicos / Gmail    | Texto de correos del cliente o avisos recibidos      |
| PDFs / Avisos subidos           | Cartas del IRS, NY, Hacienda PR y otros documentos   |

| Salida                          | Descripción                                          |
|---------------------------------|------------------------------------------------------|
| Reporte para ProConnect         | Datos organizados para entrada en ProConnect         |
| Reporte de faltantes            | Lista de documentos o datos que aún se necesitan     |
| Resumen de estatus              | Estado actual del caso del cliente                   |
| Calendario de cumplimiento      | Fechas límite y obligaciones por jurisdicción        |
| Borradores de email en español  | Correos listos para enviar al cliente                |

---

## Jurisdicciones Cubiertas

- 🇺🇸 **Federal** (IRS — Form 1120)
- 🗽 **New York** (NY DTF — Form CT-3)
- 🇵🇷 **Puerto Rico** (Hacienda PR — Planilla Corporativa)

## Tipo de Entidad

- **Corporación (Corporation)** únicamente

---

## Archivos del Agente

### `system_prompt.md`
Define la identidad, el rol y las reglas de comportamiento de Tagercom. Este archivo es el "prompt de sistema" que se carga al iniciar una sesión con el agente.

### `workflow.md`
Describe el flujo de trabajo paso a paso: desde la recepción de datos del cliente hasta la entrega de los reportes finales. Sirve como guía operativa del agente.

### `templates/proconnect_report.md`
Plantilla estructurada para organizar los datos del cliente (ingresos, deducciones, créditos, información de la entidad) en el formato requerido por ProConnect Tax.

### `templates/missing_items.md`
Plantilla para generar el reporte de faltantes. Lista qué documentos, formularios o datos aún no han sido proporcionados por el cliente, clasificados por jurisdicción.

### `templates/status_summary.md`
Plantilla para el resumen de estatus del caso. Incluye el progreso general, advertencias, próximas fechas límite y notas del preparador.

### `templates/client_email_es.md`
Plantilla para redactar correos electrónicos profesionales en español dirigidos al cliente, ya sea para solicitar documentos, enviar actualizaciones o comunicar el estado de la declaración.

---

## Uso Rápido

Consulta el [README principal](../../README.md) para instrucciones completas de configuración y uso.

1. Carga los datos del cliente (QuickBooks, ProConnect, emails, PDFs).
2. Inicia una sesión con Tagercom usando el `system_prompt.md`.
3. Sigue el `workflow.md` para procesar la información.
4. Usa las plantillas en `/templates/` para generar los reportes de salida.
