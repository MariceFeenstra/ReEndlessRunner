using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatScript : MonoBehaviour
{

    private float score;

    private float currentMana;
    private float maxMana;
    private float manaRestorationRate;

    // Use this for initialization
    void Start()
    {
        score = 0;

        currentMana = 0;
        maxMana = 100;
        manaRestorationRate = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        restoreMana();


    }

    private void restoreMana()
    {
        if (currentMana < maxMana)
        {
            //currentMana += manaRestorationRate;
        }
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }



    #region getters
    public int GetScore()
    {
        return (int)score;
    }

    public float GetMana()
    {
        return currentMana;
    }
    public float GetManaPercentage()
    {
        return currentMana / maxMana;
    }

    #endregion

    public void PickupCoin(float sc)
    {
        score += sc;
        currentMana += sc;
    }

    public void UseSkill(Skill skill)
    {
        skill.Use(ref currentMana);
        Debug.Log("used Skill: "+skill.getName());
    }


}
