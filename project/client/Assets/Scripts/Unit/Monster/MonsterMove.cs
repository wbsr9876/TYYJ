using UnityEngine;
using System.Collections;
using GameBase;
using ConfigData;
using SkillSystem;

public class MonsterMove : MonoBehaviour {

	public float speed;
	public int unitIndex;
	private UnitProperty property;
	// Use this for initialization
	void Start () {
		property = new UnitProperty(gameObject,unitIndex);
		property.SetPos(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		//MOVE
		transform.Translate(new Vector3(-1*Time.deltaTime*speed,0,0),Space.World);
		property.SetPos(transform.position);
	}
}
