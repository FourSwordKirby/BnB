//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections;
using System;


public class DialogState {

	public enum Character
	{
		None,
		A,
		Beauregard,
		C,
		D,
		E,
	}

	public Character FarLeftCharacter = Character.None;
	public Character NearLeftCharacter = Character.None;
	public Character CenterCharacter = Character.None;
	public Character NearRightCharacter= Character.None;
	public Character FarRightCharacter = Character.None;

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