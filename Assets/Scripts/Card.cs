using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    int damage = 0;
    TextMeshProUGUI text;
    bool player1;
    GameManager gm;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        gm = GameManager.GetInstance();
    }

    public void SetPlayer1(bool p1)
    {
        player1 = p1;
    }

    public void DamageCreature()
    {
        damage++;
        text.SetText(damage.ToString());
    }

    public void KillCreature()
    {
        damage = 0;
        text.SetText(damage.ToString());
        if (player1)
            gm.EarnBonePlayer2();
        else
            gm.EarnBonePlayer1();
    }
}
