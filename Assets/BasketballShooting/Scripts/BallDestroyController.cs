using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyController : MonoBehaviour
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
		if (sb != null) {
			// Goal!!
            Destroy(sb.gameObject);    
            Shooter.Instance.setChargeState();
			
		}
	}

    

}
