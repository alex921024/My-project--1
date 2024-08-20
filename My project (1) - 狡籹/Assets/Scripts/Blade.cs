using UnityEngine.Rendering; // 引入用於 Unity 渲染的命名空間
using UnityEngine; // 引入 Unity 引擎的命名空間

public class Blade : MonoBehaviour // 定義一個名為 Blade 的類，繼承自 MonoBehaviour 類，用於控制刀的行為
{
    public float sliceForce = 5f; // 切割力量的值
    public float minSliceVelocity = 0.01f; // 最小切割速度的值

    private Camera mainCamera; // 主攝像機的引用
    private Collider sliceCollider; // 刀的碰撞器
    private TrailRenderer sliceTrail; // 刀的拖尾效果

    private Vector3 direction; // 切割方向的向量
    public Vector3 Direction => direction; // 允許外部訪問切割方向

    private bool slicing; // 是否正在切割
    public bool Slicing => slicing; // 允許外部訪問是否正在切割
    public bool AudioSource; // 是否有音效

    private float sliceTime; // 用於記錄切割的時間

    private void Awake() // 當物件被實例化時調用的方法
    {
        mainCamera = Camera.main; // 獲取主攝像機的引用
        sliceCollider = GetComponent<Collider>(); // 獲取刀的碰撞器
        sliceTrail = GetComponentInChildren<TrailRenderer>(); // 獲取刀的拖尾效果
    }

    private void OnEnable() // 啟用物件時調用的方法
    {
        StopSlice(); // 停止切割
    }

    private void OnDisable() // 停用物件時調用的方法
    {
        StopSlice(); // 停止切割
    }

    private void Update() // 每幀更新時調用的方法
    {
        //if (GameManager1.Instance != null && GameManager1.Instance.IsGameOver) return; // 檢查是否遊戲結束

        if (Input.GetMouseButtonDown(0))
        { // 當按下滑鼠左鍵時
            StartSlice(); // 開始切割
        }
        else if (Input.GetMouseButtonUp(0))
        { // 當釋放滑鼠左鍵時
            StopSlice(); // 停止切割
        }
        else if (slicing)
        { // 當正在切割時
            ContinueSlice(); // 繼續切割
        }

        if (Input.GetKeyDown(KeyCode.R)) // 檢測重置鍵，這裡設為 R 鍵
        {
            ResetBlade(); // 重置刀刃
        }
    }

    private void StartSlice() // 開始切割的方法
    {
        Vector3 position = mainCamera.ScreenToWorldPoint(Input.mousePosition); // 將滑鼠位置轉換為世界空間位置
        position.z = 0f; // 固定 z 軸位置為 0
        transform.position = position; // 設置刀的位置為滑鼠位置

        slicing = true; // 設置正在切割為 true
        sliceCollider.enabled = true; // 啟用刀的碰撞器
        sliceTrail.enabled = true; // 啟用刀的拖尾效果
        sliceTrail.Clear(); // 清除拖尾效果

        sliceTime = 0f; // 初始化切割時間
    }

    private void StopSlice() // 停止切割的方法
    {
        slicing = false; // 設置正在切割為 false
        sliceCollider.enabled = false; // 停用刀的碰撞器
        sliceTrail.enabled = false; // 停用刀的拖尾效果
        AudioSource = false; // 停用音效
    }

    private void ContinueSlice() // 繼續切割的方法
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); // 將滑鼠位置轉換為世界空間位置
        newPosition.z = 0f; // 固定 z 軸位置為 0
        direction = newPosition - transform.position; // 計算切割方向

        transform.position = newPosition;

        sliceTime += Time.deltaTime; // 更新切割時間
    }

    private void ResetBlade() // 重置刀刃的方法
    {
        StopSlice(); // 停止切割
        sliceTime = 0f; // 重置切割時間
    }
}
