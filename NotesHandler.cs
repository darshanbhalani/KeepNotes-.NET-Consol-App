using Newtonsoft.Json;
using NodaTime;

namespace KeepNotes
{
    internal class NotesHandler
    {
        private string jsonDataFilePath = @"C:\\Users\\DARSHAN BHALANI\\Desktop\\Temp C#\\Data.json";
        
        private List<Note> notesList;
        private void fatchNotes()
        {
            string jsonString = File.ReadAllText(jsonDataFilePath);
            notesList = JsonConvert.DeserializeObject<List<Note>>(jsonString);
        }
        public void AddNote()
        {
            Note note = new Note();

            note.noteId = DateTime.UtcNow.Ticks.ToString();

            Console.Write("Title :- ");
            note.title = Console.ReadLine();

            Console.Write("Description :- ");
            note.description = Console.ReadLine();

            char c;
            
                Console.Write("You want to save note ? (y/n) :- ");
                c = Convert.ToChar(Console.ReadLine());

                switch (c)
                {
                    case 'y':
                case 'Y':
                        SaveNote(note.noteId, note.title, note.description);
                        break;
                    case 'N':
                    case 'n':
                        break;
                    default:
                        Console.WriteLine("Enter valid input...");
                        break;
                }
        }
        public void DeleteNote() {
            Console.Write("Enter id :- ");
            string id = Convert.ToString(Console.ReadLine());   
            fatchNotes();
            int index = notesList.FindIndex(note => note.noteId == id);
            if (index != -1)
            {
                notesList.RemoveAt(index);
                string updatedJsonData = JsonConvert.SerializeObject(notesList, Formatting.Indented);
                File.WriteAllText(jsonDataFilePath, updatedJsonData);
                Console.WriteLine("Note deleted successfully...");
            }
            else
            {
                Console.WriteLine("Note not found...");
            }
        }
        public void UpdateNote() {
            Console.Write("Enter id :- ");
            string id = Convert.ToString(Console.ReadLine());
            fatchNotes();
            int index = notesList.FindIndex(note => note.noteId == id);
            if (index != -1)
            {
                char c;
                Console.Write("New Title :- ");
                string tempTitle = Console.ReadLine();

                Console.Write("New Description :- ");
                string tempDescription = Console.ReadLine();
                
                Console.Write("You want to save note ? (y/n) :- ");
                c = Convert.ToChar(Console.ReadLine());

                switch (c)
                {
                    case 'y':
                    case 'Y':
                        notesList[index].title = tempTitle;
                        notesList[index].description = tempDescription;
                        notesList[index].updateAt = DateTime.Now;
                        string updatedJsonData = JsonConvert.SerializeObject(notesList, Formatting.Indented);
                        File.WriteAllText(jsonDataFilePath, updatedJsonData);
                        Console.WriteLine("Note updated successfully...");
                        fatchNotes();
                        break;
                    case 'N':
                    case 'n':
                        break;
                    default:
                        Console.WriteLine("Enter valid input...");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Note not found...");
            }
        }
        public void ViewNote()
        {
            fatchNotes();
            Console.WriteLine(new string('_', 20));
            foreach (var note in notesList)
            {
                Console.WriteLine($"Note ID: {note.noteId}");
                Console.WriteLine($"Title: {note.title}");
                Console.WriteLine($"Description: {note.description}");
                Console.WriteLine($"Created At: {note.createAt}");
                Console.WriteLine($"Updated At: {note.updateAt}");
                Console.WriteLine();
            }
            Console.WriteLine(new string('_', 20));
        }
        public void SaveNote(string noteId, string title, string description)
        {
            Note newData = new Note
            {
                noteId = noteId,
                title = title,
                description = description,
                createAt = DateTime.Now,
                updateAt = DateTime.Now
            };

            fatchNotes();
            notesList.Add(newData);
            string updatedJsonData = JsonConvert.SerializeObject(notesList, Formatting.Indented);
            File.WriteAllText(jsonDataFilePath, updatedJsonData);
            Console.WriteLine("Note Saved...");
        }
    }
}

