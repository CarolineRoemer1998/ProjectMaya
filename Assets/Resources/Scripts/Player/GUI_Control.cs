using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Control : MonoBehaviour
{
    [SerializeField] private Image signFuture;
    [SerializeField] private Image signPast;
    [SerializeField] private Image barHealth;
    [SerializeField] private Image barMana;

    // Start is called before the first frame update
    void Start()
    {
        signFuture.enabled = false;
        signPast.enabled = true;
    }

    private void Update()
    {
        IncreaseMana();
    }

    public void LowerHealth(float amount)
    {
        if(barHealth.rectTransform.sizeDelta.x > 0)
        {
            if (barHealth.rectTransform.sizeDelta.x - (247f/20f*amount) >= 0)
                barHealth.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barHealth.rectTransform.sizeDelta.x - (247f/20f*amount));
            else
                barHealth.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
    }

    /// <summary>
    /// Verringert die Mana-Bar um "amount" in Prozent
    /// </summary>
    /// <param name="amount"></param>
    public void LowerMana(float amount)
    {
        if(barMana.rectTransform.sizeDelta.x > 0)
        {
            if(barMana.rectTransform.sizeDelta.x - 247f/100*amount > 0)
                barMana.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barMana.rectTransform.sizeDelta.x - 247f / 100 * amount);
            else
                barMana.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        }
    }

    public void IncreaseMana()
    {
        if (barMana.rectTransform.sizeDelta.x < 247f)
        {
            barMana.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barMana.rectTransform.sizeDelta.x + (247f / 3 /2 * Time.deltaTime));
        }
    }

    public void SetTime(string time)
    {
        if (time == "past")
        {
            signFuture.enabled = false;
            signPast.enabled = true;

        }
        if (time == "future")
        {
            signPast.enabled = false;
            signFuture.enabled = true;
        }
    }
}
