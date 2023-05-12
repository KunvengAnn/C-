import sys
from translate import Translator   # thiếu thư viện, cần cài

lang1 = sys.argv[1]
lang2 = sys.argv[2]
txt = sys.argv[3]

translator= Translator(from_lang=lang1, to_lang=lang2)
kq = translator.translate(txt)

f = open("kq.txt", "w", encoding="utf-8")
f.write(kq)
f.close()

#print (kq)