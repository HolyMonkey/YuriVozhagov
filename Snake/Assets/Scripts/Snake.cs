using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(IHealth))]
public class Snake : MonoBehaviour {

    public List<Transform> Tail;
    public float Speed;
    [Range(0, 10)]
    public float BonesDistance;
    public IHealth Health { get; private set;  }
     
    public GameObject TailPrefab;
    public UnityEvent OnEat;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        Health = GetComponent<IHealth>();
        if(Health == null)
        {
            Debug.LogError("Snake need IHealth implementation");
        } 
    }

    private void Update()
    {
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
            var logics = collision.gameObject.GetComponents<IFoodLogic>();

            foreach (var logic in logics)
            {
                logic.Do(gameObject.GetComponent<Snake>());
            }

            Destroy(collision.gameObject);
            var bone = Instantiate(TailPrefab);
            Tail.Add(bone.transform);

            if(OnEat != null)
            {
                OnEat.Invoke();
            }
        }
    }

    

    
}
