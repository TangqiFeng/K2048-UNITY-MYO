using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// store tiles (in Start method, the array will be deleted after executed)
	private Tile[,] AllTiles = new Tile[4, 4];

	// Use this for initialization
	void Start () {
		// get all tiles, store in an array
		Tile[] AllTilesOneDim = GameObject.FindObjectsOfType<Tile>();
		foreach (Tile t in AllTilesOneDim) {
			// clear all tiles
			t.Number = 0;
			// add tile to alltiles array
			AllTiles[t.indRow, t.indCol] = t;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Move (MoveDirection md)
	{
		Debug.Log (md.ToString () + " move.");
	}
}
