using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

    public List<Transform> Tail;
    public float Speed;
    [Range(0, 10)]
    public float BonesDistance;
    public Text HealthDisplay;
    public int Health = 3;
    public float StartHungerTime = 3;
    public float hungerTime = 3;
    public GameObject TailPrefab;

    public UnityEvent OnEat;

    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        GetHunger();
        DisplayHealth();
        MoveSnake(_transform.position + (transform.forward * (Speed)));

        float angel = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0, angel, 0);
    }

    public void MoveSnake(Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        var prevPosition = _transform.position;

        foreach (var bone in Tail)
        {
            if((bone.position - prevPosition).sqrMagnitude >= sqrDistance)
            {
                var temp = bone.position;
                bone.position = prevPosition;
                prevPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            collision.gameObject.GetComponent<IFoodLogic>().Do(gameObject.GetComponent<Snake>());

            Destroy(collision.gameObject);
            var bone = Instantiate(TailPrefab);
            Tail.Add(bone.transform);

            if(OnEat != null)
            {
                OnEat.Invoke();
            }
        }
    }

    void DisplayHealth()
    {
        if (Health >= 0)
        {
            HealthDisplay.text ="Здоровье: " +  Health.ToString();
        }
        else
        {
            HealthDisplay.text = "Здоровье: 0";
        }
    }

    void GetHunger()
    {
        StartHungerTime -= Time.deltaTime;
        if (StartHungerTime <= 0)
        {
            Health -= 1;
            StartHungerTime = hungerTime;
            CheckDeath();
        }
    }

    void CheckDeath()
    {
        if (Health <= 0)
        {
            Application.Quit();
        }
    }
}
