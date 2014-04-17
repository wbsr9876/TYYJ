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

	void OnTime()
	{
		Timer t = timerHeap.RemoveMin();
	}

	void SetTimer(float time,Timer.OnTimeHandle handle)
	{
		timerHeap.Insert(new Timer(Time.time + time,handle));
		Invoke ("OnTime", time);
	}
}
