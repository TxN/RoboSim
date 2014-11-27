﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public string BlockID = "null";
	public string BlockName = "null block";
	public GameObject BlockObj;
	public BlockInfo.BlockType Type;
	
	public float BlockHealth = 100f;
	public float BlockCrashTol = 10f;
	public float BlockEnergyDrain = 0.0f;

	void Start () {
		BlockObj = this.gameObject;
	}

	public void RegisterBlock(GameObject owner)
	{
		owner.GetComponent<BlockManager> ().RegisterNew (BlockID, BlockName, Type, this.gameObject);


	}


}
