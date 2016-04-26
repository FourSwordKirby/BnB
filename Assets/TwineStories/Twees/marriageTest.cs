/*
Generated by UnityTwine on 4/25/2016 6:21:26 PM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class marriageTest: TwineStory
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
		passageInit_1();
		passageInit_2();
	}
    
	// .............
	// #0: StoryTitle

	void passageInit_0()
	{
		this.Passages["StoryTitle"] = new TwinePassage("StoryTitle", new string[]{  }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"Untitled Story");	
	}
    
	// .............
	// #1: Start

	void passageInit_1()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{  }, passageExecute_1);
	}

	IEnumerable<TwineOutput> passageExecute_1()
	{
		yield return new TwineText(@"Beauregard's voice echoes through the loudspeaker.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Please, sire! This isn't the right room, and you know it. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Stop messing about and meet me in the sitting parlor!");
		yield return new TwineText(@"");
		yield return new TwineText(@"&beau&");	
	}
    
	// .............
	// #2: StoryAuthor

	void passageInit_2()
	{
		this.Passages["StoryAuthor"] = new TwinePassage("StoryAuthor", new string[]{  }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(@"Anonymous");	
	}

}