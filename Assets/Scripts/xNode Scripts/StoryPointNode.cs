using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StoryPointNode : BaseNode {

	//node for if the tension gets too high and the game ends

	[Input] public int entry;
	[Output] public int exit;
	public string dialogueLine;

	public override string GetString()
{
	return "StoryPoint" + dialogueLine;
}

}