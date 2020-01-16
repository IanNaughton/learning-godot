using Godot;
using System;

public class Bullet : Godot.RigidBody2D
{

  public int BulletSpeed = 2000;
  public int BulletMaxAngle = 150;
  public Vector2 velocity = new Vector2();
  private static RandomNumberGenerator _random;

  public Bullet()
  {
    if (_random == null)
    {
      _random = new RandomNumberGenerator();
    }

  }

  // Called when the node enters the scene tree for the first time.
  public override void _Ready()
  {
    velocity.x = BulletSpeed;
    velocity.y = _random.RandiRange(-BulletMaxAngle, BulletMaxAngle);
  }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _PhysicsProcess(float delta)
  {
    OrientBullet();
    SetLinearVelocity(velocity);
  }

  private void OrientBullet()
  {
    var sprite = (Sprite)GetNode("Sprite");
    if (BulletSpeed < 0)
    {
      sprite.SetFlipH(true);
    }
    else
    {
      sprite.SetFlipH(false);
    }
  }
}
