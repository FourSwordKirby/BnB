using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTwine;

//Basically just a struct to get and set the current status of the love interest.
public class LoveInterest : MonoBehaviour {

    //This is a collection of stories associated with this love interest.
    public TwineStory LoveInterestStory;

	public TwineStory DinnerStory;

	public int approvalRaiting;

    //These describe emotions which the love interest will display
    public enum Emotion
    {
        Neutral,
        Happy,
        Flattered,
        Angry,
        Sad
    }
    public List<Sprite> loveInterestSprites;

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
    public GameManager.RoomName currentRoom { get; private set; }

    /// <summary>
    /// This is your actual affinity rating.
    /// Rating varies from 0 to 100. Every 20 points = another relationship rank
    /// </summary>
    private int affinityRating;


    public Sprite getEmotionSprite(Emotion emotion)
    {
        return loveInterestSprites[(int)emotion];
    }

    public void increaseRank(int rank)
    {
        if (rank > 0)
            relationshipRank += rank;
        else
            Debug.Log("rank increase must be positive");
    }
    public void decreaseRank(int rank)
    {
        if (rank > 0)
            relationshipRank -= rank;
        else
            Debug.Log("rank increase must be positive");
    }
    public void receiveGift()
    {
        giftReceived = true;
    }
    public void triggerEvent()
    {
        specialEventTriggered = true;
    }
}
