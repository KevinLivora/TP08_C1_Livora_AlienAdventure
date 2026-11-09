# AlienAdventure

[English](#english) | [Español](#español)

---

## English

2D platformer made in Unity 6 (6000.3.21f1, URP 2D) for TP08 of *Programación con Motores de Videojuegos I* - Image Campus. Inspired by Hollow Knight and Timespinner.

**Play it on itch.io:** https://kevinlivora.itch.io/alienadventure

### Goal

Cross two levels, collect the 3 golden keys of each one and walk through the door to move on. The first level goes from left to right and the second one goes back from right to left.
If you lose all your health, it's Game Over.

### Controls

| Action | Key |
|---|---|
| Move | A / D or arrow keys |
| Jump (press again in the air for a double jump) | Space |
| Melee attack | Left mouse click or J |
| Open the shop (near the shop) | E |
| Pause / Audio settings | Esc |

### Mechanics

- **Melee combat:** a slash with a timed hitbox that damages enemies, pushes them back and stuns them for a moment. Enemies flash red when hit and have a health bar and a particle effect on death.
- **Enemies:** Slime, Ladybug and Snail patrol their platforms and damage you on contact. They can drop coins.
- **Saw:** a fixed, indestructible hazard.
- **Pickables:** Heal (restores health), Damage (your attacks do more damage for a few seconds), Star (invulnerability for a few seconds), Coins (the reward) and Keys (open the door).
- **Double jump.**
- **Shop:** at the start of level 2 there is a shop. Spend the coins you saved to buy permanent upgrades: max health, attack damage and invincibility duration (3 levels each).
- **Saved data:** coins, best score and shop upgrades are kept between sessions with PlayerPrefs. Your health and coins are carried from level 1 to level 2.
- **Audio:** music and sound effects for every action. Master, Music, SFX and UI volumes can be adjusted from Settings, also while paused, through an AudioMixer.
- **Splash screen** with a fade in and out.

### Technical details

- Game data in ScriptableObjects: PlayerDataSo, EnemyDataSo, ShopItemSo and LevelDataSo.
- Abstract `Pickable` class with one subclass per item (inheritance).
- Event-based communication (HealthChanged, Died, Jumped, Landed, Attacked) and the IDamageable interface.
- Persistent data with PlayerPrefs through a static SaveData class, and RunState to carry data between levels.
- AudioManager singleton with an AudioMixer.
- Coroutines for the attack, the hit flash and the splash fade (CanvasGroup).
- Filled Image health bar, one-way platforms with Platform Effector 2D, 3-layer parallax and a smoothed camera follow with limits.

### Credits

- Development: Kevin Livora
- Art and interface sounds: [Kenney.nl](https://kenney.nl) (CC0)
- Music and victory sound: see the files in `Assets/Art/Audio` (dstechnician, emmraan, eaglaxle). Add the source and license of each one.

### Build

WebGL and Windows, published on itch.io.

---

## Español

Plataformas 2D hecho en Unity 6 (6000.3.21f1, URP 2D) para el TP08 de Programación con Motores de Videojuegos I - Image Campus. Inspirado en Hollow Knight y Timespinner.

**Jugalo en itch.io:** https://kevinlivora.itch.io/alienadventure

### Objetivo

Cruzá dos niveles, juntá las 3 llaves doradas de cada uno y entrá por la puerta para avanzar. El primer nivel va de izquierda a derecha y el segundo vuelve de derecha a izquierda.
Si perdés toda la vida, es Game Over.

### Controles

| Acción | Tecla |
|---|---|
| Moverse | A / D o flechas |
| Saltar (otra vez en el aire para el doble salto) | Espacio |
| Ataque cuerpo a cuerpo | Click izquierdo o J |
| Abrir la tienda (cerca del puesto) | E |
| Pausa / Ajustes de audio | Esc |

### Mecánicas

- **Combate cuerpo a cuerpo:** un tajo con hitbox temporizada que daña a los enemigos, los empuja y los aturde un instante. Los enemigos parpadean en rojo al recibir un golpe, tienen barra de vida y efecto de partículas al morir.
- **Enemigos:** Slime, Ladybug y Snail patrullan sus plataformas y hacen daño al tocarlos. Pueden soltar monedas.
- **Sierra:** obstáculo fijo e indestructible.
- **Pickables:** Curar (recupera vida), Daño (tus ataques hacen más daño unos segundos), Estrella (invulnerabilidad unos segundos), Monedas (la recompensa) y Llaves (abren la puerta).
- **Doble salto.**
- **Tienda:** al comenzar el nivel 2 hay una tienda. Gastá las monedas que guardaste en mejoras permanentes: vida máxima, daño y duración de la invulnerabilidad (3 niveles cada una).
- **Datos guardados:** las monedas, el mejor puntaje y las mejoras de la tienda se conservan entre sesiones con PlayerPrefs. La vida y las monedas de la partida pasan del nivel 1 al nivel 2.
- **Audio:** música y efectos para cada acción. Los volúmenes (Master, Music, SFX, UI) se ajustan desde Settings, también en pausa, con un AudioMixer.
- **Splash screen** con fade de entrada y salida.

### Detalles técnicos

- Datos del juego en ScriptableObjects: PlayerDataSo, EnemyDataSo, ShopItemSo y LevelDataSo.
- Clase abstracta `Pickable` con una subclase por ítem (herencia).
- Comunicación por eventos (HealthChanged, Died, Jumped, Landed, Attacked) e interfaz IDamageable.
- Datos persistentes con PlayerPrefs mediante la clase estática SaveData, y RunState para pasar datos entre niveles.
- AudioManager singleton con AudioMixer.
- Corrutinas para el ataque, el parpadeo al recibir un golpe y el fade del splash (CanvasGroup).
- Barra de vida con Image Filled, plataformas one-way con Platform Effector 2D, parallax de 3 capas y cámara con seguimiento suavizado y límites.

### Créditos

- Desarrollo: Kevin Livora
- Arte y sonidos de interfaz: [Kenney.nl](https://kenney.nl) (CC0)
- Música y efecto de victoria: ver archivos en `Assets/Art/Audio` (dstechnician, emmraan, eaglaxle). Completar con la fuente y licencia de cada uno.

### Build

WebGL y Windows, publicado en itch.io.
