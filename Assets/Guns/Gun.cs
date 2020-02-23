using Godot;
using System;

public abstract class Gun : Node2D
{
  [Export] public Direction Direction = Direction.RIGHT;
  [Export] public int BulletSpeed = 0;
  [Export] public int FireRate = 0;
  [Export] public int FireCycleTimer = 0;
  public abstract void Shoot();
  public abstract void SetOrientation(Direction direction);
}
