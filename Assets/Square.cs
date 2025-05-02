using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

	[Tooltip("Скорость перемещения квадрата")]
	public float moveSpeed;

    [Tooltip("Сколько раз надо поймать квадрпт , чтобы он исчез?")]
    public int catchCount;

    [Tooltip("Прирост скорсти")]
    public float speedFactor;

    [Tooltip("Уменьшение размера")]
    public float scaleFactor;

	[Tooltip("Точка, к которой движется Квадрат")]
	public Vector3 targetPosition;

    [Tooltip("Этот квадрат опасен для игрока или нет?")]
    public bool isTrap;

    [Tooltip("Компонент , управляющий анимацией Квадрата")]
    public Animator animator;

	void Start () 
	{
		if (isTrap == false)
		{
			Player.squares.Add(this);
		}
		targetPosition = GetRandomPoint();
	}
	

	void Update () 
	{
		// Движемся к целевой позиции
		transform.position = Vector3.MoveTowards(transform.position,
			targetPosition, moveSpeed * Time.deltaTime);

		//Если приехали
		if (transform.position == targetPosition) 
		{
			// Назначить новую позицию
			targetPosition = GetRandomPoint();
		}
	}

	void OnMouseDown()
	{
		if (isTrap)
		{
			Player.Defeat();
			animator.SetTrigger("trap");
		}
		else
		{
			Catch();
            animator.SetTrigger("catch");
        }
	}

	void Catch()
	{
		Player.score++;

		catchCount--;

		if (catchCount == 0)
		{
			Player.squares.Remove(this);
			Destroy(gameObject);

		}

		else
		{
			moveSpeed += speedFactor;

			transform.localScale -= new Vector3(scaleFactor, scaleFactor, scaleFactor); 

			transform.position = GetRandomPoint();

		}

	}

	Vector3 GetRandomPoint()
	{
		Vector3 randomVector = new Vector3();

		randomVector.x = Random.Range(-8,8);
		randomVector.y = Random.Range(-4,4);
		randomVector.z = transform.position.z;

		return randomVector;
	}
}
