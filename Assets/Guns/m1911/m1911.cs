using Godot;
using System;

public class m1911 : Gun
{
  [Export] int MUZZLE_X = 21;
  [Export] int MUZZLE_Y = -9;
  public m1911()
  {
    base.Direction = Direction.RIGHT;
    base.BulletSpeed = 2000;
    base.FireRate = 50;
    base.FireCycleTimer = 0;
  }

  public override void Shoot()
  {
    if (FireCycleTimer == 0)
    {
      var bullet_scene = (PackedScene)ResourceLoader.Load("res://Assets/Guns/Bullet_Scene.tscn");
      var bullet = (Bullet)bullet_scene.Instance();
      bullet.Direction = Direction;
      bullet.BulletSpeed = BulletSpeed;
      GetNode("Muzzle").AddChild(bullet);
      FireCycleTimer = FireRate;
    }
    else
    {
      FireCycleTimer -= 1;
    }
  }
  public override void SetOrientation(Direction direction)
  {
    Direction = direction;
    var sprite = (Sprite)GetNode("Sprite");
    sprite.FlipH = Direction == Direction.LEFT;
    var muzzle = (Node2D)GetNode("Muzzle");
    muzzle.Position = new Vector2(MUZZLE_X * (int)Direction, MUZZLE_Y);
  }
}
