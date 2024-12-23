using UnityEngine;

public interface IStats
{
    // strength - effects attack power
    public int Strength {  get; set; }

    // dexterity - effects chance to crit or dodge
    public int Dexterity { get; set; }

    // endurance - effects health and defense
    public int Endurance { get; set; }
}
