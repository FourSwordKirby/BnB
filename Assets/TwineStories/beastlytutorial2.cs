/*
Generated by UnityTwine on 3/31/2016 11:32:51 AM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class beastlytutorial2: TwineStory
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
		passageInit_8();
		passageInit_9();
	}
    
	// .............
	// #0: Start

	void passageInit_0()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{ "beauFROWN", }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <frown>]BEAUREGARD: Sire! Sire, they're almost here! You can't keep sulking in your room like this.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: I can try.");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <angry>]BEAUREGARD: Oh, please. Sulking won't do you any good. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: If you hadn't spent all your time moping around the castle yelling at anyone who stopped by, you wouldn't be in this position to begin with!");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: Look at me, Beauregard. I'm a monster. There's no way any of those women will want me.");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <frown>]BEAUREGARD: Well, not with that attitude. You'll have to be significantly more well-mannered if you want to win their affections. Come, practice on me.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: What?");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <neutral>]BEAUREGARD: Like this. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <blush>]BEAUREGARD: //I'm a young woman from a small village, here to meet the man who could be my future husband...if he plays his cards right.//");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: Beau, this is ridiculous.");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <frown>]BEAUREGARD: We're running out of time, sire! Or would you rather face the women downstairs as you are now, having not spoken to a woman in ten years?");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: ...Fine.");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <neutral>]BEAUREGARD: Now then. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <blush>]BEAUREGARD: //My name's Olivia. What's yours?//");
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
		yield return new TwineText(@"[1, <beau>, <center>, <angry>]BEAUREGARD: Don't be ridiculous, sire! I won't have you introducing yourself with that //silly// nickname you came up with. It's depressing.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Fine. Prince Adam, then.", @"Fine. Prince Adam, then.", @"Prince Adam.", null, null);
		yield return new TwineLink(@"Then my name is Adam. Just Adam.", @"Then my name is Adam. Just Adam.", @"Adam. Just Adam.", null, null);
		yield return new TwineLink(@"Being like this is depressing. The name suits me.", @"Being like this is depressing. The name suits me.", @"Being like this is depressing. The name suits me.", null, null);	
	}
    
	// .............
	// #2: StoryTitle

	void passageInit_2()
	{
		this.Passages["StoryTitle"] = new TwinePassage("StoryTitle", new string[]{  }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(@"Untitled Story");	
	}
    
	// .............
	// #3: Prince Adam.

	void passageInit_3()
	{
		this.Passages["Prince Adam."] = new TwinePassage("Prince Adam.", new string[]{ "beauSMILE", }, passageExecute_3);
	}

	IEnumerable<TwineOutput> passageExecute_3()
	{
		yield return new TwineText(@"BEAUREGARD: [1, <beau>, <center>, <smile>]//A pleasure to meet you, your majesty! ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: [1, <beau>, <center>, <blush>]So, what is it like, living in a castle?//");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #4: Adam. Just Adam.

	void passageInit_4()
	{
		this.Passages["Adam. Just Adam."] = new TwinePassage("Adam. Just Adam.", new string[]{ "beauSMILE", }, passageExecute_4);
	}

	IEnumerable<TwineOutput> passageExecute_4()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <smile>]BEAUREGARD: //Oh, so humble! A pleasure to meet you, Adam.// ");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <blush>]BEAUREGARD: //So, what is it like, living in a castle?//");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #5: Being like this is depressing. The name suits me.

	void passageInit_5()
	{
		this.Passages["Being like this is depressing. The name suits me."] = new TwinePassage("Being like this is depressing. The name suits me.", new string[]{ "beauFROWN", }, passageExecute_5);
	}

	IEnumerable<TwineOutput> passageExecute_5()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <frown>]BEAUREGARD: Ugh! You're impossible. Let's just keep going. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <neutral>]BEAUREGARD: Ahem. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"[1, <beau>, <center>, <blush>]BEAUREGARD: //So, what is it like, living in a castle?//");
		yield return new TwineText(@"");
		yield return new TwineLink(@"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", @"I certainly enjoy it. I hope you will, too.", null, null);
		yield return new TwineLink(@"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", @"It's alright. Better than living in a straw hut, I suppose.", null, null);
		yield return new TwineLink(@"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", @"Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", null, null);	
	}
    
	// .............
	// #6: StoryAuthor

	void passageInit_6()
	{
		this.Passages["StoryAuthor"] = new TwinePassage("StoryAuthor", new string[]{  }, passageExecute_6);
	}

	IEnumerable<TwineOutput> passageExecute_6()
	{
		yield return new TwineText(@"Anonymous");	
	}
    
	// .............
	// #7: I certainly enjoy it. I hope you will, too.

	void passageInit_7()
	{
		this.Passages["I certainly enjoy it. I hope you will, too."] = new TwinePassage("I certainly enjoy it. I hope you will, too.", new string[]{ "beauSMILE", }, passageExecute_7);
	}

	IEnumerable<TwineOutput> passageExecute_7()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <smile>]BEAUREGARD: Very good, sire! If I were a young lady, I'm sure I'd feel very charmed.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'm quite sure you're ready to face your suitors. Shall we, then?");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll be waiting for you downstairs, in the great hall. Good luck, sire!");	
	}
    
	// .............
	// #8: It's alright. Better than living in a straw hut, I suppose.

	void passageInit_8()
	{
		this.Passages["It's alright. Better than living in a straw hut, I suppose."] = new TwinePassage("It's alright. Better than living in a straw hut, I suppose.", new string[]{ "beauFROWN", }, passageExecute_8);
	}

	IEnumerable<TwineOutput> passageExecute_8()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <neutral>]BEAUREGARD: Please, sire, try to control your enthusiasm. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Well, I'd say this is as good a time as any to face the ladies downstairs, don't you think? ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll be waiting for you downstairs, in the great hall.");	
	}
    
	// .............
	// #9: Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.

	void passageInit_9()
	{
		this.Passages["Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic."] = new TwinePassage("Living in a castle alone, because I'm too beastly for anyone to look at? It's fantastic.", new string[]{  }, passageExecute_9);
	}

	IEnumerable<TwineOutput> passageExecute_9()
	{
		yield return new TwineText(@"[1, <beau>, <center>, <frown>]BEAUREGARD: Ugh! Fine. I don't know why I bother. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: There's no point in delaying it any longer, sire, foul mood or no. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Come on, then. I'll meet you downstairs in the great hall.");	
	}

}