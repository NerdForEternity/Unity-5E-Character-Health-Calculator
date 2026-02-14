using System.Collections.Generic;
using UnityEngine;
using System;

public class SolutionOne : MonoBehaviour
{

    [SerializeField] private new string name;
    [SerializeField] private int Level;
    [SerializeField] private string Class;
    [SerializeField] private string Race;
    [SerializeField] private int Constitution;
    [SerializeField] private bool isTough;
    [SerializeField] private bool isStout;
    [SerializeField] private bool isRolled;

    private double constitutionModifier;
    private int hitDieCount;
    private string ToughStoutString;
    private string RolledOrAveragedString;
    private double healthPoints;

    string[] characterClass = {"Artificer", "Barbarian", "Bard", "Cleric",
    "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer",
    "Wizard", "Warlock"};

    string[] characterRace = {"Aasimar", "Dragonborn", "Dwarf", "Elf",
        "Gnome", "Goliath", "Halfling", "Human", "Orc", "Tiefling"};

    private Dictionary<string, int> classHitDice = new Dictionary<string, int>()
    {
        {"Artificer", 8},
        {"Barbarian", 12},
        {"Bard", 8},
        {"Cleric", 8},
        {"Druid", 8},
        {"Fighter", 10},
        {"Monk", 8},
        {"Ranger", 10},
        {"Rogue", 8},
        {"Paladin", 10},
        {"Sorcerer", 6},
        {"Wizard", 6},
        {"Warlock", 8},

    };

    private void Start()
    {

        // Set Maximum Level of 20
        if (Level > 20) Level = 20;

        //Calculations for initial message
        CalculateConstitutionModifier();
        UpdateBoolStrings();

        //Initial message declaring Character Stats
        Debug.Log("My character " + name + " is a level " + Level + " " + Class +
        " with a CON score of " + Constitution + " and is of the " + Race + 
        " race. They have " + ToughStoutString + " I want the HP " 
        + RolledOrAveragedString);

        //HP Calculations
        RollHitDice();
        DetermineRaceBonus();

        Debug.Log("The character " + name + " has a total of " + Math.Floor(healthPoints) + " HP.");
        Debug.Log("Constitution Modifier: " + constitutionModifier);

    }

    private void CalculateConstitutionModifier()
    {
        constitutionModifier = Math.Floor((double)(Constitution - 10) / 2);
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
                ToughStoutString = "neither the Tough feat nor the Stout feat.";
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

    private void RollHitDice()
    {
        switch (isRolled)
        {
            case true:
                for (int i = 0; i < Level-1; i++)
                {
                    healthPoints += UnityEngine.Random.Range(1, classHitDice[Class]);
                }
                break;
            case false:
                healthPoints += Level * DieAverage();
                break;
        }

    }

    private void DetermineRaceBonus()
    {
        if (Class == "Dwarf")
        {
            healthPoints += Level * 2;
        }
        else if (Class == "Orc" ||  Class == "Goliath")
        {
            healthPoints += Level;
        }
    }

    private double DieAverage()
    {
        double average;
        average = (classHitDice[Class] + 1) / 2;
        return average;
    }
}