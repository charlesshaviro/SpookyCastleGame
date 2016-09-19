using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// if CoinType = 0, this is a Silver Coin (worth 1 point)
	// if CoinType = 1, this is a Gold Coin (worth 5 points)
	// the code to differentiate between these two types is handled by CoinPickup.cs
	public int CoinType;


}
