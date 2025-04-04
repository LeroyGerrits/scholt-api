# Code Assessment
Start op via http of https in Visual Studio. Sinds .NET9 wordt Swagger niet meer automatisch als API documentatie interface gebruikt, in plaats daarvan gebruik ik Scalar. De applicatie is dan toegankelijk via
- https://localhost:7225/scalar/v1
- http://localhost:5026/scalar/v1

De applicatie is op sommige punten ietwat minimalistisch en op sommige momenten 'overengineered'. Enkele toelichting op de onderdelen (Projects) en wat ze doen cq. wat ik met ze beoog:

## Scholt.Api 
De API zelf met de controllers. Een mapje Dto voor alle, aan de voorkant specifieke, DTO's. Er worden 'platte' DTOs gebruikt die als het ware een 1-op-1 equivalent van hun respectievelijke Entity zijn (Recipe <> RecipeDto), maar gezien we ook 2 endpoints hebben die een specifieke DTO gebruiken die afleidingen zijn, ook mapjes Request en Response, rekening houdend met een toepassing van CQRS. Een mapje mappings waar extensions in zitten om de 'platte' DTOs (in dit geval alleen Recipe) te converteren naar de respectievelijke Entities (en andersom).

## Scholt.Api.Test 
Controllers wil ik altijd getest + gecovered hebben. In dit geval bevatten de testen expliciet controles op de HTTP status codes (200, 201, 204) op de respectievelijke endpoints omdat dit een keiharde 'business' requirement was.

## Scholt.Api.Data
De datalaag (DAL). Bestaat momenteel enkel uit een static class **ScholtApiContext**. Normaliter is dit het project waar bijvoorbeeld mijn DbContext (Entity) en Migrations in leven. Unit testen (en een respectievelijk testproject) zijn hier in de meeste gevallen niet nodig. In dit geval wordt alleen de data.json file uitgelezen en de output gedeserialiseerd.

## Scholt.Api.Domain
De platgeslagen domein logica en objecten, in dit geval alleen maar een (systeem) entiteit ServiceResult, en een mapje Entities. Dit project bevat normaliter ook zaken als Utilities, Enums, Interfaces, etc.

## Scholt.Api.Repositories
De **technische** servicelaag die communiceert met de datalaag (DAL), in dit geval een simpel repository-pattern omdat we toch alleen maar platgeslagen CRUD operaties hebben en het datamodel simpel is. Bij complexere projecten splits ik dit project vaak op in een DataReader / Query en een NonQuery project.

## Scholt.Api.Repositories.Test
Repositories, datareaders, e.d. wil ik altijd getest + gecovered hebben, dus moet een testproject voor aanwezig zijn.

## Scholt.Api.Services
Nu een leeg project, maar hier zit normaliter alle business, domein en event logica. Hier leun ik vaak op de voor mij handige elementen van DDD, waarin alle (domein/business)logica in 'Services' wordt verwerkt.

## Scholt.Api.Services.Test
Services wil ik altijd getest + gecovered hebben, dus moet een testproject voor aanwezig zijn.

## Overige
- De entiteit ServiceResult wordt nu als het ware niks mee gedaan, omdat de business requirements aan de API kant vrij specifiek waren. Deze gebruik ik vaak in meerdere lagen van de applicatie (datalaag (DAL), Repository/Query/Command, Services, etc.) om eventuele output van een handeling, die op meerdere lagen 'fout' kan gaan (of waar je juist feedback wil terug krijgen), terug te sturen naar een gebruiker of applicatie. 
- 