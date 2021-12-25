using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int damagePlayer1;
    int damagePlayer2;
    int bonesPlayer1;
    int bonesPlayer2;

    public TextMeshProUGUI damagePlayer1Text;
    public TextMeshProUGUI damagePlayer2Text;
    public TextMeshProUGUI bonesPlayer1Text;
    public TextMeshProUGUI bonesPlayer2Text;

    [SerializeField, Tooltip("Board transform")]
    Transform board;

    [SerializeField, Tooltip("Card prefab")]
    GameObject cardPrefab;

    Card[] cards;

    static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        cards = new Card[8];
        for (int i = 0; i < 8; i++)
        {
            cards[i] = Instantiate(cardPrefab, board).GetComponent<Card>();
            cards[i].SetPlayer1(i < 4);

            if(i >= 4)
                cards[i].gameObject.transform.Rotate(new Vector3(0, 0, 180)); 
        }
        Reset();
    }

    public void Reset()
    {
        for (int i = 0; i < cards.Length; i++)
            cards[i].KillCreature();

        damagePlayer1 = damagePlayer2 = 0;
        bonesPlayer1 = bonesPlayer2 = 0;
        damagePlayer1Text.SetText(damagePlayer1.ToString());
        damagePlayer2Text.SetText(damagePlayer2.ToString());
        bonesPlayer1Text.SetText(bonesPlayer1.ToString());
        bonesPlayer2Text.SetText(bonesPlayer2.ToString());
    }

    public void Ring()
    {
        //Reproduce ring
    }

    public void DamagePlayer1()
    {
        damagePlayer1++;
        damagePlayer1Text.SetText(damagePlayer1.ToString());
    }

    public void DamagePlayer2()
    {
        damagePlayer2++;
        damagePlayer2Text.SetText(damagePlayer2.ToString());
    }

    public void EarnBonePlayer1()
    {
        bonesPlayer1++;
        bonesPlayer1Text.SetText(bonesPlayer1.ToString());
    }

    public void EarnBonePlayer2()
    {
        bonesPlayer2++;
        bonesPlayer2Text.SetText(bonesPlayer2.ToString());
    }

    public void SpendBonePlayer1()
    {
        if(bonesPlayer1 > 0)
        {
            bonesPlayer1--;
            bonesPlayer1Text.SetText(bonesPlayer1.ToString());
        }
    }

    public void SpendBonePlayer2()
    {
        if(bonesPlayer2 > 0)
        {
            bonesPlayer2--;
            bonesPlayer2Text.SetText(bonesPlayer2.ToString());
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }
}
