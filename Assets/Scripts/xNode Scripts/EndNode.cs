using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class EndNode : BaseNode {

	//node for if the tension gets too high and the game ends

	[Input] public int entry;
	public string dialogueLine;

	public override string GetString(){
		return "End/" + dialogueLine;
	}
}