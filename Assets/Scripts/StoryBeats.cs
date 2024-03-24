using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;


public class StoryBeats 
{
    //a story beat class to encapsulate variables that all story beats should have
  

    public StoryBeats(int id, DialogueGraph grph, int ten, string aff, int fig, int red, int prob){
        identifier = id;
        graph = grph;
        tensionLevel = ten;
        affinityRequirements = aff;
        fightRequirements = fig;
        redButton = red;
        probability = prob;
    }

    public int identifier;
    public DialogueGraph graph;
    public int tensionLevel;
    public string affinityRequirements;
    public int fightRequirements;
    public int redButton; 
    public int probability;
  

  

  
}
