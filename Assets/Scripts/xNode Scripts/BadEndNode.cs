using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BadEndNode : BaseNode {

	//node for if the tension gets too high and the game ends

	[Input] public int entry;

	public override string GetString(){
		return "BadEnd";
	}
}