using UnityEngine; // 引入 Unity 引擎的命名空間

public class Bomb : MonoBehaviour // 定義一個名為 Bomb 的類，繼承自 MonoBehaviour 類
{
    private void OnTriggerEnter(Collider other) // 當其他物體進入碰撞器時觸發的方法
    {

        if (other.CompareTag("Player")) // 檢查進入碰撞器的物體是否標記為 "Player"
        {
            FindObjectOfType<GameManager1>().Explode(); // 如果是，則尋找 GameManager 物件並觸發其 Explode 方法
        }
    }
}
