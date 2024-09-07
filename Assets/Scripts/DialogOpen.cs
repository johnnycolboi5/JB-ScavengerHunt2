using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialogue;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();

       
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialogue();
    }


    public void searchDialogue()
    {
        dialogue = "hey can you help me find my " + collectibles[clue] + "?";
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialogue, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            end = true;
        }
        else
        {
            dialogue = "no thats not my " + collectibles[clue] + " dummy";
        }
    }



    public void coinsScattered()
    {
        begin = false;
    }

}
