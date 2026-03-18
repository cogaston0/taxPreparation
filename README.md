# taxPreparation

A repository of AI-powered tax preparation workflow agents for CPAs and EAs.

---

## Agents

### Tagercom — Corporate Tax Workflow Agent

**Tagercom** is a Spanish-language AI agent designed to automate the corporate tax preparation workflow for CPAs and EAs. It handles corporations only (C-Corp and S-Corp) across Federal, New York, and Puerto Rico jurisdictions.

| Detail         | Value                                      |
|----------------|--------------------------------------------|
| Language       | Spanish                                    |
| Entity type    | Corporations only (C-Corp / S-Corp)        |
| Jurisdictions  | Federal (IRS), New York (NYDTF), Puerto Rico (Hacienda) |
| Inputs         | QuickBooks exports, ProConnect data, emails, PDFs/notices |
| Outputs        | 5 structured reports (see below)           |

**Outputs produced by Tagercom:**
1. Reporte para ProConnect — structured data ready for ProConnect entry
2. Reporte de faltantes — prioritized list of missing documents/information
3. Resumen de estatus — executive status summary per client
4. Calendario de cumplimiento — filing deadlines and estimated payment schedule
5. Borradores de email en español — ready-to-send client communication drafts

---

## Setup

### Requirements

- Access to a large language model platform that accepts a system prompt (e.g., Claude, ChatGPT, or any OpenAI-compatible API)
- No additional software installation required — Tagercom is prompt-based

### How to Deploy Tagercom

1. **Open** `agents/tagercom/system_prompt.md`
2. **Copy** the full text inside the code block
3. **Paste** it as the **System Prompt** in your LLM platform of choice
4. **Start a session** by providing the client's data as described below

---

## Usage

### Starting a New Client Session

Provide the agent with an opening message like:

```
Nuevo cliente: [Nombre de la Corporación]
Tipo de entidad: [C-Corp / S-Corp]
EIN: [número]
Año fiscal: [año]
Jurisdicciones activas: Federal, Nueva York, Puerto Rico

Adjunto / pego los siguientes documentos:
[listar documentos]
```

Then attach or paste the available documents.

### Common Commands

| Instruction to Tagercom                          | Output produced                        |
|--------------------------------------------------|----------------------------------------|
| "Analiza este QuickBooks P&L"                    | Account mapping to Form 1120 with notes |
| "Genera el reporte para ProConnect"              | Completed `proconnect_report` template  |
| "¿Qué documentos faltan?"                        | Completed `missing_items` template      |
| "Dame el resumen de estatus"                     | Completed `status_summary` template     |
| "Genera el calendario de cumplimiento"           | Filing deadlines by jurisdiction        |
| "Redacta un email solicitando los faltantes"     | Ready-to-send Spanish email draft       |
| "Analiza este aviso del IRS: [paste notice text]"| Notice analysis with recommended action |

---

## File Structure

```
taxPreparation/
├── README.md                              ← This file
└── agents/
    └── tagercom/
        ├── README.md                      ← Agent overview (in Spanish)
        ├── system_prompt.md               ← LLM system prompt — paste this into your AI platform
        ├── workflow.md                    ← Full 5-phase workflow documentation
        └── templates/
            ├── proconnect_report.md       ← ProConnect data entry template
            ├── missing_items.md           ← Missing documents checklist template
            ├── status_summary.md          ← Client case status summary template
            └── client_email_es.md         ← 7 Spanish email draft templates
```

### What Each File Does

| File | Purpose |
|------|---------|
| `agents/tagercom/README.md` | Spanish-language overview of the agent: inputs, outputs, jurisdictions, and quick-start guide |
| `agents/tagercom/system_prompt.md` | The complete LLM system prompt that defines Tagercom's behavior, rules, and capabilities. This is the core of the agent. |
| `agents/tagercom/workflow.md` | Step-by-step workflow covering all 5 phases: data intake, analysis, report generation, client communication, and case closure |
| `templates/proconnect_report.md` | Structured template mapping QuickBooks/financial data to Form 1120/1120-S lines, plus NY and PR sections, for direct ProConnect entry |
| `templates/missing_items.md` | Prioritized checklist (Critical / Important / Optional) of all documents and data that may be missing from a client's file |
| `templates/status_summary.md` | Executive dashboard showing completion percentage per jurisdiction, preliminary tax results, upcoming deadlines, and open action items |
| `templates/client_email_es.md` | Seven ready-to-customize Spanish email templates covering: document requests, receipt confirmations, status updates, IRS notice explanations, deadline reminders, signature requests, and final delivery |

---

## Important Notes

- Tagercom **does not** make final legal or tax decisions. All outputs must be reviewed by a licensed tax professional (CPA/EA) before use.
- Client data is confidential. Do not share outputs with unauthorized third parties.
- Filing deadlines in `workflow.md` and generated calendars must be verified against the current IRS, NYDTF, and Hacienda PR tax calendars each year.
