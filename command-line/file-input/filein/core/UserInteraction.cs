using System;
using System.Text;

namespace FileIn
{
    public class UserInteraction
    {
        private FileHandler fileHandler;

        public UserInteraction()
        {
            fileHandler = new FileHandler();
        }
        public void ShowCmdMenu()
        {
            Console.WriteLine("This is a experimental program");
            Console.WriteLine("Choose one of the interactions:");
            Console.WriteLine("1 - Read file from disk and show its contents");
            Console.WriteLine("2 - Write to the file");
            Console.WriteLine("Press <ESC> to exit. \n");
        }

        public void Interact()
        {
            ShowCmdMenu();
            string buffer;
            bool read = false;
            

            do
            {
                read = fileHandler.ReadUserInputWithCancel(out buffer);
                
                int option = 0;

                int.TryParse(buffer, out option);

                switch (option)
                {
                    case 1:
                        fileHandler.ReadFileFromDisk();
                        break;
                    case 2:
                        fileHandler.WriteFileInteraction();
                        break;

                }
            }
            while (read);

        }

        


    }
}