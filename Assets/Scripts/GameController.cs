using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject moleContainer;
	public TextMesh infoText;
	public Hammer hammer;
	public float spawnDuration = 1.5f;
	public float spawnDecrement = 0.1f;
	public float minimumSpawnDuration = 0.5f;
	public float gameTimer = 15f;
	public bool startedGame = false;

	private Mole[] moles;
	private float spawnTimer = 0f;
	private float resetTimer = 5f;

	// Use this for initialization
	void Start () {
		moles = moleContainer.GetComponentsInChildren<Mole> ();

		moles[Random.Range(0, moles.Length)].Rise ();
	}
	
	public void Initiate() {
		startedGame = true;
		resetTimer = 5f;
		gameTimer = 15f;
		hammer.score = 0;
	}

	// Update is called once per frame
	void Update () {
		if (startedGame == true)
		{
			gameTimer -= Time.deltaTime;
			if (gameTimer > 0f)
		{
			infoText.text = "Interactions\nTime: " + Mathf.Floor(gameTimer) + "\nScore:" + hammer.score;
			spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0f)
		{
			moles[Random.Range(0, moles.Length)].Rise ();
			spawnDuration -= spawnDecrement;
			if (spawnDuration < minimumSpawnDuration)
			{
				spawnDuration = minimumSpawnDuration;
			}
			spawnTimer = spawnDuration;
		}
		} else
		{
			infoText.text = "Game over!";
			resetTimer -= Time.deltaTime;
			if (resetTimer <= 0f)
			{
				startedGame = false;
				infoText.text = "Press Start!";
			}
		}
		} else
		{
			infoText.text = "Pick Up \nHammer!";
		}
	}
}