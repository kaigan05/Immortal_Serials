using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;

namespace AutoPot
{
    class BarPot
    {
        public BarPot(float health,float mana=0)
        {
            Health = health;
            Mana = mana;
            HealthPercent = Helper.GetPercent(Health, ObjectManager.Player.MaxHealth);
            ManaPercent = Helper.GetPercent(Mana, ObjectManager.Player.MaxMana);
        }
        public float Health { get; set; }
        public float Mana { get; set; }

        public float HealthPercent { get; set; }
        public float ManaPercent { get; set; }

        public static BarPot operator +(BarPot a, BarPot b)
        {
            return new BarPot(a.Health+b.Health,a.Mana+b.Mana);
        }
    }
}
