using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Tile : MonoBehaviour {

	private Text TileText;
	private Image TileImage;

	void Awake(){
		TileText = GetComponentsInChildren<Text> ();
		TileImage = transform.Find ("NumberCell").GetComponent<Image> ();
	}

	void GetStyleFromHolder (int index){
		TileText.text = TileStyleHolder.Instance.TileStyles [index].Number;
		TileText.color = TileStyleHolder.Instance.TileStyles [index].TextColor;
		TileImage.color = TileStyleHolder.Instance.TileStyles [index].TileColor;
	}

	void GetStyle(int n){
		switch (n) {
		case 2:
			GetStyleFromHolder (0);
			break;
		case 4:
			GetStyleFromHolder (1);
			break;
		case 8:
			GetStyleFromHolder (2);
			break;
		case 16:
			GetStyleFromHolder (3);
			break;
		case 32:
			GetStyleFromHolder (4);
			break;
		case 64:
			GetStyleFromHolder (5);
			break;
		case 128:
			GetStyleFromHolder (6);
			break;
		case 256:
			GetStyleFromHolder (7);
			break;
		case 512:
			GetStyleFromHolder (8);
			break;
		case 1024:
			GetStyleFromHolder (9);
			break;
		case 2048:
			GetStyleFromHolder (10);
			break;
		case 4096:
			GetStyleFromHolder (11);
			break;
		default:
			Debug.LogError ("Check the number you pass to GetStyle() !");
			break;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
