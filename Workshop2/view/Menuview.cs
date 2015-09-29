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
        int Listchecker;
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
            Console.WriteLine("2.view Person");
            Console.WriteLine("3.Edit person");
            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice < 1 || choice > 3)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    switch (choice)
                    {
                        case 1:
                            registerperson();
                            break;

                        case 2:
                            Viewperson();
                            break;

                        case 3:
                            editperson();
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

            Console.WriteLine("du skrev: {0}, {1}, {2} personen kommer att registreras",firstname ,lastname ,persnr);

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

        public void Viewperson()
        {
            do
            {
           Console.WriteLine("Du valde view person!");
            //fråga om verbose eller compact list, efter det visas alla medlemmar enligt den valda listan
            Console.WriteLine("vilken typ av lista?");
            Console.WriteLine("1: Compact");
            Console.WriteLine("2: Verbose");

            Listchecker = int.Parse(Console.ReadLine());
            if (Listchecker < 1 || Listchecker > 2)
            {
                if(Listchecker == 1)
                {
                    listpersoncompact();
                }
                else
                {
                    listpersonverbose();
                }
            }
            else
                throw new ArgumentOutOfRangeException();
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        

        public void editperson()
        {
            do
            {
                Console.WriteLine("Du valde edit person!\n");
                Console.WriteLine("Välj en person från listan :\n");
                //TODO: lista med personer ska hämtas från controllern..

                List<member> Persons = menucontroller.getPersons();
                int i;
                foreach(var member in Persons)
                {
                    i++;
                    Console.WriteLine("{4}: Firstname: {0}, Lastname: {1}, Persnr: {2}, ID: {3}", person.Firstname,person.Lastname,person.Persnr,person.id,i);
                    
                }

                userinput = Console.ReadLine();


                if (userinput)
                {
                    Console.WriteLine("vill du redigera person: {0} ,{1} ,{2} ,{3} ?",person.Firstname,person.Lastname,person.Persnr,person.id);
                    
                    Console.WriteLine("ja/nej");
                    finalcheck = Console.ReadLine();
                    if (finalcheck == "ja")
                    {
                        //Redigera person
                        Console.WriteLine("Temp");
                    }
                    else
                    {
                        Console.WriteLine("Registeringen avbröts eller så angavs ett ickegiltigt kommando, återgår till update person.");
                    }
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public void listpersonverbose()
        {
           Console.WriteLine("Du valde Verbose list!");
            //Visa upp alla medlemar med name,personalnumber,memberID,Boats boatsinformation
        }

        public void listpersoncompact()
        {
            Console.WriteLine("Du valde compact list!");
            //Visa upp enbart alla personer med Name,MemberID,NumberofBoats
        }
    }
}
