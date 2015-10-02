using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2.model
{
    class MemberDAL
    {
        //path to .txt file
        private string _path = "database.txt";

        //varibels that represents diffrent sections in the .txt file
        private string sectionMemberName = "[MemberName]";
        private string sectionMemberLastName = "[MemberLastName]";
        private string sectionMemberID = "[MemberID]";
        private string sectionPersonalNumber = "[MemberPersonalNumber]";
        private string sectionBoats = "[Boats]";
        private string sectionEnd = "[End]";

        //storage varibels for member object.
        private string Name;
        private string LastName;
        private string MemberID;
        private string PersonalNumber;

        //list of all members
        private List<Member> Members;
        //List of a members boats
        private List<Boat> MemberBoats;

        //Enum of current status for the reader.
        private enum MemberReadStatus { Indefinite, MemberFirstName, MemberLastName, MemberID, MemberPersonalNumber, Boats };

        //constructor
        public MemberDAL()
        {
            //TODO: Maby something in the future.
            
        }

        //Reads all members in the database.txt file and returns a List of Member objects.
        public List<Member> ReadMembers()
        {
            Members = new List<Member>(100);
            MemberBoats = new List<Boat>(5);

            Name = null;

            using (StreamReader read = new StreamReader(_path))
            {
                string reader;
                MemberReadStatus CurrentStatus = MemberReadStatus.Indefinite;

                while ((reader = read.ReadLine()) != null){
                    if (reader != "")
                    {
                        if (reader == sectionMemberName)
                        {
                            CurrentStatus = MemberReadStatus.MemberFirstName;
                        }
                        else if (reader == sectionMemberLastName)
                        {
                            CurrentStatus = MemberReadStatus.MemberLastName;
                        }
                        else if (reader == sectionMemberID)
                        {
                            CurrentStatus = MemberReadStatus.MemberID;
                        }
                        else if (reader == sectionPersonalNumber)
                        {
                            CurrentStatus = MemberReadStatus.MemberPersonalNumber;
                        }
                        else if (reader == sectionBoats)
                        {
                            CurrentStatus = MemberReadStatus.Boats;
                        }
                        else if(reader == sectionEnd && Name != null){
                            Member member = new Member(Name, LastName, PersonalNumber, MemberBoats, MemberID);
                            Members.Add(member);
                            //clears the list for the next member object
                            MemberBoats = new List<Boat>(5);
                        }
                        else
                        {
                            //Read data here.
                            switch (CurrentStatus)
                            {
                                case MemberReadStatus.MemberFirstName:
                                    //if name isent null a person just was read in.
                                    if (Name != null)
                                    {
                                        Member member = new Member(Name, LastName, PersonalNumber, MemberBoats, MemberID);
                                        Members.Add(member);
                                        //create new member object and att it to the list

                                        //clears the list for the next member object
                                        MemberBoats = new List<Boat>(5);
                                    }
                                    Name = reader;
                                    break;

                                case MemberReadStatus.MemberLastName:
                                    LastName = reader;
                                    break;

                                case MemberReadStatus.MemberID:
                                    //GuidConverter conver = new GuidConverter()
                                    MemberID = reader;
                                    break;

                                case MemberReadStatus.MemberPersonalNumber:
                                    PersonalNumber = reader;
                                    break;

                                case MemberReadStatus.Boats:
                                    string[] BoatInfo = reader.Split(new char[] { ';' }, StringSplitOptions.None);

                                    MemberBoats.Add(new Boat(double.Parse(BoatInfo[0]), BoatInfo[1]));                           
                                    break;
                                
                                default:
                                    throw new Exception();
                            }
                            
                        }
                    }
                }                
            }
            return Members;
        }


        //adds @member parameter to the .txt file
        public void AddMember(Member member)
        {
            List<Member> CurrMembers = ReadMembers();
            CurrMembers.Add(member);
            Save(CurrMembers);
        }


        //Edits a current members info.
        public void EditMember(Member member)
        {
            List<Member> CurrMembers = ReadMembers();
            for (int i = 0; i < CurrMembers.Count; i++)
            { 
                if (CurrMembers[i].MemberID == member.MemberID){
                    CurrMembers[i] = member; //object with old data
                    Save(CurrMembers); //object with new data
                    break;
                }
            }
        }

        //removes a registerd member
        public void RemoveMember(Member member)
        {
            List<Member> CurrMembers = ReadMembers();

            foreach (Member m in CurrMembers)
            {
                //it is EXREMLY unlikely that the ID's match, BUT if they do it's damn near impossible 
                //that those persons have the same name
                if (m.MemberID == member.MemberID)
                {
                    CurrMembers.Remove(m);
                    Save(CurrMembers);
                    break;
                }
            }
        }

        //Saves the databse.txt file based on parameter @_members
        public void Save(List<Member> _members)
        {
            //File.AppendText = Lägger till ny text till .txt filen.
            //new StreamWriter = skriver om HELA .txt filen.
            using (StreamWriter writer = new StreamWriter(_path))
            {               
                foreach (Member m in _members)
                {
                    writer.WriteLine(sectionMemberName);
                    writer.WriteLine(m.FirstName);

                    writer.WriteLine(sectionMemberLastName);
                    writer.WriteLine(m.LastName);

                    writer.WriteLine(sectionMemberID);
                    writer.WriteLine(m.MemberID);

                    writer.WriteLine(sectionPersonalNumber);
                    writer.WriteLine(m.PersonalNumber);

                    writer.WriteLine(sectionBoats);
                    foreach (Boat boat in m.Boats) {
                        writer.WriteLine("{0};{1}", boat.Length, boat.BoatType);
                    }
                }
                writer.WriteLine(sectionEnd);
            }
        }
    }
}
