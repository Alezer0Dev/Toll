# Toll
Programma didattico realizzato in C# (WPF), pensato per simulare la raccolta dati di un casello autostradale.

<img width="972" height="511" alt="Finestra principale" src="https://github.com/user-attachments/assets/530b4ce8-c9f9-41ab-9db7-27a806fcf6af" />

# Guida all'uso
Il programma caricherà 4 file di configurazione dalla directory del file .exe:
- paths.json
- routes.json
- locations.json
- telepassUsers.json

Questi file conterranno dati sulle rotte autostradali e sugli utenti Telepass.  
[File di esempio](#esempi-file-json)

## Visualizzazioni dati
### Cronologia passaggi
La prima scheda mostra la cronologia di tutti i passaggi al casello, la rotta, il metodo di pagamento e il timestamp.

<img width="495" height="142" alt="image" src="https://github.com/user-attachments/assets/b926b895-86c6-445c-8f7a-05d819993d88" />

### Targhe rilevate
Sono mostrate tutte le targhe che hanno passato il casello e il numero di passaggi.
> ⚠️ Degli utenti Telepass, sono inclusi solo i passaggi dove hanno usato Carta o Contanti.

<img width="492" height="86" alt="image" src="https://github.com/user-attachments/assets/f1c0ece5-a0a6-48dd-9b68-0994577a6a53" />

### Utenti Telepass
Lista di tutti gli utenti possessori di telepass, compresa dello stato dell'abbonamento e del numero di passaggi al casello.
> Lo stato dell'abbonamento può essere:
> - Active (Attivo)
> - Suspended (Temporaneamente sospeso, non può essere usato come metodo di pagamento)
> - Expired (Scaduto, non può essere usato come metodo di pagamento)

<img width="494" height="191" alt="image" src="https://github.com/user-attachments/assets/b3027e17-8371-4548-9c6e-8c2dfe18f8fe" />

## Esempi file json
### paths.json
```
[
  {
    "StartLocation": {
      "Name": "Torino"
    },
    "EndLocation": {
      "Name": "Milano"
    },
    "KMLength": 145.5
  },
  {
    "StartLocation": {
      "Name": "Milano"
    },
    "EndLocation": {
      "Name": "Bologna"
    },
    "KMLength": 215.3
  },
  {
    "StartLocation": {
      "Name": "Bologna"
    },
    "EndLocation": {
      "Name": "Firenze"
    },
    "KMLength": 106.8
  },
  {
    "StartLocation": {
      "Name": "Torino"
    },
    "EndLocation": {
      "Name": "Genova"
    },
    "KMLength": 170.2
  }
]
```
### routes.json
```
[
  {
    "RouteName": "Torino-Milano",
    "RoutePath": {
      "StartLocation": {
        "Name": "Torino"
      },
      "EndLocation": {
        "Name": "Milano"
      },
      "KMLength": 145.5
    },
    "Price": 12.5
  },
  {
    "RouteName": "Milano-Bologna",
    "RoutePath": {
      "StartLocation": {
        "Name": "Milano"
      },
      "EndLocation": {
        "Name": "Bologna"
      },
      "KMLength": 215.3
    },
    "Price": 18.9
  },
  {
    "RouteName": "Bologna-Firenze",
    "RoutePath": {
      "StartLocation": {
        "Name": "Bologna"
      },
      "EndLocation": {
        "Name": "Firenze"
      },
      "KMLength": 106.8
    },
    "Price": 8.7
  },
  {
    "RouteName": "Torino-Genova",
    "RoutePath": {
      "StartLocation": {
        "Name": "Torino"
      },
      "EndLocation": {
        "Name": "Genova"
      },
      "KMLength": 170.2
    },
    "Price": 14.2
  }
]
```
### locations.json
```
[
  {
    "Name": "Torino"
  },
  {
    "Name": "Milano"
  },
  {
    "Name": "Genova"
  },
  {
    "Name": "Bologna"
  },
  {
    "Name": "Firenze"
  }
]
```
### telepassUsers.json
```
[
  {
    "LicensePlate": {
      "CountryCode": "IT",
      "Number": "AB123CD"
    },
    "Status": "Active"
  },
  {
    "LicensePlate": {
      "CountryCode": "IT",
      "Number": "EF456GH"
    },
    "Status": "Expired"
  },
  {
    "LicensePlate": {
      "CountryCode": "IT",
      "Number": "IJ789KL"
    },
    "Status": "Suspended"
  },
  {
    "LicensePlate": {
      "CountryCode": "FR",
      "Number": "AA123BB"
    },
    "Status": "Active"
  },
  {
    "LicensePlate": {
      "CountryCode": "DE",
      "Number": "MZ987XY"
    },
    "Status": "Active"
  }
]
```
> ⚠️ Attualmente non sono implementati controlli sulla formattazione dei file.
