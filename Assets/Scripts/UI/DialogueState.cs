//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
using System;


public class DialogState {

	public enum Character
	{
		A,
		Beauregard,
		C,
		D,
		E
	}

	public Character FarLeftCharacter;
	public Character NearLeftCharacter;
	public Character CenterCharacter;
	public Character NearRightCharacter;
	public Character FarRightCharacter;






	public DialogState () {

	}
	

//	public Text optionText { get; private set; }
//
//	void Start()
//	{
//		this.optionText = this.GetComponent<Text>();
//	}
//
//	public void displayOption(string option)
//	{
//		optionText.text = option;
//	}
}