using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
//Завдання 1:
//Створіть додаток для роботи з колекцією віршів, який 
//зберігатиме таку інформацію:
// назва вірша;
// П.І.Б.автора;
// рік написання;
// текст вірша;
// тема вірша.
//Додаток має давати можливість:
// додавати вірші;
// видаляти вірші;
// змінювати інформацію про вірші;
// шукати вірш за різними характеристиками;
// зберігати колекцію віршів у файл;
// завантажувати колекцію віршів з файлу.
namespace hw_06_07
{
    public class Poem
    {
        public string Title { get; set; }
        public string PIB { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }

        public Poem(string title, string pIB, int year, string text, string subject)
        {
            Title = title;
            PIB = pIB;
            Year = year;
            Text = text;
            Subject = subject;
        }
        public override string ToString() => $"TITLE: {Title}, PIB: {PIB}, Year: {Year}, Text: {Text}, Subject: {Subject}";

    }
    public class CollectionPoem
    {
        private List<Poem> _poems = new List<Poem>();

        public void AddPoems(Poem poem)
        {
            _poems.Add(poem);
        }
        public bool RemovePoems(string title)
        {
            Poem remover = _poems.Find(x => x.Title == title);
            if (remover != null) 
            { 
                _poems.Remove(remover);
                return true;
            }
            return false;
        }

        public void SaveToFile(string filename)
        {
            string json = JsonSerializer.Serialize(_poems);
            File.WriteAllText(filename, json);
        }

        public void LoadFromFile(string filepath)
        {
            if (File.Exists(filepath))
            {
                string fileRead = File.ReadAllText(filepath);
                _poems = JsonSerializer.Deserialize<List<Poem>>(fileRead);

            }
            else
            {
                throw new Exception(filepath);
            }
        }

        public bool UpdateTitle(string currentTitle, string newTitle)
        {
            Poem poem = FindByTitle(currentTitle);
            if (poem != null)
            {
                poem.Title = newTitle;
                return true;
            }
            return false;
        }

        public bool UpdatePIB(string title, string newPIB)
        {
            Poem poem = FindByTitle(title);
            if (poem != null)
            {
                poem.PIB = newPIB;
                return true;
            }
            return false;
        }

        public bool UpdateYear(string title, int newYear)
        {
            Poem poem = FindByTitle(title);
            if (poem != null)
            {
                poem.Year = newYear;
                return true;
            }
            return false;
        }

        public bool UpdateText(string title, string newText)
        {
            Poem poem = FindByTitle(title);
            if (poem != null)
            {
                poem.Text = newText;
                return true;
            }
            return false;
        }

        public bool UpdateSubject(string title, string newSubject)
        {
            Poem poem = FindByTitle(title);
            if (poem != null)
            {
                poem.Subject = newSubject;
                return true;
            }
            return false;
        }
        public Poem FindByTitle(string title)
        {
            return _poems.Find(x => x.Title == title);
        }

        
        public List<Poem> FindByAuthor(string author)
        {
            return _poems.FindAll(x => x.PIB == author);
        }

        
        public List<Poem> FindByYear(int year)
        {
            return _poems.FindAll(x => x.Year == year);
        }

        
        public List<Poem> FindBySubject(string subject)
        {
            return _poems.FindAll(x => x.Subject == subject);
        }

        
        
        public void Show()
        {
            foreach(var item in  _poems) 
            {
                Console.WriteLine(item);
            }
        }
    }

}
