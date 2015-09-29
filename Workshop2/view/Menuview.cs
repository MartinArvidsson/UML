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
        string userinput;
        string finalcheck;
        public void Runapplication()
        {
            placeholder menucontroller = new placeholder();
            StartMenu();
        }
        public void StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===================================");
            Console.WriteLine("===            MENU             ===");
            Console.WriteLine("===================================\n\n");
            Console.ResetColor();
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
            Console.WriteLine("Du valde ny person!\n");
            Console.WriteLine("förnamn:?");
            firstname = Console.ReadLine();
            Console.WriteLine("efternamn:?");
            lastname = Console.ReadLine();
            Console.WriteLine("personnummer:?");
            persnr = int.Parse(Console.ReadLine());

            Console.WriteLine("du skrev: " + firstname + "," + lastname + "," + persnr + " personen kommer att registreras");

        }

        //Funktionerna som anropas efter att man har registerat en användare
        public string getfirstname
        {
            get { return firstname; }
        }

        public string getlastname
        {
            get { return lastname; }
        }

        public int getpersnr
        {
            get { return persnr; }
        }

        public void updateperson()
        {
            do
            {
                Console.WriteLine("Du valde update person!\n");
                Console.WriteLine("Välj en person från listan genom att skriva ID:t :\n");
                //TODO: lista med personer ska hämtas från controllern..

                List<string> Persons = menucontroller.getPersons();

                foreach(var person in Persons)
                {
                    Console.Writeline("Firstname: {0}, Lastname: {1}, Persnr: {2}, ID: {3}", person.Firstname,person.Lastname,person.Persnr,person.id);
                    
                }

                userinput = Console.ReadLine();

                //Kolla om userinput machar ett id till en person

                if()
                {
                    //Görs här
                }

                if ()
                {
                    Console.WriteLine("vill du redigera person:" + person.Firstname + "," + person.Lastname + "," + person.Persnr + "," + person.id +"?");
                    Console.WriteLine("ja/nej");
                    finalcheck = Console.ReadLine();
                    if (finalcheck == "ja")
                    {
                        //Redigera person
                        Console.WriteLine("Temp");
                    }
                    else
                    {
                        Console.WriteLine("Registeringen avbröts eller så angavs ett ickegjiltigt kommando, återgår till update person.");
                    }
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        

        public void editperson()
        {
            Console.WriteLine("Du valde redigera person!");
        }

        public void listpersonverbose()
        {
           Console.WriteLine("Du valde Verbose list!");
        }

        public void listpersoncompact()
        {
            Console.WriteLine("Du valde compact list!");
        }
    }
}
