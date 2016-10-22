/*TwinStick Assignment
 * Roald Russel T. Palaya
 * 300714999
 * Date last Modified: 10/3/2016
 */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    private int _lives;
    private int _score;

    [Header("UI objects")]
    public Text LivesLbl;
    public Text ScoreLbl;
   
    


    public int Lives
    {
        get {
            return this._lives;
        }
        set {
            this._lives = value;
            if (this._lives <= 0)
            {
               this._endGame();

            } else
            {
                this._lives = value;
                this.LivesLbl.text = "Lives: "+this._lives;
            }
        }
    }
    public int Score
    {
        get
        {
            return this._score;
        }
        set
        {
            this._score = value;
            this.ScoreLbl.text = "Score: " + this._score;
        }
    }



    // Use this for initialization
    void Start() {
       
        this._lives = 5;
        this._score = 0;
        Debug.Log("you start with: " + this._lives);
        
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}
    //happens after player loses
    private void _endGame()
    {
        SceneManager.LoadScene("RestartScene");

    }
    //Enables to play the game again
    
}
