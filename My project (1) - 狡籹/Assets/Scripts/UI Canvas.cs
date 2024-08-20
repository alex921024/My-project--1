using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    public Text leaderboardTitle;
    public Text[] playerNames;
    public Text[] playerScores;

    // 在 Start 方法中初始化排行榜
    private void Start()
    {
        InitializeLeaderboard();
    }

    // 初始化排行榜界面
    private void InitializeLeaderboard()
    {
        // 在這裡可以從數據庫或其他地方加載排行榜數據

        // 假設有10個排行榜項目
        int numEntries = 10;

        // 設置排行榜標題
        leaderboardTitle.text = "排行榜";

        // 假設這些是排行榜的示例數據
        string[] names = { "玩家1", "玩家2", "玩家3", "玩家4", "玩家5", "玩家6", "玩家7", "玩家8", "玩家9", "玩家10" };
        int[] scores = { 1000, 950, 900, 850, 800, 750, 700, 650, 600, 550 };

        // 將玩家名稱和分數顯示在排行榜上
        for (int i = 0; i < numEntries; i++)
        {
            playerNames[i].text = names[i];
            playerScores[i].text = scores[i].ToString();
        }
    }
}
