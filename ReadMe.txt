Muhammad Nasik Iqbal/463

Dalam game ini saya menambah dan mengubah beberapa yaitu:

1. Spawn point enemy saya ubah menjadi SpawnPoint1-3 sebagai tempat spawn enemy secara random menggunakan script factory
yang ada di folder Factory

2. Animasi Game Over saya buat bergerak dengan cepat

3. Pada Script Player Health saya mengubah bagian fungsi restart level:
///
public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
///
Untuk langsung meload ulang ketika player mati

4. Animasi ketika menembak hanya terlihat cahaya didepan senapan player saja supaya game terkesan lebih realistis

Sisanya sudah sama seperti tutorial yang diberikan

