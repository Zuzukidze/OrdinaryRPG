using UnityEngine;
using System.Collections;

public abstract class EntityBase : MonoBehaviour {
    public int HP;
    public Direction direction { get; private set; }
    public float Speed;
    protected float timeToChangeDirection = 0;
    protected float timer;
	// Use this for initialization
	void Start () {
        direction = Direction.down;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Изменяет направление
    /// </summary>
    /// <param name="direction">направление</param>
    protected void ChangeDirection(Direction direction)
    {
        this.direction = direction;
    }
    /// <summary>
    /// Изменяет направление на случайное
    /// </summary>
    protected void ChangeDirection()
    {
        Direction direction = (Direction)Random.Range(0, 4);
        if (direction == this.direction)
            if (this.direction == Direction.right)
                this.direction = direction - 1;
            else
                this.direction = direction + 1;
    }
    /// <summary>
    /// Изменяет направление на обратное
    /// </summary>
    protected void FlipDirection()
    {
        switch(direction)
        {
            case Direction.up: direction = Direction.down; break;
            case Direction.right: direction = Direction.left; break;
            case Direction.left: direction = Direction.right; break;
            case Direction.down: direction = Direction.up; break;
        }
    }
    protected Direction ChooseDirection(Direction direction1, Direction direction2)
    {
        if (Random.Range(0, 2) == 0)
            return direction1;
        return direction2;
    }
    public enum Direction
    {
        up,
        left,
        down,
        right

    }
}
