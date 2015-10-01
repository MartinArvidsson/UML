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
        private double boatLength;
        private string typeofboat;
        private int boatnumber = 1;
        private int deletechoice;
        private int deleteconfirmation;

        private int b;
        private int i;

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
                Console.WriteLine("\nInput was not valid number beween [1 - 5] please!\n");
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
            Console.WriteLine("you chose new person!\n");
            Console.WriteLine("Firstname:");
            firstname = Console.ReadLine();
            Console.WriteLine("Lastname:");
            lastname = Console.ReadLine();
            Console.WriteLine("PersonID:");
            persnr = Console.ReadLine();
            Console.WriteLine("Number of boats:");
            int numberOfboats = int.Parse(Console.ReadLine());

            updateMess = String.Format("you wrote:\n {0}, {1}, {2} \nperson will be registred aswell as the boats.", firstname, lastname, persnr);
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
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}:\nFirstname: {1}\nLastname: {2}\nPersonID: {3}\n", i, member.FirstName, member.LastName, member.PersonalNumber);
            }
            i = 0;
            Console.WriteLine("You chose edit\n");

            Console.WriteLine("Choose a person to edit from the list above");

            editchoice = int.Parse(Console.ReadLine());
            if (editchoice != 0) 
            {
                Console.Clear();
                Console.WriteLine("1:Edit person");
                Console.WriteLine("2:Edit boats");
            }
            return Persons[editchoice - 1];
        }


        public void editPersonalInfo(Member membertoedit)
        {
            Console.WriteLine("Current first name: {0}", membertoedit.FirstName);
            Console.WriteLine("Current last name: {0}", membertoedit.LastName);
            Console.WriteLine("Current personal number: {0}", membertoedit.PersonalNumber);

            Console.WriteLine("New Firstname");
            firstname = Console.ReadLine();

            Console.WriteLine("New Lastname");
            lastname = Console.ReadLine();

            Console.WriteLine("New PersonID");
            persnr = Console.ReadLine();


            updateMess = String.Format("You have just updated member\n {0}, {1}\n With personID: {2}\n To {3}, {4}\n With PersonID: {5}\n", membertoedit.FirstName, membertoedit.LastName, membertoedit.PersonalNumber,
                firstname, lastname, persnr);

        }

        public void editBoatInfo(Member _membertoedit)
        {
            int i = 0;

            foreach (Boat boat in _membertoedit.Boats)
            {
                i++;
                Console.WriteLine("{0} Length: {1}m, Type: {2}", i, boat.Length, boat.BoatType);
                
            }

            b = EditMenu() - 1;
            Console.WriteLine("Current boatchoice name: {0}, Length {1}", _membertoedit.Boats[b].BoatType, _membertoedit.Boats[b].Length); 
            Console.WriteLine("New Boattype:");
            for ( i = 0; i < diffrentBoatTypes.Length; i++)
            {
                Console.WriteLine("{0}. {1}",boatnumber, diffrentBoatTypes[i]);
                boatnumber++;
            }
            boatnumber = 1;
            int choice = EditMenu() - 1;
            typeofboat = diffrentBoatTypes[choice];

            Console.WriteLine("New length:");
            boatLength = int.Parse(Console.ReadLine());


            updateMess = String.Format("You have just updated the boat {0} with the length: {1}\n To the boat {3} with the Length {4}", _membertoedit.Boats[b].BoatType, _membertoedit.Boats[b].Length, typeofboat, boatLength);
        }

        public int getcurrentboat
        {
            get { return b; }
        }

        public string getboattype
        {
            get { return typeofboat; }
        }

        public double getboatlength
        {
            get { return boatLength; }
        }


        public int EditMemberInfo(Member m)
        {
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }
        
        public Member Deletechoice(List<Member> Persons)
        {
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}: \nFirstname: {1}\nLastname: {2}\nPersonID: {3}\n", i, member.FirstName, member.LastName, member.PersonalNumber);
            }
            i = 0;
            Console.WriteLine("You chose delete\n");
            Console.WriteLine("Choose a person that you want to delete from from the list\n");
            deletechoice = int.Parse(Console.ReadLine());

            if (deletechoice != 0)
            {
                Console.WriteLine("1:Delete the entire person");
                Console.WriteLine("2:Remove boat/s from person");
            }
            return Persons[deletechoice - 1];
        }
        

        public Member deleteperson(Member toDelete)
        {
            Console.WriteLine("Do you really want to delete this person? This action cannot be reverted");
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No");

            deleteconfirmation = int.Parse(Console.ReadLine());

            if (deleteconfirmation == 1)
            { 
                return toDelete;
            }
            return null;

        }

        public void DeleteBoat(Member _toDelete)
        {
            Console.WriteLine("Choose a boat from the person that you would like to remove:");
            i = 0;
            foreach (Boat boat in _toDelete.Boats)
            {
                i++;
                Console.WriteLine("{0} Length: {1}m, Type: {2}", i, boat.Length, boat.BoatType);

            }
            b = EditMenu() - 1;
            Console.WriteLine("Current boatchoice name: {0}, Length {1}", _toDelete.Boats[b].BoatType, _toDelete.Boats[b].Length);

            updateMess = string.Format("The boat {0} with the length {1} was removed from {2} {3}", _toDelete.Boats[b].BoatType, _toDelete.Boats[b].Length, _toDelete.FirstName, _toDelete.LastName);
        }

        public void Viewperson(List<Member> Persons)
        {

                Console.WriteLine("Du chose view person!");
                //fråga om verbose eller compact list, efter det visas alla medlemmar enligt den valda listan
                Console.WriteLine("What type of list shall i show?");
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
            Console.WriteLine("You chose compact list!");
            i = 0;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}:\n Firstname: {1}\n Lastname: {2}\n PersonID: {3}\n Antal båtar {4}\n", i, member.FirstName, member.LastName, member.PersonalNumber, member.Boats.Count);
            }
        }

        public void listpersonverbose(List<Member> Persons)
        {
           Console.WriteLine("You chose verbose list!\n\n");
           i = 0;
           foreach (var member in Persons)
           {
               i++;
               if (member.Boats.Count > 0)
               {
                   for (var _i = 0; _i < member.Boats.Count; _i++)
                   //for ()
                   {
                       _i++;
                       Console.WriteLine("{0}:\nFirstname: {1}\nLastname: {2}\nPersonID: {3}\nMemberID: {4}\nBoatinfo : Number of boats: {5}\nBoattype: {6}\nBoatlength: {7}\n", _i, member.FirstName, member.LastName, member.PersonalNumber, member.MemberID, member.Boats.Count, member.Boats[i].BoatType, member.Boats[i].Length);
                       Console.WriteLine("");
                   }
               }
               else
               {
                   Console.WriteLine("{0}:\nFirstname: {1}\nLastname: {2}\nPersonID: {3}\nMemberID: {4}\nBoatinfo : Number of boats: {5}\nBoattype: {6}\nBoatlength: {7}\n", i, member.FirstName, member.LastName, member.PersonalNumber, member.MemberID, member.Boats.Count, member.Boats[i].BoatType, member.Boats[i].Length);
                   Console.WriteLine("\nPersonen hade inga båtar");
               }
           }
        }

        public void listpersonspecific(List<Member> Persons)
        {
            Console.WriteLine("You chose specific person\n");
            Console.WriteLine("Choose a person to look at details");
            i = 0;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}:\nFirstname: {1}\n Lastname: {2}\n uniqeID: {3}\n", i, member.FirstName, member.LastName,member.MemberID);
            }

            viewspecificuser = int.Parse(Console.ReadLine());

            if (viewspecificuser < 0 || viewspecificuser > Persons.Count)
            {
                throw new ArgumentOutOfRangeException(); //Flytta till controller
            }
            Member toview = Persons[viewspecificuser - 1];


            Console.WriteLine("The person you chose is:\n {0},{1}\n With PersonID: {2}\n And userID: {3}",
            toview.FirstName, toview.LastName, toview.PersonalNumber, toview.MemberID);

            if (toview.Boats.Count > 0)
            {
                for (i = 0; i < toview.Boats.Count; i++)
                {
                    Console.WriteLine("Person has a boat of the {0} type, with the length {1} Meters", toview.Boats[i].BoatType, toview.Boats[i].Length);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("The person had no boats");
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
            boatLength = double.Parse(Console.ReadLine());
            typeofboat = diffrentBoatTypes[boatchoice - 1];
        }
    }
}
