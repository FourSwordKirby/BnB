/*
Generated by UnityTwine on 4/29/2016 12:23:36 AM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class lucille_intro: TwineStory
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
		this.Passages["Start"] = new TwinePassage("Start", new string[]{  }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"%1, <lucy>, <center>, <neutral>%");
		yield return new TwineText(@"LUCILLE: 'Morning. I'm Lucille. I hope you don't expect me to curtsy.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAST: Good morning. You can call me...");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Adam.", @"Adam.", @"l1", null, null);
		yield return new TwineLink(@"Prince Adam.", @"Prince Adam.", @"l2", null, null);
		yield return new TwineLink(@"The Beast.", @"The Beast.", @"l3", null, null);	
	}
    
	// .............
	// #1: l1

	void passageInit_1()
	{
		this.Passages["l1"] = new TwinePassage("l1", new string[]{  }, passageExecute_1);
	}

	IEnumerable<TwineOutput> passageExecute_1()
	{
		yield return new TwineText(@"~1~");
		yield return new TwineText(@"$LucySmile$");
		yield return new TwineText(@"#lucy_approval, +5#");
		yield return new TwineText(@"LUCILLE: Adam. Huh. Less poncy than I would've expected.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: So are us girls supposed to just stand around in this big echo-y hall all day, or will there be food? I traveled a long way to get here.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Of course. It's the least I can do.", @"Of course. It's the least I can do.", @"Of course. It's the least I can do.", null, null);
		yield return new TwineLink(@"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", null, null);
		yield return new TwineLink(@"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", null, null);	
	}
    
	// .............
	// #2: l2

	void passageInit_2()
	{
		this.Passages["l2"] = new TwinePassage("l2", new string[]{  }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(@"~-1~");
		yield return new TwineText(@"$LucyAngry$");
		yield return new TwineText(@"#lucy_approval, -5#");
		yield return new TwineText(@"%1, <lucy>, <center>, <frown>%");
		yield return new TwineText(@"LUCILLE: Hmpfh. Poncy as expected.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: So are us girls supposed to just stand around in this big echo-y hall all day, or will there be food? I traveled a long way to get here.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Of course. It's the least I can do.", @"Of course. It's the least I can do.", @"Of course. It's the least I can do.", null, null);
		yield return new TwineLink(@"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", null, null);
		yield return new TwineLink(@"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", null, null);	
	}
    
	// .............
	// #3: l3

	void passageInit_3()
	{
		this.Passages["l3"] = new TwinePassage("l3", new string[]{  }, passageExecute_3);
	}

	IEnumerable<TwineOutput> passageExecute_3()
	{
		yield return new TwineText(@"~1~");
		yield return new TwineText(@"$LucySmile$");
		yield return new TwineText(@"%1, <lucy>, <center>, <smile>%");
		yield return new TwineText(@"LUCILLE: 'The Beast'? Hah. You royal types are all so dramatic.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: So are us girls supposed to just stand around in this big echo-y hall all day, or will there be food? I traveled a long way to get here.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Of course. It's the least I can do.", @"Of course. It's the least I can do.", @"Of course. It's the least I can do.", null, null);
		yield return new TwineLink(@"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", @"Didn't you eat before leaving home?", null, null);
		yield return new TwineLink(@"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", @"Typical of a peasant to ask for charity.", null, null);	
	}
    
	// .............
	// #4: Of course. It's the least I can do.

	void passageInit_4()
	{
		this.Passages["Of course. It's the least I can do."] = new TwinePassage("Of course. It's the least I can do.", new string[]{  }, passageExecute_4);
	}

	IEnumerable<TwineOutput> passageExecute_4()
	{
		yield return new TwineText(@"~0~");
		yield return new TwineText(@"%1, <lucy>, <center>, <neutral>%");
		yield return new TwineText(@"LUCILLE: Yes. It is.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: You know what you're getting yourself into, right? I mean, the cow should be a pretty big tip off. It's an insult.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: People aren't too happy with you right now. That tends to happen when you force women to come to a strange place as candidates for marriage to a man they don't know.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", null, null);
		yield return new TwineLink(@"I have as little choice in this as you do.", @"I have as little choice in this as you do.", @"I have as little choice in this as you do.", null, null);
		yield return new TwineLink(@"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", null, null);	
	}
    
	// .............
	// #5: Didn't you eat before leaving home?

	void passageInit_5()
	{
		this.Passages["Didn't you eat before leaving home?"] = new TwinePassage("Didn't you eat before leaving home?", new string[]{  }, passageExecute_5);
	}

	IEnumerable<TwineOutput> passageExecute_5()
	{
		yield return new TwineText(@"~0~");
		yield return new TwineText(@"%1, <lucy>, <center>, <frown>%");
		yield return new TwineText(@"LUCILLE: Oh, sure, I ate before leaving home. Two days ago.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: You know what you're getting yourself into, right? I mean, the cow should be a pretty big tip off. It's an insult.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: People aren't too happy with you right now. That tends to happen when you force women to come to a strange place as candidates for marriage to a man they don't know.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", null, null);
		yield return new TwineLink(@"I have as little choice in this as you do.", @"I have as little choice in this as you do.", @"I have as little choice in this as you do.", null, null);
		yield return new TwineLink(@"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", null, null);	
	}
    
	// .............
	// #6: Typical of a peasant to ask for charity.

	void passageInit_6()
	{
		this.Passages["Typical of a peasant to ask for charity."] = new TwinePassage("Typical of a peasant to ask for charity.", new string[]{  }, passageExecute_6);
	}

	IEnumerable<TwineOutput> passageExecute_6()
	{
		yield return new TwineText(@"~1~");
		yield return new TwineText(@"$LucyAngry$");
		yield return new TwineText(@"#lucy_approval, -5#");
		yield return new TwineText(@"%1, <lucy>, <center>, <frown>%");
		yield return new TwineText(@"LUCILLE: Right. That's me. The girl making selfish requests after volunteering to travel to a creepy castle so no one else had to.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: You know what you're getting yourself into, right? I mean, the cow should be a pretty big tip off. It's an insult.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: People aren't too happy with you right now. That tends to happen when you force women to come to a strange place as candidates for marriage to a man they don't know.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", @"My butler is the one who sent that summons.", null, null);
		yield return new TwineLink(@"I have as little choice in this as you do.", @"I have as little choice in this as you do.", @"I have as little choice in this as you do.", null, null);
		yield return new TwineLink(@"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", @"I'm used to people being unhappy with me.", null, null);	
	}
    
	// .............
	// #7: My butler is the one who sent that summons.

	void passageInit_7()
	{
		this.Passages["My butler is the one who sent that summons."] = new TwinePassage("My butler is the one who sent that summons.", new string[]{  }, passageExecute_7);
	}

	IEnumerable<TwineOutput> passageExecute_7()
	{
		yield return new TwineText(@"~-1~");
		yield return new TwineText(@"$LucyAngry$");
		yield return new TwineText(@"#lucy_approval, -5#");
		yield return new TwineText(@"%1, <lucy>, <center>, <frown>%");
		yield return new TwineText(@"LUCILLE: Oh, right. It's all the servant's fault. Typical.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: Excuse me. I've got some very important standing-around to get back to.");	
	}
    
	// .............
	// #8: I have as little choice in this as you do.

	void passageInit_8()
	{
		this.Passages["I have as little choice in this as you do."] = new TwinePassage("I have as little choice in this as you do.", new string[]{  }, passageExecute_8);
	}

	IEnumerable<TwineOutput> passageExecute_8()
	{
		yield return new TwineText(@"~-1~");
		yield return new TwineText(@"$LucyAngry$");
		yield return new TwineText(@"#lucy_approval, -5#");
		yield return new TwineText(@"%1, <lucy>, <center>, <frown>%");
		yield return new TwineText(@"LUCILLE: Right. I should've expected as much. Cryptic and condescending seems to be the way things go around here.");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: Excuse me. I've got some very important standing-around to get back to.");	
	}
    
	// .............
	// #9: I'm used to people being unhappy with me.

	void passageInit_9()
	{
		this.Passages["I'm used to people being unhappy with me."] = new TwinePassage("I'm used to people being unhappy with me.", new string[]{  }, passageExecute_9);
	}

	IEnumerable<TwineOutput> passageExecute_9()
	{
		yield return new TwineText(@"~0~");
		yield return new TwineText(@"%1, <lucy>, <center>, <neutral>%");
		yield return new TwineText(@"LUCILLE: Hm. Well. Not much I can say in response to that, is there?");
		yield return new TwineText(@"");
		yield return new TwineText(@"LUCILLE: So if you'll excuse me, I've got some very important standing-around to get back to.");	
	}

}