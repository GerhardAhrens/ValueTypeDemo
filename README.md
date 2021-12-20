# Value Objects <img src="./ValueObject.png" style="width:50px;"/>
## This Demo is written in C# for NET5

# Was sind Value Objects?
Value Objects sind dann besonders wichtig, wenn diese im Bezug des Domain Driven Design (DDD) verwendet werden. Ein weiterer wichtiger Aspekt, ist wenn die Benutzung von Typen 
einen konkreten Bezug zu einer Fachlichkeit haben soll. Strukturen, die für sich genommen keinen Sinn ergeben, aber Informationen enthalten, werden als Wertobjekte bezeichnet. 
Wir können die Datumsstruktur als Beispiel betrachten. Die Kombination von 3 Zahlen, Tag, Monat und Jahr, erzeugt Informationen, die auf ein bestimmtes Datum hinweisen. Es ist jedoch unklar, was dieses Datum bedeutet. Dieses Problem wird verständlicher, wenn wir über zwei Hauptmerkmale von Wertobjekten sprechen.

## 1 —Identityless
Wertobjekte sind anonyme Einheiten. Sie enthalten also Daten, die für sich allein keinen Sinn ergeben. Betrachten wir die DateTime-Struktur, so enthält sie eine Datumsinformation. 
Wir können jedoch nicht wissen, was dieses Datum bedeutet, wenn es allein verwendet wird. Wertobjekte gewinnen an Bedeutung, wenn sie von einer Entität verwendet werden. 
Stellen wir uns einen Person oder eine Rechnung vor. Zusammen mit diesen Entitäten kann die Datumsinformation Bedeutungen wie das Geburtsdatum oder das Erstellungsdatum Rechnung haben.

## 2 — Immutable
Während der Erstellung von Objekten erhalten sie über Konstruktormethoden Daten, die danach nicht mehr geändert werden können. Wir können diese Situation anhand des DateTime-Beispiels erklären. Nachdem wir das Datumsobjekt mit den Werten für Tag, Monat und Jahr erstellt haben, können wir diese Werte nicht mehr ändern. Wenn wir ein neues Datum setzen wollen, müssen wir erneut ein DateTime-Objekt erstellen.

## Beispiel
```
class Person
{
    string Name;
    int BirthDate_Year;
    int BirthDate_Month;
    int BirthDate_Date;
}

class Person
{
    Name Name;
    Birthday BirthDate;
}
```
Betrachtet man die obigen Beipiele, so ist das zweite Beispiel der Person-Klasse besser lesbar. Im in diesem Beispiel wird am deutlichsten wie ValueObjects einzusetzten werden können. Die Darstellung der Informationen wirkt sich positiv auf die Wartbarkeit des Codes aus.

## Sicherheit in der parallelen Programmierung
Während der parallelen Codeausführung kann es vorkommen, dass verschiedene Threads die Werte, die Objekte tragen, ändern wollen. In diesem Fall tritt eine "Race Condition" auf. Aufgrund der "Race Condition" kann das Programm bei jeder Ausführung unterschiedliche Ergebnisse liefern. Da Wertobjekte unveränderlich sind, können sie keine "Race Condition" auslösen.

## Vor- und Nachteile von Value Objects
Bei der Verwendung von Value Objects sehe ich folgende wichtige Vorteile
- Konkrete Beschreibung eines Wertes
- Erweiterungen, die nur auf diesem Typ wirken (z.B. durch Extensions)
- Value Objects können nach dem Erstellen nicht mehr geändert werden (Immutable)

Bei den Nachteilen wäre zu nennen den Aufwand zur Erstellung von Value Objects den den damit verbundenen Test, dieser sehr ausführlich sein sollte da die Value Objects in der gesammten Applikation verwendet werden.
Weiter gibt es sicher auch Situationen, das eine Value Objects nach dem Erstellen geändert werden muß. Hier müssen dann nachträglich sepzielle Methoden erstellt werden.
