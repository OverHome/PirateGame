
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    public GameObject spawnObject;
    
    public Collider2D canvasCollider;

    public PlayerMiniGame PlayerMiniGame;
    
    public GameObject obj;

    public int ticks = 0;
    
    private void Update()
    {
        ticks++;
        try
        {
            if (ticks % 60 != 0) return;
            if (obj.transform.position.x != null)
            {
                PlayerMiniGame.hit();
                Destroy(obj);
                obj = null;
            }
            var canvasSize = GetComponent<RectTransform>().sizeDelta;
            var x = Random.Range(-canvasSize.x / 2, canvasSize.x / 2);
            var y = Random.Range(-canvasSize.y / 2, canvasSize.y / 2);
            var position = new Vector3(x, y, 0f);
            var newObject = Instantiate(spawnObject, transform);
            newObject.transform.localPosition = position;
            obj = newObject;
        }
        catch (Exception e)
        {
            Debug.Log("catch ");
            var canvasSize = GetComponent<RectTransform>().sizeDelta;
            var x = Random.Range(-canvasSize.x / 2, canvasSize.x / 2);
            var y = Random.Range(-canvasSize.y / 2, canvasSize.y / 2);
            var position = new Vector3(x, y, 0f);
            var newObject = Instantiate(spawnObject, transform);
            newObject.transform.localPosition = position;
            obj = newObject;
        }
    }

    public void OnClick(GameObject gameObject)
    {
    }
}
