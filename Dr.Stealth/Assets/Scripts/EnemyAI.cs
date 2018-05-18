using UnityEngine;
using System.Collections;

[RequireComponent(typeof(EnemyMovemnt))]
[RequireComponent(typeof(EnemyInteraction))]

public class EnemyAI : MonoBehaviour {

    private EnemyMovemnt movement;
    private EnemyInteraction interaction;

    // Use this for initialization
    void Start() {
        movement = GetComponent<EnemyMovemnt>();
        interaction = GetComponent<EnemyInteraction>();
    }

    // Update is called once per frame
    void Update() {

    }
}
