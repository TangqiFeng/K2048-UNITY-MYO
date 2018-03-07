using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// store tiles (in Start method, the array will be deleted after executed)
	private Tile[,] AllTiles = new Tile[4, 4];
	// add tile array lists to store rows and columns
	private List<Tile[]> rows = new List<Tile[]> ();
	private List<Tile[]> columns = new List<Tile[]> ();
	// use list to store empty tiles
	private List<Tile> EmptyTiles = new List<Tile>();


	// Use this for initialization
	void Start () {
		// get all tiles, store in an array
		Tile[] AllTilesOneDim = GameObject.FindObjectsOfType<Tile>();
		foreach (Tile t in AllTilesOneDim) {
			// clear all tiles
			t.Number = 0;
			// add tile to alltiles array
			AllTiles[t.indRow, t.indCol] = t;
			// add to empty tile list
			EmptyTiles.Add(t);
		}

		// add rows and columns to tile array list
		rows.Add(new Tile[]{AllTiles[0,0],AllTiles[0,1],AllTiles[0,2],AllTiles[0,3]});
		rows.Add(new Tile[]{AllTiles[1,0],AllTiles[1,1],AllTiles[1,2],AllTiles[1,3]});
		rows.Add(new Tile[]{AllTiles[2,0],AllTiles[2,1],AllTiles[2,2],AllTiles[2,3]});
		rows.Add(new Tile[]{AllTiles[3,0],AllTiles[3,1],AllTiles[3,2],AllTiles[3,3]});
		columns.Add(new Tile[]{AllTiles[0,0],AllTiles[1,0],AllTiles[2,0],AllTiles[3,0]});
		columns.Add(new Tile[]{AllTiles[0,1],AllTiles[1,1],AllTiles[2,1],AllTiles[3,1]});
		columns.Add(new Tile[]{AllTiles[0,2],AllTiles[1,2],AllTiles[2,2],AllTiles[3,2]});
		columns.Add(new Tile[]{AllTiles[0,3],AllTiles[1,3],AllTiles[2,3],AllTiles[3,3]});

	}

	// generate a new tile (with number 2/4)
	void Generate(){
		// if empty tile exists, then generate a tile (2/4) in random position.
		if (EmptyTiles.Count > 0) {
			int indexForNewNumber = Random.Range (0, EmptyTiles.Count);
			// create a random number to control generate 4
			int RandomNumber = Random.Range(0,10);
			if(RandomNumber == 0)
				EmptyTiles [indexForNewNumber].Number = 4;
			else
				EmptyTiles [indexForNewNumber].Number = 2;
			EmptyTiles.RemoveAt (indexForNewNumber);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// add event to test method 'Generate'
		if (Input.GetKeyDown (KeyCode.G)) {
			Generate ();
		}
	}

	public void Move (MoveDirection md)
	{
		Debug.Log (md.ToString () + " move.");
	}
}
