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
                    view.registerperson();
                    
                    try
                    {
                        Member newMember = new Member(view.getfirstname, view.getlastname, view.getpersnr);
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
                        Member membertoedit = view.editperson(memberDAL.ReadMembers());

                        membertoedit.FirstName = view.getfirstname;
                        membertoedit.LastName = view.getlastname;
                        membertoedit.PersonalNumber = view.getpersnr;

                        memberDAL.EditMember(membertoedit);
                        Console.Clear();
                    }
                    catch
                    {
                        view.ErrorMess("Ditt val av person som skulle tas bort existerade inte.");
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
    }
}
