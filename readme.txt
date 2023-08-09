# Übung zur Vorlesung Virtual Reality

## Abgabe Aufgabe 4:

## Externals:
-Darth Artisan's Free Trees: siehe Übung 2
-Road Architect: https://github.com/MicroGSD/RoadArchitect
-Blue Sedan: https://assetstore.unity.com/packages/3d/vehicles/land/blue-sedan-195200
-Sound Effect - Screeching tires 1: https://bigsoundbank.com/sound-2368-screeching-tires-1.html
-Sound Effect - Car Accident Real Interior: https://pixabay.com/de/sound-effects/car-accident-real-interior-46387/
-Sound Effect - Interior Car Start and Departure: https://pixabay.com/de/sound-effects/interior-car-start-and-departure-16666/

## Funktionsweise:

Bei dem Spiel handelt es sich um einen Reaktionstest zur Gefahrenbremsung im Auto. 
Mit dem Öffnen der "LevelMenu"-Szene öffnet sich ein Level Menu, in dem insgesamt 12 Levels zur Auswahl stehen. Wird ein Level ausgewählt, lässt sich das Auto mit "W" beschleunigen uns "A" und "S" nach links, bzw. nach rechts lenken.
Per Leertaste lässt sich eine Gefahrenbremsung hinlegen. Geschieht diese zu früh, gilt das Level als gescheitert und muss wiederholt werden. Ebenso scheitert man, sollte man in eine Leitplanke oder eines der plötzlich erscheinenden Hindernisse fahren.
Sollte man nach Erschienen eines Hindernisses erfolgreich gebremst haben, wird die verbliebene Distanz zu diesem Objekt angezeigt und das nächste Level kann gespielt werden.


## Erläuterung:
Für eine authentische User Experience haben wir uns entschieden, unser Bremsspiel aus der Ego Perspektive zu designen, also aus der Windschutzscheibe des Autos heraus, wie man es auch tasächlich gewohnt ist, Auto zu fahren. Diese Erfahrung bietet sich daher an, im Dreidimenstionalen Raum vermittelt zu werden.
Um diese gewohnte Erfahrung authentischer zu vermitteln, machen wir Gebrauch von Soundeffekten wie Motorengeräuschen, quietschenden Bremsen und dumpfen Stoßen im Falle eines Unfalls. Entsprechend gefährlich ist es, in eine Leitplanke zu fahren oder vollkommen grundlos eine Gefahrenbremsung hinzulegen.
Dies ist nur von Nöten, wenn tatsächlich ein Hindernis zum Bremsen auf der Straße liegt. Um die Gefahrenbremsung möglichst realistsich zu simulieren, ist im Gegensatz zum konstanten Beschleunigen nur ein einzelner Druck der Leertaste von Nöten, um die plötzliche Dringlichkeit einer solchen Gefahrensituation zu untermauern.
Gelingt das Bremsmanöver, sieht man den verbleibenden Abstand zum Hindernis, um die Gefahrensituation noch einmal zu verdeutlichen. 
Die Kamera folgt dabei stets der Rotation des Autos, was nicht unbedingt realistsich, aber deutlich nutzerfreundlicher ist und aus ähnlichen Rennspielen gewohnt ist.  