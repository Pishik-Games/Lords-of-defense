using UnityEngine;

[CreateAssetMenu(fileName = "CharactersStats", menuName = "ScriptableObjects/CharactersStats")]
public class CharactersStats : ScriptableObject{
    public string characterName;
    public float maxHealth;
    public float damage;
    public GameObject ProjectilePrefab;
}
