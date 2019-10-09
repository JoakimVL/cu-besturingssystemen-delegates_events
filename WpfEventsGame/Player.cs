using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEventsGame
{
    public class Player
    {
        public int Health { get; private set; }
        public string Name { get; private set; }

        public delegate void PlayerEventHandler(object sender, PlayerEventArgs e);
        public event PlayerEventHandler OnDie;
        public event PlayerEventHandler OnHpChanged;

        public Player(int health, string playerName)
        {
            Health = health;
            Name = playerName;
        }

        public void GetHp()
        {
            Health++;

            if (OnHpChanged != null)
            {
                OnHpChanged(this, new PlayerEventArgs(false));
            }
        }

        public void LoseHp()
        {
            Health--;

            if(OnHpChanged != null)
            {
                OnHpChanged(this, new PlayerEventArgs(false));
            }            

            if (Health <= 0)
            {
                if (OnDie != null)
                {
                    OnDie(this, new PlayerEventArgs(true));
                }
            }
        }
    }

    public class PlayerEventArgs : EventArgs
    {
        //null means player is still alive and kickin'!
        public DateTime TimeOfDeath;

        public PlayerEventArgs(bool IsDead)
        {
            if (IsDead) { TimeOfDeath = DateTime.Now; }
        }
    }
}
