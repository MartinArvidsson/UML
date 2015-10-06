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
        private string persnr = ""; //varibels that are used to store member data before being turned into an object
        private double boatLength;
        private string typeofboat;
        private int b;


        private int boatnumber = 0;
        private int deletechoice; //varibels to check what the user picks, 

        
        private int i; //used in loops

        private int viewspecificuser; 
        private int boatchoice;
        private int editchoice;

        private string updateMess; //A string that represents a message set after a successful action.
         

        public void StartMenu() //presents a start menu
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
        }

        public int EditMenu() //Called on to read user input
        {
            int choiceEdit = int.Parse(Console.ReadLine());
            return choiceEdit;
        }

        public int registerperson() //Called when registering a new member
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

            updateMess = String.Format("\n\nYou added:\n{0}, {1}, {2} \nperson will be registred aswell as the boats.", firstname, lastname, persnr);
            return numberOfboats;        
        }

        //Properties for storing input data.
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

        public Member editperson(List<Member> Persons) //Edits a person, edit boat or boatinfo, or add more boats to an existing member.
        {
            i = 0;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}:\nFirstname: {1}\nLastname: {2}\nPersonID: {3}\n", i, member.FirstName, member.LastName, member.PersonalNumber);
            }
            
            Console.WriteLine("You chose edit\n");

            Console.WriteLine("Choose a person to edit from the list above");

            editchoice = int.Parse(Console.ReadLine());
            if (editchoice != 0) 
            {
                Console.Clear();
                Console.WriteLine("1:change personinformation");
                Console.WriteLine("2:change boatinformation");
                Console.WriteLine("3.Add boat to existing member");
            }
            return Persons[editchoice - 1];
        }


        public void editPersonalInfo(Member membertoedit) //Used to edit member data
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

        public void editBoatInfo(Member _membertoedit) //Used to edit boat data
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

            boatnumber = 0;
            for ( i = 0; i < diffrentBoatTypes.Length; i++)
            {
                boatnumber++;
                Console.WriteLine("{0}. {1}",boatnumber, diffrentBoatTypes[i]);           
            }
            
            int choice = EditMenu() - 1;
            typeofboat = diffrentBoatTypes[choice];

            Console.WriteLine("New length:");
            boatLength = double.Parse(Console.ReadLine());


            updateMess = String.Format("You have just updated the boat {0} with the length: {1}\n To the boat {2} with the Length {3}", _membertoedit.Boats[b].BoatType, _membertoedit.Boats[b].Length, typeofboat, boatLength);
        }

        public void AddnewBoat(Member membertoaddboat) //Adds a boat to a existing member
        {
            Console.WriteLine("What kind of boat ?");

            boatnumber = 0;
            for (i = 0; i < diffrentBoatTypes.Length; i++)
            {
                boatnumber++;
                Console.WriteLine("{0}. {1}", boatnumber, diffrentBoatTypes[i]);
                
            }
            
            int choice = EditMenu() - 1;
            typeofboat = diffrentBoatTypes[choice];

            Console.WriteLine("New length:");
            boatLength = int.Parse(Console.ReadLine());

        }

        //properties for storing data for boats.
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
        
        public Member Deletechoice(List<Member> Persons) //chose if a member or a member boat should be deleted
        {
            i = 0;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}: \nFirstname: {1}\nLastname: {2}\nPersonID: {3}\n", i, member.FirstName, member.LastName, member.PersonalNumber);
            }
            
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


        public Member deleteperson(Member toDelete) //returns a member that gonna be deleted
        {
                return toDelete;
        }

        public void DeleteBoat(Member _toDelete) //removes a boat from an existing member
        {
            Console.WriteLine("Choose a boat from the person that you would like to remove:");
            i = 0;
            boatnumber = 0;
            foreach (Boat boat in _toDelete.Boats)
            {
                boatnumber++;
                Console.WriteLine("{0} Length: {1}m, Type: {2}", boatnumber, boat.Length, boat.BoatType);

            }
            
            b = EditMenu() - 1;
            Console.WriteLine("Current boatchoice name: {0}, Length {1}", _toDelete.Boats[b].BoatType, _toDelete.Boats[b].Length);

            updateMess = string.Format("The boat {0} with the length {1} was removed from {2} {3}", _toDelete.Boats[b].BoatType, _toDelete.Boats[b].Length, _toDelete.FirstName, _toDelete.LastName);
        }

        public void Viewperson(List<Member> Persons) //Menu for view person option.
        {
                Console.WriteLine("Du chose view person!");
                Console.WriteLine("What type of list do you want");
                Console.WriteLine("0: Go back");
                Console.WriteLine("1: Compact");
                Console.WriteLine("2: Verbose");
                Console.WriteLine("3: Specific person");
        }


        public void listpersoncompact(List<Member> Persons) //Lists all members in a compat list
        {
            Console.WriteLine("You chose compact list!");
            i = 0;
            foreach (var member in Persons)
            {
                i++;
                Console.WriteLine("{0}:\n Firstname: {1}\n Lastname: {2}\n PersonID: {3}\n Antal båtar {4}\n", i, member.FirstName, member.LastName, member.PersonalNumber, member.Boats.Count);
            }
        }

        public void listpersonverbose(List<Member> Persons) //Lists all members in a verbose list
        {
           Console.WriteLine("You chose verbose list!\n\n");
           i = 0;
           foreach (var member in Persons)
           {
               i++;
               Console.WriteLine("\nMember {0}: \n Firstname: {1}\n Lastname: {2}\n Personalnumber: {3}\n Member ID: {4}\n Number of boats: {5}", i, member.FirstName, member.LastName, member.PersonalNumber, member.MemberID, member.Boats.Count);
               if (member.Boats.Count > 0)
               {
                   Console.WriteLine("Boat info:");
                   for (var _i = 0; _i < member.Boats.Count; _i++)
                   {
                       Console.WriteLine("{0}: Boat Type: {1}\n   Boat Length: {2}", _i + 1, member.Boats[_i].BoatType, member.Boats[_i].Length);
                   }
               }
               
           }
        }

        public void listpersonspecific(List<Member> Persons) //Lists out all members and giving the option to chose 1 specific member to view that members data
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
            Member toview = Persons[viewspecificuser - 1];


            Console.WriteLine("The person you chose is:\n {0},{1}\n With PersonID: {2}\n And userID: {3}",
            toview.FirstName, toview.LastName, toview.PersonalNumber, toview.MemberID);

            if (toview.Boats.Count > 0)
            {
                for (i = 0; i < toview.Boats.Count; i++)
                {
                    Console.WriteLine("{0} has a boat of the {1} type, with the length {2} Meters",toview.FirstName, toview.Boats[i].BoatType, toview.Boats[i].Length);
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("The person had no boats");
            }
        }


        public void readBoatInfo() //used to read new boat data, properties returns the values.
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


        //Error message display.
        public void NotValidInputError()
        {
            Console.WriteLine("Not Valid input.");
        }

        public void ValidationError()
        {
            Console.WriteLine("An error occured when validating the data, please try again.");
        }

        public void EditError()
        {
            Console.WriteLine("Could not edit the member / boat.");
        }

        public void EmptyDataBaseError()
        {
            Console.WriteLine("Could not view members at this moment, the database is probably empty.");
        }
    }
}
