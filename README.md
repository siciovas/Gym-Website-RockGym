# RockGym

## 1.	Sprendžiamo uždavinio aprašymas
### 1.1.	Sistemos paskirtis

Sistemos paskirtis – individualios sporto salės abonemento pirkimas bei grupinių treniruočių registracija. Sistemoje egzistuos trys rolės – administratorius, registruotas vartotojas bei svečias. Svečias turės galimybę peržiūrėti abonementų kainas, grupinių treniruočių laikus, grupinių treniruočių tipų pasirinkimus. Registruotas vartotojas galės nusipirkti abonementą, matyti grupinių treniruočių pasirinkimą. Administratorius valdys grupines treniruotes.
Taikomosios srities objektai yra Abonementas  Grupinė treniruotė  Atsiliepimas

### 1.2.	Funkciniai reikalavimai

Neregistruotas sistemos vartotojas galės:
-	  Užsiregistruoti sistemoje
-	  Peržiūrėti abonementų tipus bei jų kainas
-	  Peržiūrėti grupinių treniruočių tipus bei jų laiką
-	  
Registruotas sistemos naudotojas galės:
-	  Prisijungti į sistemą
-	  Nusipirkti abonementą
-	  Užsiregistruoti grupinei treniruotei
-	  Atšaukti savo abonementą
-	  Parašyti atsiliepimą apie treniruotę
-	  
Administratorius sistemoje galės:
-	  Tvarkyti grupinių treniruočių žmonių skaičių

## 2.	Sistemos architektūra

Sistemos sudedamosios dalys:
•	Kliento pusė – React. js TypeScript;
•	Serverio pusė – C# .NET Core 6;
•	Duomenų bazė – MySQL;

