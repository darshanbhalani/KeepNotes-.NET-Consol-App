using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;

namespace KeepNotes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                int n;
                do
                {
                    Console.WriteLine(new string('_', 20));
                    Console.WriteLine(new string('_', 20));
                    Console.WriteLine($"-::KEEP NOTES ::-");
                    Console.WriteLine(new string('_', 20));
                    Console.WriteLine(new string('_', 20));
                    Console.WriteLine("Press");
                    Console.WriteLine("1 for Add Note");
                    Console.WriteLine("2 for Delete Note");
                    Console.WriteLine("3 for Update Note");
                    Console.WriteLine("4 for View Note");
                    Console.WriteLine("0 for Exit");
                    Console.WriteLine(new string('_', 20));
                    Console.Write("⭕ => ");
                    n = Convert.ToInt32(Console.ReadLine());

                    NotesHandler notesHandle = new NotesHandler();
                    switch (n)
                    {
                        case 1:
                            notesHandle.AddNote();
                            break;
                        case 2:
                            notesHandle.DeleteNote();
                            break;
                        case 3:
                            notesHandle.UpdateNote();
                            break;
                        case 4:
                            notesHandle.ViewNote();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("⚠️ Enter Valid Input...");
                            break;
                    }
                } while (n != 0);
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
        }
    }
}
