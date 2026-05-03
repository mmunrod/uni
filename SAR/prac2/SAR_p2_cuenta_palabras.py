#! -*- encoding: utf8 -*-

#Clara Fangli Caudeli Soriano
#Marta Munera Rodrigues 

########################################################################
########################################################################
###                                                                  ###
###  Todos los métodos y funciones que se añadan deben documentarse  ###
###                                                                  ###
########################################################################
########################################################################

import argparse
import re
import sys
import math
import json

def sort_dic_by_values(d, asc=True):
    return sorted(d.items(), key=lambda a: (-a[1], a[0]))

def get_ngrams(l, n, add_marks=False):
    if add_marks:
        l.append('$')
        l.insert(0, '$')
    ngrams = []
    for i in range(len(l)-n+1):
        ngrams.append(l[i:i+n])
    return ngrams

class WordCounter:

    def __init__(self):
        """
           Constructor de la clase WordCounter
        """
        self.clean_re = re.compile('\W+')

    def write_stats_text(self, filename, stats, use_stopwords, full):
        """
        Este método escribe en texto plano las estadísticas de un fichero.
            
        :param 
            filename: el nombre del fichero destino.
            stats: las estadísticas del texto.
            use_stopwords: booleano, si se han utilizado stopwords.
            full: boolean, si se deben mostrar las stats completas.

        :return: None
        """
        
        def formatear_lista(lista_tuplas, es_full):
            """
            Función auxiliar para formatear una lista de tuplas en una cadena de texto multilínea.
            Aplica el límite de 20 elementos si no se ha solicitado la salida completa,
            e indenta cada par clave-valor con un tabulador.

            :param
                lista_tuplas: lista de elementos (clave, valor) a formatear.
                es_full: booleano que indica si se debe devolver la lista entera o solo los primeros 20.
            :return: string con los elementos formateados, uno por línea.
            """
            
            elementos = lista_tuplas if es_full else lista_tuplas[:20]
            if not elementos:
                return ""
            
            resultado = ""
            for k, v in elementos:
                resultado += f"\n\t{k}: {v}"
            return resultado

        res = f"Lines: {stats['nlines']}\n"
        res += f"Number words (including stopwords): {stats['nwords']}\n"
        
        if use_stopwords:
            res += f"Number words (excluding stopwords): {stats['nwordsNoStopWords']}\n" 
            
        res += f"Vocabulary size: {len(stats['vocabulary'])}\n"
        res += f"Number of symbols: {stats['nsymbols']}\n"
        res += f"Number of different symbols: {stats['ndistinctsymbols']}\n"
        
        if 'entropy' in stats and stats['entropy'] is not None:
            res += f"Shannon entropy: {stats['entropy']:.4f} bits/symbol\n" 
            res += f"Redundancy: {stats['redundancy'] * 100:.2f}%\n"

        res += f"Words (alphabetical order):{formatear_lista(sorted(stats['word'].items()), full)}\n"
        res += f"Words (by frequency):{formatear_lista(sort_dic_by_values(stats['word']), full)}\n"
        res += f"Symbols (alphabetical order):{formatear_lista(sorted(stats['symbol'].items()), full)}\n"
        res += f"Symbols (by frequency):{formatear_lista(sort_dic_by_values(stats['symbol']), full)}\n"
        
        if 'biword' in stats:
            res += f"Word Bigrams (alphabetical order):{formatear_lista(sorted(stats['biword'].items()), full)}\n"
            res += f"Word Bigrams (by frequency):{formatear_lista(sort_dic_by_values(stats['biword']), full)}\n"
            res += f"Symbol Bigrams (alphabetical order):{formatear_lista(sorted(stats['bisymbol'].items()), full)}\n"
            res += f"Symbol Bigrams (by frequency):{formatear_lista(sort_dic_by_values(stats['bisymbol']), full)}\n"

        with open(filename, 'w', encoding='utf-8') as fh:
            fh.write(res)

    def write_stats_json(self, filename, source_file, stats, lower, use_stopwords, full):
        """
        Este método escribe en formato JSON las estadísticas de un fichero.
            
        :param 
            filename: el nombre del fichero destino.
            source_file: el nombre del fichero fuente.
            stats: las estadísticas del texto.
            use_stopwords: booleano, si se han utilizado stopwords.
            full: boolean, si se deben mostrar las stats completas.

        :return: None
        """
        
        js = {
            "metadata": {
                "source_file": source_file,
                "options": {
                    "lower": lower, 
                    "stopwords": use_stopwords,
                    "bigrams": 'biword' in stats,
                    "entropy": 'entropy' in stats and stats['entropy'] is not None
                }
            },
            "basic_stats": {
                "lines": stats['nlines'],
                "words": stats['nwords'],
                "vocab_size": len(stats['vocabulary']), 
                "symbols": stats['nsymbols'],
                "unique_symbols": stats['ndistinctsymbols']
            }
        }

        if use_stopwords:
            js["basic_stats"]["words_no_stopwords"] = stats['nwordsNoStopWords']

        if 'entropy' in stats and stats['entropy'] is not None:
            js["entropy_analysis"] = {
                "shannon_entropy": stats['entropy'],
                "redundancy": stats['redundancy']
            }

        js["top_words"] = dict(sort_dic_by_values(stats['word'])) if full else dict(sort_dic_by_values(stats['word'])[:20])
        js["top_symbols"] = dict(sort_dic_by_values(stats['symbol'])) if full else dict(sort_dic_by_values(stats['symbol'])[:20])

        if 'biword' in stats:
            js["top_biwords"] = dict(sort_dic_by_values(stats['biword'])) if full else dict(sort_dic_by_values(stats['biword'])[:20])
            js["top_bisymbols"] = dict(sort_dic_by_values(stats['bisymbol'])) if full else dict(sort_dic_by_values(stats['bisymbol'])[:20])

        with open(filename, 'w', encoding='utf-8') as fh:
            json.dump(js, fh, indent=4, ensure_ascii=False)




    def file_stats(self, filename, lower, stopwordsfile, bigrams, full, entropy, use_json):
        """
        Este método calcula las estadísticas de un fichero de texto

        :param 
            filename: el nombre del fichero.
            lower: booleano, se debe pasar todo a minúsculas?
            stopwordsfile: nombre del fichero con las stopwords o None si no se aplican
            bigram: booleano, se deben calcular bigramas?
            full: booleano, se deben montrar la estadísticas completas?
            entropy: booleano, se debe calcular la entropía de Shannon?
            use_json: booleano, se debe mostrar las estadísticas en formato JSON?
        :return: None
        """

        if stopwordsfile is None:
            stopwords = []
        else:
            contenido_stop = open(stopwordsfile, encoding='utf-8').read()
            if lower:
                contenido_stop = contenido_stop.lower()
            stopwords = contenido_stop.split()

        # variables for results

        sts = {
                'nwords': 0,
                'nlines': 0,
                'vocabulary':0,
                'nsymbols':0,
                'ndistinctsymbols':0,
                'word': {},
                'symbol': {},
                }
        if stopwords is not None :
            sts['nwordsNoStopWords'] = 0


        if bigrams:
            sts['biword'] = {}
            sts['bisymbol'] = {}

        if entropy:
            sts['entropy'] = None
            sts['redundancy'] = None

        f = open(filename, encoding ='utf-8').read()

        if lower:
            f = f.lower()

        lines = f.splitlines()
        sts['nlines'] = len(lines)

        texto_limpio = self.clean_re.sub(' ', f)

        words = texto_limpio.split()
        totalWords = len(words)
        sts['nwords'] = totalWords
                

        if stopwords:
            words = [w for w in words if w not in stopwords]

        words_no_stopwords = len(words)
        vocabulary = set(words)
        caracteres = "".join(words)
        caracteres_totales = len(caracteres)
        caracteres_distintos = len(set(caracteres))

        if bigrams:
            freqBigramP = {}
            for l in lines:
                l = self.clean_re.sub(' ', l).split()
                bigramP = get_ngrams(l, 2, True)
                for b in bigramP:
                    b_str = " ".join(b)
                    freqBigramP[b_str] = freqBigramP.get(b_str, 0) + 1
            sts['biword'] = freqBigramP

            freqBigramL = {}
            for w in words:
                bigramL = get_ngrams(w, 2)
                for b in bigramL:
                    b_str = "".join(b)
                    freqBigramL[b_str] = freqBigramL.get(b_str, 0) + 1
            sts['bisymbol'] = freqBigramL

        if entropy:
            p = [caracteres.count(c)/caracteres_totales for c in set(caracteres)]
            ent = -sum([x*math.log2(x) for x in p])
            red = 1 - ent/math.log2(caracteres_distintos)
            sts['entropy'] = ent
            sts['redundancy'] = red
        
        sts['vocabulary'] = vocabulary
        sts['nsymbols'] = caracteres_totales
        sts['ndistinctsymbols'] = caracteres_distintos
        sts['nwordsNoStopWords'] = words_no_stopwords
            
        word_freq = {}
        for word in words:
            word_freq[word] = word_freq.get(word,0) + 1

        caracter_freq = {}
        for c in caracteres:
            caracter_freq[c] = caracter_freq.get(c,0) + 1

        for k in word_freq:
            sts['word'][k] = word_freq[k]
    
        for k in caracter_freq:
            sts['symbol'][k] = caracter_freq[k]

        options = ""
        if lower: options += "l"
        if stopwordsfile: options += "s"
        if bigrams: options += "b"
        if full: options += "f"
        if entropy: options += "e"
        if use_json: options += "j"

        extension = ""
        if use_json: 
            extension = ".json"
        else: 
            extension = ".txt"

        new_filename = filename.rsplit('.', 1)[0] if '.' in filename else filename
        
        if options == "":
            new_filename = new_filename + "_stats" + extension
        else:
            new_filename = new_filename + "_" + options + "_stats" + extension
        
       
        if use_json:
            self.write_stats_json(new_filename, filename, sts, lower, stopwordsfile is not None, full)
        else:
            self.write_stats_text(new_filename, sts, stopwordsfile is not None, full)


    def compute_files(self, filenames, **args):
        """
        Este método calcula las estadísticas de una lista de ficheros de texto

        :param 
            filenames: lista con los nombre de los ficheros.
            args: argumentos que se pasan a "file_stats".

        :return: None
        """

        for filename in filenames:
            self.file_stats(filename, **args)

if __name__ == "__main__":

    parser = argparse.ArgumentParser(description='Compute comprehensive statistics from text files.')
    parser.add_argument('file', metavar='file', type=str, nargs='+',
                        help='text files to analyze.')

    parser.add_argument('-l', '--lower', dest='lower',
                        action='store_true', default=False, 
                        help='lowercase all words before computing stats.')

    parser.add_argument('-s', '--stop', dest='stopwords', action='store',
                        help='filename with the stopwords.')

    parser.add_argument('-b', '--bigram', dest='bigram',
                        action='store_true', default=False, 
                        help='compute bigram stats.')

    parser.add_argument('-f', '--full', dest='full',
                        action='store_true', default=False, 
                        help='show full stats (instead of top 20).')
    
    parser.add_argument('-e', '--entropy', dest='entropy',
                        action='store_true', default=False, 
                        help='compute Shannon entropy and redundancy.')
    
    parser.add_argument('-j', '--json', dest='json',
                        action='store_true', default=False,
                        help='output statistics in JSON format.')

    args = parser.parse_args()
    wc = WordCounter()
    wc.compute_files(args.file,
                     lower=args.lower,
                     stopwordsfile=args.stopwords,
                     bigrams=args.bigram,
                     full=args.full,
                     entropy=args.entropy,
                     use_json=args.json)