using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class okcs : MonoBehaviour
{
    public int score = 0;
    public float speed = 0.1f;
    private float direction = -1f;
    [Header("Mouse Info")]
    public Vector3 clickStartLocation;

    [Header("Score Text")]
    private GameObject ScoreObject;
    public GameObject Text68;
    
    [Header("Physics")]
    public Vector3 launchVector;
    public float launchForce;
    private Text UIText;
    public GameObject ScoreText;
    public GameObject goalie;
    public GameObject Laser;
    public GameObject Slime;

    [Header("Slime")]
    public Transform slimeTransform;
    public Rigidbody slimeRigidbody;

    // Start is called before the first frame update
    private Vector3 originalSlimePosition;
    private Quaternion originalSlimeRotation;
    private Text scoreVal;
    private int tempScore;
    private Text gameOTxt;

    [Header("Laser")]
    public Rigidbody laserRb;

    void Start()
    {
        originalSlimePosition = slimeTransform.position;
        originalSlimeRotation = slimeTransform.rotation;
        scoreVal = ScoreText.GetComponent<Text>();
        gameOTxt = Text68.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
           transform.position.x + speed * direction * Time.deltaTime,
           transform.position.y,
           transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            clickStartLocation = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mouseDifference = clickStartLocation - Input.mousePosition;
            launchVector = new Vector3(
                mouseDifference.x,
                mouseDifference.y * 1.2f,
                (mouseDifference.y) * 1.5f
            );

            slimeTransform.position = originalSlimePosition - launchVector / 500;
            launchVector.Normalize();
        }

        if (Input.GetMouseButtonUp(0))
        {
            slimeRigidbody.isKinematic = false;
            slimeRigidbody.AddForce(launchVector * launchForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(1))
        {
            slimeRigidbody.isKinematic = true;
            slimeTransform.position = originalSlimePosition;
            slimeTransform.rotation = originalSlimeRotation;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            //Text68.GetComponent<Text68>().text(Text68.text + " Final Score: " + score.tempScore.ToString());
            /*
            tempScore = score;
            gameOTxt.text(gameOTxt + " Final score: " + tempScore.ToString());
            */
            Text68.SetActive(true);
            Slime.SetActive(false);      
        }
        else if (other.gameObject.name == "Plane")
        {
            score = score + 1;
            scoreVal.text = score.ToString();
            slimeRigidbody.isKinematic = true;
            slimeTransform.position = originalSlimePosition;
            slimeTransform.rotation = originalSlimeRotation;
            //Laser.position.x = 3;
            if (Mathf.Abs(goalie.GetComponent<idc>().speed) >= 15)
            {
                goalie.GetComponent<idc>().speed *= 1f;
                Debug.Log("MAX: " + goalie.GetComponent<idc>().speed);
            }
            else
            {
                goalie.GetComponent<idc>().speed *= 1.25f;
                Debug.Log(goalie.GetComponent<idc>().speed);
            }
        }
    }
}
