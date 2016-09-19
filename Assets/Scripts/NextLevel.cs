using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

	public int DoorIndex;
	public string nextLevel;


	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Door")) {

			int Door = other.gameObject.GetComponent<DoorScript> ().DoorIndex;

			if (gameObject.GetComponent<Inventory>().Keys[Door]) {
			
				SceneManager.LoadScene (nextLevel);
			}

		}
	}
		

}
