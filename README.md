# word-password-generator

Console application to generate word based passwords. It uses **Mnemonicodes**, which is a method for encoding binary data into a sequence of words which can be spoken over the phone, for example, and converted back to data on the other side.

The code showcases some new .Net 6 features such as the new console templates, and use of the in-built (well MS based) command line parameter parsing.

- https://github.com/dotnet/command-line-api
- https://aka.ms/new-console-template


## Examples

```
 .\word-password-generator.exe
clark-biscuit-spoon

.\word-password-generator.exe -w 3
ramirez-square-brush

.\word-password-generator.exe -w 4
method-regard-cuba-acid

.\word-password-generator.exe -w 5
client-heroic-mirage-mimic-imagine

.\word-password-generator.exe -d "#"
simon#prime#bombay

.\word-password-generator.exe -d "#" -w 5
nato#current#major#import#spend
```

### Mnemonicodes

Mnemonic tries to do better than stand OTP codes etc, by being more selective about its word list. Its criteria are thus:

Mandatory Criteria:

- The wordlist contains 1626 words.
- All words are between 4 and 7 letters long.
- No word in the list is a prefix of another word (e.g. visit, visitor).
- Five letter prefixes of words are sufficient to be unique.

Less Strict Criteria:

- The words should be usable by people all over the world. The list is far from perfect in that respect. It is heavily biased towards western culture and English in particular. The international vocabulary is simply not big enough. One can argue that even words like "hotel" or "radio" are not truly international. You will find many English words in the list but I have tried to limit them to words that are part of a beginner's vocabulary or words that have close relatives in other european languages. In some cases a word has a different meaning in another language or is pronounced very differently but for the purpose of the encoding it is still ok - I assume that when the encoding is used for spoken communication both sides speak the same language.

- The words should have more than one syllable. This makes them easier to recognize when spoken, especially over a phone line. Again, you will find many exceptions. For one syllable words I have tried to use words with 3 or more consonants or words with diphthongs, making for a longer and more distinct pronounciation. As a result of this requirement the average word length has increased. I do not consider this to be a problem since my goal in limiting the word length was not to reduce the average length of encoded data but to limit the maximum length to fit in fixed-size fields or a terminal line width.

- No two words on the list should sound too much alike. Soundalikes such as "sweet" and "suite" are ruled out. One of the two is chosen and the other should be accepted by the decoder's soundalike matching code or using explicit aliases for some words.

- No offensive words. The rule was to avoid words that I would not like to be printed on my business card. I have extended this to words that by themselves are not offensive but are too likely to create combinations that someone may find embarrassing or offensive. This includes words dealing with religion such as "church" or "jewish" and some words with negative meanings like "problem" or "fiasco". I am sure that a creative mind (or a random number generator) can find plenty of embarrasing or offensive word combinations using only words in the list but I have tried to avoid the more obvious ones. One of my tools for this was simply a generator of random word combinations - the problematic ones stick out like a sore thumb.

- Avoid words with tricky spelling or pronounciation. Even if the receiver of the message can probably spell the word close enough for the soundalike matcher to recognize it correctly I prefer avoiding such words. I believe this will help users feel more comfortable using the system, increase the level of confidence and decrease the overall error rate. Most words in the list can be spelled more or less correctly from hearing, even without knowing the word.

- The word should feel right for the job. I know, this one is very subjective but some words would meet all the criteria and still not feel right for the purpose of mnemonic encoding. The word should feel like one of the words in the radio phonetic alphabets (alpha, bravo, charlie, delta etc).
