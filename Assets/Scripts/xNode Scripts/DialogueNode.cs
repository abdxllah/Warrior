using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogueNode : BaseNode {

	//dialogue node for when speakers are giving lines

	[Input] public int entry;
	[Output] public int exit;
	public string dialogueLine;
	public int tension;
	public int affinity; 
	public int fight; 
	public int red; 
	
public override string GetString()
{
	return "DialogueNode/" + dialogueLine;
}





}