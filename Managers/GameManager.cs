using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Interfaces;
using C16_Ex04_Yakir_201049475_Omer_300471430.Models;
using C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models;
using C16_Ex04_Yakir_201049475_Omer_300471430.Enums;
using C16_Ex04_Yakir_201049475_Omer_300471430.CustomEventArgs;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Managers
{
    public class GameManager : GameComponent, IGameManager
    {
        private const int k_MaxSpeed = 25;
        private const int k_MinSpeed = 10;
        private readonly Vector3 r_DreidelMostDistantPosition;
        private readonly Vector3 r_DreidelNearestPosition;
        // $G$ DSN-999 (-3) readonly..
        private List<Dreidel> m_Dreidels;
        private List<Player> m_Players;
        private List<Vector3> m_UnavailableDreidelPositions;
        private eLetters m_CurrentBetLetter;
        private int m_CurrentStoppedDreidelsCount;

        public GameManager(Game i_Game)
            : base(i_Game)
        {
            m_CurrentStoppedDreidelsCount = 0;
            r_DreidelMostDistantPosition = new Vector3(-100, -40, -40);
            r_DreidelNearestPosition = new Vector3(100, 40, 40);
            m_Dreidels = new List<Dreidel>();
            m_Players = new List<Player>();
            m_UnavailableDreidelPositions = new List<Vector3>();
            i_Game.Services.AddService(typeof(IGameManager), this);
            i_Game.Components.Add(this);
        }

        public override void Initialize()
        {
            setDreidelsRandomlyInWorld();
            base.Initialize();
        }

        public void AddToMonitor(Dreidel i_Dreidel)
        {
            if(!m_Dreidels.Contains(i_Dreidel))
            {
                i_Dreidel.StoppedSpinning += dreidel_StoppedSpinning;
                m_Dreidels.Add(i_Dreidel);
            }
        }

        public void AddToNotify(Player i_Player)
        {
            if(!m_Players.Contains(i_Player))
            {
                i_Player.Spin += player_Spin;
                m_Players.Add(i_Player);
            }
        }

        private void setDreidelsRandomlyInWorld()
        {
            int x, y, z;
            Vector3 currentPosition;
            Random randomPosition;

            m_UnavailableDreidelPositions = new List<Vector3>();
            randomPosition = new Random();
            foreach(Dreidel dreidel in m_Dreidels)
            {
                do
                {
                    x = randomPosition.Next((int)r_DreidelMostDistantPosition.X, (int)r_DreidelNearestPosition.X);
                    y = randomPosition.Next((int)r_DreidelMostDistantPosition.Y, (int)r_DreidelNearestPosition.Y);
                    z = randomPosition.Next((int)r_DreidelMostDistantPosition.Z, (int)r_DreidelNearestPosition.Z);
                    currentPosition = new Vector3(x, y, z);
                }
                while(doesDreidelsIntercect(currentPosition));
                m_UnavailableDreidelPositions.Add(currentPosition);
                dreidel.DreidelPosition = currentPosition;
            }
            
            m_UnavailableDreidelPositions.Clear();
        }

        private bool doesDreidelsIntercect(Vector3 i_CurrentPosition)
        {
            int power = 2;
            bool doesIntercect = false;
            double distance;

            foreach(Vector3 takenPosition in m_UnavailableDreidelPositions)
            {
                distance = Math.Sqrt(
                    Math.Pow(i_CurrentPosition.X - takenPosition.X, power) +
                    Math.Pow(i_CurrentPosition.Y - takenPosition.Y, power) +
                    Math.Pow(i_CurrentPosition.Z - takenPosition.Z, power));
                if (distance < m_Dreidels[0].DreidelHeight)
                {
                    doesIntercect = true;
                    break;
                }
            }

            return doesIntercect;
        }

        private void dreidel_StoppedSpinning(object sender, DreidelEventArgs e)
        {
            m_CurrentStoppedDreidelsCount++;
            if(e.CurrentLetter == m_CurrentBetLetter)
            {
                m_Players[0].Score++;
            }

            if(m_CurrentStoppedDreidelsCount == m_Dreidels.Count)
            {
                m_Players[0].DidPlayerGiveInput = false;
                m_Players[0].RoundStarted = false;
            }
        }

        private void player_Spin(object sender, DreidelEventArgs e)
        {
            Random randomSpeed;

            randomSpeed = new Random();
            m_CurrentStoppedDreidelsCount = 0;
            m_CurrentBetLetter = e.CurrentLetter;
            foreach (Dreidel dreidel in m_Dreidels)
            {
                dreidel.Spin(randomSpeed.Next(k_MinSpeed, k_MaxSpeed));
            }
        }
    }
}
