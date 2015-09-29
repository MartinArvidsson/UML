using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop2.controller;
using Workshop2.model;

namespace Workshop2.view
{
    class Menuview
    {
        int choice;
        string firstname = "";
        string lastname = "";
        string persnr = "";
        
        string newfirstname;
        string newlastname;
        int newpersnr;

        string userinput;
        string deleteinput;
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
            Console.WriteLine("4.Delete person");
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

                        case 4:
                            deleteperson();
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
            persnr = Console.ReadLine();

            Console.WriteLine("du skrev: {0}, {1}, {2} personen kommer att registreras",firstname ,lastname ,persnr);
            Member member new Member(firstname,lastname,persnr);

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

        public string getpersnr
        {
            get { return persnr; }
        }

        public Member editperson()
        {
            do
            {
                Console.WriteLine("Du valde edit person!\n");
                Console.WriteLine("Välj en person från listan");
                //TODO: lista med personer ska hämtas från controllern..

                List<Member> Persons = menucontroller.getPersons();
                int i;
                foreach(var member in Persons)
                {
                    i++;
                    Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", i,person.Firstname,person.Lastname,person.persnr);
                    //TODO båt
                    
                }

                userinput = Console.ReadLine();

                try
                {
                    Persons[userinput - 1];
                    Console.WriteLine("nytt förnamn?");
                    newfirstname = Console.ReadLine();
                    Console.WriteLine("Nytt efternamn");
                    newlastname = Console.ReadLine();
                    Console.WriteLine("Nytt personnummer?");
                    newpersnr= int.Parse(Console.ReadLine());

                    //ANROPA METOD I CONTROLLER
                }
                catch
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        public string getnewfirstname
        {
            get { return newfirstname; }
        }

        public string getnewlastname
        {
            get { return newlastname; }
        }

        public int getnewpersnr
        {
            get { return newpersnr; }
        }


        public Member deleteperson()
        {
            do
            {
                Console.WriteLine("Du valde delete person!\n");
                Console.WriteLine("Välj en person från listan");
                //TODO: lista med personer ska hämtas från controllern..

                List<Member> Persons = menucontroller.getPersons();
                int i;
                foreach(var member in Persons)
                {
                    i++;
                    Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", i,person.Firstname,person.Lastname,person.persnr);
                    //TODO båt
                    
                }

                deleteinput = Console.ReadLine();

                try
                {
                    Persons[deleteinput - 1];
                    Console.WriteLine("Personen tas bort! tack");
                    return Persons[deleteinput - 1];
                }
                catch
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
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
                    if (Listchecker == 1)
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


        public void listpersoncompact()
        {
            Console.WriteLine("Du valde compact list!");
            //Visa upp enbart alla personer med Name,MemberID,NumberofBoats
            //“Compact List”; name, member id and number of boats
            List<Member> Persons = menucontroller.getCompactlist();
            int i;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2}, ID: {3}", i, person.Firstname, person.Lastname, person.id,);

            }  //TODO
        }

            
        public void listpersonverbose()
        {
           Console.WriteLine("Du valde verbose list!");
          //Visa upp alla medlemar med name,personalnumber,memberID,Boats boatsinformation
           //“Verbose List”; name, personal number, member id and boats with boat information
           List<Member> Persons = menucontroller.getVerboselist();
           int i;
           foreach (var member in Persons)
           {
               i++;
               Console.WriteLine("{0}: Firstname: {1}, Lastname: {2}, ID: {3}", i, person.Firstname, person.Lastname, person.id);
               //TODO
           }
    
        }
    }
}
