/*
Generated by UnityTwine on 04/03/2016 22:40:49
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class tutorial_a: TwineStory
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
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Sire! Sire, they're almost here! You can't keep sulking in your room like this.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: I can try.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <angry>%");
		yield return new TwineText(@"BEAUREGARD: Oh, please. Sulking won't do you any good. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: If you hadn't spent all your time moping around the castle yelling at anyone who stopped by, you wouldn't be in this position to begin with!");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Just stop hiding in your room and come meet me down in the sitting parlor. I'll help you get ready.");	
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