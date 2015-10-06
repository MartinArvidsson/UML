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

            try
            {
                view.StartMenu();
                choice = view.EditMenu();
                if (choice >= 0 && choice <= 4)
                {
                    MenuChoice();
                }
            }
            catch
            {
                view.NotValidInputError();
            }
        }

        public void MenuChoice()
        {
            
            switch (choice) //Mainmenus switch, CRUD
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
                        view.ValidationError();
                    }
                    Console.Clear();
                    break;

                case 2: //UPDATE
                    try
                    {
                        Console.Clear();
                        Member m = view.editperson(memberDAL.ReadMembers()); 
                        switch (view.EditMenu())
                        {
                                	        
		                        case 1: //updates person data
                                try
                                {
                                view.editPersonalInfo(m);
                                m.FirstName = view.getfirstname;
                                m.LastName = view.getlastname;
                                m.PersonalNumber = view.getpersnr;
                                
	                            }
	                            catch
	                            {
                                    view.ValidationError();
	                            }
                                break;

                            case 2: //Updates boat data
                                try
                                {
                                    view.editBoatInfo(m);

                                    boattoedit = view.getcurrentboat;
                                    m.Boats[boattoedit].Length = view.getboatlength;
                                    m.Boats[boattoedit].BoatType = view.getboattype;

                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;

                            case 3:
                                try
                                {
                                    view.AddnewBoat(m);
                                    m.Boats.Add(new Boat(view.getboatlength, view.getboattype));                                   
                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                        }
                        memberDAL.EditMember(m);

                    }
                    catch
                    {
                        view.EditError();
                    }
                    
                    break;

                case 3: //DELETE
                    try
                    {
                        Console.Clear();
                        Member toDelete = view.Deletechoice(memberDAL.ReadMembers());
                        switch (view.EditMenu())
                        {
                            case 1: //removes a member
                                try{
                                view.deleteperson(toDelete);
                                memberDAL.RemoveMember(toDelete);
                                
                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                            case 2: //removes a boat
                                try
                                {
                                    view.DeleteBoat(toDelete);
                                    toDelete.Boats.RemoveAt(view.getcurrentboat);
                                    memberDAL.EditMember(toDelete);
                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                        }
                        

                    }
                    catch
                    {
                        view.EditError();
                    }
                    Console.Clear();
                    break;

                case 4: //VIEW
                    try
                    {
                        Console.Clear();
                        view.Viewperson(memberDAL.ReadMembers());
                        switch (view.EditMenu())
                        {
                            case 1:
                                try
                                {
                                    view.listpersoncompact(memberDAL.ReadMembers());

                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                            case 2: 
                                try
                                {
                                    view.listpersonverbose(memberDAL.ReadMembers());
                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                            case 3:
                                try{
                                    view.listpersonspecific(memberDAL.ReadMembers());
                                }
                                catch
                                {
                                    view.ValidationError();
                                }
                                break;
                        }
                    }
                    catch 
                    {

                        view.EmptyDataBaseError();
                    }
                    break;
            }

            Runapplication();
        }


        private List<Boat> CreateMemberBoats(int amountOfBoats) //Creates a boat object
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
                view.ValidationError();
            }

            return MemberBoats;
        }
    }
}
