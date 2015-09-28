using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2.model
{
    class Member
    {
        //fields
        private string _FirstName;

        private string _LastName;

        private string _PersonalNr;

        private string _MemberID;

        private List<Boat> _MemberBoats;

        //properties
        public string FirstName
        {
            get { return _FirstName; }          
        }

        public string LastName
        {
            get { return _LastName; }
        }

        public string PersonalNumber
        {
            get { return _PersonalNr; }
        }
        public string MemberID
        {
            get { return _MemberID; }
        }
        public List<Boat> Boats
        {
            get { return _MemberBoats; }
        }

       
        public Member(string _firstName, string _lastName, string _personalNr)
            : this(_firstName, _lastName, _personalNr, null, null)
        {
            //This constructor calls the constructor with 5 parameters.
        }
        public Member(string _firstName, string _lastName, string _personalNr, string _memberID = null, List<Boat> _memberBoats = null)
        {
            _FirstName = _firstName;
            _LastName = _lastName;
            _PersonalNr = _personalNr;
            if(_memberID == null)
            {
                _MemberID = Guid.NewGuid().ToString();
            }
            else
            {
                _MemberID = _memberID;
            }
            _MemberBoats = _memberBoats;
            

            //TODO: Set all values and generate random ID
            //also test if default value works
        }

        
    }
}
