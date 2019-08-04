using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CutSceneState
{
    IDLE,
    ACTIVE,
    FINISHED
}

public class CutSceneBase : MonoBehaviour
{

    private bool isDestroyOnEnd;

    public UnityEvent onEnter;


    CutSceneState state;

    // Start is called before the first frame update
    void Start()
    {
        state = CutSceneState.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void InitCutScene()
    {
        state = CutSceneState.ACTIVE;
        Debug.Log("STARTCUTSCENE TEST");

        if(onEnter != null)
        {
            onEnter.Invoke();
        }
        
    }

    public virtual void EndCutScene()
    {
        state = CutSceneState.FINISHED;
        Debug.Log("END CUTSCENE TEST");

        if(isDestroyOnEnd)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && state == CutSceneState.IDLE)
        {
            InitCutScene();
        }
    }
}
