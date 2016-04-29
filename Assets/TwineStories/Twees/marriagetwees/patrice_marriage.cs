/*
Generated by UnityTwine on 04/28/2016 21:00:49
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class patrice_marriage: TwineStory
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
		yield return new TwineText(@"%1, <pat>, <center>, <marriage>%");
		yield return new TwineText(@"<i>The marriage is everything you'd never dared to hope for. Music, good cheer, and a person--er, cow--by your side who actually wants to be there.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>The wedding is small, of course--there's really no one around to celebrate with--but the people who are in attendance are beaming ear to ear. You even notice tears in Beauregard's eyes.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Patrice smiles through the whole ceremony, as if unable to help herself. It makes something warm rise in your chest, to be able to make her so happy.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>During the reception, Patrice introduces you to her son, who has come with his grandmother to see his mother get married.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Patrice tries to teach you how to dance, but eventually you manage to gracefully bow out. She spends the next several dances twirling her giggling son around the floor.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>The night ends with Patrice giving her son a kiss on the cheek, and sending him off with his grandmother and the rest of the wedding guests. When she turns to you, her eyes are soft.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Tomorrow, you will wake up with your new wife, human once more--and your new life will begin.</i>");	
	}

}