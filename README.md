# DevoraLimeArena

Teszt project a DevoraLime-nak.

# Feladat leírása:
Az arénában N darab hős küzd, akik lehetnek íjászok, lovasok és kardosok. Minden hős
rendelkezik egy azonosítóval és életerővel, valamint a következő szabályok szerint támadnak és
védekeznek:
- Íjász támad
  - lovast: 40% eséllyel a lovas meghal, 60%-ban kivédi
  - kardost: kardos meghal
  - íjászt: védekező meghal
- Kardos támad
  - lovast: nem történik semmi
  - kardost: védekező meghal
  - íjászt: íjász meghal
- Lovas támad
  - lovast: védekező meghal
  - kardost: lovas meghal
  - íjászt: íjász meghal

A csata körökre van lebontva, minden körben véletlenszerűen kiválasztásra kerül egy támadó és
egy védekező. A kimaradt hősök pihennek, és életerejük 10-zel nő, de nem mehet a maximum
fölé.
A harcban résztvevő hősök életereje a felére csökken, ha ez kisebb, mint a kezdeti életerő
negyede, akkor meghalnak. Kezdeti életerők: íjász - 100, lovas - 150, kardos - 120.
A csata addig tart, amíg maximum 1 hős marad életben.
Készíts egy olyan web API-t, amely a fenti szabályokat figyelembe véve hősöket csatáztat
egymással, és ellátva van unit tesztekkel. Az alábbi endpointokat szükséges implementálni:
1. Random hősgenerátor
-  input: harcosok száma
- return: aréna azonosító
2. Csata
- input: aréna azonosító
- return: History, ami leírja a körök számát, valamint a körökben ki támadott meg kit,
és hogyan változott az életerejük.

# Endpoints
- **/api/arena** -> Az alap endpoint. Annyit csinál hogy kiír egy üzenetet
- **/api/arena/GenerateArenaWithHeroes/{amount}** -> Egy arénát generál, az **amount** érték a generálandó hősök száma amennyit az arénába generáltatnia kell. Visszaadja az aréna azonosítóját
- **/api/arena/Fight/{arenaId}** -> Lejátssza a meccseket amíg több mint két hős él, majd az eredményt visszaadja.

# Megjegyzések
- In Memory adatbázist használunk, ezért ha valaki újraindítja az applikációt az aréna és hős adatok törlődnek. Lehetne SQLite is vagy akármilyen más adatbázis, és akkor megmaradnának. Ez minimális változtatás igazából.
- Amint lezajlik a csata az arénában, a service elmenti az eredményeket. Így ha valaki újra ugyanazt az endpoint-ot hívja meg, a ugyanazt az eredményt adja vissza. A halottak nem támadnak fel újra csatázni. :grin:
- Minden endpoint meghívható GET request-tel a böngészőben.
- A Unit testek külön projectben vannak, ugyanazon a solution-ön belül.
