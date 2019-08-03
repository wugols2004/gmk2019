using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup pressKeyToStart;
    

    private void Awake()
    {        
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartFadeLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator StartFadeLoop()
    {
        while(true)
        {
            yield return pressKeyToStart.DOFade(0.5f, 1.5f).WaitForCompletion();
            yield return pressKeyToStart.DOFade(0.9f, 1.5f).WaitForCompletion();
        }        
    }
}
