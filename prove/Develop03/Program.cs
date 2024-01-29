using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureHider
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no bcommandments unto the children of men, save he shall cprepare a way for them that they may accomplish the thing which he commandeth them."),
                new Scripture("D&C 82:10", "I, the Lord, am abound when ye do what I say; but when ye do not what I say, ye have no bpromise."),
                new Scripture("Alma 32:13", "And now, because ye are compelled to be humble blessed are ye; for a man sometimes, if he is compelled to be humble, seeketh arepentance; and now surely, whosoever repenteth shall find mercy; and he that findeth mercy and bendureth to the end the same shall be saved."),
            };

            foreach (var scripture in scriptures)
            {
                scripture.HideWords();
                Console.ReadLine();
            }
        }
    }

    public class Scripture {
        private Reference _reference;
        private string _text;
        private List<Word> _words;
        private Random _random;

        public Scripture(string reference, string text) {
            _reference = new Reference(reference);
            _text = text;
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
            _random = new Random();
        }

        public void HideWords() {
            while (!_words.TrueForAll(w => w.IsHidden)) {
                List<Word> unhiddenWords = _words.Where(w => !w.IsHidden).ToList();
                if (unhiddenWords.Count > 0) {
                  int index = _random.Next(unhiddenWords.Count);
                 unhiddenWords[index].Hide();
            }
            ClearConsole();
            Display();
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit") {
            break;
            }
        }
    }

        public void Display() {
            Console.WriteLine(_reference);
            Console.WriteLine(_text);
            Console.WriteLine("-------------------------");
            foreach (Word word in _words) {
                Console.Write(word.Text + " ");
            }
            Console.WriteLine();
        }

        private void ClearConsole() {
            Console.Clear();
            Console.WriteLine("Press enter to continue:");
        }
    }

    public class Reference {
        private string _reference;

        public Reference(string reference) {
            _reference = reference;
        }

        public override string ToString() {
            return _reference;
        }
    }

    public class Word {
        private string _text;
        private bool _isHidden;

        public Word(string text) {
            _text = text;
            _isHidden = false;
        }

        public string Text {
            get {
                if (_isHidden) {
                    return "____";
                } else {
                    return _text;
                }
            }
        }

        public bool IsHidden {
            get {
                return _isHidden;
            }
            set {
                _isHidden = value;
            }
        }

        public void Hide() {
            _isHidden = true;
        }
    }
}