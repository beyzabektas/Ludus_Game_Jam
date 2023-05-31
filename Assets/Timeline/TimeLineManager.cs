using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class TimeLineManager : MonoBehaviour
{
    public string MainMenu; 
    private TimelinePlayable timeline;

 

    private PlayableDirector playableDirector;

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.stopped += OnTimelineFinish;
    }

    private void OnDestroy()
    {
        playableDirector.stopped -= OnTimelineFinish;
    }

    private void OnTimelineFinish(PlayableDirector director)
    {
       
        SceneManager.LoadScene(MainMenu);
    }
}
