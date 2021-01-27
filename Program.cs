using System;

namespace TextTowerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TextTower textTower = new TextTower();
            CvsManager cvsFile = new CvsManager();

            string[] options = new string[] { "1", "2", "3", "4" };
            bool execute = true;

            int secretTrigger = 0;
            string secretText = "";

            System.Console.WriteLine(@"    Welcome to the Text Tower!
Here you can pile as much Text Boxes as you want to create your custom Text Tower.
You can also remove one input at a time as well, in case you made a mistake.
But do remember this is a tower, you should only remove Boxes you just stored!
If you don't want your tower to fall apart, that is.
");

            while (execute)
            {
                System.Console.WriteLine(@"    Please, enter a number according to the desired operation:

(1) Store a text box inside your tower.
(2) Remove the last stored text box from the tower.
(3) Exit the program.{0}
", secretText);

                string input = Console.ReadLine();
                int option = Array.IndexOf(options, input);
                
                if (option == -1)
                {
                    System.Console.WriteLine(@"That's not a valid option number.
Please, try again...
");
                }
                else
                {
                    if (option == 0)
                    {
                        System.Console.Write("Please, enter what you would like to add to the tower: ");
                        input = Console.ReadLine();
                        textTower.Push(input);
                        cvsFile.PushText(input);
                        secretTrigger++;

                        System.Console.WriteLine("Tower successfully expanded!");
                    }
                    if (option == 1)
                    {
                        System.Console.Write("The following text box was removed: ");
                        System.Console.WriteLine(textTower.Pop());
                        cvsFile.PopText();
                        secretTrigger--;

                        if (secretTrigger == 3)
                            secretText = "";

                        System.Console.WriteLine("Removal successful. Now your tower looks smaller, though...");
                    }

                    if (option == 2)
                    {
                        System.Console.WriteLine("Closing the program...");
                        execute = false;
                    }

                    if (option == 3 && secretTrigger > 3)
                    {
                        System.Console.WriteLine("... You shouldn't have done that.");

                        textTower.Clear();
                        cvsFile.ClearText();
                        secretTrigger = 0;
                        secretText = "";

                        System.Console.WriteLine("Who would have thought? The tower collapsed, all text was lost.");
                    }

                    if (secretTrigger == 4)
                        secretText = @"
(4) ... Try to play Jenga with your tower.";
                }

                System.Console.WriteLine("Press 'Enter' to continue...");
                Console.ReadLine();
            }

            System.Console.WriteLine("Execution stopped successfully.");
        }
    }
}
