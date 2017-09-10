using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill {

    protected string name;
    protected float manaCost;
    

    public Skill(string Name, float ManaCost)
    {
        name = Name;
        manaCost = ManaCost;

    }


    public abstract void Use(ref float PlayerMana);

    public string getName()
    {
        return name;
    }


}
