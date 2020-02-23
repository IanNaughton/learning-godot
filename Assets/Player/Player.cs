using Godot;
using System;
using System.Collections.Generic;

public class Player : Godot.KinematicBody2D
{
  [Export] public int GRAVITY = 1000;
  [Export] public int MOVEMENT_SPEED = 300;
  [Export] public int JUMP_HEIGHT = 650;
  [Export] public Direction FACING = Direction.RIGHT;
  [Export] public int GUN_X = 49;
  [Export] public int GUN_Y = 0;

  Vector2 velocity = new Vector2();
  private List<Gun> Guns;

  public override void _Ready()
  {
    var resourcePath = "res://Assets/Guns/AK47/AK47.tscn";
    var gunScene = (PackedScene)ResourceLoader.Load(resourcePath);
    var gun = (Gun)gunScene.Instance();
    gun.Name = "Gun";
    AddChild(gun);
  }

  public void ApplyUserControls()
  {
    if (Input.IsActionPressed("right"))
    {
      FACING = Direction.RIGHT;
      velocity.x = MOVEMENT_SPEED;
    }
    else if (Input.IsActionPressed("left"))
    {
      FACING = Direction.LEFT;
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

  public void OrientPlayer()
  {
    // Flip player sprites
    var visibleAssets = (Node2D)GetNode("VisibleAssets");
    visibleAssets.Scale = new Vector2((int)FACING, 1);

    // Flip gun location relative to player
    var gun = (Gun)GetNode("Gun");
    gun.Position = new Vector2(GUN_X * (int)FACING, GUN_Y);
    gun.SetOrientation(FACING);
  }

  public override void _PhysicsProcess(float delta)
  {
    ApplyGravity(delta);
    ApplyUserControls();
    OrientPlayer();
    velocity = MoveAndSlide(velocity, new Vector2(0, -1));
  }
}