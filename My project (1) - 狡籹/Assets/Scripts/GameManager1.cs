using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    // 公开的UI变量
    public Text scoreText; // 用于显示分数的UI文本
    public Image fadeImage; // 用于显示淡入淡出效果的UI图像
    public static GameManager1 Instance { get; private set; }
    public bool IsGameOver { get; set; }
    [SerializeField] private TMP_Text ScoreText; // 用于显示分数的TextMeshPro文本
    [SerializeField] private GameObject gameOverMenu; // 游戏结束菜单
    [SerializeField] private TMP_Text GameOverScoreText; // 游戏结束时显示分数的TextMeshPro文本
    [SerializeField] private TMP_Text GameOverBestScoreText; // 游戏结束时显示最高分的TextMeshPro文本

    // 私有的游戏对象变量
    private Blade blade; // 刀刃对象
    private Spawner spawner; // 生成器对象

    // 分数变量
    private int score;

    // 在游戏开始时调用
    private void Start()
    {
        // 重新查找刀刃和生成器对象
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();

        NewGame(); // 开始新游戏
    }

    // 开始新游戏的方法
    private void NewGame()
    {
        Time.timeScale = 1f; // 恢复时间尺度

        blade.enabled = true; // 启用刀刃

        spawner.enabled = true; // 启用生成器

        score = 0; // 重置分数
        scoreText.text = score.ToString(); // 更新分数UI

        ClearScene(); // 清理场景
    }

    // 清理场景中的水果和炸弹
    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>(); // 查找所有水果对象
        foreach (Fruit fruit in fruits) // 遍历并销毁所有水果
        {
            Destroy(fruit.gameObject);
        }

        Bomb[] bombs = FindObjectsOfType<Bomb>(); // 查找所有炸弹对象
        foreach (Bomb bomb in bombs) // 遍历并销毁所有炸弹
        {
            Destroy(bomb.gameObject);
        }
    }

    // 增加分数的方法
    public void IncreaseScore(int amount)
    {
        score += amount; // 增加分数
        scoreText.text = score.ToString(); // 更新分数UI
    }

    // 处理爆炸效果
    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false; // 禁用生成器
        StartCoroutine(ExplodeSequence()); // 启动爆炸序列协程
    }

    // 爆炸序列的协程
    private IEnumerator ExplodeSequence()
    {
        // 如果 fadeImage 不为空，执行以下代码块
        if (fadeImage != null)
        {
            float elapsed = 0f; // 初始化经过时间为0
            float duration = 0.5f; // 设置动画持续时间为0.5秒

            // 淡入效果
            while (elapsed < duration)
            {
                // 如果 fadeImage 已被销毁，退出协程
                if (fadeImage == null) yield break;

                float t = Mathf.Clamp01(elapsed / duration); // 计算插值系数t，范围在0到1之间
                fadeImage.color = Color.Lerp(Color.clear, Color.white, t); // 根据t值从透明过渡到白色

                // 移除或修改这行代码以不改变时间缩放
                // Time.timeScale = 1f - t; 

                elapsed += Time.unscaledDeltaTime; // 增加经过的时间，使用未缩放的增量时间

                yield return null; // 等待下一帧
            }

            // 等待1秒钟的实际时间（未缩放时间）
            yield return new WaitForSecondsRealtime(1f);

            SetGameOver(); // 调用方法设置游戏结束状态

            elapsed = 0f; // 重置经过时间为0

            // 淡出效果
            while (elapsed < duration)
            {
                // 如果 fadeImage 已被销毁，退出协程
                if (fadeImage == null) yield break;

                float t = Mathf.Clamp01(elapsed / duration); // 计算插值系数t，范围在0到1之间
                fadeImage.color = Color.Lerp(Color.white, Color.clear, t); // 根据t值从白色过渡到透明

                elapsed += Time.unscaledDeltaTime; // 增加经过的时间，使用未缩放的增量时间

                yield return null; // 等待下一帧
            }
        }
    }


    // 设置游戏结束
    public void SetGameOver()
    {
        IsGameOver = true; // 设置游戏结束标志

        gameOverMenu.SetActive(true); // 显示游戏结束菜单
        int bestScore = PlayerPrefs.GetInt("BestScore", 0); // 获取最高分
        if (score > bestScore) // 如果当前分数大于最高分
        {
            bestScore = score; // 更新最高分
            PlayerPrefs.SetInt("BestScore", bestScore); // 保存最高分
        }
        GameOverScoreText.text = "Score: " + score.ToString(); // 显示当前分数
        GameOverBestScoreText.text = "Best Score: " + bestScore.ToString(); // 显示最高分
    }

    // 重试游戏
    public void Retry()
    {
        SceneManager.LoadScene("20240527", LoadSceneMode.Single); // 重新加载游戏场景，确保是单场景加载模式
        StartCoroutine(ResetGameAfterLoad()); // 在场景加载后重新设置游戏状态

    }

    // 重新加载场景后重新设置游戏状态
    private IEnumerator ResetGameAfterLoad()
    {
        yield return new WaitForEndOfFrame(); // 等待帧末

        // 重新查找刀刃和生成器对象
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();

        NewGame(); // 开始新游戏

    }

    // 退出游戏
    public void Exit()
    {
        blade.enabled = false;
        spawner.enabled = false;
        Application.Quit(); // 退出游戏应用程序
    }
}