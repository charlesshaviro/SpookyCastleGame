using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// if CoinType = 0, this is a Silver Coin (worth 1 point)
	// if CoinType = 1, this is a Gold Coin (worth 5 points)
	// the code to differentiate between these two types is handled by CoinPickup.cs
	public int CoinType;
	private int CoinValue;

	void Start(){
		if (CoinType == 0) {
			CoinValue = 1;
		} else {
			CoinValue = 5;
		}
	}

	public int GetCoinValue(){
		return CoinValue;
	}


}
