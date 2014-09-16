using UnityEngine;
using System.Collections;
using GameBase;

public class TimerManager : MonoBehaviour {
	
	private MinHeap<Timer> timerHeap = new MinHeap<Timer>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTime()
	{
		print ("OnTime");
		Timer t = timerHeap.RemoveMin();
		t.OnTime();
	}

	public float SetTimer(float time,Timer.OnTimeHandle handle)
	{
        float finishTime = Time.time + time;
        timerHeap.Insert(new Timer(finishTime, handle));
		Invoke ("OnTime", time);
        return finishTime;
	}
}
