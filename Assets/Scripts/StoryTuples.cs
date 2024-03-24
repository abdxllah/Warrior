using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;


//script to declare a storytuple
public class StoryTuples
{
     public StoryTuples (DialogueGraph grph, StoryBeats beat){
        graph = grph;
        storybeat =beat;
     }

     public DialogueGraph graph;
     public StoryBeats storybeat;
}
