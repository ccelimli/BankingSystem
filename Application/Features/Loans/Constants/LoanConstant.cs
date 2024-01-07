using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Features.Loans.Constants
{
    public struct LoanInterestRate
    {
        private Dictionary<int,double> data = new Dictionary<int, double>();
        
        public LoanInterestRate()
        {
            data.Add(0, 2.80);  
            data.Add(1, 2.80);  
            data.Add(2, 2.80);  
            data.Add(3, 2.80);  
        }

        public Dictionary<int,double> Data { get=> data;}
       //Mortgage = 2.80;
       //Vehicle = 3.65;
       //Consumer = 3.74;
       //Education = 3.25;
    }

}
