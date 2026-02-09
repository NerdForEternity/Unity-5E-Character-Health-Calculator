using System.Collections.Generic;
using UnityEngine;
using System;

public class SolutionOne : MonoBehaviour {
    
    [SerializeField] private string Name;
    [SerializeField] private int Level;
    [SerializeField] private string Class;
    [SerializeField] private string Race;
    [SerializeField] private int Constitution;
    [SerializeField] private bool isTough;
    [SerializeField] private bool isStout;
    [SerializeField] private bool isRolled;

    string[] characterClass = {"Artificer", "Barbarian", "Bard", "Cleric", 
    "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer", 
    "Wizard", "Warlock"};
    

    private Dictionary<string, int> classHitDice = new Dictionary<string, int>();

    private double constitutionModifier;
    private int hitDieCount;
    private string ToughStoutString;
    private string RolledOrAveragedString;
    
    private void Start() {
        
        FillClassHitDiceDictionary();
        CalculateConstitutionModifier();
        UpdateBoolStrings();

        // Set Maximum Level of 20
        if(Level > 20) Level = 20;

        //Initial message declaring Character
        Debug.Log("My character " + Name + " is a level " + Level + " " + Class + 
        " with a CON score of " + Constitution + " and is of the " + Race + " and has " + ToughStoutString
        + " I want the HP " + RolledOrAveragedString);
        Debug.Log(constitutionModifier);

    }

    private void FillClassHitDiceDictionary()
    {
        //Fill classHitDice Dictionary
        classHitDice.Add("Artificer", 8);
        classHitDice.Add("Barbarian", 12);
        classHitDice.Add("Bard", 8);
        classHitDice.Add("Cleric", 8);
        classHitDice.Add("Druid", 8);
        classHitDice.Add("Fighter", 10);
        classHitDice.Add("Monk", 8);
        classHitDice.Add("Ranger", 10);
        classHitDice.Add("Rogue", 8);
        classHitDice.Add("Paladin", 10);
        classHitDice.Add("Sorcerer", 6);
        classHitDice.Add("Wizard", 6);
        classHitDice.Add("Warlock", 8);
    }

    private void CalculateConstitutionModifier()
    {
        constitutionModifier = Math.Floor((double)(Constitution - 10)/2);
    }

    private void UpdateBoolStrings()
    {
        switch (isTough + "-" + isStout)
        {
            case "true-true":
                ToughStoutString = "the Tough feat and the Stout feat.";
                break;
            case "true-false":
                ToughStoutString = "the Tough feat.";
                break;
            case "false-true":
                ToughStoutString = "the Stout feat.";
                break;
            case "false-false":
                ToughStoutString = "neither the Tough feat or the Stout feat.";
                break;
        }

        switch (isRolled)
        {
            case true:
                RolledOrAveragedString = "rolled.";
                break;
            case false:
                RolledOrAveragedString = "averaged.";
                break;
        }
    }
}