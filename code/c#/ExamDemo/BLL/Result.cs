using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Result
    {
        private int topID;
        private int topKey;
        private int oResult;
        public int TopID
        {
            get
            {
                return topID;
            }

            set
            {
                topID = value;
            }
        }

        public int TopKey
        {
            get
            {
                return topKey;
            }

            set
            {
                topKey = value;
            }
        }

        public int OResult
        {
            get
            {
                return oResult;
            }

            set
            {
                oResult = value;
            }
        }
    }
}
