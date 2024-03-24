using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

public class TensionManager : MonoBehaviour
{

    //tension manager to deal with beat selection and managing game tensions as well as changing some aspects of graphics
    
    //global tension value that determines how the game progresses - following the three act structure - ensuring that we reach a climax in the story
    public int tension = 0 ;
    //global affinity value - positive value if towards Ulf and negative value is towards Trygve
    public int affinity = 0;
    //global fight value - how much Ulf and Trygve are hostile towards each other 
    public int fight = 0;
    //global redbutton value - this is the hostility towards the two main characters and on 100 it causes then the redbutton beat to occur
    public int redB = 0;

    public DialogueGraph beatOne;
    public StoryBeats oneStoryBeat;


    public DialogueGraph  ulfOneWarriorTalk;
    public StoryBeats ulfOneWarriorTalkBeat;
    public DialogueGraph  ulfOneEastAnglia;
    public StoryBeats ulfOneEastAngliaBeat;
    public DialogueGraph  ulfOneMercia;
    public StoryBeats ulfOneMerciaBeat;
    public DialogueGraph  ulfOneIceland;
    public StoryBeats ulfOneIcelandBeat;

    public DialogueGraph  trygveOneAshdown;
    public StoryBeats trygveOneAshdownBeat;
    public DialogueGraph  trygveOneFarming;
    public StoryBeats trygveOneFarmingBeat;
    public DialogueGraph  trygveOneRagnar;
    public StoryBeats trygveOneRagnarBeat;
    public DialogueGraph  trygveOneTrue;
    public StoryBeats trygveOneTrueBeat;

    public DialogueGraph neutralOneFloki;
    public StoryBeats neutralOneFlokiBeat;
    public DialogueGraph neutralOneLegends;
    public StoryBeats neutralOneLegendsBeat;

    public DialogueGraph  ulfTwoBjorn;
    public StoryBeats ulfTwoBjornBeat;
    public DialogueGraph  ulfTwoKill;
    public StoryBeats ulfTwoKillBeat;

    public DialogueGraph  trygveTwoChange;
    public StoryBeats trygveTwoChangeBeat;
    public DialogueGraph  trygveTwoSave;
    public StoryBeats trygveTwoSaveBeat;

    public DialogueGraph neutralTwoTogether;
    public StoryBeats neutralTwoTogetherBeat;
    
    public DialogueGraph climaxOne;
    public StoryBeats climaxOneBeat;
    public DialogueGraph climaxTwo;
    public StoryBeats climaxTwoBeat;
    public DialogueGraph climaxThree;
    public StoryBeats climaxThreeBeat;


    public DialogueGraph  ulfThreeFather;
    public StoryBeats ulfThreeFatherBeat;
    public DialogueGraph  ulfThreeNoSword;
    public StoryBeats ulfThreeNoSwordBeat;

    public DialogueGraph  trygveThreeFather;
    public StoryBeats trygveThreeFatherBeat;
    public DialogueGraph  trygveThreeDead;
    public StoryBeats trygveThreeDeadBeat;

    public DialogueGraph neutralThreeIngolfr;
    public StoryBeats neutralThreeIngolfrBeat;

    public DialogueGraph endingOne;
    public StoryBeats endingOneBeat;
    public DialogueGraph endingTwo;
    public StoryBeats endingTwoBeat;
    public DialogueGraph endingThree;
    public StoryBeats endingThreeBeat;
    public DialogueGraph endingFour;
    public StoryBeats endingFourBeat;



    public DialogueGraph currentNode;
    public DialogueGraph exposition;
    public DialogueGraph badend;

  
    public int startGame = 0;
    public Image tensionPanel;
    

    public List<StoryBeats> tensionLevel1 = new List<StoryBeats>();
    public List<StoryBeats> tensionLevel2 = new List<StoryBeats>();
    public List<StoryBeats> tensionLevel3 = new List<StoryBeats>();
    public List<StoryBeats> climaxes= new List<StoryBeats>();
    public List<StoryBeats> endingsT= new List<StoryBeats>();  
    public List<StoryBeats> endingsU= new List<StoryBeats>();    
    public List<StoryBeats> endings= new List<StoryBeats>();  

    //function to create beat variables and add them to the correct lists.
    public void AssignBeats(){
        oneStoryBeat = new StoryBeats(1, beatOne, 0, "none", 0, 0, 100);

        ulfOneWarriorTalkBeat = new StoryBeats(2,  ulfOneWarriorTalk, 5, "ulf", 0, 0, 50);
        ulfOneEastAngliaBeat = new StoryBeats(3,  ulfOneEastAnglia, 5, "ulf", 0, 0, 50);
        ulfOneMerciaBeat = new StoryBeats(4,  ulfOneMercia, 5, "ulf", 0, 0, 50);
        ulfOneIcelandBeat= new StoryBeats(5,  ulfOneIceland, 5, "ulf", 0, 0, 50);
        trygveOneAshdownBeat= new StoryBeats(5,  trygveOneAshdown, 5, "trygve", 0, 0, 50);
        trygveOneFarmingBeat= new StoryBeats(6,  trygveOneFarming, 5, "trygve", 0, 0, 50);
        trygveOneRagnarBeat= new StoryBeats(7,  trygveOneRagnar, 5, "trygve", 0, 0, 50);
        trygveOneTrueBeat= new StoryBeats(8,  trygveOneTrue, 5, "trygve", 0, 0, 50);
        neutralOneFlokiBeat = new StoryBeats(9,  neutralOneFloki, 5, "none", 0, 0, 50);
        neutralOneLegendsBeat = new StoryBeats(10,  neutralOneLegends, 5, "none", 0, 0, 50);

        tensionLevel1.Add(ulfOneWarriorTalkBeat);
        tensionLevel1.Add(ulfOneEastAngliaBeat);
        tensionLevel1.Add(ulfOneMerciaBeat);
        tensionLevel1.Add(ulfOneIcelandBeat);
        tensionLevel1.Add(trygveOneAshdownBeat);
        tensionLevel1.Add(trygveOneFarmingBeat);
        tensionLevel1.Add(trygveOneRagnarBeat);
        tensionLevel1.Add(trygveOneTrueBeat);    
        tensionLevel1.Add(neutralOneFlokiBeat);
        tensionLevel1.Add(neutralOneLegendsBeat);   

        ulfTwoBjornBeat = new StoryBeats(11,  ulfTwoBjorn, 5, "ulf", 0, 0, 50);
        ulfTwoKillBeat= new StoryBeats(12,  ulfTwoKill, 5, "ulf", 0, 0, 50);
        trygveTwoChangeBeat= new StoryBeats(13,  trygveTwoChange, 5, "trygve", 0, 0, 50);
        trygveTwoSaveBeat= new StoryBeats(14,  trygveTwoSave, 5, "trygve", 0, 0, 50);
        neutralTwoTogetherBeat = new StoryBeats(15,  neutralTwoTogether, 5, "none", 0, 0, 50);

        tensionLevel2.Add(ulfTwoBjornBeat);    
        tensionLevel2.Add(ulfTwoKillBeat);
        tensionLevel2.Add(trygveTwoChangeBeat);
        tensionLevel2.Add(trygveTwoSaveBeat);
        tensionLevel2.Add(neutralTwoTogetherBeat);
       
        climaxOneBeat = new StoryBeats(16,  climaxOne, 5, "none", 0, 0, 50);
        climaxTwoBeat = new StoryBeats(17,  climaxTwo, 5, "none", 0, 0, 50);
        climaxThreeBeat = new StoryBeats(18,  climaxThree, 5, "none", 0, 0, 50); 

        climaxes.Add(climaxOneBeat);
        climaxes.Add(climaxTwoBeat);
        climaxes.Add(climaxThreeBeat);


        ulfThreeFatherBeat = new StoryBeats(19,  ulfThreeFather, 5, "ulf", 0, 0, 50);
        ulfThreeNoSwordBeat = new StoryBeats(20,  ulfThreeNoSword, 5, "ulf", 0, 0, 50);
        trygveThreeDeadBeat= new StoryBeats(21,  trygveThreeDead, 5, "trygve", 0, 0, 50);
        trygveThreeFatherBeat= new StoryBeats(22,  trygveThreeFather, 5, "trygve", 0, 0, 50);
        neutralThreeIngolfrBeat = new StoryBeats(23,  neutralThreeIngolfr, 5, "none", 0, 0, 50);

        tensionLevel3.Add(ulfThreeFatherBeat);    
        tensionLevel3.Add(ulfThreeNoSwordBeat);
        tensionLevel3.Add(trygveThreeDeadBeat);
        tensionLevel3.Add(trygveThreeFatherBeat);
        tensionLevel3.Add(neutralThreeIngolfrBeat);

        endingOneBeat = new StoryBeats(24,  endingOne, 5, "none", 0, 0, 50);
        endingTwoBeat = new StoryBeats(25,  endingTwo, 5, "none", 0, 0, 50);
        endingThreeBeat = new StoryBeats(26,  endingThree, 5, "none", 0, 0, 50); 
        endingFourBeat = new StoryBeats(27,  endingFour, 5, "none", 0, 0, 50); 
        
        endingsU.Add(endingOneBeat);
        endingsT.Add(endingTwoBeat);
        endingsT.Add(endingThreeBeat);
        endingsU.Add(endingFourBeat);
        endings.Add(endingOneBeat);
        endings.Add(endingTwoBeat);
        endings.Add(endingThreeBeat);
        endings.Add(endingFourBeat);
    }
    //function to start the process
    public void Current(){

       
        if (startGame == 0){
        currentNode = oneStoryBeat.graph;
        startGame = 1;
        }




    }

    //function to find which beat we should move to next -- removes the beat from the beats that can be used
    public void CalculateNext(int ten, int aff, int fig, int red){


        //changing the global values
        tension += ten;
        affinity += aff;
        fight += fig;
        redB += red;

        // changing the colour of the scene if tension increases
         var temp = tensionPanel.color;
        

        

        List<StoryBeats> whichBeats = new List<StoryBeats>();
        StoryBeats chosen;
        switch(tension){
          case int i when i < 30:
          
            whichBeats = BeatsCanBe(tensionLevel1, affinity, fight, redB);
            if (whichBeats.Count == 0){
                tension = 30;
                currentNode= exposition;
                break;
            }
            chosen = WeightedRandomChoice(whichBeats);
            tensionLevel1.RemoveAll(beat => beat.identifier == chosen.identifier);
            currentNode = chosen.graph;
            break;


        case int i when i< 40 && i>= 30:
            currentNode = exposition;
            break;


        case int i when i >= 40 && i< 60: 
            tensionPanel.GetComponent<Image>();
            temp.a = 0.15f;
            tensionPanel.color =temp;
            whichBeats = tensionLevel2;
            if (whichBeats.Count == 0){
                tension = 60;
                whichBeats = climaxes; 
                chosen = WeightedRandomChoice(whichBeats);
                tensionLevel2.RemoveAll(beat => beat.identifier == chosen.identifier);
                currentNode = chosen.graph;
                break;
            }
            chosen = WeightedRandomChoice(whichBeats);
            tensionLevel2.RemoveAll(beat => beat.identifier == chosen.identifier);
            currentNode = chosen.graph;
            break;



        case int i when i >= 60 && i< 70:
            whichBeats = climaxes; 
            chosen = WeightedRandomChoice(whichBeats);
            tensionLevel2.RemoveAll(beat => beat.identifier == chosen.identifier);
            currentNode = chosen.graph;
            break;



        case int i when i >= 70 && i< 90:
            tensionPanel.GetComponent<Image>();
            temp.a = 0.2f;
            tensionPanel.color =temp;
            if (tensionLevel3.Count == 0){
                chosen = WeightedRandomChoice(endings);
                currentNode= chosen.graph;
                break;
            }
            chosen = WeightedRandomChoice(tensionLevel3);
            tensionLevel3.RemoveAll(beat => beat.identifier == chosen.identifier);
            currentNode = chosen.graph;
            break;

        case int i when i >= 90: 
            if (affinity >= 0){
                chosen = WeightedRandomChoice(endingsT);
                currentNode=chosen.graph;
                break;
            } else{

             if (affinity < 0){
                chosen = WeightedRandomChoice(endingsU);
                currentNode=chosen.graph;
                break;
            }}
            break;
        

        }

        if (redB >= 40){
            currentNode = badend;
        }

        
    }


    //function to choose a beat from the list of eligible beats based on there weighted probability
    public StoryBeats WeightedRandomChoice(List<StoryBeats> storyBeats){
    
    int totalProbability = 0;

    foreach (StoryBeats storyBeat in storyBeats)
    {
        totalProbability += storyBeat.probability;
    }

    int randomValue = Random.Range(0, totalProbability);
    int cumulativeProbability = 0;

    foreach (StoryBeats storyBeat in storyBeats)
    {
        cumulativeProbability += storyBeat.probability;

        if (randomValue < cumulativeProbability)
        {
            return storyBeat;
        }
    }

    return null;
    }   

    //function to find which beats are eligible to be selected
    public List<StoryBeats> BeatsCanBe(List<StoryBeats> storyBeats, int aff, int fig, int red){
        string affinityChosen = "none";
        switch(aff){
            case int i when i< 0:
                affinityChosen = "ulf";
                break;
            case 0:
                affinityChosen = "none";
                break;
            case int i when i>0:
                affinityChosen = "trygve";
                break;
        }
        List<StoryBeats> beatsNarrowed = new List<StoryBeats>();
        foreach (StoryBeats storyBeat in storyBeats)
    {
        if ((affinityChosen == storyBeat.affinityRequirements) && (fig >= storyBeat.fightRequirements) && (red >= storyBeat.redButton)){
            beatsNarrowed.Add(storyBeat);
        }
    }
        return beatsNarrowed;
    }

/*
what do i want to do
i want to have a set of tuples for each tension level. the first thing to do is using calculatenext 
should do before continuing is seeing what set of beats we are going to go into - using the tension variable
then look at the list of beats we have- check affinity for each
create a new list with just the beats that satisfy both affinity and fightrequirements
then use check the probability of every beat in that list and roll a dice to see which
beat to select.


*/

}
