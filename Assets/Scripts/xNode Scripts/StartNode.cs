using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class StartNode : BaseNode {


	//start node
	[Output] public int exit;

	public override string GetString(){
		return "Start";
	}
}