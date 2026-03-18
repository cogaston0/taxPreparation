# Tagercom — Flujo de Trabajo

## Visión General

El flujo de trabajo de Tagercom está dividido en **5 fases** que cubren desde la recepción inicial de datos hasta el cierre del caso. Cada fase produce salidas específicas y puede ejecutarse de forma secuencial o en paralelo según la disponibilidad de información.

---

## Diagrama de Flujo

```
[INICIO]
    │
    ▼
[FASE 1: Recepción y Clasificación de Datos]
    │   ├─ QuickBooks export
    │   ├─ ProConnect prep data
    │   ├─ Emails / mensajes
    │   └─ PDFs / avisos
    │
    ▼
[FASE 2: Análisis y Verificación]
    │   ├─ Mapeo de cuentas → formularios
    │   ├─ Identificación de faltantes
    │   └─ Revisión de avisos y deadlines
    │
    ▼
[FASE 3: Generación de Reportes]
    │   ├─ Reporte para ProConnect
    │   ├─ Reporte de faltantes
    │   └─ Resumen de estatus
    │
    ▼
[FASE 4: Comunicación con el Cliente]
    │   ├─ Borradores de email en español
    │   └─ Calendario de cumplimiento
    │
    ▼
[FASE 5: Revisión Final y Cierre]
    │   ├─ Confirmación de datos completos
    │   ├─ Aprobación del preparador
    │   └─ Archivado del caso
    │
[FIN]
```

---

## FASE 1: Recepción y Clasificación de Datos

### Objetivo
Identificar y organizar todos los documentos e información recibida del cliente.

### Entradas
- Exportaciones de QuickBooks (P&L, Balance General, Trial Balance)
- Datos de ProConnect (si ya existen del año anterior o actuales)
- Emails del cliente (forwards o texto copiado)
- PDFs subidos (avisos, 1099s, estados bancarios, etc.)

### Acciones de Tagercom
1. Clasificar cada documento por tipo y fuente
2. Identificar el año fiscal del cliente
3. Confirmar el tipo de entidad (C-Corp o S-Corp)
4. Listar todos los documentos recibidos con fecha de recepción
5. Identificar documentos faltantes con base en el perfil estándar del cliente

### Salida de esta fase
```
DOCUMENTOS RECIBIDOS:
✅ QuickBooks P&L — [año]
✅ Balance General — [año]
❌ Trial Balance — FALTANTE
✅ Aviso IRS [número] — recibido [fecha]
...
```

---

## FASE 2: Análisis y Verificación

### Objetivo
Procesar los datos recibidos, identificar inconsistencias y preparar la información para su ingreso en ProConnect.

### 2A — Análisis de QuickBooks

| Paso | Acción |
|------|--------|
| 1 | Revisar totales del P&L: ingresos, COGS, gastos operativos, utilidad neta |
| 2 | Verificar Balance General: activos = pasivos + capital |
| 3 | Mapear cuentas del P&L a líneas del Form 1120 / 1120-S |
| 4 | Identificar gastos no deducibles (entretenimiento al 50%, multas, etc.) |
| 5 | Detectar partidas inusuales que requieran justificación |
| 6 | Calcular diferencias libro vs. tax (Schedule M-1 adjustments) |

**Mapeo principal Form 1120 (C-Corp):**

| Cuenta QuickBooks        | Línea Form 1120           |
|--------------------------|---------------------------|
| Total ingresos           | Line 1c (Gross receipts)  |
| COGS                     | Line 2 (Cost of goods)    |
| Salarios y sueldos       | Line 13 (Salaries/wages)  |
| Depreciación             | Line 20 (Depreciation)    |
| Renta de oficina         | Line 16 (Rents)           |
| Intereses pagados        | Line 18 (Interest)        |
| Otros gastos             | Schedule K / Other ded.   |

**Mapeo principal Form 1120-S (S-Corp):**

| Cuenta QuickBooks        | Línea Form 1120-S         |
|--------------------------|---------------------------|
| Total ingresos           | Line 1c (Gross receipts)  |
| COGS                     | Line 2                    |
| Salarios oficiales       | Line 7 (Compensation)     |
| Otros gastos             | Lines 8-19                |
| Items de pass-through    | Schedule K                |

### 2B — Análisis de Avisos y PDFs

Para cada aviso recibido, identificar:

- **Tipo de aviso**: deficiencia, penalidad, solicitud de información, confirmación
- **Jurisdicción**: IRS / NYDTF / Hacienda PR
- **Monto**: si aplica
- **Fecha límite de respuesta**: crítico
- **Acción requerida**: responder, pagar, ignorar, apelar

### 2C — Revisión de Emails del Cliente

- Extraer cifras mencionadas y agregarlas al análisis
- Identificar preguntas sin responder
- Marcar compromisos de fechas mencionados por el cliente
- Detectar documentos prometidos aún no recibidos

---

## FASE 3: Generación de Reportes

### 3.1 — Reporte para ProConnect
Usar la plantilla `templates/proconnect_report.md`.

Incluye:
- Datos de identificación de la corporación
- Cifras mapeadas por línea de formulario
- Notas para el preparador por cada partida relevante
- Banderas [REVISAR] donde se requiere decisión del preparador

### 3.2 — Reporte de Faltantes
Usar la plantilla `templates/missing_items.md`.

Incluye:
- Lista priorizada de documentos faltantes
- Categoría de cada faltante (crítico / importante / opcional)
- Impacto en la declaración si no se obtiene
- Sugerencia de cómo solicitarlo al cliente

### 3.3 — Resumen de Estatus
Usar la plantilla `templates/status_summary.md`.

Incluye:
- Porcentaje de completitud del caso
- Jurisdicciones pendientes
- Próximas fechas límite
- Alertas activas (avisos, penalidades, etc.)

---

## FASE 4: Comunicación con el Cliente

### 4A — Borradores de Email
Usar la plantilla `templates/client_email_es.md`.

Tipos de email a generar según necesidad:
1. **Solicitud de documentos faltantes** — lista clara de lo que se necesita
2. **Confirmación de recepción** — acuse de recibo de documentos enviados
3. **Actualización de estatus** — progreso de la declaración
4. **Notificación de aviso** — explicar al cliente un aviso recibido
5. **Recordatorio de fecha límite** — alertar sobre deadlines próximos
6. **Solicitud de firma** — para extensiones o declaraciones listas

### 4B — Calendario de Cumplimiento

Generar calendario con las siguientes fechas según jurisdicción y tipo de entidad:

#### C-Corp (Form 1120) — Año calendario
| Fecha          | Evento                                      | Jurisdicción   |
|----------------|---------------------------------------------|----------------|
| 15 de enero    | Pago estimado Q4 año anterior               | Federal / NY   |
| 15 de marzo    | [S-Corp únicamente] Fecha límite 1120-S     | Federal        |
| 15 de abril    | Fecha límite Form 1120 / SC 2644            | Federal / PR   |
| 15 de abril    | Pago estimado Q1                            | Federal / NY   |
| 15 de junio    | Pago estimado Q2                            | Federal / NY   |
| 15 de sept.    | [S-Corp] Fecha límite con extensión         | Federal        |
| 15 de sept.    | Pago estimado Q3                            | Federal / NY   |
| 15 de octubre  | Fecha límite con extensión (C-Corp / PR)    | Federal / PR   |
| 15 de dic.     | Pago estimado Q4                            | Federal / NY   |

> ⚠️ Verificar estas fechas contra el calendario fiscal del IRS vigente para el año en curso.

---

## FASE 5: Revisión Final y Cierre

### Checklist de Cierre

- [ ] Todos los documentos requeridos recibidos y procesados
- [ ] Reporte ProConnect revisado y aprobado por el preparador
- [ ] No hay ítems marcados como [REVISAR] sin resolver
- [ ] Todos los avisos atendidos o en proceso
- [ ] Cliente notificado del estatus final
- [ ] Documentos archivados en el sistema del cliente
- [ ] Calendario de cumplimiento enviado al cliente

---

## Instrucciones de Uso con el Agente

### Cómo iniciar una sesión

```
1. Cargar el system_prompt.md como System Prompt en tu plataforma LLM

2. Indicar al agente:
   "Nuevo cliente: [Nombre Corporación], [C-Corp o S-Corp], año fiscal [año],
    jurisdicciones: Federal, NY, PR. Adjunto los siguientes documentos: [listar]"

3. Adjuntar o pegar los documentos disponibles

4. Solicitar la fase o output específico que necesitas
```

### Comandos útiles para el agente

| Comando / Instrucción                        | Resultado esperado                        |
|----------------------------------------------|-------------------------------------------|
| "Analiza este QuickBooks P&L"                | Mapeo a Form 1120 con notas               |
| "Genera el reporte para ProConnect"          | Plantilla proconnect_report completada    |
| "¿Qué documentos faltan?"                    | Reporte de faltantes priorizado           |
| "Dame el resumen de estatus"                 | Status summary del caso                   |
| "Genera el calendario de cumplimiento"       | Fechas límite por jurisdicción            |
| "Redacta un email pidiendo los faltantes"    | Borrador en español listo para enviar     |
| "Analiza este aviso del IRS [pegar texto]"   | Análisis del aviso con acción requerida   |
