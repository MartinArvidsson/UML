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

        public void Runapplication()
        {
            

            choice = view.StartMenu();


            MenuChoice();
        }

        public void MenuChoice()
        {
            
            switch (choice)
            {
                case 0: 
                    Environment.Exit(0);
                    break;

                case 1:
                    try
                    {
                        List<Boat> boats = CreateMemberBoats(view.registerperson());
                        Member newMember = new Member(view.getfirstname, view.getlastname, view.getpersnr, boats);
                        memberDAL.AddMember(newMember);
                    }
                    catch
                    {
                        view.ErrorMess("Medlem las inte till för att valideringen inte gick igenom av medlems data.");
                    }
                    Console.Clear();
                    break;

                case 2:
                    try
                    {
                        //Member UpdatedMember = Edit(view.editperson(memberDAL.ReadMembers()));
                        //memberDAL.EditMember(UpdatedMember);
                        Console.Clear();
                        Member m = view.editperson(memberDAL.ReadMembers());
                        switch (view.EditMenu())
                        {
                            case 1:
                                view.editPersonalInfo(m);
                                m.FirstName = view.getfirstname;
                                m.LastName = view.getlastname;
                                m.PersonalNumber = view.getpersnr;
                                break;

                            case 2:
                                view.editBoatInfo(m);

                                boattoedit = view.returncurrentboat;
                                m.Boats[boattoedit].Lenght = view.getboatlength;
                                m.Boats[boattoedit].BoatType = view.getboattype;

                                break;
                        }
                        memberDAL.EditMember(m);

                    }
                    catch
                    {
                        //view.ErrorMess("Kunde inte redigera båt / Person.");
                    }
                    
                    break;

                case 3:
                    try
                    {
                        Member membertotdelete = view.deleteperson(memberDAL.ReadMembers());

                        memberDAL.RemoveMember(membertotdelete);
                    }
                    catch
                    {
                        view.ErrorMess("Ditt val av person som skulle tas bort existerade inte.");
                    }
                    Console.Clear();
                    break;

                case 4:
                    Console.Clear();
                    view.Viewperson(memberDAL.ReadMembers());
                    break;
            }

            Runapplication();
        }


        private List<Boat> CreateMemberBoats(int amountOfBoats)
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
