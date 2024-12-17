using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
   public int currentLevel = 1;
   public int currentXP = 0;
   public int xpToNextLevel = 100;

   public float xpMultiplier = 1.5f;

   private void Start() {
       Debug.Log("Level: " + currentLevel + ", XP: " + currentXP + "/" + xpToNextLevel);  
   }

    public void AddXP(int xpAmount){
        currentXP += xpAmount;
        Debug.Log("XP Added: " + xpAmount + ", Total XP: " + currentXP);

        if(currentXP >= xpToNextLevel)
        {
            LevelUp();
        }
    }

    void LevelUp(){
        currentLevel++;
        currentXP -= xpToNextLevel;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * xpMultiplier);

        Debug.Log("Level Up! New Level: " + currentLevel);
        Debug.Log("XP: " + currentXP + "/" + xpToNextLevel);
}
}
