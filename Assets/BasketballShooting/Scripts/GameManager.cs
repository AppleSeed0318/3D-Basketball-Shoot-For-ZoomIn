using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance = null;
    public GameObject goalRing;
    public GameObject shooter;
    public GameObject goalScoreAnim;
    public Text goalScoreText;

    public GameObject camera;

    private float speedV;
    private float moveTopDown;
    private bool flgMoveRing;

    public int checkStep {get; set;}

    void Awake()
    {
         if(m_instance == null) {
            m_instance = this;
        }
        else if(m_instance != this){
            Destroy(gameObject);
        }
    }

    public static GameManager Instance{
        get{
            if(m_instance == null) {
                m_instance = new GameManager();
            }
            return m_instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        checkStep = 0;
        moveTopDown = 0.0f;
        flgMoveRing = false;
        speedV = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(flgMoveRing) {
            goalRing.transform.Translate(speedV * Time.deltaTime, moveTopDown*speedV * 0.3f * Time.deltaTime, 0);

            if (goalRing.transform.position.x > 1.5){ 
                speedV = -1.0f;
            } else if (goalRing.transform.position.x < -1.5) {
                speedV = 1.0f;
            }
        }
    }

    public void changeBallPos (int dir) {
        shooter.transform.localPosition = new Vector3(dir, 0.11f, 0.72f);
    }

    public void moveBallRight() {
        goalRing.transform.localPosition = new Vector3(0.5f, goalRing.transform.position.y, goalRing.transform.position.z);
        camera.transform.localPosition = new Vector3(0.5f, camera.transform.position.y, camera.transform.position.z);
    }

    public void moveBallLeft() {
        goalRing.transform.localPosition = new Vector3(-0.5f, goalRing.transform.position.y, goalRing.transform.position.z);
        camera.transform.localPosition = new Vector3(-0.5f, camera.transform.position.y, camera.transform.position.z);
    }

    public void startMoveRing() {
        goalRing.transform.localPosition = new Vector3(0, goalRing.transform.position.y, goalRing.transform.position.z);
        camera.transform.localPosition = new Vector3(0, camera.transform.position.y, camera.transform.position.z);

        shooter.transform.localPosition = new Vector3(0, 0.11f, 0.72f);
        flgMoveRing = true;
    }

    public void goalScoreAnimPlay(int score) {
        goalScoreText.text = "+" + score.ToString();
        goalScoreAnim.GetComponent<Animation>().Play("goal");
    }

    public void startMoveTopDown(float flag) {
        moveTopDown = flag * 1.0f;
    }

    public void stopMoveRing() {
        flgMoveRing = false;
    }
}
