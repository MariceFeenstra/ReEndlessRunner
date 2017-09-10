using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillList {

    public static SpeedBoost speedBoost;


	public static void Init()
    {
        speedBoost = new SpeedBoost("speed boost", 60, 2, 15);
    }


}
