using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantBase : MonoBehaviour
{
    public int gold = 0;
    public int years = 0;
    public bool is_honest = true;
    public bool deceived = false;
    public string merchant_name = "";

    void Awake() {
        string cn = "BCDFGHJKLMNPRSTVXZ";
        string vw = "AEOIU";
        for(int i = 0; i < Random.Range(4, 6); i++){
            if (i % 2 == 0) {merchant_name += cn[Random.Range(0, cn.Length)];}
            else {merchant_name += vw[Random.Range(0, vw.Length)];}
        }
        merchant_name = merchant_name[0] + merchant_name.Substring(1).ToLower();
    }
    public void Deal(MerchantBase merchant) {
        if(Random.value < 0.05f) {is_honest = !is_honest;}

        if (is_honest == merchant.is_honest) {
            gold += 2 + 2 * (is_honest ? 1 : 0);
            merchant.gold += 2 + 2 * (is_honest ? 1 : 0);
        } else {
            gold += 1 + 4 * (is_honest ? 0 : 1);
            merchant.gold += 1 + 4 * (is_honest ? 1 : 0);
        }
        if (!merchant.is_honest) {
            deceived = true;
        }
    }
}
