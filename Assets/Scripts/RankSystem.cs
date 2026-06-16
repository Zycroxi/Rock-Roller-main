using TMPro;
using UnityEngine;

public class RankSystem : MonoBehaviour
{
    [System.Serializable]
    public class Rank
    {
        public string rankName;
        public int requiredScore;
    }

    public Rank[] ranks;
    public TMP_Text rankText;

    public void UpdateRank(int score)
    {
        string currentRank = "E";

        foreach (var rank in ranks)
        {
            if (score >= rank.requiredScore)
                currentRank = rank.rankName;
        }

        rankText.text = currentRank;
    }
}