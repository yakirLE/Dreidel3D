using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Interfaces;
using C16_Ex04_Yakir_201049475_Omer_300471430.CustomEventArgs;
using C16_Ex04_Yakir_201049475_Omer_300471430.Enums;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Models
{
    public class Player : GameComponent
    {
        public event EventHandler<DreidelEventArgs> Spin;

        private int m_Score;
        private string m_Bet;
        private eLetters m_BetLetter;
        private string m_PlayerStatus;
        private bool m_RoundStarted;
        private bool m_DidPlayerGiveInput;
        private IInputManager m_InputManager;
        private IGameManager m_GameManager;

        public string Bet
        {
            get { return m_Bet; }
            set { m_Bet = value; }
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public bool DidPlayerGiveInput
        {
            get { return m_DidPlayerGiveInput; }
            set { m_DidPlayerGiveInput = value; }
        }

        public bool RoundStarted
        {
            get { return m_RoundStarted; }
            set { m_RoundStarted = value; }
        }

        public Player(Game i_Game)
            : base(i_Game)
        {
            m_Score = 0;
            m_Bet = string.Empty;
            m_RoundStarted = false;
            m_DidPlayerGiveInput = false;
        }

        public override void Initialize()
        {
            m_InputManager = this.Game.Services.GetService(typeof(IInputManager)) as IInputManager;
            m_GameManager = this.Game.Services.GetService(typeof(IGameManager)) as IGameManager;
            notifyMe();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (m_InputManager.IsKeyPressed(Keys.B) && !this.RoundStarted)
            {
                this.Bet = "נ";
                m_BetLetter = eLetters.Nes;
                this.DidPlayerGiveInput = true;
            }
            else if (m_InputManager.IsKeyPressed(Keys.D) && !this.RoundStarted)
            {
                this.Bet = "ג";
                m_BetLetter = eLetters.Gadol;
                this.DidPlayerGiveInput = true;
            }
            else if (m_InputManager.IsKeyPressed(Keys.V) && !this.RoundStarted)
            {
                this.Bet = "ה";
                m_BetLetter = eLetters.Haya;
                this.DidPlayerGiveInput = true;
            }
            else if (m_InputManager.IsKeyPressed(Keys.P) && !this.RoundStarted)
            {
                this.Bet = "פ";
                m_BetLetter = eLetters.Po;
                this.DidPlayerGiveInput = true;
            }
            else if (m_InputManager.IsKeyPressed(Keys.Space) && this.DidPlayerGiveInput && !this.RoundStarted)
            {
                OnSpin(new DreidelEventArgs(m_BetLetter));
                this.RoundStarted = true;
            }

            m_PlayerStatus = string.Format("Score: {0}   Bet: {1}", this.Score.ToString(), this.Bet);
            this.Game.Window.Title = m_PlayerStatus;
            base.Update(gameTime);
        }

        protected virtual void OnSpin(DreidelEventArgs e)
        {
             if(Spin != null)
            {
                Spin.Invoke(this, e);
            }
        }

        private void notifyMe()
        {
            m_GameManager.AddToNotify(this);
        }
    }
}
