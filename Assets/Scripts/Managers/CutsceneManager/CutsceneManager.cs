using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class CutsceneManager : MonoBehaviour
{
        

    public PlayableDirector director;
    public List<TimelineAsset> timelines;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void PlayFromTimelines(int index)
    {
        TimelineAsset selectedAsset;

        if (timelines.Count <= index)
        {
            selectedAsset = timelines[timelines.Count - 1];
        }
        else
        {
            selectedAsset = timelines[index];
        }

        director.Play(selectedAsset);
    }
}