using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    private static GameStatus m_instance = null;
    public GameObject resultBoard;

    void Awake()
    {
         if(m_instance == null) {
            m_instance = this;
        }
        else if(m_instance != this){
            Destroy(gameObject);
        }
    }

    public static GameStatus Instance{
        get{
            if(m_instance == null) {
                m_instance = new GameStatus();
            }
            return m_instance;
        }
    }

    public bool IsPlaying = true;
    
    public void stopPlaying() {
        IsPlaying = false;
        resultBoard.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        resultBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
