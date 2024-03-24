using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;


//script for a choice node
public class ChoiceNode : BaseNode {
	[Input] public int entry;
	[Output] public int Agree;
	[Output] public int Disagree; 
	[Output] public int Anger;
	[Output] public int Threaten;
	[Output] public int Apologise;
	[Output] public int Thank;
	[Output] public int ExpressHappiness;
	[Output] public int ExpressSadness;
	[Output] public int Question;
	[Output] public int Resolve;
	[Output] public int Inappropriate;
	[Output] public int dontUnderstand;
	public int Tension;
	
public override string GetString()
{
	return "ChoiceNode";
}


	

	
}

