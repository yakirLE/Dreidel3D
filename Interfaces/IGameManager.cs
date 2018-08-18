using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Models;
using C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Interfaces
{
    public interface IGameManager
    {
        void AddToMonitor(Dreidel i_Dreidel);

        void AddToNotify(Player i_Player);
    }
}
