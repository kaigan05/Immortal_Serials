using System;
using System.Collections.Generic;
using System.Linq;
using ImmortalSerials.Objects;
using LeagueSharp;
using LeagueSharp.Common;

namespace ImmortalSerials.Model
{
    public static class SpellData
    {
        public static MySpell Q, W, E, R;
        public static MySpell Flash, Ignite;
        public static List<MySpell> PlayerSpells=new List<MySpell>();
        public static readonly List<MySpell> SpellList = new List<MySpell>();

        static SpellData()
        {
            SpellList.AddRange(
                new List<MySpell>
                {
                    new MySpell(SpellSlot.Q, 675) { ChampionName = "Katarina" },
                    new MySpell(SpellSlot.W, 375) { ChampionName = "Katarina",CastType = CastType.Self},
                    //EvadeType =EvadeType.MoveBuff, MoveSpeed = () => ObjectManager.Get<Obj_AI_Hero>().Any(h => h.IsValidTarget(375))? ObjectManager.Player.MoveSpeed *(1 + 0.10f + 0.05f * ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level): 0},
                    new MySpell(SpellSlot.E, 700)
                    {
                        ChampionName = "Katarina",
                        IsFlee = true,
                        TargetTypes = new[] { TargetType.Ally, TargetType.Enemy }
                    },
                    new MySpell(SpellSlot.R, 550) { ChampionName = "Katarina",CastType = CastType.Self }
                });
            //Q.SetSkillshot(Q.Instance.SData.SpellCastTime, Q.Instance.SData.LineWidth, Q.Instance.SData.MissileSpeed, true, SkillshotType.SkillshotLine);
            //Console.WriteLine("Add Leesin");
            SpellList.AddRange(
                new List<MySpell>
                {
                    new MySpell(SpellSlot.Q, 1100)
                    {
                        ChampionName = "LeeSin",
                        CastType = CastType.Skillshot,
                        Delay = 250,
                        Width = 65,
                        Speed = 1800,
                        Collision = true,
                        TargetTypes = new[]{TargetType.Enemy},
                        Type = SkillshotType.SkillshotLine,
                    },
                    new MySpell(SpellSlot.W, 700)
                    {
                        ChampionName = "LeeSin",CastType = CastType.Targeted,IsFlee = true,TargetTypes = new[] { TargetType.Ally}
                    },
                     new MySpell(SpellSlot.E, 350)
                     {
                         ChampionName = "LeeSin",CastType = CastType.Self,
                     },
                    new MySpell(SpellSlot.R, 375)
                    {
                        ChampionName = "LeeSin",CastType = CastType.Targeted,
                    }
                });
            Console.WriteLine("Add for");
            foreach (var spell in SpellList.Where(spell=>spell.ChampionName == ChampionData.Player.ChampionName))
            {
                spell.Name = ChampionData.Player.GetSpell(SpellSlot.Q).Name;
                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        PlayerSpells.Add(Q = spell);
                        break;
                    case SpellSlot.W:
                        PlayerSpells.Add(W = spell);
                        Console.WriteLine(W.Range);
                        break;
                    case SpellSlot.E:
                        PlayerSpells.Add(E = spell);
                        break;
                    case SpellSlot.R:
                        PlayerSpells.Add(R = spell);
                        break;
                }
            }
           
            var flash = ObjectManager.Player.GetSpellSlot("summonerflash");
            if (flash != SpellSlot.Unknown)
            {
                Flash = new MySpell(flash, 400);
            }
            var ignite = ObjectManager.Player.GetSpellSlot("summonerdot");
            if (ignite != SpellSlot.Unknown)
            {
                Ignite = new MySpell(ignite, 600);
            } 
        }
        public static Dictionary<SpellSlot, MySpell> GetSpell()
        {
            return SpellList.Where(spell => spell.ChampionName == ObjectManager.Player.ChampionName).ToDictionary(spell => spell.Slot);
        }
    }
}
