using System;
using System.Text;

namespace FileIn
{
    public class FileHandler
    {
        private readonly string ByeWord = "EXIT";
        private readonly string DefaltFilePath = "command-line/file-input/data/mock_data.txt";

        public bool ReadUserInputWithCancel(out string buffer)
        {
            StringBuilder sb = new StringBuilder();
            var inputKey = Console.ReadKey();
            Console.TreatControlCAsInput = true;

            while (inputKey.Key != ConsoleKey.Escape && inputKey.Key != ConsoleKey.Enter)
            {
                sb.Append(inputKey.KeyChar);
                inputKey = Console.ReadKey();
            }

            Console.TreatControlCAsInput = false;

            buffer = sb.ToString();

            if (inputKey.Key == ConsoleKey.Enter)
                return true;
            else
                return false;

        }

        public bool ReadUserInputWithSave(out string buffer)
        {
            StringBuilder sb = new StringBuilder();
            var inputKey = Console.ReadKey();
            var ctrlS = ((inputKey.Modifiers & ConsoleModifiers.Control) != 0 && inputKey.Key == ConsoleKey.S);
            while (!ctrlS)
            {
                sb.Append(inputKey.KeyChar);
                inputKey = Console.ReadKey();
                ctrlS = ((inputKey.Modifiers & ConsoleModifiers.Control) != 0 && inputKey.Key == ConsoleKey.S);
            }

            buffer = sb.ToString();

            if (ctrlS)
                return false;
            else
                return true;

        }

        public void ReadFileFromDisk(string path)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaltFilePath;

            try
            {
                var text = System.IO.File.ReadAllText(@path);
                Console.WriteLine("Here it is what is in the file: \n");
                Console.WriteLine(text + "\n");
                Console.WriteLine("End of the file. \n");
                //var text = System.IO.File.ReadAllLines(@path);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Oops, Something went wrong while trying to read the file. The error is: [{0}]", e.Message);
            }
        }

        public void ReadFileFromDisk()
        {
            ReadFileFromDisk(null);
        }

        public void WriteFileInteraction()
        {
            Console.WriteLine("Write something and press <CTRL+S> to save to the file or <ESC> to exit.");

            string content;
            bool read = false;
            do
            {
                read = ReadUserInputWithSave(out content);

            } while (read);

            WriteFile(content.ToString());
            Console.WriteLine("\n File saved \n");


        }
        private void WriteFile(string content)
        {
            WriteFile(null, content);
        }
        private void WriteFile(string filepath, string content)
        {
            if (string.IsNullOrEmpty(filepath))
                filepath = DefaltFilePath;

            try
            {
                System.IO.File.WriteAllText(@filepath, content);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("Oops! Something went wrong while trying to write to the file. The error is: [{0}]", e.Message);
                throw;
            }
        }


    }
}