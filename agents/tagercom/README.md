# Tagercom — Agente de Flujo de Trabajo de Impuestos Corporativos

## Descripción

**Tagercom** es un agente de inteligencia artificial diseñado para gestionar el flujo de trabajo completo de preparación de impuestos corporativos. Opera enteramente en español y está especializado en corporaciones (entidad tipo C-Corp y S-Corp) bajo las jurisdicciones federal, Nueva York y Puerto Rico.

---

## Propósito

Automatizar y estructurar el proceso de preparación de impuestos corporativos desde la recopilación de datos hasta la generación de reportes finales, comunicaciones con clientes y seguimiento de cumplimiento.

---

## Jurisdicciones

| Jurisdicción  | Formularios principales                          |
|---------------|--------------------------------------------------|
| Federal       | Form 1120 / 1120-S, Schedule M-1, M-2, M-3      |
| Nueva York    | NY CT-3, CT-3-S, CT-400, MTA surcharge          |
| Puerto Rico   | SC 2644, SC 2553, Modelo SC 480.20               |

---

## Tipo de Entidad

- **Corporaciones únicamente** (C-Corp y S-Corp)
- No aplica para partnerships, sole proprietors ni LLC no incorporadas

---

## Entradas (Inputs)

| Fuente                  | Descripción                                                        |
|-------------------------|--------------------------------------------------------------------|
| QuickBooks              | Exportación de P&L, Balance General, Trial Balance, transacciones |
| ProConnect (prep data)  | Datos de la plataforma de preparación de Intuit ProConnect         |
| Gmail / texto de email  | Mensajes de clientes con información, documentos o consultas       |
| PDFs / avisos subidos   | Notificaciones del IRS, DOR NY, Hacienda PR, estados de cuenta     |

---

## Salidas (Outputs)

| #  | Salida                        | Descripción                                                        |
|----|-------------------------------|--------------------------------------------------------------------|
| 1  | Reporte para ProConnect       | Datos estructurados listos para ingreso en ProConnect              |
| 2  | Reporte de faltantes          | Lista de documentos o información que aún se requiere del cliente  |
| 3  | Resumen de estatus            | Vista general del progreso de la declaración por cliente           |
| 4  | Calendario de cumplimiento    | Fechas límite de presentación, pagos estimados y extensiones       |
| 5  | Borradores de email en español| Comunicaciones listas para enviar al cliente                       |

---

## Archivos del Agente

```
agents/tagercom/
├── README.md               ← Este archivo. Descripción general del agente.
├── system_prompt.md        ← Prompt de sistema que define el comportamiento de Tagercom.
├── workflow.md             ← Flujo de trabajo paso a paso para procesar un cliente.
└── templates/
    ├── proconnect_report.md   ← Plantilla: reporte estructurado para ProConnect.
    ├── missing_items.md       ← Plantilla: lista de documentos/datos faltantes.
    ├── status_summary.md      ← Plantilla: resumen ejecutivo de estatus del cliente.
    └── client_email_es.md     ← Plantilla: borrador de email al cliente en español.
```

---

## Uso Rápido

1. Proveer al agente el `system_prompt.md` como prompt de sistema en tu plataforma LLM.
2. Adjuntar o pegar los datos del cliente (QuickBooks, PDFs, emails).
3. Especificar la tarea deseada: análisis, generación de reporte, borrador de email, etc.
4. El agente responderá usando las plantillas de `/templates` según corresponda.

Ver `workflow.md` para el proceso completo.

---

## Notas Importantes

- Tagercom **no** toma decisiones legales ni fiscales definitivas. Todas sus salidas deben ser revisadas por un preparador de impuestos certificado (CPA/EA).
- Los datos del cliente son confidenciales. No compartir outputs con terceros sin autorización.
- Las fechas del calendario de cumplimiento deben verificarse contra el calendario fiscal vigente del IRS, NYDTF y Hacienda PR.
