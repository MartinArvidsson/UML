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
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name requires a value.");
                } 
                _FirstName = value;
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set {
                    if (String.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentNullException("Last name requires a value.");
                    }
                    _LastName = value; 
                } 
        }

        public string PersonalNumber
        {
            get { return _PersonalNr; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Personal number requires a value.");
                } 
                _PersonalNr = value;
            } //TODO: check if value is a legit personal number
        }
        //is read only
        public string MemberID
        {
            get { return _MemberID; }
        }
        public List<Boat> Boats
        {
            get { return _MemberBoats; }
            set { _MemberBoats = value; }
        }

       
        public Member(string _firstName, string _lastName, string _personalNr)
            : this(_firstName, _lastName, _personalNr, null, null)
        {
            //This constructor calls the constructor with 5 parameters.
        }


        public Member(string _firstName, string _lastName, string _personalNr, string _memberID = null, List<Boat> _memberBoats = null)
        {
            //validates values sent, they must NOT be null or white space.
            if (String.IsNullOrWhiteSpace(_firstName) || String.IsNullOrWhiteSpace(_lastName) || String.IsNullOrWhiteSpace(_personalNr))
            {
                throw new ArgumentNullException();
            }
            _FirstName = _firstName;
            _LastName = _lastName;
            _PersonalNr = _personalNr;
            if(_memberID == null)
            {
                //saving as string beacuse it makes it easier to handle when getting it form the .txt file.
                _MemberID = Guid.NewGuid().ToString();
            }
            else
            {
                _MemberID = _memberID;
            }
            _MemberBoats = _memberBoats;
        }

        
    }
}
