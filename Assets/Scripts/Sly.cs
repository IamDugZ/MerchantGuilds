using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sly : MerchantBase
{
    void YearDeals(MerchantBase merchant){
        is_honest = true;
        for (int i = 0; i < Random.Range(5, 10); i++){
            Deal(merchant);
            is_honest = merchant.is_honest;
        }
    }
}
