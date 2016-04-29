/*
Generated by UnityTwine on 04/28/2016 21:00:49
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class lucille_marriage: TwineStory
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
		yield return new TwineText(@"%1, <lucy>, <center>, <marriage>%");
		yield return new TwineText(@"<i>The marriage is everything you'd never dared to hope for. Music, good cheer, and a woman by your side who actually wants to be there.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>The wedding is small, of course--there's really no one around to celebrate with--but the people who are in attendance are beaming ear to ear. You even notice tears in Beauregard's eyes.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>During the reception, Lucille drinks champagne like it's her job, but there's always a grin hiding behind her champagne glass.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Beauregard even manages to get the two of you to dance, which goes as poorly as expected--but the minutes Lucille spends laughing at your clumsiness are some of the happiest of your life.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>The reception adjourns, and Lucille drags you and a bottle of wine back to your new shared bedroom.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Tomorrow, you will wake up with your new wife, human once more--and your new life will begin.</i>");	
	}

}