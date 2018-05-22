using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    /// <summary>
    /// Dungeons entity
    /// </summary>
    public class Donjon
    {
        public const String PATH = "/donjons";
        public const String BY_DONJON = "/donjons/";
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int loot { get; set; }
        public List<Donjon> Donjons { get; set; }
    }

    /// <summary>
    /// Quest entity
    /// </summary>
    public class Quest
    {
        public const String PATH = "/quetes";
        public const String BY_QUEST = "/quetes/";
        public int id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public int time { get; set; }
        public int xp { get; set; }
        public int loot { get; set; }
    }
}
