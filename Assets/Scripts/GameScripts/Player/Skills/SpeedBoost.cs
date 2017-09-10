using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Skill
{
    private float boost;
    private float duration;


    public SpeedBoost(string Name, float ManaCost, float boost, float duration) : base(Name, ManaCost)
    {
        this.boost = boost;
        this.duration = duration;
    }

    public override void Use(ref float PlayerMana)
    {
        if(PlayerMana < manaCost)
        {
            throw new ArgumentException("Current Mana cannot be lower than the ManaCost of the skill.");
        }
        PlayerMana -= manaCost;
        WorldScript.World.player.GetComponent<PlayerControlScript>().SpeedBoost(boost, duration);
    }







}
