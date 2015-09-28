using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop2.model;

namespace Workshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ECH!");
            Console.WriteLine("Hej");

            //TEST CODE
            MemberDAL members = new MemberDAL();

            members.AddMember(new Member("Stig", "Ålan", "560427-4237"));

            List<Member> AllMembers = members.ReadMembers();


            foreach(Member m in AllMembers){
                Console.WriteLine(m.FirstName);
                Console.WriteLine(m.LastName);
                Console.WriteLine(m.MemberID);
                Console.WriteLine(m.PersonalNumber);
                Console.WriteLine(m.Boats);
            }

            


            //TEST CODE END
        }
    }
}
