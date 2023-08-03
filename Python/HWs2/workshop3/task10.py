# В большой текстовой строке подсчитать количество встречаемых
# слов и вернуть 10 самых частых. Не учитывать знаки препинания
# и регистр символов. За основу возьмите любую статью
# из википедии или из документации к языку.

import re

text = '''In times of hardship, a well-led rebellion was infectious. Whether it was to survive or simply to vent their anger, many people were easily convinced to join the uprising.

The rebels first suppressed the local officers and took over the county governor’s office. They then went on to rob the rich and distributed food and gold among the poor. As they only robbed from people with a bad reputation and did not kill indiscriminately, many more supported their cause wholeheartedly. At the peak of their influence, the people had called them the “Common Men’s Army”.

When Suzhou’s General, Shen Tu Xu, received the news, he immediately deployed troops to contain the rebellion. However, many of his soldiers had relatives and family members who had joined the uprising. Furthermore, the rebel army had outnumbered his troops. Shen Tu Xu had no choice but to turn to Yejing for help.

Emperor An Qing was naturally enraged upon hearing the news.

Prior to this event, the Emperor was in high spirits. The newly inducted Taoist Master prophesied that he would face adversity this year. To resolve this, firstly, he would need someone close to him to ward off this misfortune and secondly, to build a 99 story pagoda to please the heavens. After that, he would be able to lead a long and prosperous life like that of the immortals.

Now that Emperor An Qing had fully trusted this Taoist Master, he certainly would not risk disobeying him. He enforced the construction of the pagoda under the excuse of praying for Da Ye but in fact, it was all for his own well being.

Now that a rebellion had arisen, an event which Emperor An Qing believed to be the foretold misfortune, only solidified his faith in the Taoist Master.

Although he had already followed his instructions to build the pagoda, Emperor An Qing was still not pacified. He hurriedly called for the Taoist Master to divine for him on who would help him ward off this disaster.

The Taoist Master who went by the name of Master Liao, had lived past the age of seventy; a longevity that earned him the respect of many. Although his hair and beard were all white, there was no weakness in his steps. He exuded divinity when walking into the room.'''


def count_words(text_str):
    text_str = re.sub(r'[^\w\s]', '', text_str).lower()
    words = text_str.split()
    word_count = {}
    for word in words:
        if word in word_count:
            word_count[word] += 1
        else:
            word_count[word] = 1
    sorted_words = sorted(word_count.items(), key=lambda x: x[1], reverse=True)
    return sorted_words[:10]


print(count_words(text))
