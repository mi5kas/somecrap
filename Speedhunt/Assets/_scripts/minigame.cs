using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class minigame : MonoBehaviour
{
    int whichSuspect = 1;
    [SerializeField] Text dateText;
    [SerializeField] Text baseInfo;
    [SerializeField] Text bioText;
    [SerializeField] Text suspectText;
    [SerializeField] Text showResults;
    [SerializeField] GameObject endMinigame;
    int howManyEvidence;
    int howManyAlibis;
    int howManyGoodTraits;
    int howManyBadTraits;
    int moneyGained = 0;
    string[] firstNamesFemale = new string[] { "Sarah", "Joanne", "Joyce", "Anna", "Kaylee", 
    "Mickayla", "Nicole", "Tracy", "Emma", "Jacklyn", "Evelynn", "Olivia", "Sophia", "Isabella",
    "Mia", "Charlotte", "Abigail", "Amelia", "Harper", "Ella", "Aria", "Avery", "Scarlett",
    "Mila", "Lily", "Chloe", "Layla", "Riley", "Elizabeth", "Addison", "Natalie", "Savannah" };
    string[] firstNamesMale = new string[] { "John", "Justin", "Alex", "Michael", "Robert", 
    "Christian", "Luke", "Paul", "Noah", "Liam", "Benjamin", "Elijah", "Alexander", "Ethan",
    "Logan", "Sebastian", "Carter", "Jayden", "Wyatt", "Grayson", "Gabriel", "Owen", "Levi", 
    "Lincoln", "Leo", "Jaxon", "Muhammad", "Isaiah", "Samuel", "Henry", "Jacob", "Jason", "Watt" };
    string[] lastNames = new string[] { "Faulkner", "Johnson", "Wolfe", "Black", "Robertson", 
    "Smith", "Yullker", "Fornell", "Nahf", "Wheelwright", "Cantor", "Boggs", "Wolk", "Le blanc",
    "De lorenzo", "Micallef", "Braudel", "Lovison", "Motimaya", "Bonhoeffer", "Thurber", "Sase",
    "Seoh", "Mcneill", "Foley", "Flemming", "Ghildyal", "Bashevis", "Lyons", "Lowenstein", "Hansen",
    "Ettner", "Bodrock", "Judd", "Tam", "Revlin", "Grusby", "Inniss", "Conklin", "Esslemont", "Malova",
    "Barrant", "Dottin", "Campos", "Magruder", "Serfling", "Touborg", "Casacchia", "Merrill", "Saph",
    "Larsen", "Hyatt", "Burner", "Ebbitt", "Randolph", "Munoz-porras", "Jaccarino", "Chun", "Hulbert" };
    string[] occupations = new string[] { "Baker", "Doctor", "Makeup artist", "Blogger", 
    "Youtuber", "Mechanic", "Programmer", "Designer", "Lawyer", "Psychologist", "Farmer", 
    "Managing director", "Fork-lift driver", "Shop assistant", "Illustrator", "Historian", "Decorator",
    "Cleaner", "Policeman", "Security guard", "Magician", "Builder", "Customs officer", "Nurse",
    "Taxi driver", "Lorry driver", "Fitness instructor", "School crossing warden", "Craftsperson" };

    string[] crimes = new string[] { "shoplifting", "mass murder", "vandalism", "selling drugs", 
    "insulting the government", "brawling", "terrorism", "promoting a sexual performance by a child",
    "bail jumping", "rape", "false advertising", "tax evasion", "bribe receiving", "car theft",
    "prostitution", "assault", "blackmail", "kidnapping", "burglary", "desecration", "diabolism", "extortion",
    "smuggling", "necromancy", "witchcraft", "poisoning the president", "robbery", "theft", "treason",
    "feeding dogs chocolate" };

    string[] evidence = new string[] { "surveilance camera footage", "eye witness", "fingerprints", "footprints", "traces of hair", "personal belongings", "confession", "victim's testimony" };

    string[] alibis = new string[] { "father", "mother", "son", "daughter", "co-worker", "boss", "girlfriend", "wife", "friend"};
    string[] traitsGood = new string[] { "gentle", "loves animals", "loves children", "honest", 
    "loyal", "respectful", "compassionate", "generous", "wise", "lively", "rational", "responsible",
    "outgoing" };
    string[] traitsEvil = new string[] { "evil", "addicted to cocaine", "loves shooting people for fun", 
    "abusive", "unstable", "insane", "likes torture", "possibly a vampire", "foolish", "likes staring at people",
    "untrustworthy", "traitorous", "sneaky", "no self discipline" };
    // Start is called before the first frame update
    void Start()
    {
        dateText.text = Random.Range(1, 5) + ":" + Random.Range(0, 59) + " PM";
        GenerateSuspect();
    }
    void GenerateSuspect()
    {
        suspectText.text = "SUSPECT " + whichSuspect + "/10";
        int maleFemale = Random.Range(0, 2);
        if(maleFemale == 0)
        {
            baseInfo.text = "NAME: " + firstNamesMale[Random.Range(0, firstNamesMale.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)] + "\nAGE: " + Random.Range(18, 60) + "\nSEX: Male\nOCCUPATION: " + occupations[Random.Range(0, occupations.Length)];
        }
        else
        {
            baseInfo.text = "NAME: " + firstNamesFemale[Random.Range(0, firstNamesFemale.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)] + "\nAGE: " + Random.Range(18, 60) + "\nSEX: Female\nOCCUPATION: " + occupations[Random.Range(0, occupations.Length)];
        }
        string evidenceText = "";
        howManyEvidence = Random.Range(0, 3);
        if(howManyEvidence == 0)
        {
            evidenceText = "No evidence collected so far.";
        }
        else if(howManyEvidence == 1)
        {
            evidenceText = "For evidence we only have " + evidence[Random.Range(0, evidence.Length)] + ".";
        }
        else if(howManyEvidence == 2)
        {
            int firstEvidence = Random.Range(0, evidence.Length);
            int secondEvidence;
            forSecondEvidence:
            secondEvidence = Random.Range(0, evidence.Length);
            if(secondEvidence == firstEvidence)
                goto forSecondEvidence;
            evidenceText = "Evidence includes " + evidence[firstEvidence] + " as well as " + evidence[secondEvidence] + ".";
        }
        string alibiText = "";
        howManyAlibis = Random.Range(0, 3);
        if(howManyAlibis == 0)
        {
            alibiText = " The suspect has no alibis.";
        }
        else if(howManyAlibis == 1)
        {
            alibiText = " The suspect has " + alibis[Random.Range(0, alibis.Length)] + " as alibi.";
        }
        else if(howManyAlibis == 2)
        {
            int firstEvidence = Random.Range(0, alibis.Length);
            int secondEvidence;
            forSecondEvidence:
            secondEvidence = Random.Range(0, alibis.Length);
            if(secondEvidence == firstEvidence)
                goto forSecondEvidence;
            alibiText = " Suspect's " + alibis[firstEvidence] + " and " + alibis[secondEvidence] + " claim that the suspect was somewhere else during the crime.";
        }
        string traitsText = "";
        howManyGoodTraits = Random.Range(0, 3);
        howManyBadTraits = Random.Range(0, 3);
        //int p = 0;
        int[] previous = { -1, -1, -1};
        for(int i=0; i<howManyGoodTraits; i++)
        {
            int traitPicked;
            pickingTrait:
            traitPicked = Random.Range(0, traitsGood.Length);
            if(previous.Contains(traitPicked))
                goto pickingTrait;
            traitsText+= traitsGood[traitPicked] + ", ";
            previous[i] = traitPicked;
        }
        previous[0] = -1;
        previous[1] = -1;
        previous[2] = -1;
        for(int i=0; i<howManyBadTraits; i++)
        {
            int traitPicked;
            pickingTrait:
            traitPicked = Random.Range(0, traitsEvil.Length);
            if(previous.Contains(traitPicked))
                goto pickingTrait;
            traitsText+= traitsEvil[traitPicked] + ", ";
            previous[i] = traitPicked;
        }
        bioText.text = "Suspected for " + crimes[Random.Range(0, crimes.Length)] + ". " + evidenceText + alibiText + " Personal traits: " + traitsText;
    }
    // Update is called once per frame
    public void EndMinigame()
    {
        endMinigame.SetActive(true);
    }
    public void ToJail()
    {
        if(howManyBadTraits+howManyEvidence-howManyGoodTraits-howManyAlibis > 0)
        {
            moneyGained+=10;
        }
        if(whichSuspect != 10)
        {
            whichSuspect++;
            GenerateSuspect();
        }
        else
        {
            showResults.transform.parent.gameObject.SetActive(true);
            suspectText.text = "NO SUSPECTS";
            showResults.text = "$" + moneyGained + " added to your account\nYour heat has been decreased";
        }
    }
    public void ToTrial()
    {
        if(howManyBadTraits+howManyEvidence-howManyGoodTraits-howManyAlibis <= 0)
        {
            moneyGained+=10;
        }
        if(whichSuspect != 10)
        {
            whichSuspect++;
            GenerateSuspect();
        }
        else
        {
            showResults.transform.parent.gameObject.SetActive(true);
            suspectText.text = "NO SUSPECTS";
            showResults.text = "$" + moneyGained + " added to your account\nYour heat has been decreased";
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")+moneyGained);
        }
    }
}
