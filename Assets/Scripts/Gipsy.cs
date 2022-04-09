using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gipsy : MerchantBase
{
    private bool[] pattern = new bool[] {true,false,true,true};
    void YearDeals(MerchantBase merchant) {
        is_honest = true;
        for (int i = 0; i < Random.Range(5, 10); i++){
            if (i < 5) {is_honest = pattern[i];} 
            else {
                if (deceived) {is_honest = false;}
                if (i == 5) {is_honest = true;}
            }
            Deal(merchant);
            if (i > 5 && !deceived) {is_honest = merchant.is_honest;}
        }
    }
}
