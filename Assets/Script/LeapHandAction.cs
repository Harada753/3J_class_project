﻿using UnityEngine;
using System.Collections;
using Leap;

public class LeapHandAction : MonoBehaviour {
	Controller controller = new Controller();
	BlockController blockController;
	private GameObject block;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		Frame frame = controller.Frame();
		HandList hands = frame.Hands;
		Hand hand = hands[0];

		if (hand.Confidence < 0.2) return;

		if (!blockController) {
			ConnectWithBlock();
		}

		// Move
		Vector handCenter = hand.PalmPosition;
		float position_scale = 1000;
		float hand_x = handCenter.x / position_scale;
		float hand_z = -handCenter.z / position_scale;
		blockController.MoveBlock(hand_x, hand_z);
	}

	void ConnectWithBlock() {
		block = GameObject.Find("block");
		if (!block) return;
		blockController = block.GetComponent<BlockController>();
	}
}
