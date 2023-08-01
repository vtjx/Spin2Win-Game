using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    [HideInInspector]
    public bool pressed;
    HitPoint hitPoint;
    GameMaster gameMaster;
    AudioSource aS;
    [SerializeField]
    private AudioClip score;
    [SerializeField]
    private AudioClip miss;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
        Controls();
    }
    void Spin()
    {
        if (gameMaster.startGame)
        {
            hitPoint = GameObject.Find("Circle Hit Marker(Clone)").GetComponent<HitPoint>();
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
            if (speed > 400)
            {
                speed = 400;
            }
        }
    }

    void Controls()
    {
        if (gameMaster.startGame)
        {
            if (Input.GetKeyDown(KeyCode.Space) && hitPoint.hit)
            {
                aS.PlayOneShot(score);
                speed += 25;
                gameMaster.health.fillAmount += 0.2f;
                gameMaster.score += 10 * gameMaster.multiplier;
                Destroy(GameObject.Find("Circle Hit Marker(Clone)"));
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !hitPoint.hit)
            {
                aS.PlayOneShot(miss);
                gameMaster.health.fillAmount -= 0.1f;
                gameMaster.score -= 5 * gameMaster.multiplier;
                Destroy(GameObject.Find("Circle Hit Marker(Clone)"));
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
