using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shopUIUpdate : MonoBehaviour
{
    public playerStats playerStats;
    public Text username, money, confirmation;
    public Image highlightBar, thumb;
    public Button accept, remove;
    public Button yes, no;
    public GameObject buying, selling;
    public Text a, b, c, d, e, f, g;
    public bool buyOrSell=true;//true is Buy, false is Sell
    

    void Awake()
    {
        money.text = playerStats.getMoney().ToString();
        username.text = playerStats.username;
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        confirmation.gameObject.SetActive(false);
        if(buying.gameObject.activeSelf)
        {
            buyOrSell = true;
        }
        else
        {
            buyOrSell = false;
        }
        
    }

    public void Accept(int row)
    {
        confirmation.text = "Are you sure you want to accept this bid and end the auction?";
        confirmation.gameObject.SetActive(true);
        yes.gameObject.SetActive(true);
        no.gameObject.SetActive(true);
        accept.gameObject.SetActive(false);
        remove.gameObject.SetActive(false);
    }

    public void removeListing(int row)
    {
        //do stuff
    }
    
    public void confirm()
    {
        if(buyOrSell == true)
        {
            playerStats.addMoney(-float.Parse(g.text));
            money.text = playerStats.getMoney().ToString();
            confirmation.text = "You bought " + a.text + " #" + b.text + " for $" + g.text + "!";
        }
        else
        {
            playerStats.addMoney(float.Parse(g.text));
            money.text = playerStats.getMoney().ToString();
            confirmation.text = "You sold " + a.text + " #" + b.text + " for $" + g.text + "!";
        }
        
        highlightBar.gameObject.SetActive(false);
        thumb.gameObject.SetActive(false);
        accept.gameObject.SetActive(true);
        remove.gameObject.SetActive(true);
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        a.gameObject.SetActive(false);
        b.gameObject.SetActive(false);
        c.gameObject.SetActive(false);
        d.gameObject.SetActive(false);
        e.gameObject.SetActive(false);
        f.gameObject.SetActive(false);
        g.gameObject.SetActive(false);
    }

    public void unconfirm()
    {
        confirmation.text = "";
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        accept.gameObject.SetActive(true);
        remove.gameObject.SetActive(true);
    }
}
