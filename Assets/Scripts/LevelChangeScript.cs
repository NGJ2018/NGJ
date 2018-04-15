using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelChangeScript : MonoBehaviour {
	private GameObject Player;

	private RoomHolder curEnabled;

	private Queue<RoomHolder> RQ;
	public RoomHolder StartingRoom;

	public PsychHolder Psych;

	// Use this for initialization
	void Start () {
		RQ = new Queue<RoomHolder> ();
		Player = GameObject.FindGameObjectWithTag ("Player");

		RQ.Enqueue (StartingRoom);

        changeLevel();
    }

    public void changeLevel(){
		print ("change");

		RoomHolder holder = RQ.Dequeue();

		if (holder.PsychFirst) {
			var ps = Psych;
			ps.NextRoom = holder.NextRoom;

			RQ.Enqueue (ps); //pysch
		} else{
			RQ.Enqueue (holder.NextRoom);
		}

		if (curEnabled != null) {
			curEnabled.gameObject.SetActive (false);
		}

		curEnabled = holder;
		holder.gameObject.SetActive (true);
		setPlayerPositionAndRotation(holder.SpawnPoint);
	

		try{
			BlinkController.OnBlink -= changeLevel;
		} catch(System.Exception e){
			
		}
    }

    void setPlayerPositionAndRotation(GameObject newPositionAndRotation){
		var rb = Player.GetComponent<Rigidbody> ();

		rb.isKinematic = true;

		Vector3 newRot = new Vector3 (
			                 newPositionAndRotation.transform.rotation.x,
			                 newPositionAndRotation.transform.rotation.y,
			                 newPositionAndRotation.transform.rotation.z);
		
		var cont = Player.GetComponent<RigidbodyFirstPersonController> ();

		cont.enabled = false;
		rb.position = newPositionAndRotation.transform.position;



		Player.transform.position = newPositionAndRotation.transform.position;
		Player.transform.rotation = newPositionAndRotation.transform.rotation;

		Camera.main.transform.rotation = Quaternion.Euler (Vector3.zero);

		rb.rotation = Quaternion.Euler(newRot);
		cont.enabled = true;
		rb.isKinematic = false;
    }
}
