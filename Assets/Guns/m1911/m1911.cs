using Godot;
using System;

public class m1911 : Gun
{
  public m1911()
  {
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
      GetNode("Muzzle").AddChild(bullet);
      FireCycleTimer = FireRate;
    }
    else
    {
      FireCycleTimer -= 1;
    }
  }
}
