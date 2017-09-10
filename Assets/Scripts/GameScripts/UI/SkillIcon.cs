using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcon : MonoBehaviour {

    public Image ManaBar;
    public Image skillIcon;
    public float ManaUsage;

    public Skill skill;

    PlayerStatScript playerStats;

    private Color skillIconBaseColor;
    private bool SkillAvailable;

	// Use this for initialization
	void Start () {
        skillIconBaseColor = skillIcon.color;
        skill = SkillList.speedBoost;
	}
	
	// Update is called once per frame
	void Update () {
        float ManaPerc = ManaToFloat();
        ManaBar.fillAmount = ManaPerc;

        if( ManaPerc >= 1)
        {
            skillIcon.color = skillIconBaseColor;
            SkillAvailable = true;
        }
        else
        {
            skillIcon.color = new Color(0.3f, 0.3f, 0.3f, 0.7f);
            SkillAvailable = false;
        }
        
	}

    float ManaToFloat()
    {
        float fillAmount = 0;
        if (playerStats != null)
        {
            fillAmount = playerStats.GetMana() / ManaUsage;
        }
        else
        {
            playerStats = WorldScript.World.player.GetComponent<PlayerStatScript>();
        }

        
        return fillAmount;
    }

    public void UseSkill()
    {
        if (SkillAvailable)
        {
            WorldScript.World.player.GetComponent<PlayerStatScript>().UseSkill(skill);
        }
        else
        {
            Debug.Log("not enough Mana.");
        }
    }


}
