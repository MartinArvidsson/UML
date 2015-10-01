using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop2.model
{
    class Boat
    {
        private double _length;

        private string _boatType;

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public string BoatType 
        {
            get { return _boatType; }
            set { _boatType = value; }
        }

        public Boat(double length, string boatType) {
            _length = length;
            _boatType = boatType;
        }
    }
}
