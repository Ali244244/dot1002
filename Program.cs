
public Text goldText;
public Text crystalText;
public Text foodText;

void UpdateGold(int amount) {
    goldText.text = "Amount: " + amount.ToString();
}

void UpdateCrystal(int amount) {
    crystalText.text = "Amount: " + amount.ToString();
}

void UpdateFood(int amount) {
    foodText.text = "Amount: " + amount.ToString();
}
List<int> startingLevels = new List<int>();
void Start() {
    startingLevels.Add(1);
    startingLevels.Add(2);
    startingLevels.Add(3);
}
void CheckEnemy(string enemyType) {
    if (enemyType == "Goblin") {
        Attack();
    } else if (enemyType == "Orc") {
        Attack();
    } else if (enemyType == "Troll") {
        Attack();
    } else {
        RunAway();
    }
}
//What if we need a simple 5-second cooldown timer?
float timer = 0f;
bool isCooldown = true;

void Update() {
    if (isCooldown) {
        timer += Time.deltaTime;
        if (timer >= 5f) {
            isCooldown = false;
            timer = 0f;
        }
    }
}
//What if someone reads this boolean check?
public bool IsPlayerDead() {
    if (health <= 0) {
        return true;
    } else {
        return false;
    }
}
//What if we need to find the highest score between two players?
int GetHighestScore(int score1, int score2) {
    List<int> scores = new List<int>();
    scores.Add(score1);
    scores.Add(score2);
    scores.Sort();
    return scores[1];
}
public class HealthPotion {
    public int healAmount = 10;
    public bool isPoisonous = false;
    public float expirationDate = 9999f;
    public string crafterName = "Unknown";
    public string loreDescription = "A basic potion.";

    public void Consume(Player player) {
        if (!isPoisonous && Time.time < expirationDate) {
            player.Heal(healAmount);
        }
    }
}
public class CollectibleDot {
    public string itemName = "Dot";
    public string itemRarity = "Common";
    public int requiredLevelToEquip = 1;
    public bool canBeSoldToMerchant = true;
    public int pointValue = 10;

    public void Collect(Player player) {
        if (player.level >= requiredLevelToEquip) {
            player.AddScore(pointValue);
            Debug.Log(itemName + " collected! It is " + itemRarity);
        }
    }
}
public class Spaceship {
    public float moveSpeed = 5f;
    public float flySpeed = 10f;
    public float swimSpeed = 2f;
    public float teleportDistance = 50f;

    public void MoveHorizontal(float input) {
        transform.Translate(Vector3.right * input * moveSpeed * Time.deltaTime);
    }

    public void FlyVertical(float input) {
        transform.Translate(Vector3.up * input * flySpeed * Time.deltaTime);
    }

    public void Swim() {
        // Added just in case we add water levels later
    }
}
public class PlayerStats {
    public float jumpForce = 5f;
    public float charisma = 10f;
    public float intelligence = 8f;
    public float luck = 5f;
    public float swimmingSpeed = 2f;
}
public interface IWeaponSystem {
    void Fire();
    void Reload();
    void Jam();
    void AttachSilencer();
    void ChangeFireMode();
}

public class Pistol : IWeaponSystem {
    // Implements all 5 methods, even though 3 of them are empty
}
void Jump() {
    AudioSource audio = GetComponent<AudioSource>();
    audio.clip = jumpSound;
    audio.Play();
    rb.velocity = Vector2.up * jumpForce;
}

void Shoot() {
    AudioSource audio = GetComponent<AudioSource>();
    audio.clip = shootSound;
    audio.Play();
    Instantiate(bullet);
}
void TakePhysicalDamage(int amount) {
    health -= amount;
    if (health < 0) health = 0;
    Debug.Log("Health: " + health);
}

void TakeMagicDamage(int amount) {
    health -= amount;
    if (health < 0) health = 0;
    Debug.Log("Health: " + health);
}
void SpawnGoblin() {
    Vector3 spawnPos = transform.position + new Vector3(0, 1, 0);
    Instantiate(goblinPrefab, spawnPos, Quaternion.identity);
    PlaySpawnParticle(spawnPos);
}

void MoveRight() {
    if (transform.position.x < 100f) {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
// I used artifical intelligent 