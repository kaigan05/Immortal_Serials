using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;

namespace AutoPot
{
    static class Helper
    {
        public static float PredictedHealth(this Obj_AI_Hero champion,int secondTime)
        {
            var predictedhealth = champion.Health + champion.HPRegenRate * secondTime;
            return predictedhealth > champion.MaxHealth ? champion.MaxHealth : predictedhealth;
        }
        public static float PredictedMana(this Obj_AI_Hero champion, int secondTime)
        {
            var predictedMana = champion.Mana + champion.PARRegenRate * secondTime;
            return predictedMana > champion.MaxMana ? champion.MaxMana : predictedMana;
        }
        public static int GetPercent(float cur, float max)
        {
            return (int)((cur * 1.0) / max * 100);
        }
    }
}
