using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mad : MerchantBase
{
    void YearDeals(MerchantBase merchant){
        for (int i = 0; i < Random.Range(5, 10); i++){
            is_honest = (Random.value > 0.5f);
            Deal(merchant);
        }
    }
}
