/*
Generated by UnityTwine on 4/29/2016 12:23:36 AM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class tutorial_end: TwineStory
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
		yield return new TwineText(@"$BeauSmile$");
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Well then! Now that you've all been acquainted with his highness, I think you ought to make yourselves at home. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Please, feel free to <color=""white"">go wherever you like</color>. The castle is your home now, at least for this week.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: I think that went well, sire! Better than expected, at least. None of them have left yet!");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: I had no idea you were so <i>confident</i> in my abilities.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Oh, really, sire. You musn't take it so personally. Everyone needs a good dose of the truth sometimes.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Now, before you go out and catch yourself a bride, there's something you should know.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Light conversation is all well and good, but should you talk to your suitors about something more personal, you may lose track of time. <color=""white"">Two deeper conversations</color>, and poof! You'll find that it's <color=""white"">dinnertime</color> already.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Now go forth and woo yourself a fair maiden!");	
	}

}