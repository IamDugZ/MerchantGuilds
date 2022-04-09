using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuildManager : MonoBehaviour
{
    public List<MerchantBase> guild_members;
    public GameObject merchant_prefab;
    public GameObject year_count_text;
    public int year = 1;

    private List<System.Type> best_strategies;
    private int max_members = 60;

    void Start()
    {
        guild_members = new List<MerchantBase>();
        best_strategies = new List<System.Type>();

        best_strategies.Add(typeof(Altruist));
        best_strategies.Add(typeof(Deceiver));
        best_strategies.Add(typeof(Gipsy));
        best_strategies.Add(typeof(Sly));
        best_strategies.Add(typeof(Mad));
        best_strategies.Add(typeof(Vindict));

        Populate(max_members);
    }

    void Populate(int members) {
        for(int i = 0; i < members; i++) {
            int strat = Random.Range(0,best_strategies.Count);
            GameObject member = GameObject.Instantiate(merchant_prefab, transform.position, transform.rotation);
            member.AddComponent(best_strategies[strat]);
            member.transform.parent = transform;
            guild_members.Add(member.GetComponent<MerchantBase>());
        }
        YearCycle();
    }

    void YearCycle() {
        for(int i = 0; i < guild_members.Count; i++) {
            for(int j = i; j < guild_members.Count; j++) {
                guild_members[i].Deal(guild_members[j]);
            }
            guild_members[i].gameObject.name = guild_members[i].merchant_name;
            guild_members[i].gameObject.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0} | Gold: {1} | Years: {2}", guild_members[i].merchant_name, guild_members[i].gold, guild_members[i].years);
            guild_members[i].years += 1;
        }
        guild_members.Sort(CompareGold);
        for(int i = 0; i < guild_members.Count; i++) {
            guild_members[i].gameObject.transform.SetAsLastSibling();
            Debug.Log(guild_members[i].gold);
        }
    }
    void NewYear() {
        Debug.Log(guild_members.Count);
        best_strategies.Clear();
        for(int i = 0; i < 12; i++){
            MerchantBase strat = guild_members[i].GetComponent<MerchantBase>();
            if (!best_strategies.Contains(strat.GetType())){
                best_strategies.Add(strat.GetType());
            }
        }
        for(int i = guild_members.Count - 12; i < guild_members.Count; i++){
            Destroy(guild_members[i].gameObject);
        }
        guild_members.RemoveRange(guild_members.Count - 12, 12);

        Populate(max_members - guild_members.Count);
        year_count_text.GetComponent<UnityEngine.UI.Text>().text = year.ToString();
    }

    public int CompareGold(MerchantBase merchant1, MerchantBase merchant2) {
        return merchant2.gold.CompareTo(merchant1.gold);
    }
}
