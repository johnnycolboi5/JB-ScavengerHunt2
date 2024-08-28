using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public Image seekImage;
    public GameObject npc;
    public GameObject randomSpawn;

    [SerializeField]
    private Sprite[] collectibleSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CollectibleUpdate(int item)
    {

    }

    public void ShowBox(string dialog, int item)
    {
        if (npc.GetComponent<DialogOpen>().begin)
        {
            scatterCoins();
        }
    }

    public void scatterCoins()
    {
        randomSpawn.GetComponent<RandomSpawn>().DistributeCollectibles();
        npc.GetComponent<DialogOpen>().coinsScattered();
    }
}
