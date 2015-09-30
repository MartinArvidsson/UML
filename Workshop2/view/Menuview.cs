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
        private string firstname = "";
        private string lastname = "";
        private string persnr = "";

        private int i;
        private int j;
        private int k;
        private int l;

        private int userinput;
        private int deleteinput;
        private int Listchecker;

        private int menuChoice;

        private string updateMess;


        public int StartMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("===============================");
            Console.WriteLine("=            MENU             =");
            Console.WriteLine("===============================\n\n");
            Console.ResetColor();
            Console.WriteLine("0.Exit application.");
            Console.WriteLine("1.Register person");
            Console.WriteLine("2.Edit person");
            Console.WriteLine("3.Delete person");
            Console.WriteLine("4.view Person");
            Console.WriteLine(updateMess);
            updateMess = "";

            try
            {
                menuChoice = int.Parse(Console.ReadLine());
                if (menuChoice < 0 || menuChoice > 4)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nDu angav inte ett giltigt tal. Ange ett nummer från [1 till 5] tack!\n");
                Console.ResetColor();
            }

            return menuChoice;           
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

            updateMess = String.Format("du skrev: {0}, {1}, {2} personen kommer att registreras",firstname ,lastname ,persnr);
            

            
            //Member member new Member(firstname,lastname,persnr);

            //TODO skapa memberobjekt som fylls på och retuneras till controllern som sedan tar och skickar till member för att skapa en ny instans av en medlem.

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

        public Member editperson(List<Member> Persons)
        {
            Member membertoedit;
            Console.WriteLine("Du valde edit person!\n");
            Console.WriteLine("Välj en person från listan");
            //TODO: lista med personer ska hämtas från controllern..

            //List<Member> Persons = menucontroller.getPersons();
                
            foreach(var member in Persons)
            {
                i++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", i, member.FirstName, member.LastName, member.PersonalNumber);
                //TODO lägg till ett båtelement
                    
            }
            i = 0;

          
            userinput = int.Parse(Console.ReadLine());
            if (userinput < 0 || userinput > Persons.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            membertoedit = Persons[userinput - 1];
            Console.WriteLine("Current first name: {0}", membertoedit.FirstName);
            Console.WriteLine("Current last name: {0}", membertoedit.LastName);
            Console.WriteLine("Current personal number: {0}", membertoedit.PersonalNumber);

            Console.WriteLine("nytt förnamn?");
            firstname = Console.ReadLine();

            Console.WriteLine("Nytt efternamn");
            lastname = Console.ReadLine();

            Console.WriteLine("Nytt personnummer?");
            persnr= Console.ReadLine();

            //Member updatemember new Member(newfirstname,newlastname,newpersnr);
            //Skapa ett memberobjekt med den nya informationen, skicka till controller som skickar till member.
                

            updateMess = String.Format("Du har precis uppdaterat medlem {0} {1} med personNr: {2} till {3} {4} med personNr: {5}", membertoedit.FirstName, membertoedit.LastName, membertoedit.PersonalNumber,
                firstname, lastname, persnr);

            return membertoedit;
        }
       


        public Member deleteperson(List<Member> Persons)
        {
            Member Membertodelete;
            Console.WriteLine("Du valde delete person!\n");
            Console.WriteLine("Välj en person från listan");
            //TODO: lista med personer ska hämtas från controllern..

            //List<Member> Persons = menucontroller.getPersons();
            foreach(var member in Persons)
            {
                j++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", j, member.FirstName, member.LastName, member.PersonalNumber);
                //TODO lägg till båtelement, båtarna ska synas när man  ska ta bort.
                    
            }
            j = 0;
                
            
            deleteinput = int.Parse(Console.ReadLine());
            if (deleteinput < 0 || deleteinput > Persons.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Membertodelete = Persons[deleteinput - 1];
            updateMess = String.Format("Personen tas bort!");
                    

            //Retunera platsen i memberarrayen till en metod i controllern, som skickar till member där man tar bort personen.
                
            return Membertodelete;
        }

        public void Viewperson(List<Member> Persons)
        {

                Console.WriteLine("Du valde view person!");
                //fråga om verbose eller compact list, efter det visas alla medlemmar enligt den valda listan
                Console.WriteLine("vilken typ av lista?");
                Console.WriteLine("1: Compact");
                Console.WriteLine("2: Verbose");

                Listchecker = int.Parse(Console.ReadLine());

                if (Listchecker == 1)
                {
                    listpersoncompact(Persons);
                }
                else if(Listchecker == 2)
                {
                    listpersonverbose(Persons);
                }              
                else
                    throw new ArgumentOutOfRangeException();
        }


        public void listpersoncompact(List<Member> Persons)
        {
            Console.WriteLine("Du valde compact list!");

            foreach (var member in Persons)
            {
                k++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", k, member.FirstName, member.LastName, member.PersonalNumber);
                //TODO lägg till båtelement, båtarna ska synas när man  ska ta bort.

            }
            k = 0;
            //Visa upp enbart alla personer med Name,MemberID,NumberofBoats
            //“Compact List”; name, member id and number of boats
        }


        public void listpersonverbose(List<Member> Persons)
        {
           Console.WriteLine("Du valde verbose list!");

           foreach (var member in Persons)
           {
               l++;
               Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", l, member.FirstName, member.LastName, member.PersonalNumber);
               //TODO lägg till båtelement, samt båtinformation

           }
           l = 0;
          ////Visa upp alla medlemar med name,personalnumber,memberID,Boats boatsinformation
          // //“Verbose List”; name, personal number, member id and boats with boat information    
        }


        public void ErrorMess(string message)
        {
            updateMess = message;
        }
    }
}
