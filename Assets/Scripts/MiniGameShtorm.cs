using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class MiniGameShtorm: MonoBehaviour
{
    [SerializeField] public GameObject Helm;
    [SerializeField] public int Spead = 2;
    [SerializeField] public int ResistSpead = 1;
    [SerializeField] public int Health = 1000;
    [SerializeField] public int Damage = 1;
    [SerializeField] public int Assumption = 5;
    [SerializeField] public TextMeshProUGUI PositionText;
    [SerializeField] public TextMeshProUGUI HealthText;

    private float timeBeforSwitch;
    private bool IsMove;
    private int helmRotation;
    private Dictionary<string, int> positions;
    public Dictionary<string, int> resistDerection;
    private string neadPosition;
    private Random random;

    private void Start()
    {
        random = new Random();
        positions = new (){{"Left",90}, {"Right",-90}, {"Center",0}};
        resistDerection = new Dictionary<string, int>() { { "Left", -1 }, { "Right", 1 }, { "Center", 0 } };
        SetEvent(5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) IsMove = true;
        if (Input.GetKeyUp(KeyCode.Mouse0)) IsMove = false;
        timeBeforSwitch -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        helmRotation = GetRotation();
        Resistance();
        RotateHelm();
        TakeDamage();
        SwitchEvent();
    }

    private void SetEvent(float time)
    {
        var a = random.Next(0, positions.Count);
        neadPosition = positions.ElementAt(a).Key;
        PositionText.text = neadPosition;
        timeBeforSwitch = time;
    }

    private void Resistance()
    {
        if (Math.Abs(helmRotation + Spead+5 * resistDerection[neadPosition]) <= 90)
        {
            var a = random.Next(1, 5);
            int spead = ResistSpead;
            if (a > 3)
            {
                spead = Spead + 1;
            }
            Helm.transform.rotation *= Quaternion.Euler(0, 0, spead*resistDerection[neadPosition]);
        }
    }

    private void SwitchEvent()
    {
        if (timeBeforSwitch <= 0)
        {
            var a = random.Next(2,10);
            SetEvent(a);
        }
    }

    public int GetRotation()
    {
        float localRotate = Helm.transform.localEulerAngles.z;
        if (localRotate > 180) localRotate -= 360;
        return (int)(localRotate);
    }

    public void TakeDamage()
    {
        if (Math.Abs(helmRotation - positions[neadPosition]) > Assumption)
        {
            Health -= Damage;
            HealthText.text = Health.ToString();
        }
    }

    public void RotateHelm()
    {
        if (IsMove)
        {
            Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int direction = getMousePosition.x > 0 ? -1 : 1;
            if (Math.Abs(helmRotation + Spead * direction) <= 90)
            {
                Helm.transform.rotation *= Quaternion.Euler(0, 0, Spead*direction);
            }
        }
    }
}
