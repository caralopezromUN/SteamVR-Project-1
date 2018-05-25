using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
	public GameObject gameContainer;
	public GameController gameOn;
	private Vector3 initialPosition;
	public int score = 0;

	// Use this for initialization
	void Awake () {
		initialPosition = transform.localPosition;
	}

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag.Equals("Mole") == true)
        {
         Mole mole = col.gameObject.GetComponent<Mole>();
		 mole.OnHit ();
		 score++;
        }
    }

	// Update is called once per frame
	void Update () {
			if (gameOn.startedGame == false)
			{
				transform.localPosition = initialPosition;
			}
			
	}
}
