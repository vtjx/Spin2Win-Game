using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HitPoint : MonoBehaviour
{
    [HideInInspector]
    public bool hit;
    private Vector2[] colliderPoints;
    private EdgeCollider2D edgeCollider;
    GameMaster gameMaster;
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        img = GetComponent<Image>();
        colliderPoints = edgeCollider.points;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameMaster.level == 5)
        {
            img.fillAmount = 0.06f;
            colliderPoints[1] = new Vector2(17.17f, 43.34f);
            edgeCollider.points = colliderPoints;
        }
        else if (gameMaster.level == 4)
        {
            img.fillAmount = 0.08f;
            colliderPoints[1] = new Vector2(22.56f, 41.04f);
            edgeCollider.points = colliderPoints;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        hit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        hit = false;
    }
}
