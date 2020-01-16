using Godot;
using System;

public class Player : Godot.KinematicBody2D
{
  [Export] public int GRAVITY = 1000;
  [Export] public int MOVEMENT_SPEED = 300;
  [Export] public int JUMP_HEIGHT = 650;
  [Export] public bool FACING_RIGHT = true;

  Vector2 velocity = new Vector2();

  public void ApplyUserControls()
  {
    if (Input.IsActionPressed("right"))
    {
      FACING_RIGHT = true;
      velocity.x = MOVEMENT_SPEED;
    }
    else if (Input.IsActionPressed("left"))
    {
      FACING_RIGHT = false;
      velocity.x = -MOVEMENT_SPEED;
    }
    else
    {
      velocity.x = 0;
    }

    if (Input.IsActionPressed("up"))
    {
      Jump();
    }

    if (Input.IsActionPressed("shoot"))
    {
      Shoot();
    }
  }

  public void Jump()
  {
    if (IsOnFloor())
    {
      velocity.y -= JUMP_HEIGHT;
    }
  }

  public void Shoot()
  {
    var gun = (Gun)GetNode("Gun");
    gun.Shoot();
  }

  public void ApplyGravity(float delta)
  {
    velocity.y += delta * GRAVITY;
  }

  public override void _PhysicsProcess(float delta)
  {
    ApplyGravity(delta);
    ApplyUserControls();
    velocity = MoveAndSlide(velocity, new Vector2(0, -1));
  }
}