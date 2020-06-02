using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;

    private int Score = 0;
    private GameObject ScoreText;

	void Start ()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.ScoreText  = GameObject.Find("Score");
    }
	
	
	void Update ()
    {
	    if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
            
        }
        this.ScoreText.GetComponent<Text>().text = this.Score.ToString() + " Score";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject .tag == ("LargeStarTag"))
        {
            Score += 1000;
           
        }
        else if(collision.gameObject.tag == ("SmallCloudTag"))
        {
            Score += 3000;
        }
        else if (collision.gameObject.tag == ("LargeCloudTag"))
        {
            Score += 5000;  
        }
    }
}
