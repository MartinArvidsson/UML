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
        private string[] diffrentBoatTypes = new string[4] { "Sailboat", "Motorsailer", "Kayak/Canoe", "Other" };
        private string firstname = "";
        private string lastname = "";
        private string persnr = "";
        private double boatLenght;
        private string typeofboat;
        private int boatnumber = 1;



        private int b;
        private int i;
        private int j;
        private int k;
        private int l;
        private int m;

        private int deleteinput;
        private int Listchecker;
        private int viewspecificuser;
        private int boatchoice;
        private int editchoice;

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
            Console.WriteLine("2.Edit");
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

        public int EditMenu()
        {
            int choiceEdit = int.Parse(Console.ReadLine());

            return choiceEdit;
        }




        public int registerperson()
        {
            Console.WriteLine("Du valde ny person!\n");
            Console.WriteLine("förnamn:");
            firstname = Console.ReadLine();
            Console.WriteLine("efternamn:");
            lastname = Console.ReadLine();
            Console.WriteLine("personnummer:");
            persnr = Console.ReadLine();
            Console.WriteLine("Number of boats:");
            int numberOfboats = int.Parse(Console.ReadLine());

            updateMess = String.Format("du skrev: {0}, {1}, {2} personen kommer att registreras samt båtarna.", firstname, lastname, persnr);
            return numberOfboats;        
        }

        //Funktionerna som anropas efter att man har registerat en användare för att få ut datan.
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
            
            ////TODO: lista med personer ska hämtas från controllern..

            //List<Member> Persons = menucontroller.getPersons();

            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3}", i, member.FirstName, member.LastName, member.PersonalNumber);
                //TODO lägg till ett båtelement
            }
            i = 0;

            editchoice = int.Parse(Console.ReadLine());

            Console.WriteLine("Du valde edit\n");
            Console.WriteLine("1:Edit person");
            Console.WriteLine("2:Edit boats");

            return Persons[editchoice - 1];
        }


        public void editPersonalInfo(Member membertoedit)
        {
            Console.WriteLine("Current first name: {0}", membertoedit.FirstName);
            Console.WriteLine("Current last name: {0}", membertoedit.LastName);
            Console.WriteLine("Current personal number: {0}", membertoedit.PersonalNumber);

            Console.WriteLine("nytt förnamn?");
            firstname = Console.ReadLine();

            Console.WriteLine("Nytt efternamn");
            lastname = Console.ReadLine();

            Console.WriteLine("Nytt personnummer?");
            persnr = Console.ReadLine();


            updateMess = String.Format("Du har precis uppdaterat medlem {0} {1} med personNr: {2} till {3} {4} med personNr: {5}", membertoedit.FirstName, membertoedit.LastName, membertoedit.PersonalNumber,
                firstname, lastname, persnr);

        }

        public void editBoatInfo(Member m)
        {
            int i = 0;

            foreach (Boat boat in m.Boats)
            {
                i++;
                Console.WriteLine("{0} Length: {1}m, Type: {2}", i, boat.Lenght, boat.BoatType);
                
            }

            b = EditMenu() - 1;
            Console.WriteLine("Current boatchoice name: {0}, Length {1}", m.Boats[b].BoatType, m.Boats[b].Lenght); //<--- VÄRDET AV DENNA POSITIONEN PRONTO

            Console.WriteLine("Ny Båttyp:");
            for ( i = 0; i < diffrentBoatTypes.Length; i++)
            {
                Console.WriteLine("{0}. {1}",boatnumber, diffrentBoatTypes[i]);
                boatnumber++;
            }
            boatnumber = 1;
            int choice = EditMenu() - 1;
            typeofboat = diffrentBoatTypes[choice];

            Console.WriteLine("Ny längd:");
            boatLenght = int.Parse(Console.ReadLine());


            updateMess = String.Format("Du har precis uppdaterat båten {0} med längden: {1}", m.Boats[b].BoatType, m.Boats[b].Lenght);
        }

        public int returncurrentboat
        {
            get { return b; }
        }

        public string getboattype
        {
            get { return typeofboat; }
        }

        public double getboatlength
        {
            get { return boatLenght; }
        }


        public int EditMemberInfo(Member m)
        {
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        
       
        public Member deleteperson(List<Member> Persons)
        {
            Member Membertodelete;
            Console.WriteLine("Du valde delete !\n");

            Console.WriteLine("1:Ta bort person.");
            Console.WriteLine("2: Ta bort båt.");

            int deletechoice = int.Parse(Console.ReadLine());

            if (deletechoice == 1)
            {

                Console.WriteLine("Välj en person från listan");
                foreach (var member in Persons)
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

                return Membertodelete;
            }

            if (deletechoice == 2)
            {

                Console.WriteLine("Välj en person från listan");
                foreach (var member in Persons)
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
                int boattodelete = deleteinput -1;

                    foreach (var boats in Persons[deleteinput - 1].Boats)
                    //for (j = 0; j < Persons[boattodelete].Boats.Count; i++)
                    {

                        Console.WriteLine("{0},boattype {1} , boatlength {2}", j, Persons.boats[j].Boattype, Persons.Boats[j].length);
                        j++;

                    } 
                j = 0;

                //return Membertodelete;
            }
          
            //updateMess = String.Format("Personen tas bort!");            
            //return Membertodelete;
        }

        public void Viewperson(List<Member> Persons)
        {

                Console.WriteLine("Du valde view person!");
                //fråga om verbose eller compact list, efter det visas alla medlemmar enligt den valda listan
                Console.WriteLine("vilken typ av lista?");
                Console.WriteLine("1: Compact");
                Console.WriteLine("2: Verbose");
                Console.WriteLine("3: Specific person");

                Listchecker = int.Parse(Console.ReadLine());

                if (Listchecker == 1)
                {
                    listpersoncompact(Persons);
                }
                else if(Listchecker == 2)
                {
                    listpersonverbose(Persons);
                }
                else if (Listchecker == 3)
                {
                    listpersonspecific(Persons);
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
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3} , Antal båtar {4}", k, member.FirstName, member.LastName, member.PersonalNumber,member.Boats.Count);
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

               if (member.Boats.Count > 0)
               {
                   for (i = 0; i < member.Boats.Count; i++)
                   {
                       Console.WriteLine("{0}: Firstname: {1}, Lastname: {2} PersonID: {3} MemberID:{4} Boatinfo : Number of boats :{5}, Boattype{6}, Boatlength{7}", i, member.FirstName, member.LastName, member.PersonalNumber,member.MemberID,member.Boats.Count,member.Boats[i].BoatType,member.Boats[i].Lenght);
                       Console.WriteLine("");
                   }
               }
               else
               {
                   Console.WriteLine("Personen hade inga båtar");
               }
               
               
               //TODO lägg till båtelement, samt båtinformation

           }
           l = 0;
          ////Visa upp alla medlemar med name,personalnumber,memberID,Boats boatsinformation
          // //“Verbose List”; name, personal number, member id and boats with boat information    
        }

        public void listpersonspecific(List<Member> Persons)
        {
            Console.WriteLine("Du valde view spefific person!");

            foreach (var member in Persons)
            {
                m++;
                Console.WriteLine("{0}: Firstname: {1}, Lastname: {2}, uniqeID:{3}", m, member.FirstName, member.LastName,member.MemberID);
                //TODO lägg till båtelement, båtarna ska synas när man  ska ta bort.

            }
            m = 0;
            viewspecificuser = int.Parse(Console.ReadLine());

            if (viewspecificuser < 0 || viewspecificuser > Persons.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            Member toview = Persons[viewspecificuser - 1];


            Console.WriteLine("Personen du valde är: {0},{1}, med personnummer: {2} och ID{3}",
            toview.FirstName, toview.LastName, toview.PersonalNumber, toview.MemberID);

            if (toview.Boats.Count > 0)
            {
                for (i = 0; i < toview.Boats.Count; i++)
                {
                    Console.WriteLine("personen har båtar av typen {0}, med längden {1}", toview.Boats[i].BoatType, toview.Boats[i].Lenght);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Personen hade inga båtar");
            }

            
            //Visa upp enbart alla personer med Name,MemberID,NumberofBoats
            //
        }

        public void ErrorMess(string message)
        {
            updateMess = message;
        }


        //reads in boat info, info is returned by properties
        public void readBoatInfo()
        {
            
            Console.WriteLine("\nNew Boat:");
            for(int i = 0; i < diffrentBoatTypes.Length; i ++){
                Console.WriteLine("{0}:{1}",i+1,diffrentBoatTypes[i]);
            }

            boatchoice = int.Parse(Console.ReadLine());
            Console.WriteLine("A boat of type {0} was added", diffrentBoatTypes[boatchoice - 1]);

            Console.WriteLine("Length of boat in meters:");
            boatLenght = double.Parse(Console.ReadLine());
            typeofboat = diffrentBoatTypes[boatchoice - 1];
        }
    }
}
