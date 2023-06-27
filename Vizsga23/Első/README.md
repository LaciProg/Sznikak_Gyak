Tesztek Vik wiki.
Tervezési minták: Composite + Abstarct Factory.
Bővebben teszt_1_3_4_imsc_feladt Program.cs -ben.

1.
SpeedLimiter osztály.
2 privát tagváltozó: speed (jelenelegi sebesség) speedLimit = 90 fix érték.
Speed Property, ha az új értéke nagybb mint a speedLimit speed = speedLimit + elsüt egy SpeedIsLimited eseményt azzal az értékkel, amit eredetileg be akartak állítani.

Egy kis mintaprogram, múködés bemutatása, az esemény értékét írj a ki a standdar kimenetere.

2.
Sok részfeladat volt:
Egér kattintásra jelenjen meg egy kék kitöltetlen négyzet, úgy hogy az egér a nyégyzet közepén legyen.
Ez után induljon egy timer 5-10 mp múlva a négyzet legyen a  200 200 pontban (bal felső sarok).
A K gomb lenyomására legyen piros.
Írja ki az 50 100 pontba az aktuális egérkoordinátákat label/texbox nem jó csak kirajzolással.
Csak időzítő alapú megoldás elfogadott.
Segítség a szokásos: timer, random, MouseEventArgs.

3.
Nagyon hasonló egy korábbi zh feladatra.
Egy Listába pakol egy termelő szál számokat. 200at minden, szám után vár 100ms-et. A 200 db után 10sec-et.
A fő szál elindítja a termelőszálat majd vár véletlen időt 0-10 sec között.
Ha az utolsó szám ami a listában van az páratlan (List<int>) akkor berak egy -1 -et majd megvárja hatékonyoan amíg a termelő megcsinálja a 200 számot.
Ez után kiírja, hogy "Köszönöm".
Majd megvárja amíg a termelő behófejezi a futását (EGYSZERŰ, HATÉKONY módon).
