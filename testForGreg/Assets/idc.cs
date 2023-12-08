using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class idc : MonoBehaviour
{
    [Header("Score Text")]
    private GameObject ScoreObject;
    public GameObject Text68;
    public int score = 0;

    [Header("Movement Values")]
    public float distanceToMove;

    private Vector3 startingPosition;
    private Vector3 endingPosition;

    public float speed = 0.1f;
    public bool right = false;
    private float direction = -1f;

    [Header("Scene to Load")]
    public int sceneNumber;

    private Text UIText;

    void Start()
    {
        ScoreObject = GameObject.Find("ScoreText");
        UIText = ScoreObject.GetComponent<Text>();
        UIText.text = "0";
        startingPosition = transform.position;
        endingPosition = new Vector3(
            transform.position.x + distanceToMove,
            transform.position.y,
            transform.position.z
            );
    }


    void Update()
    {
       
        if (transform.position.x < startingPosition.x && !right)
        {
            if (Mathf.Abs(speed) >= 15)
            {
                speed *= -1f;
            }
            else
            {
                speed *= -1f;
            }
            right = !right;
            //UIText.text = score.ToString();
        }
        else if (transform.position.x > endingPosition.x && right)
        {
            if (Mathf.Abs(speed) >= 15)
            {
                speed *= -1f;
                Debug.Log("MAX" + speed);

            }
            else
            {
                speed *= -1f;
                Debug.Log(speed);
            }
            right = !right;
            //UIText.text = score.ToString();
        }
        transform.position = new Vector3(
            transform.position.x + speed * direction * Time.deltaTime,
            transform.position.y,
            transform.position.z);
            //UIText.text = score.ToString();
    }
 
}
