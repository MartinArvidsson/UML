using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop2.controller;

namespace Workshop2.view
{
    class Menuview
    {
        int choice;
        string firstname = "";
        string lastname = "";
        int persnr;
        public void Runapplication()
        {
            placeholder menucontroler = new placeholder();
            StartMenu();
        }
        public void StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===================================");
            Console.WriteLine("===            MENU             ===");
            Console.WriteLine("===================================");
            Console.ResetColor();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("1.Register person");
            Console.WriteLine("2.Update Person");
            Console.WriteLine("3.Edit person");
            Console.WriteLine("4.Verbose List");
            Console.WriteLine("5.Compact List");
            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 5)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    switch (choice)
                    {
                        case 1:
                            registerperson();
                            break;

                        case 2:
                            updateperson();
                            break;

                        case 3:
                            editperson();
                            break;

                        case 4:
                            listpersonverbose();
                            break;

                        case 5:
                            listpersoncompact();
                            break;

                        default:
                            Console.WriteLine("Du valde inget giltigt");
                            break;
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n angav inte ett giltigt tal. Ange ett nummer från [1 till 5] tack!\n");
                    Console.ResetColor();
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void registerperson()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Du valde ny person!\n");
            Console.WriteLine("förnamn:?");
            firstname = Console.ReadLine();
            Console.WriteLine("efternamn:?");
            lastname = Console.ReadLine();
            Console.WriteLine("personnummer:?");
            persnr = int.Parse(Console.ReadLine());

            Console.WriteLine("du skrev: " + firstname + "," + lastname + "," + persnr + " personen kommer att registreras");

        }

        public void updateperson()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Du valde update person!");
        }

        public void editperson()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Du valde redigera person!");
        }

        public void listpersonverbose()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Du valde Verbose list!");
        }

        public void listpersoncompact()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Du valde compact list!");
        }



    }
}
