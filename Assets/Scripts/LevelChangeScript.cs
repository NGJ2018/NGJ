using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeScript : MonoBehaviour {

    public Dictionary<int,GameObject> levelEntrences;
    public int currentLevel;

	// Use this for initialization
	void Start () {
        levelEntrences = new Dictionary<int, GameObject>();
        var entrences = GameObject.FindGameObjectsWithTag("Level_Entrence");
        foreach(var level in entrences){
            var arr = level.name.Split('_');

            levelEntrences.Add(int.Parse(arr[1]),level);
        }

        currentLevel = 0;
        changeLevel();

    }

    public void changeLevel(){
        var newPos = levelEntrences[currentLevel];
        if(newPos != null){
            setPlayerPositionAndRotation(newPos);
            currentLevel++;
        }
    }

    void setPlayerPositionAndRotation(GameObject newPositionAndRotation){
        this.gameObject.transform.position = newPositionAndRotation.transform.position;
        this.gameObject.transform.rotation = newPositionAndRotation.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {

	}
}
