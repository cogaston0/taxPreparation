# Workflow — Tagercom

> **Flujo de trabajo operativo del agente Tagercom.**
> Este documento describe los pasos que sigue el agente para procesar un caso de impuestos corporativos desde la recepción de datos hasta la entrega de reportes.

---

## Visión General del Flujo

```
[ENTRADA DE DATOS]
       │
       ▼
[PASO 1] Recepción e Identificación del Cliente
       │
       ▼
[PASO 2] Revisión y Clasificación de Documentos
       │
       ▼
[PASO 3] Extracción y Validación de Datos
       │
       ▼
[PASO 4] Identificación de Faltantes
       │
       ▼
[PASO 5] Organización de Datos para ProConnect
       │
       ▼
[PASO 6] Generación de Reportes
       │
       ▼
[PASO 7] Comunicación con el Cliente
       │
       ▼
[SALIDA: Reportes + Emails]
```

---

## Paso 1 — Recepción e Identificación del Cliente

**Objetivo:** Establecer el contexto del caso antes de procesar cualquier documento.

### Datos requeridos al inicio:

| Campo                     | Ejemplo                          | Fuente              |
|---------------------------|----------------------------------|---------------------|
| Nombre de la corporación  | ABC Holdings Corp.               | Cliente / ProConnect|
| EIN                       | 12-3456789                       | ProConnect / W-9    |
| Año fiscal                | 2024                             | Cliente             |
| Tipo de corporación       | C-Corp / S-Corp                  | ProConnect / cliente|
| Jurisdicciones            | Federal, New York, Puerto Rico   | ProConnect / cliente|
| Preparador asignado       | [Nombre del preparador]          | Interno             |

### Acción:
- Crear o confirmar el expediente del cliente.
- Verificar que las jurisdicciones correspondan al historial previo (si existe).

---

## Paso 2 — Revisión y Clasificación de Documentos

**Objetivo:** Identificar todos los documentos recibidos y clasificarlos por tipo y jurisdicción.

### Categorías de documentos:

| Categoría                  | Tipo de documento                                           |
|----------------------------|-------------------------------------------------------------|
| Contabilidad               | QuickBooks P&L, Balance Sheet, Trial Balance                |
| Preparación previa         | Datos de ProConnect del año anterior                        |
| Comunicaciones             | Correos del cliente, avisos del IRS / NY DTF / Hacienda PR  |
| Documentos de soporte      | Formularios 1099, W-2, estados de cuenta bancarios          |
| Nómina                     | Form 941, Form 940, reportes de nómina                      |
| Créditos e incentivos      | Documentación de créditos aplicables                        |
| Acuerdos / Contratos       | Acuerdos de accionistas, contratos relevantes               |

### Acción:
- Listar todos los documentos recibidos.
- Marcar los que están **completos**, **incompletos** o **faltantes**.
- Registrar la fecha de recepción de cada documento.

---

## Paso 3 — Extracción y Validación de Datos

**Objetivo:** Extraer los datos clave de los documentos recibidos y validarlos para detectar inconsistencias.

### Datos a extraer por jurisdicción:

#### Federal (Form 1120 / 1120-S)
- Ingresos brutos y netos
- Costo de bienes vendidos (COGS)
- Deducciones ordinarias (salarios, alquiler, seguros, depreciación, etc.)
- Distribuciones a accionistas
- Créditos fiscales federales
- Pagos estimados realizados
- NOL (Net Operating Loss) de años anteriores

#### New York (Form CT-3 / CT-3-S)
- Ingresos sujetos a impuesto en NY
- Modificaciones NY al ingreso federal
- Créditos del estado de NY
- Pagos estimados NY
- Capital base NY

#### Puerto Rico (Planilla Corporativa)
- Ingresos de fuente PR vs. fuente no-PR
- Deducciones aplicables bajo el Código de Rentas Internas de PR
- Créditos Hacienda PR
- Pagos estimados PR (Vouchers)
- Exenciones bajo Act 20/22/60 (si aplica)

### Validaciones clave:
- ✅ El ingreso total en QuickBooks coincide con lo reportado en ProConnect.
- ✅ Los pagos de nómina en QuickBooks coinciden con los Form 941 recibidos.
- ✅ Las distribuciones a accionistas están documentadas.
- ✅ Los pagos estimados están registrados para cada jurisdicción.
- ⚠️ Identificar cualquier discrepancia y documentarla.

---

## Paso 4 — Identificación de Faltantes

**Objetivo:** Generar la lista completa de documentos y datos que aún se necesitan para completar la preparación.

### Proceso:
1. Comparar los datos disponibles con los requerimientos de cada jurisdicción.
2. Clasificar cada faltante por:
   - **Jurisdicción:** Federal / New York / Puerto Rico
   - **Categoría:** Ingresos, Deducciones, Créditos, Nómina, Información corporativa
   - **Prioridad:** Alta / Media / Baja
3. Documentar el **impacto** de cada faltante en el proceso.
4. Generar el **Reporte de Faltantes** usando la plantilla `templates/missing_items.md`.

---

## Paso 5 — Organización de Datos para ProConnect

**Objetivo:** Estructurar todos los datos validados en el formato requerido para su ingreso en ProConnect Tax.

### Proceso:
1. Organizar los datos por sección de ProConnect (información de la entidad, ingresos, deducciones, créditos, pagos, estados).
2. Identificar campos que requieren entrada manual del preparador.
3. Señalar ajustes o entradas especiales (e.g., depreciación especial, elecciones fiscales).
4. Generar el **Reporte para ProConnect** usando la plantilla `templates/proconnect_report.md`.

---

## Paso 6 — Generación de Reportes

**Objetivo:** Producir todos los documentos de salida requeridos.

### Reportes a generar:

| Reporte                    | Plantilla                          | Estado       |
|----------------------------|------------------------------------|--------------|
| Reporte para ProConnect    | `templates/proconnect_report.md`   | [ ] Pendiente|
| Reporte de faltantes       | `templates/missing_items.md`       | [ ] Pendiente|
| Resumen de estatus         | `templates/status_summary.md`      | [ ] Pendiente|
| Calendario de cumplimiento | (generado inline)                  | [ ] Pendiente|
| Borradores de email        | `templates/client_email_es.md`     | [ ] Pendiente|

### Calendario de Cumplimiento (referencia general):

| Formulario         | Jurisdicción  | Fecha límite original | Fecha con prórroga |
|--------------------|---------------|-----------------------|--------------------|
| Form 1120 (C-Corp) | Federal       | 15 de abril           | 15 de octubre      |
| Form 1120-S (S-Corp)| Federal      | 15 de marzo           | 15 de septiembre   |
| Form CT-3          | New York      | 15 de abril           | 15 de octubre      |
| Form CT-3-S        | New York      | 15 de marzo           | 15 de septiembre   |
| Planilla Corp. PR  | Puerto Rico   | 15 de abril           | 15 de octubre      |

> ⚠️ Las fechas específicas pueden variar por año fiscal y extensiones solicitadas. Verificar siempre las fechas actuales del IRS, NY DTF y Hacienda PR.

---

## Paso 7 — Comunicación con el Cliente

**Objetivo:** Redactar y enviar comunicaciones profesionales en español al cliente.

### Tipos de comunicación:

| Tipo de email              | Cuándo enviarlo                                        |
|----------------------------|--------------------------------------------------------|
| Solicitud de documentos    | Al identificar faltantes (después del Paso 4)          |
| Actualización de estatus   | Al completar una fase del proceso                      |
| Entrega de declaración     | Al tener la declaración lista para revisión del cliente|
| Aviso de fecha límite      | Cuando se acerque una fecha de vencimiento importante  |
| Respuesta a aviso fiscal   | Al recibir una carta del IRS, NY DTF o Hacienda PR     |

### Proceso:
1. Seleccionar el tipo de email apropiado.
2. Completar la plantilla `templates/client_email_es.md`.
3. Revisar el borrador antes de enviarlo.
4. Registrar el envío en el expediente del cliente.

---

## Criterios de Cierre del Caso

Un caso se considera **completo** cuando:

- [x] Todos los documentos requeridos han sido recibidos y validados.
- [x] El Reporte para ProConnect ha sido generado y revisado por el preparador.
- [x] La declaración ha sido preparada y revisada en ProConnect.
- [x] El cliente ha aprobado la declaración (firma de autorización).
- [x] La declaración ha sido presentada ante las jurisdicciones correspondientes.
- [x] Los comprobantes de presentación han sido archivados en el expediente.
- [x] El cliente ha recibido la copia final de su declaración.

---

## Notas Importantes

- **Extensiones:** Si se necesita una prórroga, debe solicitarse **antes** de la fecha límite original. Documentar en el expediente.
- **Pagos estimados:** Recordar al cliente los pagos estimados del año en curso al cerrar la preparación del año anterior.
- **Cambios en la entidad:** Verificar si hubo cambios en accionistas, directores, dirección o actividad del negocio durante el año fiscal.
- **Enmiendas:** Si se detectan errores después de presentar, documentar y evaluar la necesidad de una declaración enmendada (Amended Return).
