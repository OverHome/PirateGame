using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class MiniGameShtorm: MonoBehaviour
{
    [SerializeField] public GameObject Helm;
    [SerializeField] public GameObject Arrow;
    [SerializeField] public List<Transform> BezierPoints;
    [Range(0, 1)][SerializeField] public float ArrowPos;
    [SerializeField] public int Spead = 2;
    [SerializeField] public int ResistSpead = 1;
    [SerializeField] public int Health = 1000;
    [SerializeField] public int Damage = 1;
    [SerializeField] public int Assumption = 5;
    [SerializeField] public TextMeshProUGUI PositionText;
    [SerializeField] public TextMeshProUGUI HealthText;

    private float timeBeforSwitch;
    private bool IsMove;
    private bool IsMouse;
    private bool IsRight;
    private int helmRotation;
    private float resDirection;
    private float nextResDirection;
    private float changeResDirTime;
    private float neadAngle;
    private float NextArrowPos;
    private Random random;

    private void Start()
    {
        random = new Random();
        neadAngle = 0;
        NextArrowPos = 0;
        nextResDirection = 1;
        SetEvent(5);
        SetResDir(2);
    }

    private void Update()
    {
        GetInput();
        timeBeforSwitch -= Time.deltaTime;
        changeResDirTime -= Time.deltaTime;
        ArrowPos = Mathf.Lerp(ArrowPos, NextArrowPos, Time.deltaTime*2);
        resDirection = Mathf.Lerp(resDirection, nextResDirection, Time.deltaTime*1);
        neadAngle = GenAngle(ArrowPos);
        SetArrowPosition();
        print(resDirection);
        print(nextResDirection);
    }
    
    private void GetInput()
    {
        bool tIsMove = false;
        bool tIsRight = false;
        bool tIsMouse = false;
        foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
            if(Input.GetKey(vKey)){
                if (vKey == KeyCode.E)
                {
                    tIsMove = true;
                    tIsRight = true;
                }
                if (vKey == KeyCode.Q)
                {
                    tIsMove = true;
                    tIsRight = false;
                } 
                if (vKey == KeyCode.Mouse0)
                {
                    tIsMove = true;
                    tIsMouse = true;
                }
            }
        }
        
        IsMove = tIsMove;
        IsRight = tIsRight;
        IsMouse = tIsMouse;
    }

    private void FixedUpdate()
    {
        helmRotation = GetRotation();
        Resistance();
        RotateHelm();
        TakeDamage();
        SwitchEvent();
        ChangeResDir();
    }

    private void SetArrowPosition()
    {
        var p1 = BezierPoints[0].position;
        var p2 = BezierPoints[1].position;
        var p3 = BezierPoints[2].position;
        var p4 = BezierPoints[3].position;
        Arrow.transform.position = Bezier.GetPoint(p1, p2, p3, p4, ArrowPos);
        Arrow.transform.rotation = Quaternion.Euler(0,0,GenAngle(ArrowPos));
    }

    private void SetEvent(float time)
    {
       // var a = random.Next(0, positions.Count);
       // neadPosition = positions.ElementAt(a).Key;
       // PositionText.text = neadPosition;
       // timeBeforSwitch = time;
       var a = (float)GetRandomNumber(0.1, 0.9);
       NextArrowPos = a;
       timeBeforSwitch = time;
    }

    private float GenAngle(float arrowPos)
    {
        return (180 * arrowPos - 90) * -1;
    }

    private void Resistance()
    {
        if (Math.Abs(helmRotation+ResistSpead*resDirection)<=90)
        {
            Helm.transform.rotation *= Quaternion.Euler(0, 0, ResistSpead*resDirection);
        }
    }

    private void ChangeResDir()
    {
        if (changeResDirTime <= 0)
        {
            SetResDir(random.Next(1, 5));
        }
    }

    private void SetResDir(int rnd)
    {
        nextResDirection *= -1;
        changeResDirTime = rnd;
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
        if (Math.Abs(helmRotation - neadAngle) > Assumption)
        {
            Health -= Damage;
            HealthText.text = Health.ToString();
        }
    }

    public void RotateHelm()
    {
        if (IsMove)
        {
            int direction;
            if (IsMouse)
            {
                Vector2 getMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                direction = getMousePosition.x > 0 ? -1 : 1;
            }
            else
            {
                direction = IsRight ? -1 : 1;
            }
           
            if (Math.Abs(helmRotation + Spead * direction) <= 90)
            {
                Helm.transform.rotation *= Quaternion.Euler(0, 0, Spead*direction);
            } 
        }
    }
    
    public double GetRandomNumber(double minimum, double maximum)
    {
        return random.NextDouble() * (maximum - minimum) + minimum;
    }
}
