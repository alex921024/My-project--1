
using System.Collections; // 引入用於管理集合和協程的命名空間
using Unity.VisualScripting; // 引入用於 Unity 的視覺腳本工具的命名空間
using UnityEngine; // 引入 Unity 引擎的命名空間
using UnityEngine.UIElements; // 引入用於 Unity UI 元素的命名空間

public class Spawner : MonoBehaviour // 定義一個名為 Spawner 的類，繼承自 MonoBehaviour 類，用於在場景中生成遊戲物件
{
    private Collider spawnArea; // 儲存生成區域的碰撞器

    public GameObject[] fruitPrefabs; // 儲存不同水果遊戲物件的數組

    public GameObject bombPrefab; // 儲存炸彈遊戲物件的引用
    [Range(0f,1f)] // 定義 bombChance 在 0 到 1 之間的範圍
    public float bombChance=0.05f; // 控制生成炸彈的機率，預設為 0.05f，表示 5%

    public float minSpawnDelay = 0.25f; // 定義生成物件的最小延遲時間
    public float maxSpawnDelay = 1f; // 定義生成物件的最大延遲時間

    public float minAngle = -15f; // 定義生成物件的最小旋轉角度
    public float maxAngle = 15f; // 定義生成物件的最大旋轉角度

    public float minForce = 18f; // 定義生成物件的最小推力
    public float maxForce = 22f; // 定義生成物件的最大推力

    public float maxLifetime = 5f; // 定義生成物件的最大存活時間

    private void Awake() // 當物件被實例化時調用的方法
    {
        spawnArea = GetComponent<Collider>(); // 獲取生成區域的碰撞器
    }

    private void OnEnable() // 啟用物件時調用的方法
    {
        StartCoroutine(Spawn()); // 開始生成物件的協程
    }

    private void OnDisable() // 停用物件時調用的方法
    {
        StopAllCoroutines(); // 停止所有協程
    }

    private IEnumerator Spawn() // 生成物件的協程方法
    {
        yield return new WaitForSeconds(2f); // 等待 2 秒

        while (enabled) // 當物件啟用時執行無限迴圈
        {
            GameObject prefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)]; // 從水果的數組中隨機選擇一個遊戲物件
            if (Random.value<bombChance){ // 如果隨機值小於 bombChance，則生成炸彈
                prefab=bombPrefab; // 將遊戲物件設置為炸彈
            }

            Vector3 position = new Vector3(); // 儲存生成位置的向量
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x); // 在 x 軸上隨機生成位置
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y); // 在 y 軸上隨機生成位置
            position.z = 0f; // 在 z =0 生成位置

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle)); // 生成隨機旋轉角度

            GameObject fruit = Instantiate(prefab, position, rotation); // 生成遊戲物件
            Destroy(fruit, maxLifetime); // 設置遊戲物件的存活時間

            float force = Random.Range(minForce, maxForce); // 隨機生成推力大小
            fruit.GetOrAddComponent<Rigidbody>().AddForce(fruit.transform.up * force, ForceMode.Impulse); // 對遊戲物件施加推力

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay)); // 等待隨機時間再次生成物件
        }
    }

}

