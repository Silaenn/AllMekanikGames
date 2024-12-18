using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    [Serializable]
    public class Skill
    {
        public string skillName;
        public int requiredLevel;
        public bool isUnlocked;
        public Button skillButton;
    }
   public int currentLevel = 1;
   public int currentXP = 0;
   public int xpToNextLevel = 100;
   public float xpMultiplier = 1.5f;
   public bool run = false;
   public bool attack = false;
   public bool canShoot = true;
   public List<Skill> skillTree;

   private void Start() {
       Debug.Log("Level: " + currentLevel + ", XP: " + currentXP + "/" + xpToNextLevel);

       foreach (Skill skill in skillTree)  {
        skill.isUnlocked = false;
        if(skill.skillButton != null)
        {
            skill.skillButton.interactable = false;
            skill.skillButton.onClick.AddListener(() => ActivateSkill(skill.skillName));
        }
       }
   }


    public void AddXP(int xpAmount){
        currentXP += xpAmount;
        Debug.Log("XP Added: " + xpAmount + ", Total XP: " + currentXP);

        if(currentXP >= xpToNextLevel)
        {
            LevelUp();
        }

        CheckSkillUnlocks();
    }

    void LevelUp(){
        currentLevel++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * xpMultiplier);

        Debug.Log("Level Up! New Level: " + currentLevel);
        Debug.Log("XP: " + currentXP + "/" + xpToNextLevel);

        CheckSkillUnlocks();
    }

    void CheckSkillUnlocks(){
        foreach (Skill skill in skillTree){
            if(!skill.isUnlocked && currentLevel >= skill.requiredLevel)
            {
                skill.isUnlocked = true;
                  if (skill.skillButton != null)
                {
                    skill.skillButton.interactable = true;
                }
                Debug.Log("Skill Unlocked: " + skill.skillName);
            }
        }
    }

    void ActivateSkill(string skillName)
    {
        Debug.Log($"Skill Activated: {skillName}");
        // Implementasikan efek skill sesuai nama skill
        switch (skillName)
        {
            case "Run":
                run = !run;
                Debug.Log("Player can now run faster!");
                break;
            case "Attack":
            attack = !attack;
                Debug.Log("Player can now deal double damage!");
                break;
            default:
                Debug.Log("Unknown skill effect!");
                break;
        }
    }
}
