using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

	public GameObject enemy;
    //public int speed = 3;
    public Health HP;
	public Sendo sendo;
    public Timer time;
    public float endTimer;
    public bool isDead;

    [SerializeField]
    private Image bloodImage;
    void Start()
    {
        //sendo = this.GetComponent<Sendo> ();
        time.GetComponent<Timer>();
        HP.health = 5;
        isDead = true;
    }

    void Update()
    {
        //this.transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, 0);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("enemy"))
		{
            StopCoroutine(bloodOnScreen(0.5f));
            StartCoroutine(bloodOnScreen(0.5f));
            HP.health -= 1f;
			sendo.removeSendo ();
			Destroy(col.gameObject);
            if (HP.health <= 0)
            {
                endTimer = time.myTimer;
                print(endTimer);
                isDead = false;
            }
        }
    }
    private IEnumerator bloodOnScreen(float forTime)
    {
        float t = 0;
        while(t < forTime)
        {
            bloodImage.color = new Color(1,0,0,1 - (t / forTime));

            t += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
