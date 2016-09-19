using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	public bool[] Keys = new bool[5];



	void Start () {
	
		Keys = new bool[]{false, false, false, false, false};
	}

}
