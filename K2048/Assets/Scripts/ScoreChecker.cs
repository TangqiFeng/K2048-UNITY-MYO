using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreChecker : MonoBehaviour {

	private int score;

	// SINGLETON
	public static ScoreChecker Instance;

	public Text ScoreText;
	public Text HighScoreText;

	public int Score{
		get{
			return score;
		}
		set{
			score = value;
			ScoreText.text = score.ToString();
			// check is/not the high score, then update highscore
			if(PlayerPrefs.GetInt("HighScore") < score){
				PlayerPrefs.SetInt ("HighScore", score);
				HighScoreText.text = score.ToString ();
			}
		}
	}

	void Awake(){
//		// clear high score manually
//		PlayerPrefs.DeleteAll ();

		Instance = this;

		// PlayerPrefs -> Stores and accesses player preferences between game sessions.
		// just for first time run the game, there is not a high score
		if (!PlayerPrefs.HasKey ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", 0);

		ScoreText.text = "0";
		HighScoreText.text = PlayerPrefs.GetInt ("HighScore").ToString();
	}
}
