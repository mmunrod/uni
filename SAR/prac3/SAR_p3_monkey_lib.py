#!/usr/bin/env python
#! -*- encoding: utf8 -*-
# 3.- Mono Library

import pickle
import random
import re
import sys
from typing import List, Optional, TextIO

## Nombres: Clara Fangli Caudeli Soriano, Mara Munera Rodrigues

########################################################################
########################################################################
###                                                                  ###
###  Todos los métodos y funciones que se añadan deben documentarse  ###
###                                                                  ###
########################################################################
########################################################################


def convert_to_lm_dict(d: dict):
    for k in d:
        l = sorted(((y, x) for x, y in d[k].items()), reverse=True)
        d[k] = (sum(x for x, _ in l), l)


class Monkey():

    def __init__(self):
        self.r1 = re.compile('[.;?!]')
        self.r2 = re.compile('\W+')
        self.info = {}

    def get_n(self):
        return self.info.get('n', 0)

    def index_sentence(self, sentence: str):
        """
        Procesa una oración, extrae n-gramas desde el nivel 2 hasta n, y contabiliza
        las frecuencias absolutas de cada palabra objetivo dado su contexto histórico.

        :param sentence: Cadena de texto que representa una oración individual.
        :return: None
        """
        n = self.info['n']
        sentence_clean = self.r2.sub(" ", sentence.lower()) #solo letras y números, el resto se convierte en espacios
        tokens = sentence_clean.split()
        
        if not tokens:
            return
            
        for i in range(2, n + 1):
            padded_tokens = ['$'] * (i - 1) + tokens + ['$']
            for j in range(len(padded_tokens) - i + 1):
                context = tuple(padded_tokens[j : j + i - 1])
                target = padded_tokens[j + i - 1]
                
                if context not in self.info['lm'][i]:
                    self.info['lm'][i][context] = {}
                    
                self.info['lm'][i][context][target] = self.info['lm'][i][context].get(target, 0) + 1
        
        

    def compute_lm(self, filenames: List[str], lm_name: str, n: int):
        """
        Orquesta la creación del modelo de lenguaje leyendo los archivos proporcionados,
        dividiendo el texto en oraciones e indexando las probabilidades de los n-gramas.

        :param filenames: Lista de rutas de los archivos de texto a procesar.
        :param lm_name: Nombre identificativo para el modelo de lenguaje.
        :param n: Grado máximo de n-gramas a calcular.
        :return: None
        """
        self.info = {'name': lm_name, 'filenames': filenames, 'n': n, 'lm': {}}
        
        for i in range(2, n + 1):
            self.info['lm'][i] = {}
            
        for filename in filenames:
            with open(filename, encoding='utf-8') as fh:
                text = fh.read()
                paragraphs = text.split('\n\n')
                for p in paragraphs:
                    sentences = self.r1.split(p)
                    for sentence in sentences:
                        self.index_sentence(sentence)
                        
        for i in range(2, n + 1):
            convert_to_lm_dict(self.info['lm'][i])

    def load_lm(self, filename:str):
        with open(filename, "rb") as fh:
            self.info = pickle.load(fh)

    def save_lm(self, filename:str):
        with open(filename, "wb") as fh:
            pickle.dump(self.info, fh)

    def save_info(self, filename:str):
        with open(filename, "w", encoding='utf-8', newline='\n') as fh:
            self.print_info(fh=fh)

    def show_info(self):
        self.print_info(fh=sys.stdout)

    def print_info(self, fh:TextIO):
        print("#" * 20, file=fh)
        print("#" + "INFO".center(18) + "#", file=fh)
        print("#" * 20, file=fh)
        print(f"language model name: {self.info['name']}", file=fh)
        print(f'filenames used to learn the language model: {self.info["filenames"]}', file=fh)
        print("#" * 20, file=fh)
        print(file=fh)
        for i in range(2, self.info['n']+1):
            print("#" * 20, file=fh)
            print("#" + f'{i}-GRAMS'.center(18) + "#", file=fh)
            print("#" * 20, file=fh)
            for prev in sorted(self.info['lm'][i].keys()):
                wl = self.info['lm'][i][prev]
                print(f"'{' '.join(prev)}'\t=>\t{wl[0]}\t=>\t{', '.join(['%s:%s' % (x[1], x[0]) for x in wl[1]])}" , file=fh)


    def generate_sentences(self, n: Optional[int], nsentences: int = 10, prefix: Optional[str] = None):
        """
        Genera texto estocástico basado en las probabilidades condicionales del modelo 
        de lenguaje, partiendo opcionalmente de un prefijo inicial.

        :param n: Grado del n-grama a utilizar para la predicción.
        :param nsentences: Número total de oraciones independientes a generar.
        :param prefix: Cadena de texto inicial para condicionar la generación.
        :return: None
        """
        if n is None:
            n = self.info['n']
            
        for _ in range(nsentences):
            if prefix is None:
                sentence_words = []
                tokens = ['$'] * (n - 1)
            else:
                pref_clean = self.r2.sub(' ', prefix.lower()).strip()
                sentence_words = pref_clean.split()
                if len(sentence_words) < n - 1:
                    tokens = ['$'] * (n - 1 - len(sentence_words)) + sentence_words
                else:
                    tokens = sentence_words[-(n - 1):]

            for _ in range(50):
                prev = tuple(tokens[-(n - 1):])
                
                if prev not in self.info['lm'][n]:
                    break
                    
                total, candidates = self.info['lm'][n][prev]
                weights = [c[0] for c in candidates]
                words = [c[1] for c in candidates]
                
                next_word = random.choices(words, weights=weights)[0]
                
                if next_word == '$':
                    break
                    
                sentence_words.append(next_word)
                tokens.append(next_word)

            sentence = " ".join(sentence_words)
            print(sentence)

    


if __name__ == "__main__":
    print("Este fichero es una librería, no se puede ejecutar directamente")