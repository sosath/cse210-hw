using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            string[] parts = text.Split(' ');
            foreach (string part in parts)
            {
                _words.Add(new Word(part));
            }
        }

        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            
            int actualToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < actualToHide; i++)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        public string GetDisplayText()
        {
            string scriptureText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
            return $"{_reference.GetDisplayText()} {scriptureText}";
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}