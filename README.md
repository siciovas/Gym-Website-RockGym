# RockGym
Project for "Web Application Design" module

![image](https://user-images.githubusercontent.com/90570865/194002596-1c5f60b8-aac5-41c1-9110-12f9996cc8b8.png)
INFORMATIKOS FAKULTETAS

T120B165 Saityno taikomųjų programų projektavimas
Projekto „Sporto salės/Grupinių treniruočių registracijos sistema“


Studentas:
Sičiovas Rokas, IFF9-5
Dėstytojas(i):
prof. BLAŽAUSKAS Tomas
doc. prakt. MAŽUTIENĖ Rasa
doc. prakt. TAMOŠIŪNAS Petras


1.	Sprendžiamo uždavinio aprašymas
1.1.	Sistemos paskirtis

Sistemos paskirtis – individualios sporto salės abonemento pirkimas bei grupinių treniruočių registracija. Sistemoje egzistuos trys rolės – administratorius, registruotas vartotojas bei svečias. Svečias turės galimybę peržiūrėti abonementų kainas, grupinių treniruočių laikus, grupinių treniruočių tipų pasirinkimus. Registruotas vartotojas galės nusipirkti abonementą, matyti grupinių treniruočių pasirinkimą. Administratorius valdys grupines treniruotes.
Taikomosios srities objektai yra Abonementas  Grupinė treniruotė  Atsiliepimas
1.2.	Funkciniai reikalavimai

Neregistruotas sistemos vartotojas galės:
•	Užsiregistruoti sistemoje
•	Peržiūrėti abonementų tipus bei jų kainas
•	Peržiūrėti grupinių treniruočių tipus bei jų laiką
Registruotas sistemos naudotojas galės:
•	Prisijungti į sistemą
•	Nusipirkti abonementą
•	Užsiregistruoti grupinei treniruotei
•	Atšaukti savo abonementą
•	Parašyti atsiliepimą apie treniruotę
Administratorius sistemoje galės:
•	Tvarkyti grupinių treniruočių žmonių skaičių



2.	Sistemos architektūra

Sistemos sudedamosios dalys:
•	Kliento pusė – React. js TypeScript;
•	Serverio pusė – C# .NET Core 6;
•	Duomenų bazė – MySQL;
pav. 1 „Deployment diagrama“ pavaizduota kuriamos sistemos diegimo diagrama. Sistemos talpinimui yra naudojamas Azure serveri. Internetinė aplikacija yra pasiekiama per HTTP protokolą. 
![image](https://user-images.githubusercontent.com/90570865/194002721-1800aafc-47ee-4af5-b1b4-ff795935e3da.png)
