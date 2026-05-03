from __future__ import annotations
from typing import Any, Dict, List
import os
from duckduckgo_search import DDGS
from dotenv import load_dotenv
from fpdf import FPDF
import json
import wikipedia
import trafilatura


load_dotenv()

try:
    # Newer docs often show this path.
    from google.adk.agents.llm_agent import Agent  # type: ignore
except Exception:  # pragma: no cover
    from google.adk.agents import Agent  # type: ignore

from google.adk.models.lite_llm import LiteLlm 


def web_search_tool(topic: str) -> Dict[str, Any]:
    """
    Realiza una búsqueda real en internet sobre un tema específico.
    Devuelve un resumen de los resultados y enlaces para fundamentar el informe.
    """
    print(f"\n[DEBUG] Buscando fuentes unificadas para: '{topic}'")
    sources = []
    
    # Búsqueda en Wikipedia
    try:
        wikipedia.set_lang("es")
        wiki_results = wikipedia.search(topic, results=3)
        for title in wiki_results:
            try:
                page = wikipedia.page(title, auto_suggest=False)
                sources.append({
                    "title": f"Wikipedia: {page.title}",
                    "url": page.url,
                    "source": "wikipedia"
                })
            except Exception:
                continue
    except Exception as e:
        print(f"[DEBUG] Wikipedia no disponible: {e}")

    # Búsqueda en DuckDuckGo
    try:
        with DDGS() as ddgs:
            ddg_results = ddgs.text(
                f"{topic} guía técnica",
                region='es-es',
                safesearch='moderate',
                max_results=5
            )
            for r in ddg_results:
                sources.append({
                    "title": r['title'],
                    "url": r['href'],
                    "source": "web"
                })
    except Exception as e:
        print(f"[DEBUG] DuckDuckGo no disponible: {e}")

    if not sources:
        return {"error": "No se han encontrado fuentes relevantes en ninguna plataforma."}

    return {"found_sources": sources}


def fetch_content_tool(url: str) -> Dict[str, Any]:
    """
    Extrae el contenido textual detallado de una URL específica. 
    Usa esta herramienta sobre las mejores fuentes encontradas en web_search_tool.
    """
    print(f"[DEBUG] Extrayendo información de: {url}")
    
    # Caso especial: Wikipedia (mejor calidad vía API)
    if "wikipedia.org" in url:
        try:
            page_title = url.split('/')[-1]
            content = wikipedia.page(page_title, auto_suggest=False).content
            return {"url": url, "content": content[:4000]}
        except Exception:
            pass

    # Caso general: Webs externas
    try:
        downloaded = trafilatura.fetch_url(url)
        content = trafilatura.extract(downloaded)
        if content:
            return {"url": url, "content": content[:3000]}
        return {"error": "No se pudo extraer texto útil de esta URL."}
    except Exception as e:
        return {"error": f"Fallo al leer la web: {str(e)}"}
 

def create_pdf_report(
    title: str,
    sections: List[Dict[str, str]],
    references: List[str]
) -> Dict[str, Any]:
    """
    Crea un informe técnico en formato PDF con una estructura profesional.
    """
    print(f"[*] Generando archivo PDF: {title}...")
    
    try:
        # Carpeta de salida
        base_path = os.path.dirname(os.path.abspath(__file__))
        output_dir = os.path.join(base_path, "output")
        os.makedirs(output_dir, exist_ok=True)
        
        pdf = FPDF()
        pdf.set_auto_page_break(auto=True, margin=15)
        pdf.add_page()
        
        # Título del documento
        pdf.set_font("Times", 'B', 20)
        pdf.cell(
            0,
            20,
            title.encode('latin-1', 'replace').decode('latin-1'),
            ln=True,
            align='C'
        )
        pdf.ln(10)
        
        # Generar secciones
        for section in sections:
            pdf.set_font("Arial", 'B', 14)
            pdf.cell(
                0,
                10,
                section['name'].encode('latin-1', 'replace').decode('latin-1'),
                ln=True
            )
            
            pdf.set_font("Arial", '', 11)
            pdf.multi_cell(
                0,
                8,
                section['content'].encode('latin-1', 'replace').decode('latin-1')
            )
            pdf.ln(5)
            
        # Bibliografía
        if references:
            pdf.add_page()
            pdf.set_font("Arial", 'B', 14)
            pdf.cell(0, 10, "Bibliografía", ln=True)
            pdf.set_font("Arial", 'I', 10)
            for ref in references:
                pdf.multi_cell(
                    0,
                    6,
                    f"- {ref}".encode('latin-1', 'replace').decode('latin-1')
                )
                pdf.ln(2)

        # Guardar archivo
        filename = title.replace(' ', '_').replace('/', '').replace('\\', '') + ".pdf"
        pdf_path = os.path.join(output_dir, filename)
        pdf.output(pdf_path)

        json_path = create_json_report(title, sections, references, pdf_path)
        
        return {
            "status": "success",
            "pdf_path": pdf_path,
            "json_path": json_path,
            "message": f"El informe '{title}' se ha generado correctamente en {pdf_path}"
        }
        
    except Exception as e:
        return {"status": "error", "message": str(e)}

import pypandoc

def create_pdf_from_md(md_content: str, output_path: str):
    md_file = output_path.replace(".pdf", ".md")
    
    with open(md_file, "w", encoding="utf-8") as f:
        f.write(md_content)

    pypandoc.convert_file(
        md_file,
        'pdf',
        outputfile=output_path
    )

    return md_file, output_path
def create_json_report(
    title: str,
    sections: List[Dict[str, str]],
    references: List[str],
    pdf_path: str
) -> str:
    """
    Genera el archivo JSON con las estadísticas del informe para la evaluación automática.
    """
    print(f"[*] Generando estadísticas JSON para: {title}...")
    
    sections_stats = []
    total_words = 0
    
    for sec in sections:
        count = len(sec['content'].split())
        total_words += count
        sections_stats.append({
            "name": sec['name'],
            "word_count": count
        })
    
    report_map = {
        "title": title,
        "sections": sections_stats,
        "total_words": total_words,
        "num_sections": len(sections),
        "num_references": len(references),
        "pdf_path": pdf_path
    }
    
    json_path = pdf_path.replace(".pdf", ".json")
    with open(json_path, 'w', encoding='utf-8') as f:
        json.dump(report_map, f, ensure_ascii=False, indent=4)
        
    return json_path


def save_report_artifacts(report_data: Dict[str, Any]) -> Dict[str, Any]:
    """
    Tool envoltorio para que el agente guarde SIEMPRE el informe final
    en PDF y JSON a partir de un único objeto estructurado.
    """
    print("[*] save_report_artifacts invocado")

    title = str(report_data.get("title", "")).strip()
    sections = report_data.get("sections", [])
    references = report_data.get("references", [])

    if not title:
        return {"status": "error", "message": "Falta el campo 'title'."}

    if not isinstance(sections, list) or not sections:
        return {"status": "error", "message": "Falta una lista válida en 'sections'."}

    normalized_sections = []
    for sec in sections:
        if not isinstance(sec, dict):
            continue
        name = str(sec.get("name", "")).strip()
        content = str(sec.get("content", "")).strip()
        if name and content:
            normalized_sections.append({
                "name": name,
                "content": content
            })

    if not normalized_sections:
        return {"status": "error", "message": "No hay secciones válidas para generar el informe."}

    normalized_references = []
    if isinstance(references, list):
        for ref in references:
            ref_text = str(ref).strip()
            if ref_text:
                normalized_references.append(ref_text)

    return create_pdf_report(
        title=title,
        sections=normalized_sections,
        references=normalized_references
    )


# ---------------------------
# Root agent
# ---------------------------

root_agent = Agent(
    model=LiteLlm(
        model="openai/gpt-oss-120b",
        api_base="https://api.poligpt.upv.es/",
        api_key=os.getenv("OPENAI_API_KEY")
    ),

    name="root_agent",
    description=(
        "Agente especializado en investigar temas técnicos en la web y redactar "
        "informes estructurados con salida en formato PDF y JSON."
    ),
    instruction=(
        "Eres un Agente especializado en investigar temas técnicos en la web y redactar "
        "informes estructurados con salida en formato PDF y JSON.\n"
        "La extensión del documento preferiblemente debe ser mayor a 500 palabras, "
        "pero más importante la calidad de la información que la longitud.\n"
        "Tu prioridad es la veracidad y la estructura académica.\n\n"
        
        "Protocolo de Ejecución Paso a Paso:\n"
        "1. DESCUBRIMIENTO: Llama a `web_search_tool`.\n"
        
        "2. SELECCIÓN Y EXTRACCIÓN: De los resultados obtenidos, selecciona un máximo de 10 URLs que parezcan más técnicas. "
        "Llama a `fetch_content_tool` para cada una.\n"
        "   - IMPORTANTE: Si solo encuentras 1 o 2 fuentes válidas, PROCEDE con ellas. No entres en bucle buscando más.\n"
        "   - Si una URL falla, descártala y sigue con las demás.\n\n"
        
        "3. REDACCIÓN TÉCNICA (SÍNTESIS):\n"
        "   - Utiliza EXCLUSIVAMENTE la información extraída. No inventes datos.\n"
        "   - Si la información encontrada está en otro idioma, tradúcela a español.\n"
        "   - Estructura: Crea un título breve, una Introducción, un Desarrollo detallado (mínimo 2 secciones) y Conclusiones.\n"
        "   - Bibliografía: Crea una lista de strings con los títulos y URLs de las fuentes usadas.\n\n"
        
        "4. GENERACIÓN DE ENTREGABLES:\n"
        "   - Cuando tengas listo el informe, construye un único objeto con esta estructura:\n"
        "     {\n"
        '       "title": "Título del informe",\n'
        '       "sections": [\n'
        '         {"name": "Introducción", "content": "..."},\n'
        '         {"name": "Desarrollo 1", "content": "..."},\n'
        '         {"name": "Desarrollo 2", "content": "..."},\n'
        '         {"name": "Conclusiones", "content": "..."}\n'
        "       ],\n"
        '       "references": ["Fuente 1 - URL", "Fuente 2 - URL"]\n'
        "     }\n"
        "   - Llama OBLIGATORIAMENTE a la herramienta `save_report_artifacts(report_data)` con ese objeto completo.\n"
        "   - No finalices la conversación sin haber llamado a `save_report_artifacts`.\n"
        "   - Tras la llamada a `save_report_artifacts`, DEBES usar exactamente la información devuelta por la herramienta.\n"
        "   - NO inventes rutas.\n"
        "   - NO generes rutas manualmente.\n"
        "   - La respuesta final debe basarse únicamente en el resultado de la tool, incluyendo:\n"
        "     - pdf_path\n"
        "     - json_path\n"
        "   - Utiliza exactamente los campos `pdf_path` y `json_path` devueltos por la herramienta.\n\n"

        "FORMATO DE SALIDA:\n"
        "- No copies formato literal de páginas web.\n"
        "- No uses tablas Markdown.\n"
        "- No uses notación LaTeX (ej: \mu, \sigma, \Phi, \n, etc.).\n"
        "- Escribe siempre en texto plano claro.\n"
        "- Estructura el contenido usando:\n"
        "  - párrafos\n"
        "  - listas con guiones (-)\n"
        "  - líneas tipo 'Campo: valor'\n"
        
        "Restricciones y Control de Errores:\n"
        "- ANTI-ALUCINACIÓN: No inventes bibliografía. Si no hay datos, admítelo.\n"
        "- ANTI-BUCLE: Tienes prohibido realizar más de 10 llamadas a la herramienta `web_search_tool`.\n"
        "- IDIOMA: Responde y redacta siempre en español.\n"
        "- ÉXITO: Tu tarea termina únicamente cuando confirmes la ruta del PDF generado.\n"
        "- REGLA DE SINTAXIS: Al llamar a las herramientas, utiliza únicamente el nombre exacto de la función "
        "(ej: fetch_content_tool). No añadas prefijos, sufijos, comentarios ni tokens especiales dentro del nombre de la herramienta.\n"
),
    tools=[web_search_tool, fetch_content_tool, save_report_artifacts],
)