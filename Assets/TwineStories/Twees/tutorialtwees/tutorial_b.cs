/*
Generated by UnityTwine on 4/28/2016 10:10:02 PM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class tutorial_b: TwineStory
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
		passageInit_3();
		passageInit_4();
		passageInit_5();
		passageInit_6();
		passageInit_7();
	}
    
	// .............
	// #0: Start

	void passageInit_0()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{ "beauFROWN", }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"$BeauSmile$");
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: There you are, sire! Excellent. Now we can get you ready to woo a fair maiden.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: Look at me, Beauregard. I'm a monster. There's no way any of those women will want me.");
		yield return new TwineText(@"");
		yield return new TwineText(@"$BeauSad$");
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Well, not with that attitude. You'll have to be <color=""white"">significantly more well-mannered</color> if you want to win their affections. Come, practice on me.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: What?");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Like this. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"$BeauBlush$");
		yield return new TwineText(@"%1, <beau>, <center>, <blush>%");
		yield return new TwineText(@"BEAUREGARD: <i>I'm a young woman from a small village, here to meet the man who could be my future husband...if he plays his cards right.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: Beau, this is ridiculous.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: We're running out of time, sire! Or would you rather face the women out there as you are now, having not spoken to a woman in ten years?");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: ...Fine.");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Now then. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"$BeauBlush$");
		yield return new TwineText(@"%1, <beau>, <center>, <blush>%");
		yield return new TwineText(@"BEAUREGARD: <i>My name's Olivia. What's yours?</i>");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Prince Adam.", @"Prince Adam.", @"Prince Adam.", null, null);
		yield return new TwineLink(@"Adam. Just Adam.", @"Adam. Just Adam.", @"Adam. Just Adam.", null, null);
		yield return new TwineLink(@"Beast.", @"Beast.", @"Beast.", null, null);	
	}
    
	// .............
	// #1: Beast.

	void passageInit_1()
	{
		this.Passages["Beast."] = new TwinePassage("Beast.", new string[]{ "beauANGRY", }, passageExecute_1);
	}

	IEnumerable<TwineOutput> passageExecute_1()
	{
		yield return new TwineText(@"$BeauAngry$");
		yield return new TwineText(@"%1, <beau>, <center>, <angry>%");
		yield return new TwineText(@"BEAUREGARD: Don't be ridiculous, sire! I won't have you introducing yourself with that <i>silly</i> nickname you came up with. It's depressing.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Fine. Prince Adam, then.", @"Fine. Prince Adam, then.", @"Prince Adam.", null, null);
		yield return new TwineLink(@"Then my name is Adam. Just Adam.", @"Then my name is Adam. Just Adam.", @"Adam. Just Adam.", null, null);
		yield return new TwineLink(@"Being like this is depressing. The name suits me.", @"Being like this is depressing. The name suits me.", @"Being like this is depressing. The name suits me.", null, null);	
	}
    
	// .............
	// #2: Prince Adam.

	void passageInit_2()
	{
		this.Passages["Prince Adam."] = new TwinePassage("Prince Adam.", new string[]{ "beauSMILE", }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: <i>A pleasure to meet you, your majesty!</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <blush>%");
		yield return new TwineText(@"BEAUREGARD: ");
		yield return new TwineText(@"<i>So, what is it like, living in a castle?</i>");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #3: Adam. Just Adam.

	void passageInit_3()
	{
		this.Passages["Adam. Just Adam."] = new TwinePassage("Adam. Just Adam.", new string[]{ "beauSMILE", }, passageExecute_3);
	}

	IEnumerable<TwineOutput> passageExecute_3()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: <i>Oh, so humble! A pleasure to meet you, Adam.</i> ");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <blush>%");
		yield return new TwineText(@"BEAUREGARD: <i>So, what is it like, living in a castle?</i>");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #4: Being like this is depressing. The name suits me.

	void passageInit_4()
	{
		this.Passages["Being like this is depressing. The name suits me."] = new TwinePassage("Being like this is depressing. The name suits me.", new string[]{ "beauFROWN", }, passageExecute_4);
	}

	IEnumerable<TwineOutput> passageExecute_4()
	{
		yield return new TwineText(@"$BeauAngry$");
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Ugh! You're impossible. Let's just keep going. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Ahem. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <blush>%");
		yield return new TwineText(@"BEAUREGARD: <i>So, what is it like, living in a castle?</i>");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", @"Because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #5: I certainly enjoy it. I hope you will, too.

	void passageInit_5()
	{
		this.Passages["I certainly enjoy it. I hope you will, too."] = new TwinePassage("I certainly enjoy it. I hope you will, too.", new string[]{ "beauSMILE", }, passageExecute_5);
	}

	IEnumerable<TwineOutput> passageExecute_5()
	{
		yield return new TwineText(@"$BeauSmile$");
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Very good, sire! If I were a young lady, I'm sure I'd feel very charmed.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'm quite sure you're ready to <color=""white"">face your suitors</color>. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll go fetch them. They should be with you shortly.");	
	}
    
	// .............
	// #6: It's alright. Better than living in a straw hut, I suppose.

	void passageInit_6()
	{
		this.Passages["It's alright. Better than living in a straw hut, I suppose."] = new TwinePassage("It's alright. Better than living in a straw hut, I suppose.", new string[]{ "beauFROWN", }, passageExecute_6);
	}

	IEnumerable<TwineOutput> passageExecute_6()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Please, sire, try to control your enthusiasm. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Well, I'd say this is as good a time as any to face the ladies, don't you think? ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: <color=""white"">I'll bring them in now.</color>");	
	}
    
	// .............
	// #7: Because I'm too beastly for anyone to look at? It's fantastic.

	void passageInit_7()
	{
		this.Passages["Because I'm too beastly for anyone to look at? It's fantastic."] = new TwinePassage("Because I'm too beastly for anyone to look at? It's fantastic.", new string[]{  }, passageExecute_7);
	}

	IEnumerable<TwineOutput> passageExecute_7()
	{
		yield return new TwineText(@"$BeauAngry$");
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Ugh! Fine. I don't know why I bother. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: There's no point in delaying it any longer, sire, foul mood or no. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: <color=""white"">I'll bring the ladies in. </color>Please at least <i>attempt</i> to be civil?");	
	}

}