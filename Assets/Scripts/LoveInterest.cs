using UnityEngine;
using System.Collections;
using UnityTwine;


public class LoveInterest : MonoBehaviour {

    public TwineStory LoveInterestStory;

    //These are variables which are publically available and other characters can reference/acknowledge these
    public enum Rank
    {
        S,
        A, 
        B, 
        C
    }

    public Rank relationshipRank { get; private set; }
    public bool specialEventTriggered { get; private set; }
    public bool giftReceived { get; private set; }
    public GameManager.Room currentRoom { get; private set; }

    /// <summary>
    /// This is your actual affinity rating.
    /// Rating varies from 0 to 100. Every 20 points = another relationship rank
    /// </summary>
    private int affinityRating;

	// This shouldbe an interface with which to interact with this love interest's specific story
}
