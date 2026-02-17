using UnityEngine;

public class SolutionTwo : MonoBehaviour
{
    [SerializeField] newPlayer player = new newPlayer();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private class newPlayer
    {
        private string name;
        private int level;
        private string pcClass;
        private string pcRace;
        private bool isTough;
        private bool isStout;
        private int conScore;
        private int conModifier;
        private int healthPoints;
        private bool calculateRolled;
        private bool calculateAverage;
        private int raceIndex;
        private int classIndex;
        private string[] CharacterRace = 
        [
            "Aasimar",
            "Dragonborn",
            "Dwarf",
            "Elf",
            "Gnome",
            "Goliath",
            "Halfling",
            "Human",
            "Orc",
            "Tiefling"
        ];
        private string[] CharacterClass = 
        [
            "Artificer",
            "Barbarian",
            "Bard",
            "Cleric",
            "Druid",
            "Fighter",
            "Monk",
            "Ranger",
            "Rogue",
            "Paladin",
            "Sorcerer",
            "Wizard",
            "Warlock"
        ];
        private int[] HitDie = 
        [
            8, 12, 8, 8, 8, 10, 8, 10, 8, 10, 6, 6, 8
        ];
        
        private newPlayer()
        {
            if(level > 20)
            {
                level = 20;
            }
            else if (level < 1 )
            {
                level = 1;
            };
            CalcIndexes();
            CalcConModifier();
        }
        
        private void CalcIndexes()
        {
            classIndex = partNames.IndexOf(pcClass);
            raceIndex = partNames.IndexOf(pcRace);
        }
        
        private void CalcConModifier()
        {
            conModifier = Math.Floor(conScore-10)/2;
        }
        
        private void CalcRaceBonus()
        {
            int raceBonus;
            if (CharacterClass[classIndex] == "Dwarf")
            {
                raceBonus += 2*level;
            }
            else if (CharacterClass[classIndex] == "Orc" || CharacterClass[classIndex] == "Goliath")
            {
                raceBonus += level;
            }
        }

        private int RollHitDice()
        {
            int startingHP;
        if (calculateRolled)
        {
            for (i = 0;i < level; i++)
            {
                startingHP += Random.Range(1, hitDie[classIndex])+conModifier;
            };
            
        }
        else if (calculateAverage)
        {
            startingHP += ((1+hitDie[classIndex])+conModifier)*level;
        };
        return startingHP;
        }
        
        private int CalcFeatBonus()
        {   
            int featBonus;
            if(isStout)
            {
                featBonus += 2*level;
            }
            else if (isTough)
            {
                featBonus += level;
            }
            return featBonus;
        }
        
    }

    
    void Start()
{
    Debug.Log("My character " + player.name + " is a level " + player.level + " " + player.CharacterClass +
        " with a CON score of " + player.conScore + " and is of the " + player.race + 
        " race.");
    
    player.healthPoints += player.RollHitDice();
    player.healthPoints += player.CalcRaceBonus();
    player.healthPoints += player.CalcFeatBonus();

    Debug.Log(player.name + " has " + player.healthPoints + " health points.");
}

// Update is called once per frame
void Update()
    {
        
    }
}
