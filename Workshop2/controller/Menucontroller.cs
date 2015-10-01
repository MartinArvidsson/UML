using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop2.view;
using Workshop2.model;

namespace Workshop2.controller
{
    class Menucontroller
    {
        Menuview view = new Menuview();
        MemberDAL memberDAL = new MemberDAL();

        private int choice;
        private int boattoedit;
        private int boattodelete;

        public void Runapplication()
        {
            

            choice = view.StartMenu();


            MenuChoice();
        }

        public void MenuChoice()
        {
            
            switch (choice) //Huvudmenyns switchsats, CRUD
            {
                case 0: 
                    Environment.Exit(0);
                    break;

                case 1:
                    try
                    {
                        List<Boat> boats = CreateMemberBoats(view.registerperson()); // CREATE
                        Member newMember = new Member(view.getfirstname, view.getlastname, view.getpersnr, boats);
                        memberDAL.AddMember(newMember);
                    }
                    catch
                    {
                        view.ErrorMess("Medlem las inte till för att valideringen inte gick igenom av medlems data.");
                    }
                    Console.Clear();
                    break;

                case 2: //UPDATE
                    try
                    {
                        Console.Clear();
                        Member m = view.editperson(memberDAL.ReadMembers()); //Fel här, hämtar ut en lista av ALLA medlemmar, detta leder till att alla båtobjekt kommer med så väljer man t.ex
                        switch (view.EditMenu())//Person 1 kommer alla båtar även för pers. 2 / 3 hämtas ut via .Boats attributet.
                        {
                            case 1: //UPDATERA PERSONINFORMATION
                                view.editPersonalInfo(m);
                                m.FirstName = view.getfirstname;
                                m.LastName = view.getlastname;
                                m.PersonalNumber = view.getpersnr;
                                break;

                            case 2: //UPDATERA BÅTINFORMATION
                                view.editBoatInfo(m);

                                boattoedit = view.getcurrentboat;
                                m.Boats[boattoedit].Length = view.getboatlength;
                                m.Boats[boattoedit].BoatType = view.getboattype;

                                break;

                            case 3: //SKAPA EN NY BÅT OCH LÄGG TILL PÅ EXISTERANDE ANVÄNDARE.
                                //List<Boat> boats = CreateMemberBoats(view.registerperson());
                                //Member newMember = new Member(view.getfirstname, view.getlastname, view.getpersnr, boats);
                                //memberDAL.AddMember(newMember);
                                
                                view.AddnewBoat(m);
                                //BEHÖVER FUNKTION FÖR ATT LÄGGA TILL ENBART 1 BÅT. 

                                break;
                        }
                        memberDAL.EditMember(m);

                    }
                    catch
                    {
                        view.ErrorMess("Kunde inte redigera båt / Person.");
                    }
                    
                    break;

                case 3: //DELETE
                    try
                    {
                        Console.Clear();
                        Member toDelete = view.Deletechoice(memberDAL.ReadMembers());
                        switch (view.EditMenu())
                        {
                            case 1: //TA BORT PERSON
                                view.deleteperson(toDelete);
                                memberDAL.RemoveMember(toDelete);
                                break;

                            case 2: //TA BORT EN BÅT
                                view.DeleteBoat(toDelete);
                                boattodelete = view.getcurrentboat;
                                break;
                        }
                        

                    }
                    catch
                    {
                        view.ErrorMess("Kunde inte redigera båt / Person.");
                    }
                    Console.Clear();
                    break;

                case 4: //VIEW
                    Console.Clear();
                    view.Viewperson(memberDAL.ReadMembers());
                    break;
            }

            Runapplication();
        }


        private List<Boat> CreateMemberBoats(int amountOfBoats) //SKAPAR BÅTOBJEKT
        {
            List<Boat> MemberBoats = new List<Boat>(5);
            try
            {
                for (int i = 0; i < amountOfBoats; i++)
                {
                    view.readBoatInfo();
                    if (view.getboatlength <= 0 ||String.IsNullOrWhiteSpace(view.getboattype))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    MemberBoats.Add(new Boat(view.getboatlength, view.getboattype));
                }
            }
            catch
            {
                view.ErrorMess("Fel hände när båt data skrevs in.");
            }

            return MemberBoats;
        }
    }
}
