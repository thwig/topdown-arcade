using UnityEngine;
public interface IProjectile<T>
{
    public void SetVelocity(Vector2 direction, float speed);
    public void SetDamage(float damage);
    public float GetDamage();
}