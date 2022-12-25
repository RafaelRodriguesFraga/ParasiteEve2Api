namespace Pe2Api.Domain.Queries.Response
{
    public class ParasiteEnergySeparatedByType
    {

        public List<Fire> Fire { get; set; }
        public List<Water> Water { get; set; }
        public List<Wind> Wind { get; set; }
        public List<Earth> Earth { get; set; }

        public ParasiteEnergySeparatedByType(List<Fire> fire, List<Water> water, List<Wind> wind, List<Earth> earth)
        {
            Fire = fire;
            Water = water;
            Wind = wind;
            Earth = earth;
        }
    }

    public class BaseType
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public int MpCost { get; set; }
        public int AtpLoss { get; set; }
        public int ExpCost { get; set; }
        public int BonusMp { get; set; }
        public int Power { get; set; }
    }

    public class Earth : BaseType
    {

    }

    public class Fire : BaseType
    {

    }

    public class Wind : BaseType
    {

    }

    public class Water : BaseType
    {

    }
}
