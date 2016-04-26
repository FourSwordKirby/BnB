/*
Generated by UnityTwine on 4/25/2016 6:15:00 PM
https://github.com/daterre/UnityTwine
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

public class marriage: TwineStory
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
		passageInit_10();
		passageInit_11();
	}
    
	// .............
	// #0: Start

	void passageInit_0()
	{
		this.Passages["Start"] = new TwinePassage("Start", new string[]{  }, passageExecute_0);
	}

	IEnumerable<TwineOutput> passageExecute_0()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: I'm so sorry to interrupt, but it's time for dinner, sire! ");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Oh, how the time flies! Who woud you like to dine with this evening, sire?");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Noelle.", @"Noelle.", @"Noelle.", null, null);
		yield return new TwineLink(@"Jane.", @"Jane.", @"Jane.", null, null);
		yield return new TwineLink(@"Patrice.", @"Patrice.", @"Patrice.", null, null);
		yield return new TwineLink(@"Lucille.", @"Lucille.", @"Lucille.", null, null);
		yield return new TwineLink(@"Henrietta.", @"Henrietta.", @"Henrietta.", null, null);	
	}
    
	// .............
	// #1: No one.

	void passageInit_1()
	{
		this.Passages["No one."] = new TwinePassage("No one.", new string[]{  }, passageExecute_1);
	}

	IEnumerable<TwineOutput> passageExecute_1()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Oh, yes. Ha ha. Very funny, sire. As if I would let you squander an opportunity like this!");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: Now, choose a dining companion or I'll do it for you!");
		yield return new TwineText(@"");
		yield return new TwineLink(@"Noelle.", @"Noelle.", @"Noelle.", null, null);
		yield return new TwineLink(@"Jane.", @"Jane.", @"Jane.", null, null);
		yield return new TwineLink(@"Patrice.", @"Patrice.", @"Patrice.", null, null);
		yield return new TwineLink(@"Lucille.", @"Lucille.", @"Lucille.", null, null);
		yield return new TwineLink(@"Henrietta.", @"Henrietta.", @"Henrietta.", null, null);	
	}
    
	// .............
	// #2: Henrietta.

	void passageInit_2()
	{
		this.Passages["Henrietta."] = new TwinePassage("Henrietta.", new string[]{  }, passageExecute_2);
	}

	IEnumerable<TwineOutput> passageExecute_2()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <frown>%");
		yield return new TwineText(@"BEAUREGARD: Oh. The...lovely Miss Henrietta. Right. ");
		yield return new TwineText(@"");
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Well, I'll, um. I suppose I'll set out some...hay? And remove the chair from the other end of the table...Oh, goodness.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"<i>The table is set.</i>", @"<i>The table is set.</i>", @"hen1", null, null);	
	}
    
	// .............
	// #3: Lucille.

	void passageInit_3()
	{
		this.Passages["Lucille."] = new TwinePassage("Lucille.", new string[]{  }, passageExecute_3);
	}

	IEnumerable<TwineOutput> passageExecute_3()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <neutral>%");
		yield return new TwineText(@"BEAUREGARD: Miss Lucille. Well. That's certainly an...interesting choice.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll be sure to provide the table with plenty of wine tonight, sire. I hope the evening proves pleasant.");
		yield return new TwineText(@"");
		yield return new TwineLink(@"<i>The table is set.</i>", @"<i>The table is set.</i>", @"lucy1", null, null);	
	}
    
	// .............
	// #4: Noelle.

	void passageInit_4()
	{
		this.Passages["Noelle."] = new TwinePassage("Noelle.", new string[]{  }, passageExecute_4);
	}

	IEnumerable<TwineOutput> passageExecute_4()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Ah, Miss Noelle. Perfect.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll get everything ready for you two. I'm sure it will be a perfectly pleasant evening!");
		yield return new TwineText(@"");
		yield return new TwineLink(@"<i>The table is set.</i>", @"<i>The table is set.</i>", @"noe1", null, null);	
	}
    
	// .............
	// #5: Patrice.

	void passageInit_5()
	{
		this.Passages["Patrice."] = new TwinePassage("Patrice.", new string[]{  }, passageExecute_5);
	}

	IEnumerable<TwineOutput> passageExecute_5()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Miss Patrice. A fine choice, sire.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: I'll make sure everything is just perfect for this evening!");
		yield return new TwineText(@"");
		yield return new TwineLink(@"<i>The table is set.</i>", @"<i>The table is set.</i>", @"pat1", null, null);	
	}
    
	// .............
	// #6: Jane.

	void passageInit_6()
	{
		this.Passages["Jane."] = new TwinePassage("Jane.", new string[]{  }, passageExecute_6);
	}

	IEnumerable<TwineOutput> passageExecute_6()
	{
		yield return new TwineText(@"%1, <beau>, <center>, <smile>%");
		yield return new TwineText(@"BEAUREGARD: Miss Jane! Lovely.");
		yield return new TwineText(@"");
		yield return new TwineText(@"BEAUREGARD: You dinner for two will be ready momentarily, sire!");
		yield return new TwineText(@"");
		yield return new TwineLink(@"<i>The table is set.</i>", @"<i>The table is set.</i>", @"john1", null, null);	
	}
    
	// .............
	// #7: hen1

	void passageInit_7()
	{
		this.Passages["hen1"] = new TwinePassage("hen1", new string[]{  }, passageExecute_7);
	}

	IEnumerable<TwineOutput> passageExecute_7()
	{
		yield return new TwineText(@"#hen_approval, +5#");
		yield return new TwineText(@"<i>The evening is calm, and pleasant. The dining room's comfortable silence is broken only by the rhythmic sounds of a cow chewing her cud.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>You might be imagining it, but there seems to be a happy gleam to Miss Henrietta's eyes.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>You walk Henrietta back to the pastures outside as gallantly as a beast walking alongside a cow  can.</i>");	
	}
    
	// .............
	// #8: lucy1

	void passageInit_8()
	{
		this.Passages["lucy1"] = new TwinePassage("lucy1", new string[]{  }, passageExecute_8);
	}

	IEnumerable<TwineOutput> passageExecute_8()
	{
		yield return new TwineText(@"#lucy_approval, +5#");
		yield return new TwineText(@"<i>It's a good thing Beauregard provided plenty of wine--despite her daily excursions to the wine cellar, Lucille goes straight for the glass bottles and starts knocking back drink after drink.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>As expected, her conversation is dry and acerbic--at least, it is at the start of the night. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>As the courses progress, you find that her comments have lost their biting edge. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Maybe it's just the wine that loosens the tight corners of her mouth, but you dare to think it might actually be your company.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>When you part ways for the night, her insults sound almost fond to your ears.</i>");	
	}
    
	// .............
	// #9: noe1

	void passageInit_9()
	{
		this.Passages["noe1"] = new TwinePassage("noe1", new string[]{  }, passageExecute_9);
	}

	IEnumerable<TwineOutput> passageExecute_9()
	{
		yield return new TwineText(@"#noelle_approval, +5#");
		yield return new TwineText(@"<i>As usual, the lady Noelle is the very picture of grace and poise. She handles herself with the air of one graciously bestowing her presence upon unworthy surroundings.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Nevertheless, you can't help but think she seems to become more comfortable over the course of the night. But then, you suppose making idle conversation about harmless topics while maintaining a comfortable physical distance would put anyone at ease. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>At the end of the night, you bid her a gallant farewell, and her smile appears almost genuine.</i>");	
	}
    
	// .............
	// #10: pat1

	void passageInit_10()
	{
		this.Passages["pat1"] = new TwinePassage("pat1", new string[]{  }, passageExecute_10);
	}

	IEnumerable<TwineOutput> passageExecute_10()
	{
		yield return new TwineText(@"#pat_approval, +5#");
		yield return new TwineText(@"<i>Pat is as kind and complimentary as always. Each course seems to amaze her more than the last, and it's clear that her pleased exclamations are sincere.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Pat always seems weighed down by something, distanced from the present by a problem no one else knows about. But tonight, bit by bit, her shoulders lift, and her expression lightens. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>When Beauregard's fancifully prepared dessert course makes her clap her hands and laugh delightedly, she looks years younger.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>You bow to her before she leaves for bed, and the smile she gives you is that of a bashful young girl.</i>");	
	}
    
	// .............
	// #11: john1

	void passageInit_11()
	{
		this.Passages["john1"] = new TwinePassage("john1", new string[]{  }, passageExecute_11);
	}

	IEnumerable<TwineOutput> passageExecute_11()
	{
		yield return new TwineText(@"#john_approval, +5#");
		yield return new TwineText(@"<i>Jane has the uncanny ability to make even the smallest of things into grand jokes, and over the course of the evening, this ability starts to rub off on you. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Eating with your ungainly claws becomes a source of laughter rather than embarrassment. </i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>Your struggle with a spoonful of soup makes both ends of the table turn red in the face from laughing--not that your skin is really visible under all the fur.</i>");
		yield return new TwineText(@"");
		yield return new TwineText(@"<i>You're still laughing as you part ways.</i>");	
	}

}