using Godot;
using System;

public class AK47 : Gun
{
  public AK47()
  {
    base.BulletSpeed = 2000;
    base.FireRate = 10;
    base.FireCycleTimer = 0;
  }

  public override void Shoot()
  {
    if (FireCycleTimer == 0)
    {
      var bullet_scene = (PackedScene)ResourceLoader.Load("res://Assets/Guns/Bullet_Scene.tscn");
      var bullet = (Bullet)bullet_scene.Instance();
      bullet.BulletSpeed = BulletSpeed;
      GetNode("Muzzle").AddChild(bullet);
      FireCycleTimer = FireRate;
    }
    else
    {
      FireCycleTimer -= 1;
    }
  }
}
