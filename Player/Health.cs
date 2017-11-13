using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour {

    Image HP;
    public float maxHp;
    public float health;

    void Start() {
        HP = GetComponent<Image>();
    }

    void Update() {
        HP.fillAmount = health / maxHp;
    }
}