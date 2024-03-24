using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class NextBeat : BaseNode {

	//node for if the tension gets too high and the game ends

	[Input] public int entry;
	public int tension;
	public int affinity; 
	public int fight; 
	public int red; 


	public override string GetString(){
		return "NextBeat/" + tension + "/" + affinity + "/" + fight + "/" + red;
	}
}