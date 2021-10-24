# Roadmap zum C# Entwickler!

## Aufgaben

### Aufgabe 1) 
Die erste Aufgabe soll sich mit der Installierung der Entwicklungsumgebung besch�ftigen.

 - Schritt 1: Visual Studio 2019 installieren.
 - Schritt 2: Eine Konsolenanwendung mit dem Namen **FahrzeugVerwaltung** in .NET 5 erstellen.
 - Schritt 3: Gebe "Hello World" auf der Konsole aus.
### Aufgabe 2)
 Erstelle die Klasse **Vehicle**  mit folgenden Eigenschaften
 
|Name|Datentyp  |
|--|--|
|Ident| int |
|Brand| string |
|Modell| string |

Nun soll der Anwender die M�glichkeit habe, die Eigenschaften �ber die Konsole einzugeben
Das Men� soll wie folgt aussehen:

    Hallo herzlich willkommen!
    Bitten w�hlen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle l�schen 
    3) Alle Vehicle anzeigen
    10) Programm beenden
    >1
    Bitten Geben sie nun die Id ein
    >1
    Bitten Geben sie nun die Marke ein
    >VW
    Bitten Geben sie nun die Modell ein
    >Caddy
    Fahrzeug wurde angelegt
    
    Bitten w�hlen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle l�schen 
    3) Alle Vehicle anzeigen
    10) Programm beenden
    >3 
    Ident: 1, Marke: VW, Modell:Caddy
    
Nun soll der User die Eigenschaft **Ident** nicht mehr selber setzen k�nnen, sondern sie soll vom System automatisch gesetzt werden. 
**Wichtig:** Jede Ident sollte nur einmal gesetzt werden d�rfen => keine Duplikate
### Aufgabe 3) Bearbeiten eines Vehicles
Es soll nun dem Nutzer erm�glich werden bestimmte Vehicle zu bearbeiten 
Bitten w�hlen Sie die Aktion 

    Bitten w�hlen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle l�schen
    3) Alle Vehicle anzeigen 
    4) Vehicle bearbeiten
    10) Programm beenden
    >4
    Geben Sie bitte nun den Ident ein
    >1
     Bitten Geben sie nun die Marke ein
    >BMW
    Bitten Geben sie nun die Modell ein
    >3er
    Fahrzeug mit dem Ident 1 wurde bearbeitet

### Aufgabe 4) Exceptionhandling
Sollten falsche Eingaben get�tigt werden, darf das Programm nicht abst�rzen.
Der User soll darauf

### Aufgabe 5) Erstellung  des VehicleService

Erstellen sie die Klasse **VehicleConsoleService** in dem Projekt **FahrzeugVerwaltung.Service**
Der **VehicleConsoleService** soll nun 4 Methoden bekommen
	

 - `public void Save(){...}` //Soll ein Vehicle hinzuf�gen k�nnen
 - `public void Delete(){...}` // Soll ein Vehicle l�schen k�nnen
 - `public void Update(){...}`//Soll ein Vehicle editieren k�nnen
 - `public void GetAll(){}` //Soll alle Vehicle anzeigen
Nun soll die alte Logik auf diese 4 Methoden extrahiert werden
Au�erdem soll die Klasse eine private Feld (auch Field genannt) bekommen 

|Name| Datentyp  |
|--|--|
| vehicleList | List\<Vehicle\> |


### Aufgabe 6) Vererbung
Es soll nun 2 Spezialisierungen von einem Vehicle geben. 
Erstelle die Klasse **PKW** und **LKW**. Beiden **erben** von Vehicle.
Die Klasse LKW soll nun eine weitere Eigenschaft bekommen
|Name|Datentyp  |Erkl�rung
|--|--|--|
| Capacity | double  |Gibt die Frachtkapazit�t an

Nun soll der Anwender beim Erstellen eines Vehicles gefragt ob es 1) ein PKW oder 2) LKW ist
 

 
    Bitten w�hlen Sie die Aktion aus
    1) Vehicle anlegen
    2) Vehicle l�schen
    3) Alle Vehicle anzeigen 
    4) Vehicle bearbeiten
    10) Programm beenden
    >1
    Welchen Typ wollen Sie anlegen 
    1)PKW
    2)LKW
    >2
    Bitte geben Sie die Frachtkapazit�t in kg an
    >4500
     Bitten Geben sie nun die Marke ein
    >MAN
    Bitten Geben sie nun die Modell ein
    >Sattelzug
    Ein LKW wurde erstellt
    
   