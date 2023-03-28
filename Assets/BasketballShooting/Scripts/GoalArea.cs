using UnityEngine;
using System.Collections;

public class GoalArea : MonoBehaviour {

	public ParticleSystem psStar;
	public int GoalAreaType ;

	public int score {get; private set;}
	private int goalCount;


	// Use this for initialization
	void Start () {
		score = 0;
		goalCount = 0;
	}



	void OnTriggerEnter (Collider other) {
		ShotBall sb = other.GetComponent<ShotBall>();
		Debug.Log("Collider");
		if (sb != null) {
			// Goal!!

			Debug.Log("Goal, "+ ScoreManager.Instance.IsCrashPan);

			if(GoalAreaType == 1) {
				GameManager.Instance.checkStep = 1;

				if(ScoreManager.Instance.IsCrashPan){
					score++;
					GameManager.Instance.goalScoreAnimPlay(1);
				} else {
					GameManager.Instance.goalScoreAnimPlay(2);
					score += 2;
				}
				
				psStar.Play();


			} else if(GoalAreaType == 2) {
				Shooter.Instance.ChargeBall();
				if(GameManager.Instance.checkStep == 0) return;
				GameManager.Instance.checkStep = 0;

				goalCount ++;

				if(goalCount == 4) {
					GameManager.Instance.moveBallLeft();
				}
				if(goalCount == 5) {
					GameManager.Instance.moveBallRight();
				}

				if(goalCount == 6) {
					GameManager.Instance.startMoveRing();
				}

				if(goalCount >= 10 && (goalCount / 4)%2 == 1 ) {
					GameManager.Instance.startMoveTopDown(1);
				}
				if(goalCount >= 10 && (goalCount / 4)%2 == 0 ) {
					GameManager.Instance.startMoveTopDown(-1);
				}

				
			}
		}
	}

}
