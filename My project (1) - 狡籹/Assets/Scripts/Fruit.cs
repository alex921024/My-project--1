using UnityEngine;
public class Fruit : MonoBehaviour
{
    // 宣告公開的遊戲物件變數
    public GameObject whole; // 完整的水果
    public GameObject sliced; // 切開的水果
    public GameObject wood; // 木頭（可能為支撐水果的平台）

    // 宣告私有的物理組件變數
    private Rigidbody fruitRigidbody; // 水果的剛體
    private Collider fruitCollider; // 水果的碰撞器
    private ParticleSystem juiceParticleEffect; // 水果汁粒子效果

    // 宣告公開的整數變數
    public int points = 1; // 分數，預設為1

    // 在物件被實例化時執行的方法
    private void Awake()
    {
        // 取得水果的剛體、碰撞器和水果汁粒子效果
        fruitRigidbody = GetComponent<Rigidbody>();
        fruitCollider = GetComponent<Collider>();
        juiceParticleEffect = GetComponentInChildren<ParticleSystem>();
    }

    // 切水果的方法，接受方向、位置和力量參數
    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        // 增加玩家的分數
        FindObjectOfType<GameManager1>().IncreaseScore(points);

        // 隱藏完整水果，顯示切開的水果
        whole.SetActive(false);
        sliced.SetActive(true);

        // 禁用水果的碰撞器，播放水果汁粒子效果
        fruitCollider.enabled = false;
        juiceParticleEffect.Play();

        // 計算切開水果的旋轉角度
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // 取得切開的水果中的所有剛體
        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices)
        {
            // 設置切開的水果的速度和在特定位置上的推力
            slice.velocity = fruitRigidbody.velocity;
            slice.AddForceAtPosition(direction * force, position, ForceMode.Impulse);
        }
    }

    // 當水果進入碰撞器時執行的方法
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager1.Instance != null && GameManager1.Instance.IsGameOver) return; // 檢查是否遊戲結束

        // 如果碰撞物是玩家
        if (other.CompareTag("Player"))
        {
            // 取得玩家的刀刃組件
            Blade blade = other.GetComponent<Blade>();
            // 呼叫切水果方法，傳入刀刃的方向、位置和切割力量
            Slice(blade.Direction, blade.transform.position, blade.sliceForce);
        }
    }
}
