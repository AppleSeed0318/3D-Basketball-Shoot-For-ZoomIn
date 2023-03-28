using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCrash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter (Collider other) {
        
		ShotBall sb = other.GetComponent<ShotBall>();
    Debug.Log("asdfasdf");
		if (sb != null) {
			// Goal!!
            ScoreManager.Instance.setCrashPan(true);


            Debug.Log("Crashed with board"+ ScoreManager.Instance.IsCrashPan);
		}
	}
}
