using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager m_instance = null;

    void Awake()
    {
         if(m_instance == null) {
            m_instance = this;
        }
        else if(m_instance != this){
            Destroy(gameObject);
        }
    }

    public static ScoreManager Instance{
        get{
            if(m_instance == null) {
                m_instance = new ScoreManager();
            }
            return m_instance;
        }
    }

    public bool IsCrashPan = false;
    

    public void setCrashPan(bool pan) {
        IsCrashPan = pan;

        Debug.Log(IsCrashPan);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
