# RockGym

## 1. Sprendžiamo uždavinio aprašymas
### 1.1. Sistemos paskirtis

Sistemos paskirtis – individualios sporto salės abonemento pirkimas bei grupinių treniruočių registracija. Sistemoje egzistuos trys rolės – administratorius, registruotas vartotojas bei svečias. Svečias turės galimybę užsiregistruoti bei prisijungti. Registruotas vartotojas galės nusipirkti abonementą, matyti grupinių treniruočių pasirinkimą. Administratorius valdys abonementus, grupines treniruotes, atsiliepimus ir žmonių paskyras per duomenų bazę.

Taikomosios srities objektai yra:
 - Abonementas 
 - Grupinė treniruotė 
 - Atsiliepimas

### 1.2. Funkciniai reikalavimai

Neregistruotas sistemos vartotojas galės:
-	  Užsiregistruoti sistemoje

Registruotas sistemos naudotojas galės:
-	  Prisijungti į sistemą
-	  Nusipirkti abonementą
-	  Peržiūrėti grupines treniruotes
-	  Parašyti anonimišką atsiliepimą apie treniruotę
-	  Peržiūrėti atsiliepimus apie treniruotes  

Administratorius sistemoje galės:
-	  Tvarkyti abonementus, grupines treniruotes, atsiliepimus ir žmonių paskyras per duomenų bazę

## 2. Sistemos architektūra

Sistemos sudedamosios dalys:
-	  Kliento pusė – React TypeScript;
-	  Serverio pusė – C# .NET Core 6;
- 	  Duomenų bazė – SQL Server Management Studio;


## 3. UML Deployment

![image](https://user-images.githubusercontent.com/90570865/207895637-14a7d77a-4861-480c-84d3-a6761afb7a6a.png)

## 4. Vartotojo sąsaja

##### Pagrindinis puslapis (pries prisijungimą)
![image](https://user-images.githubusercontent.com/90570865/207896996-09eab801-e73b-4173-8a87-3c4dd30edde3.png)

##### Prisijungimas
![image](https://user-images.githubusercontent.com/90570865/207897246-76ce21b6-c3fd-4a07-8bde-5137e7bc02ab.png)

##### Registracija
![image](https://user-images.githubusercontent.com/90570865/207897422-0ea8df3e-9c7b-4c6a-aebf-c0a0a0745982.png)

##### Pagrndinis puslapis (po prisijungimo)
![image](https://user-images.githubusercontent.com/90570865/207898033-314cbc84-5880-40ee-80be-2e6076be79fe.png)

##### Abonementai
![image](https://user-images.githubusercontent.com/90570865/207898194-bff86d10-54e3-456f-96bd-672854ed4d58.png)

##### Grupinės treniruotės
![image](https://user-images.githubusercontent.com/90570865/207898381-57c2f6ac-6a7d-477b-aa11-5d376e65fad4.png)

##### Atsiliepimo rašymas
![image](https://user-images.githubusercontent.com/90570865/207898588-f184c1c0-75a5-4b8b-8e4f-4a3e88d7e190.png)

##### Atsiliepimų peržiūra
![image](https://user-images.githubusercontent.com/90570865/207898750-3b8f515f-0d0f-43a1-8776-0107592eba41.png)

##### Atsijungimas
![image](https://user-images.githubusercontent.com/90570865/207898941-7349e097-ff42-4cf7-a269-5ae3a5afc10f.png)

## 5. API

#### Subscription
**GET** /api/subscription - skirtas gauti visus abonementus 

**POST** /api/subscription - skirtas įrašyti naują abonementą

**GET** /api/subscription/{id} - skirtas gauti unikalų abonementą pagal ID

**PUT** /api/subscription/{id} - skirtas atnaujinti unikalaus abonemento informaciją pagal ID

**DELETE** /api/subscription/{id} - skirtas ištrinti abonementą pagal unikalų ID

**POST** /api/boughtsubscription - skirtas įrašyti informaciją apie nusipirktą abonementą

#### Group Training
**GET** /api/subscription/{subscriptionId}/grouptraining - skirtas gauti visas grupines treniruotes, kurie priklauso unikaliams abonementui

**POST** /api/subscription/{subscriptionId}/grouptraining - skirtas įrašyti naują grupinę treniruotę į tam tikrą abonementą

**GET** /api/subscription/{subscriptionId}/grouptraining/{id} - skirtas gauti unikalią grupinę treniruotę pagal unikalų abonementą

**PUT** /api/subscription/{subscriptionId}/grouptraining/{id} - skirtas atnaujinti unikalaus abonemento unikalios grupinės treniruotės informaciją pagal ID

**DELETE** /api/subscription/{subscriptionId}/grouptraining/{id} - skirtas ištrinti grupinę treniruotę pagal unikalų ID

#### Group Training Feedback
**GET** /api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/grouptrainingfeedback - skirtas gauti unikalios treniruotės atsiliepimus

**POST** /api/subscription/{subscriptionId}/grouptraining/{grouptrainingId}/grouptrainingfeedback - skirtas įrašyti naują naują atsiliepimą unikalios treniruotės

**GET** /api/subscription/{subscriptionId}/grouptraining//{grouptrainingId}/grouptrainingfeedback/{id} - skirtas gauti unikalios grupinės treniruotės unikalų atsiliepimą

**PUT** /api/subscription/{subscriptionId}/grouptraining//{grouptrainingId}/grouptrainingfeedback/{id} - skirtas atnaujinti unikalios grupinės treniruotės unikalaus atsiliepimo informaciją

**DELETE** /api/subscription/{subscriptionId}/grouptraining//{grouptrainingId}/grouptrainingfeedback/{id} - skirtas ištrinti unikalios grupinės treniruotės unikalų atsiliepimą

#### Auth
**POST** /api/register - skirtas įrašyti naujos paskyros informaciją

**POST** /api/login - skirtas vartotojo prisijungimui
