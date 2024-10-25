using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create New Pokemon")]

public class PokemonBase : ScriptableObject
{
    [Header("Pokemon Name")]
    [SerializeField] string name;

    [Header("Pokemon Pokedex Description")]
    [TextArea]
    [SerializeField] string description;

    [Header("Pokemon sprites")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [Header("Pokemon Typing")]
    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;

    [Header("Pokemon Base Stats")]
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defence;
    [SerializeField] int spAttack;
    [SerializeField] int spDefence;
    [SerializeField] int speed;

    [Header("List of Learnable Moves")]
    [SerializeField] List<LearnableMoves> learnableMoves;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public Sprite FrontSprite { get { return frontSprite; } }
    public Sprite BackSprite { get {return backSprite; } }
    public PokemonType Type1 { get { return type1; } }
    public PokemonType Type2 { get { return type2; } }
    public int MaxHp { get { return maxHp; } }
    public int Attack { get { return attack; } }
    public int Defence { get { return defence; } }
    public int SpAttack { get { return spAttack; } }
    public int SpDefence { get {return spDefence; } }
    public int Speed { get { return speed; } }
    public List<LearnableMoves> LearnableMoves {  get { return learnableMoves; } }
}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base { get { return moveBase; } }
    public int Level { get { return level; } }
}

public enum PokemonType   // 
{
    None,
    Bug,
    Dark,
    Dragon,
    Electric,
    Fairy,
    Fighting,
    Fire,
    Flying,
    Ghost,
    Grass,
    Ground,
    Ice,
    Normal,
    Poison,
    Psychic,
    Rock,
    Steel,
    Water
}

public enum Stat
{
    Attack,
    Defence,
    SpAttack,
    SpDefence,
    Speed
}

public class TypeChart
{
    static float[][] chart =
    {
        //                           /BUG/ /DAR/ /DRA/ /ELE/ /FAI/ /FIG/ /FIR/ /FLY/ /GHO/ /GRA/  /GRO/ /ICE/ /NOR/ /POI/  /PSY/ /ROC/ /STE/ /WAT/         
        /*Bug*/        new float[] {  1f,   2f,   1f,   1f,  0.5f, 0.5f, 0.5f, 0.5f, 0.5f,   2f,   1f,   1f,   1f,  0.5f,   2f,   1f, 0.5f,  0.5f },
        /*Dark*/       new float[] {  1f, 0.5f,   1f,   1f,  0.5f, 0.5f,   1f,   1f,   2f,   1f,   1f,   1f,   1f,    1f,   2f,   1f,   1f,    1f },
        /*Dragon*/     new float[] {  1f,   1f,   2f,   1f,    0f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,    1f,   1f,   1f, 0.5f,    1f },
        /*Electric*/   new float[] {  1f,   1f, 0.5f, 0.5f,    1f,   1f,   1f,   2f,   1f, 0.5f,   0f,   1f,   1f,    1f,   1f,   1f,   1f,    2f },
        /*Fairy*/      new float[] {  1f,   2f,   2f,   1f,    1f,   2f, 0.5f,   1f,   1f,   1f,   1f,   1f,   1f,  0.5f,   1f,   1f, 0.5f,    1f },
        /*Fighting*/   new float[] {0.5f,   2f,   1f,   1f,  0.5f,   1f,   1f, 0.5f,   0f,   1f,   1f,   2f,   2f,  0.5f, 0.5f,   2f,   2f,    1f },
        /*Fire*/       new float[] {  2f,   1f, 0.5f,   1f,    1f,   1f, 0.5f,   1f,   1f,   2f,   1f,   2f,   1f,    1f,   1f, 0.5f,   2f,  0.5f },
        /*Flying*/     new float[] {  2f,   1f,   1f, 0.5f,    1f,   2f,   1f,   1f,   1f,   2f,   1f,   1f,   1f,    1f,   1f, 0.5f, 0.5f,    1f },
        /*Ghost*/      new float[] {  1f, 0.5f,   1f,   1f,    1f,   1f,   1f,   1f,   2f,   1f,   1f,   1f,   0f,    1f,   2f,   1f,   1f,    1f },
        /*Grass*/      new float[] {0.5f,   1f, 0.5f, 0.5f,    1f,   1f, 0.5f, 0.5f,   1f, 0.5f,   2f,   1f,   1f,  0.5f,   1f,   2f, 0.5f,    2f },
        /*Ground*/     new float[] {0.5f,   1f,   1f,   2f,    1f,   1f,   2f,   0f,   1f, 0.5f,   1f,   1f,   1f,    2f,   1f,   2f,   2f,    1f },
        /*Ice*/        new float[] {  1f,   1f,   2f,   1f,    1f,   1f, 0.5f,   2f,   1f,   2f,   2f, 0.5f,   1f,    1f,   1f,   1f, 0.5f,  0.5f },
        /*Normal*/     new float[] {  1f,   1f,   1f,   1f,    1f,   1f,   1f,   1f,   0f,   1f,   1f,   1f,   1f,    1f,   1f, 0.5f, 0.5f,    1f },
        /*Poison*/     new float[] {  1f,   1f,   1f,   1f,    2f,   1f,   1f,   1f, 0.5f,   2f, 0.5f,   1f,   1f,  0.5f,   1f, 0.5f,   0f,    1f },
        /*Psychic*/    new float[] {  1f,   0f,   1f,   1f,    1f,   2f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,    2f, 0.5f,   1f, 0.5f,    1f },
        /*Rock*/       new float[] {  2f,   1f,   1f,   1f,    1f, 0.5f,   2f,   2f,   1f,   1f, 0.5f,   2f,   1f,    1f,   1f,   1f, 0.5f,    1f },
        /*Steel*/      new float[] {  1f,   1f,   1f, 0.5f,    2f,   1f, 0.5f,   1f,   1f,   1f,   1f,   2f,   1f,    1f,   1f,   2f, 0.5f,  0.5f },
        /*Water*/      new float[] {  1f,   1f, 0.5f,   1f,    1f,   1f,   2f,   1f,   1f, 0.5f,   2f,   1f,   1f,    1f,   1f,   2f,   1f,  0.5f },
    };

    public static float GetEffectiveness(PokemonType attackType, PokemonType defenceType)
    {
        if (attackType == PokemonType.None || defenceType == PokemonType.None)
            return 1;

        int row = (int)attackType - 1;
        int col = (int)defenceType - 1;

        return chart[row][col];
    }

}