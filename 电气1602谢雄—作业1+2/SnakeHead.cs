using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    public float velocity = 0.35f;
    public int step;
    private int x;
    private int y;
    private int z;
    private Vector3 headPos;
   
    private Transform canvas;
    private bool isDie = false;

    public AudioClip eatClip;
    public AudioClip dieClip;
    public GameObject dieEffect;

    public GameObject bodyPrefab;
    public Sprite[] bodySprites = new Sprite[2];
    void Start()
    {
        InvokeRepeating("Move", 0, velocity);
        x = 0; y = step;
    }
    void Update()
    {
        //蛇的移动
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke();
            InvokeRepeating("Move", 0, velocity - 0.2f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke();
            InvokeRepeating("Move", 0, velocity);
        }
        //空格控制

        if (Input.GetKey(KeyCode.W) && y != -step)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            x = 0; y = step;
        }
        //上键控制

        if (Input.GetKey(KeyCode.S) && y != step)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 180);
            x = 0; y = -step;
        }
        //下键控制

        if (Input.GetKey(KeyCode.A) && x != step)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 90);
            x = -step; y = 0;
        }
        //右键控制

        if (Input.GetKey(KeyCode.D) && x != -step)
        {
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
            x = step; y = 0;
        }
        //左键控制
    }
    void Move()
    {
        headPos = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(headPos.x + x, headPos.y + y, headPos.z);
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(dieClip, Vector3.zero);
        CancelInvoke();
        isDie = true;
        Instantiate(dieEffect);
        PlayerPrefs.SetInt("lastl", 0);
        PlayerPrefs.SetInt("lasts", 0);
        //蛇死亡
        if (PlayerPrefs.GetInt("bests", 0) < 0)
        {
            PlayerPrefs.SetInt("bestl", 0);
            PlayerPrefs.SetInt("bests", 0);
        }

        StartCoroutine(GameOver(1.5f));
    }
    IEnumerator GameOver(float t)
    {
        yield return new WaitForSeconds(t);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

}