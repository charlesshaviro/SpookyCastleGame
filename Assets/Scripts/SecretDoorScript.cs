using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class SecretDoorScript : MonoBehaviour {

	/** Used for doors that don't require keys to enter
	For example, the Easter Egg level **/

	public int nextLevel;

	void Start () {
		
	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player") ) {

			SceneManager.LoadScene (nextLevel);
		}
	}
}
