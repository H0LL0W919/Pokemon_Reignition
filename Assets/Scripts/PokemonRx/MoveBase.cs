using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Pokemon/Create New Move")]

public class MoveBase : ScriptableObject
{
    [Header("Move Name")]
    [SerializeField] string name;

    [Header("Move Description")]
    [TextArea]
    [SerializeField] string description;

    [Header("Move Type")]
    [SerializeField] PokemonType type;

    [Header("Move Data")]
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public PokemonType Type { get { return type; } }
    public int Power { get { return power; } }
    public int Accuracy { get { return accuracy; } }
    public int PP { get { return pp; } }

}
