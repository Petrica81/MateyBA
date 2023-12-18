using System.Linq;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField]
    private int _price;
    [SerializeField]
    private bool _reusable;
    [SerializeField]
    protected Inventory inventory;
    [SerializeField]
    protected SaveManager _saveManager;

    public void Awake()
    {
        if (_saveManager.state.pickups.Contains(this.GetInstanceID()))
        {
            if (!_reusable)
            {
                var player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
                OnPickup(player);
                Destroy(gameObject);
            }
        }
    }

    //Method to implement for any class extending pickup
    public abstract void OnPickup(GameObject picker);

    //The pickup mechanic itself
    //Non-shop items should have price = 0 and no price display
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (inventory.coins >= _price && other.gameObject.CompareTag("Player"))
        {
            OnPickup(other.gameObject);
            inventory.coins -= _price;
            if (!_reusable) {
                _saveManager.AddPickup(this);
                Destroy(gameObject);
            }
            
        }
    }
}
