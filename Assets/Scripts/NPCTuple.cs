using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//class to encapsulate an NPC tuple which contains all elements needed for crewmate NPC conversations
public class NPCTuple 
{
    public NPCTuple (string charac,string intro, string dial){
        introduction = intro;
        dialogue = dial;
        character = charac;
    }

    public string introduction;
    public string character;
    public string dialogue;

}
