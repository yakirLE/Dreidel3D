using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C16_Ex04_Yakir_201049475_Omer_300471430.Enums;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.CustomEventArgs
{
    public class DreidelEventArgs : EventArgs
    {
        private eLetters m_CurrentLetter;

        public eLetters CurrentLetter
        {
            get { return m_CurrentLetter; }
            set { m_CurrentLetter = value; }
        }

        public DreidelEventArgs(eLetters i_CurrentLetter)
        {
            m_CurrentLetter = i_CurrentLetter;
        }
    }
}
