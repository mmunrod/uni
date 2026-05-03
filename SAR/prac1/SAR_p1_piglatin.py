#!/usr/bin/env python
#! -*- encoding: utf8 -*-

# 1.- Pig Latin

# Clara Fangli Caudeli Soriano
# Marta Munera Rodrigues

import re
import sys
from typing import Optional, Text
from os.path import isfile

class Translator():

    def __init__(self, punt:Optional[Text]=None):
        """
        Constructor de la clase Translator

        :param punt(opcional): una cadena con los signos de puntuación
                                que se deben respetar
        :return: el objeto de tipo Translator
        """
        if punt is None:
            punt = ".,;?!"
        self.re = re.compile(r"(\w+)([" + punt + r"]*)")

    def trans(self, word:Text) -> Text:
        word = word.lower()
        if word[0] in "aeiouy":
            return word + "yay"
        else:
            i = 0
            while word[i] not in "aeiouy":
                i += 1
            return word[i:] + word[0:i] + "ay"

    def translate_word(self, word:Text) -> Text:
        """
        Recibe una palabra en inglés y la traduce a Pig Latin

        :param word: la palabra que se debe pasar a Pig Latin
        :return: la palabra traducida
        """
        s = ""
        if word[len(word)-1] in ".,;?!":
            s = word[len(word)-1]
            word = word[0:len(word)-1]
        if not word[0].isalpha():
            new_word = word
        else:
            if word.isupper():
                new_word = self.trans(word).upper()
            elif word[0].isupper():
                new_word = self.trans(word).capitalize()
            else:
                new_word = self.trans(word)
        
        return new_word + s

    def translate_sentence(self, sentence:Text) -> Text:
        """
        Recibe una frase en inglés y la traduce a Pig Latin

        :param sentence: la frase que se debe pasar a Pig Latin
        :return: la frase traducida
        """
        words = sentence.split(" ")
        new_sentence = ""
        for word in words:
            new_sentence += self.translate_word(word) + " "
        
        new_sentence = new_sentence[0:len(new_sentence)-1]

        return new_sentence

    def translate_file(self, filename:Text):
        """
        Recibe un fichero y crea otro con su tradución a Pig Latin

        :param filename: el nombre del fichero que se debe traducir
        :return: None
        """
        
        if not isfile(filename):
            print(f'{filename} no existe o no es un nombre de fichero', file=sys.stderr)
        else:
            f = open(filename, "r", encoding="utf-8")
            aux = filename.split(".")
            res = open(aux[0] + "_latin.txt", "w", encoding="utf-8")
            lines = f.read().splitlines()
            for line in lines:
                sentence = self.translate_sentence(line)
                res.write(sentence + "\n")

if __name__ == "__main__":
    if len(sys.argv) > 2:
        print(f'Syntax: python {sys.argv[0]} [filename]')
        exit()
    t = Translator()
    if len(sys.argv) == 2:
        t.translate_file(sys.argv[1])
    else:
        sentence = input("ENGLISH: ")
        while len(sentence) > 1:
            print("PIG LATIN:", t.translate_sentence(sentence))
            sentence = input("ENGLISH: ")