using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deceiver : MerchantBase
{
    void YearDeals(MerchantBase merchant){
        is_honest = false;
        for (int i = 0; i < Random.Range(5, 10); i++){
            Deal(merchant);
        }
    }
}
