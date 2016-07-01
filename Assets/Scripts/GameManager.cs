using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Level levelPrefab;
    private Level levelInstance;

	// Use this for initialization
	void Start () {
        BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            ResetGame();
	}

    private void BeginGame()
    {
        levelInstance = Instantiate(levelPrefab) as Level;
        levelInstance.Generate(20);//TODO: move this elsewhere
    }

    private void ResetGame()
    {
        levelInstance.Reset();
        Destroy(levelInstance.gameObject);
        BeginGame();
    }
}
