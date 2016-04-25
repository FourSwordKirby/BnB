/*
Generated by UnityTwine on 04/25/2016 16:59:39
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class lucille_gift: TwineStory
{
	public override TwineVar this[string name]
	{
		get
		{
			switch(name)
			{
				default: throw new KeyNotFoundException(string.Format("There is no variable with the name '{0}'.", name));
			}
		}
		set
		{
			switch(name)
			{
				default: throw new KeyNotFoundException(string.Format("There is no variable with the name '{0}'.", name));
			}
		}
	}


	void Awake() {
		base.Init();
		passageInit_0();
	}
    
	// .............
	// #0: Start

	void passageInit_0()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{  }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"#lucy_item, +1#");
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Oh, sire! One more thing, before you go. I have the item you requested I retrieve! I'm sure Lucille will be very pleased to recieve it.");	
	}

}